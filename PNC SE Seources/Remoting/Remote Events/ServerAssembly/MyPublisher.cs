// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading;
using System.Windows.Forms;

using NumberChangedEventHandler = GenericEventHandler<int>;

namespace RemoteServer
{
   public class MyPublisher : MarshalByRefObject
   {
      public event NumberChangedEventHandler NumberChanged;
      public MyPublisher()
      {
         string appName = AppDomain.CurrentDomain.FriendlyName;
         //MessageBox.Show("Constructor",appName);
      }
      public void FireEvent(int number)
      {
         string appName = AppDomain.CurrentDomain.FriendlyName;
         MessageBox.Show("FireEvent",appName);
         EventsHelper.Fire(NumberChanged,number);
      }
   }
}
