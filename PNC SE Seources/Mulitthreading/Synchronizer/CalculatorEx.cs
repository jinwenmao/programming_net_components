// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;


public class CalculatorEx : ISynchronizeInvoke,IDisposable 
{
   ISynchronizeInvoke m_Synchronizer = new Synchronizer();
   public int Add(int arg1,int arg2)
   {
      int threadID = 0;
      threadID = Thread.CurrentThread.ManagedThreadId;
      string caption = "Callback thread ID is " + threadID.ToString();
      int sum = arg1+arg2;
      string msg = "Sum is " + sum.ToString();
      MessageBox.Show(msg,caption);
      return sum;
   }
   public object EndInvoke(IAsyncResult result)
   {
      return m_Synchronizer.EndInvoke(result);
   }
   public object Invoke(Delegate method, object[] args)
   {
      return m_Synchronizer.Invoke(method,args);
   }

   public IAsyncResult BeginInvoke(Delegate method, object[] args)
   {
      return m_Synchronizer.BeginInvoke(method,args);
   }

   public bool InvokeRequired
   {
      get
      {
         return m_Synchronizer.InvokeRequired;
      }
   }
   public void Dispose()
   {
      IDisposable disp = m_Synchronizer as IDisposable;
      if(disp != null)
      {
         disp.Dispose();
      }
   }
} 