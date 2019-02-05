// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace RemotingEx
{
   public class RemotingConfigurationEx 
   {
      public static void Configure()
      {
         string fileName = AppDomain.CurrentDomain.FriendlyName + ".config";
         RemotingConfiguration.Configure(fileName,false);
      }
   }
}

