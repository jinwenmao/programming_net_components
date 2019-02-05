// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Class)]
public class TransactionAttribute : ContextAttribute
{
   TransactionScopeOption m_TransactionOption;

   public TransactionAttribute() : this(TransactionScopeOption.Required)
   {}

   public TransactionAttribute(TransactionScopeOption transactionOption) : 
                                                       base("TransactionAttribute")
   {
      m_TransactionOption = transactionOption;  
   }
   /// Add a new transaction property to the new context 
   public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
   {
      IContextProperty transactional;
      transactional = new TransactionalProperty(m_TransactionOption);
      ctor.ContextProperties.Add(transactional);
   }
   //Rovides a private context 
   public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
   { 
      return false;
   }
}

public class TransactionalProperty : IContextProperty,IContributeServerContextSink
{
   TransactionScopeOption m_TransactionOption;

   public TransactionalProperty(TransactionScopeOption transactionOption)
   {
      m_TransactionOption = transactionOption;
   }
   public IMessageSink GetServerContextSink(IMessageSink nextSink)
   {
      IMessageSink transactionSink;
      transactionSink = new TransactionSink(nextSink,m_TransactionOption);
      return transactionSink;
   }
   public bool IsNewContextOK(Context newCtx)
   {
      TransactionalProperty newContextTransactionalProperty;
      //Find out if the new context has a color property. If not, reject it
      newContextTransactionalProperty = newCtx.GetProperty(ToString()) as TransactionalProperty;
      if(newContextTransactionalProperty == null)
      {
         Debug.Assert(false);
         return false;
      }
      //It does have log property. Verify log option match
      return (m_TransactionOption == newContextTransactionalProperty.m_TransactionOption);
   }

   public string Name
   {
      get
      {
         return ToString();
      }
   }
   public void Freeze(Context context)
   {}
}
