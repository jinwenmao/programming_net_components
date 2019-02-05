// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;

namespace RemoteServer
{
	/// <summary>
	/// Summary description for MyServer.
	/// </summary>
	public class MyServer : MarshalByRefObject
	{
		public MyServer()
		{
			Counter = 0;
		}
		protected int Counter;
		public void IncCount()
		{
			Counter++;
			MessageBox.Show("Counter value is ",Counter.ToString());
		}
	}
}
