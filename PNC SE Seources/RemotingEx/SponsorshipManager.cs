// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting;
using System.Collections;

namespace RemotingEx
{
   public class SponsorshipManager : MarshalByRefObject,ISponsor,IEnumerable<ILease>,IDisposable
   {
      IList<ILease> m_LeaseList;
      public SponsorshipManager()
      {
         m_LeaseList = new List<ILease>();
      }
      ~SponsorshipManager()
      {
         UnregisterAll();
      }
      public void Dispose()
      {
         UnregisterAll();
      }
      public void OnExit(object sender,EventArgs e)
      {
         UnregisterAll();
      }
      TimeSpan ISponsor.Renewal(ILease lease)
      {
         Debug.Assert(lease.CurrentState == LeaseState.Active);
         return lease.InitialLeaseTime;
      }
      public void Register(MarshalByRefObject obj)
      {
         ILease lease = (ILease)RemotingServices.GetLifetimeService(obj);
         Debug.Assert(lease.CurrentState == LeaseState.Active);

         lease.Register(this);
         lock(this)
         {
            m_LeaseList.Add(lease);
         }
      }
      public void UnregisterAll()
      {
         lock(this)
         {
            while(m_LeaseList.Count > 0)
            {
               ILease lease = m_LeaseList[0];
               lease.Unregister(this);
               m_LeaseList.RemoveAt(0);
            }
         }
      }
      public void Unregister(MarshalByRefObject obj)
      {
         ILease lease = (ILease)RemotingServices.GetLifetimeService(obj);
         Debug.Assert(lease.CurrentState == LeaseState.Active);

         lease.Unregister(this);
         lock(this)
         {
            m_LeaseList.Remove(lease);
         }
      }
      IEnumerator<ILease> IEnumerable<ILease>.GetEnumerator()
      {
         foreach(ILease lease in m_LeaseList)
         {
            yield return lease;
         }
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
         IEnumerable<ILease> enumerable = this;
         return enumerable.GetEnumerator();
      }
   }
}






