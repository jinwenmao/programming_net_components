// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Threading;

public class MyPublisher
{
   public event EventHandler<EventArgs> MyEvent;
   public void Fire()
   {
      EventsHelper.Fire(MyEvent,this,EventArgs.Empty);
   }
   public void FireInParallel()
   {
      EventsHelper.FireInParallel(MyEvent,this,EventArgs.Empty);
   }
   public void FireAsync()
   {
      EventsHelper.FireAsync(MyEvent,this,EventArgs.Empty);
   }
}
public class MySubscriber
{
   public void OnMyEvent(object sender,EventArgs args)
	{
      ThreadStart threadMethod = delegate
                                 {
                                    MessageBox.Show("OnMyEvent","MySubscriber");
                                 };
      Thread thread = new Thread(threadMethod);
      thread.Start();
      thread.Join();
	}
}
