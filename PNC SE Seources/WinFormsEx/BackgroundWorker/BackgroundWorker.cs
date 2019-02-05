// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace WinFormsEx
{
   [ToolboxBitmap(typeof(BackgroundWorker),"bw.bmp")]
   public class BackgroundWorker : Component
   {
      bool m_CancelPending = false;
      bool m_ReportsProgress = false;
      bool m_SupportsCancellation = false;
      public event DoWorkEventHandler DoWork;
      public event ProgressChangedEventHandler ProgressChanged;
      public event RunWorkerCompletedEventHandler RunWorkerCompleted;


      public bool WorkerSupportsCancellation
      {
         get
         {
            lock(this)
            {
               return m_SupportsCancellation;
            }
         }

         set
         {
            lock(this)
            {
               m_SupportsCancellation = value;
            }
         }
      }
      public bool WorkerReportsProgress
      {
         get
         {
            lock(this)
            {
               return m_ReportsProgress;
            }
         }

         set
         {
            lock(this)
            {
               m_ReportsProgress = value;
            }
         }
      } 
      [MethodImpl(MethodImplOptions.NoInlining)]
      void ProcessDelegate(Delegate del,params object[] args)
      {
         if(del == null)
         {
            return;
         }
         Delegate[] delegates = del.GetInvocationList();
         foreach(Delegate handler in delegates)
         {
            InvokeDelegate(handler,args);
         }
      }
      void InvokeDelegate(Delegate del,params object[] args)
      {
         ISynchronizeInvoke synchronizer  = del.Target as ISynchronizeInvoke;
         Debug.Assert(synchronizer != null); 
         
         if(synchronizer.InvokeRequired == false)
         {
            try
            {
               del.DynamicInvoke(args);
            }
            catch(Exception e)
            {
               Trace.WriteLine(e.Message);
            }
            return;
         }
         try
         {
            synchronizer.Invoke(del,args);
         }
         catch(Exception e)
         {
            Trace.WriteLine(e.Message);
         }
      }

      void ReportCompletion(IAsyncResult asyncResult)
      {
         AsyncResult ar = (AsyncResult)asyncResult;
         DoWorkEventHandler del  = (DoWorkEventHandler)ar.AsyncDelegate;
         
         DoWorkEventArgs doWorkArgs = (DoWorkEventArgs)asyncResult.AsyncState;
         object result = null;
         Exception error = null;
         try
         {
            del.EndInvoke(asyncResult);
            result = doWorkArgs.Result;
         }
         catch(Exception exception)
         {
            error = exception;
         }

         RunWorkerCompletedEventArgs completedArgs = new RunWorkerCompletedEventArgs(result,error,doWorkArgs.Cancel);
         ProcessDelegate(RunWorkerCompleted,this,completedArgs);
      }

      public void RunWorkerAsync()
      {
         RunWorkerAsync(null);
      }

      public void RunWorkerAsync(object argument)
      {
         RunWorkerAsync(DoWork,argument);
      }
      [MethodImpl(MethodImplOptions.NoInlining)]
      void RunWorkerAsync(DoWorkEventHandler doWork,object argument)
      {
         m_CancelPending = false;
         if(doWork != null)
         {
            DoWorkEventArgs args = new DoWorkEventArgs(argument);
            AsyncCallback callback = new  AsyncCallback(ReportCompletion);
            doWork.BeginInvoke(this,args,callback,args);
         }
      }

      public void ReportProgress(int percent)
      {
         ProgressChangedEventArgs progressArgs = new ProgressChangedEventArgs(percent);
         ProcessDelegate(ProgressChanged,this,progressArgs);
      }
      public void CancelAsync()
      {
         lock(this)
         {
            m_CancelPending = true;
         }
      }
      public bool CancellationPending
      {
         get
         {
            lock(this)
            {
               return m_CancelPending;
            }
         }
      }
   } 
}
