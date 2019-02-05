using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace RemoteServer
{
   public class MySubscriber : MarshalByRefObject
   {
      [OneWay]//Makes remote events robust and asynchronous 
      public void OnNewNumber(int num)
      {
         string threadID = Thread.CurrentThread.ManagedThreadId.ToString();
         string appName = AppDomain.CurrentDomain.FriendlyName;
         MessageBox.Show("New Value: " + num.ToString(),appName + " Thread ID: " + threadID.ToString());
      }
   }
}
