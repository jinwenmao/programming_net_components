// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Runtime.Remoting;

namespace RemotingEx
{
   public static class GenericActivator
   {
      public static T CreateInstance<T>()
      {
         return (T)Activator.CreateInstance(typeof(T));
      }
   }
}

