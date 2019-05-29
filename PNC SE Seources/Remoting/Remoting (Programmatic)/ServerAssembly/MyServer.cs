// ?2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;

namespace RemoteServer
{
	/// <summary>
	/// Summary description for MyServer.
	/// </summary>
	public class MyServer : MarshalByRefObject,IDisposable
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
      public void Dispose()
      {
         string appName = AppDomain.CurrentDomain.FriendlyName;
         MessageBox.Show("IDisposable.Dispose",appName);
      }
	}
}
