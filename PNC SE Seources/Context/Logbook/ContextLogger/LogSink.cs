// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace ContextLogger
{   
   public class LogSink : IMessageSink
   {
      IMessageSink m_NextSink;
      LogOption m_LogOption;
      Logbook m_Logbook;
   
      public LogSink(IMessageSink nextSink,LogOption logOption)
      {
         m_LogOption = logOption;
         m_NextSink = nextSink;
         m_Logbook = new Logbook();
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
         IMethodMessage methodMessage = (IMethodMessage)msg;            
         string assemblyName = GetAssemblyName(methodMessage);
         string typeName     = GetTypeName(methodMessage);
         string methodName   = GetMethodName(methodMessage);


         IMethodReturnMessage returnedMessage;
         returnedMessage = (IMethodReturnMessage)m_NextSink.SyncProcessMessage(msg);
      
         string exceptionName     = GetExceptionName(returnedMessage);
         string exceptionMessage  = GetExceptionMessage(returnedMessage);

         LogbookEntry logbookEntry = new LogbookEntry(assemblyName,typeName,methodName,exceptionName,exceptionMessage);

         DoLogging(logbookEntry);

         return returnedMessage;
      } 
      public IMessageCtrl AsyncProcessMessage(IMessage msg,IMessageSink replySink)
      {
         IMethodMessage methodMessage = (IMethodMessage)msg;            
         string assemblyName = GetAssemblyName(methodMessage);
         string typeName     = GetTypeName(methodMessage);
         string methodName   = GetMethodName(methodMessage);

         string exceptionName     = "Not Available";
         string exceptionMessage  = "Method invoked asynchronously";

         LogbookEntry logbookEntry = new LogbookEntry(assemblyName,typeName,methodName,exceptionName,exceptionMessage);

         DoLogging(logbookEntry);

          return m_NextSink.AsyncProcessMessage(msg,replySink);
      } 

      void DoLogging(LogbookEntry logbookEntry)
      {
         if(m_LogOption == LogOption.MethodCalls)
         {
            LogCall(logbookEntry);
         }
         if(m_LogOption == LogOption.Errors)
         {
            if(logbookEntry.ExceptionName != String.Empty)
            {
               LogCall(logbookEntry);
            }
         }
      }
      void LogCall(LogbookEntry logbookEntry)
      {
         m_Logbook.AddEntry(logbookEntry);
      }
      static string GetMethodName(IMethodMessage methodMessage)
      {
         string methodName = methodMessage.MethodName;
         switch(methodName)
         {
            case ".ctor":
            {
               return "Constructor";
            }
            case "FieldGetter":
            case "FieldSetter":
            {
               IMethodCallMessage methodCallMessage = (IMethodCallMessage)methodMessage;
               return (string)methodCallMessage.InArgs[1];
            }
         }
         if(methodName.EndsWith("Item"))
         {
            return methodName;
         }

         if(methodName.StartsWith("get_") || methodName.StartsWith("set_"))
         {
            return methodName.Substring(4);
         }
         if(methodName.StartsWith("add_"))
         {
            return methodName.Substring(4) + "+=";
         }
         if(methodName.StartsWith("remove_"))
         {
            return methodName.Substring(7) + "-=";
         }
         return methodName;
      }
      static string GetTypeName(IMethodMessage methodMessage)
      {
         string fullTypeName = methodMessage.TypeName;
         string[] arr = fullTypeName.Split(new Char[] {',', ','});
         return arr[0];
      }
      static string GetAssemblyName(IMethodMessage methodMessage)
      {
         string fullTypeName = methodMessage.TypeName;
         string[] arr = fullTypeName.Split(new Char[] {',', ','});
         return arr[1];
      }
      static string GetExceptionName(IMethodReturnMessage returnedMessage)
      {
         if(returnedMessage.Exception != null)
         {
            return returnedMessage.Exception.GetType().ToString();
         }
         return String.Empty;
      }
      static string GetExceptionMessage(IMethodReturnMessage returnedMessage)
      {
         if(returnedMessage.Exception != null)
         {
            return returnedMessage.Exception.Message;
         }
         return "";
      }
   }
}
