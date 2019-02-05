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

public class TransactionSink : IMessageSink
{
   IMessageSink m_NextSink;
   TransactionScopeOption m_TransactionOption;

   public TransactionSink(IMessageSink nextSink,TransactionScopeOption transactionOption)
   {
      m_TransactionOption = transactionOption;
      m_NextSink = nextSink;
   }

   public IMessageSink NextSink
   {
      get
      {
         return m_NextSink;
      }
   }
   public IMessage SyncProcessMessage(IMessage msg)
   {
      IMethodReturnMessage returnedMessage = null;

      Exception exception;
      TransactionScope scope = new TransactionScope(m_TransactionOption);
      using(scope)
      {
         try
         {
            returnedMessage = (IMethodReturnMessage)m_NextSink.
                                                           SyncProcessMessage(msg);
            exception = returnedMessage.Exception;
         }
         catch(Exception sinkException)
         {
            exception = sinkException;
         }
         if(exception == null)
         {
            scope.Complete();
         }
         return returnedMessage;
      }
   }
   public IMessageCtrl AsyncProcessMessage(IMessage msg,IMessageSink replySink)
   {
      string message = "Transactional calls must be synchronous";
      throw new InvalidOperationException(message); 
   }
}
