// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading;

namespace ContextLogger
{
   [Serializable]
   public struct LogbookEntry
   {
      public LogbookEntry(string assemblyName,string typeName,string methodName,string eventDescription): this(assemblyName,typeName,methodName,"","")
      {
         Event = eventDescription;
      }
      public LogbookEntry(string assemblyName,string typeName,string methodName): this(assemblyName,typeName,methodName,"","")
      {}
      public LogbookEntry(string assemblyName,string typeName,string methodName,string exceptionName,string exceptionMessage)
      {
         MachineName = Environment.MachineName;
         AppDomainName = AppDomain.CurrentDomain.FriendlyName;
         ThreadID = Thread.CurrentThread.ManagedThreadId;
         ThreadName = Thread.CurrentThread.Name;
         ContextID = Thread.CurrentContext.ContextID;
         if(Thread.CurrentPrincipal.Identity.IsAuthenticated)
         {
            UserName = Thread.CurrentPrincipal.Identity.Name;
         }
         else
         {
            UserName = "Unauthenticated";
         }
         AssemblyName = assemblyName;
         TypeName = typeName;
         MemberAccessed = methodName;
         Date = DateTime.Now.ToShortDateString();         
         Time = DateTime.Now.ToLongTimeString();         
         ExceptionName = exceptionName;
         ExceptionMessage = exceptionMessage;
         Event = "";
      }
      //Location
      public readonly string MachineName;
      public readonly string AppDomainName;
      public readonly int    ThreadID;
      public readonly string ThreadName;
      public readonly int    ContextID;
      //Identity 
      public readonly string UserName;
      //Object info
      public readonly string AssemblyName;
      public readonly string TypeName;
      public readonly string MemberAccessed;
      public readonly string Date;
      public readonly string Time;
      //Exception 
      public readonly string ExceptionName; 
      public readonly string ExceptionMessage;
      //Event
      public readonly string Event; 
   }
}