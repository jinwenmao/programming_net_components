// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Lifetime;

namespace RemoteServer
{
   public class MyClass : MarshalByRefObject
   {
      public override object InitializeLifetimeService()
      {
         ILease lease = (ILease)base.InitializeLifetimeService();
 
         //Set lease properties
         lease.InitialLeaseTime    = TimeSpan.FromSeconds(5);
         lease.RenewOnCallTime     = TimeSpan.FromSeconds(3);
         lease.SponsorshipTimeout  = TimeSpan.FromSeconds(10);
         return lease;
      }

      public MyClass()
      {
         string appName = AppDomain.CurrentDomain.FriendlyName;
         MessageBox.Show("Constructor",appName);
         Counter = 0;
      }
      protected int Counter;
      public void Count()
      {
         Counter++;
         string appName = AppDomain.CurrentDomain.FriendlyName;
         MessageBox.Show("Counter value is " + Counter.ToString(),appName);
      }
   }
}
