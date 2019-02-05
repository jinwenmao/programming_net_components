// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;

namespace RemoteServer
{
   public class MyServer : MarshalByRefObject
   {
      public MyServer()
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

   public class MyOtherServer : MarshalByRefObject
   {
      public MyOtherServer()
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
