// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Runtime.Remoting.Lifetime;

public class MySponsor : MarshalByRefObject,ISponsor 
{
	public TimeSpan Renewal(ILease lease)
	{
		Debug.Assert(lease.CurrentState == LeaseState.Active);

		//Renew lease by 5 seconds
      return TimeSpan.FromSeconds(5);
   }
}

