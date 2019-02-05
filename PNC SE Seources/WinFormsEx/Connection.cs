// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using System.Net.NetworkInformation;
using System.Net;

#endregion

namespace WinFormsEx
{
   public static class Connection
   {
      delegate bool IsAvaiable();
      public static bool IsOnline()
      {
         NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
         foreach(NetworkInterface adapter in adapters)
         {
            IPInterfaceProperties properties = adapter.GetIPProperties();
            if(adapter.OperationalStatus != OperationalStatus.Up)
            {
               continue;
            }
            UnicastIPAddressInformationCollection addressCollection = properties.UnicastAddresses;
            foreach(UnicastIPAddressInformation addressInfo in addressCollection)
            {
               if(IPAddress.IsLoopback(addressInfo.Address))
               {
                  continue;
               }
               if(addressInfo.Address.ToString() == IPAddress.IPv6None.ToString())
               {
                  continue;
               }
               if(addressInfo.Address.ToString() == IPAddress.None.ToString())
               {
                  continue;
               }
               //Automatic private address
               if(addressInfo.Address.ToString().StartsWith("169.254.245"))
               {
                  continue;
               }
               Ping ping = new Ping();
               PingReply reply = ping.Send(addressInfo.Address);
               if(reply.Status == IPStatus.Success)
               {
                  return true;
               }
            }
         }
         return false;
      }
      public static event GenericEventHandler<bool> IsOnlineCompleted;
      public static void IsOnlineAsync()
      {
         IsAvaiable isAvailable = IsOnline;
         AsyncCallback completion = delegate(IAsyncResult asyncResult)
                                    {
                                       bool available = isAvailable.EndInvoke(asyncResult);
                                       EventsHelper.Fire(IsOnlineCompleted,available);
                                       asyncResult.AsyncWaitHandle.Close();
                                    };
         isAvailable.BeginInvoke(completion,null);
      }
   }
}