// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;	
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Threading;	

namespace ContextLogger
{
   public enum LogOption
   {
      MethodCalls,
      Errors
   }

   [AttributeUsage(AttributeTargets.Class)]
   public class LogbookAttribute : ContextAttribute
   {
      LogOption m_LogOption;

      public LogbookAttribute(): this(LogOption.MethodCalls)
      {}

      public LogbookAttribute(LogOption logOption):base("LogbookAttribute")
      {
         m_LogOption = logOption;  
      }
      /// Add a new logbook property to the new context 
      public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
      {
         IContextProperty logProperty = new LogContextProperty(m_LogOption);
         ctor.ContextProperties.Add(logProperty);
      }

      //Called by the runtime in the creating client's context 
      public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
      { 
         return false;
      }
   }

   public class LogContextProperty : IContextProperty,IContributeServerContextSink
   {
      protected LogOption m_LogOption;

      public IMessageSink GetServerContextSink(IMessageSink nextSink)
      {
         IMessageSink logSink = new LogSink(nextSink,m_LogOption);
         return logSink;
      }
      public LogContextProperty(LogOption logOption) 
      {   
         Log = logOption;
      }
      public string Name
      {
         get 
         {
            return "Logbook";
         }
      }
      //IsNewContextOK called by the runtime in the new context
      public bool IsNewContextOK(Context ctx)
      {
         LogContextProperty newContextLogProperty;
         //Find out if the new context has a color property. If not, reject it
         newContextLogProperty = ctx.GetProperty("Logbook") as LogContextProperty;
         if(newContextLogProperty == null)
         {
            Debug.Assert(false);
            return false;
         }
         //It does have log property. Verify log option match
         return (this.Log == newContextLogProperty.Log);
      }

      public void Freeze(Context ctx)
      {} 
      //Log needs to be public so that the attribute class can access it
      public LogOption Log
      {
         get 
         { 
            return m_LogOption; 
         }
         set
         {
            m_LogOption = value;
         }
      }
   }	
}


