// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;

namespace MyNamespace
{
   public class MyClass : MarshalByRefObject
   {
      public void TraceAppDomain()
      {
         AppDomain currentAppDomain;
         currentAppDomain = AppDomain.CurrentDomain;

         Trace.WriteLine(currentAppDomain.FriendlyName);
      }
   }
}