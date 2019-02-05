// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading;

namespace ThreeadingEx
{
   public class Rendezvous
   {
      AutoResetEvent m_First  = new AutoResetEvent(true);
      AutoResetEvent m_Event1 = new AutoResetEvent(false);
      AutoResetEvent m_Event2 = new AutoResetEvent(false);
  
      public void Wait()
      {
         bool first = m_First.WaitOne(TimeSpan.Zero,false);
         if(first)
         {
            WaitHandle.SignalAndWait(m_Event1,m_Event2);
         }
         else
         {
            WaitHandle.SignalAndWait(m_Event2,m_Event1);
         }
      }
      public void Reset()
      {
         m_First.Set();
      }
   }    
}
