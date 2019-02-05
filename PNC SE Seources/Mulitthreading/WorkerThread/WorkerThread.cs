// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadingEx
{
   /// <summary>
   /// WorkerThread is a wrapper class around the underlying managed thread. It provides easy to use overloaded constructors, Kill() and Start() methods.
   /// </summary>
   public class WorkerThread : IDisposable
   {
      ManualResetEvent m_ThreadHandle;
      Thread m_ThreadObj;
      bool m_EndLoop;
      Mutex m_EndLoopMutex;

      /// <summary>
      /// Returns the managed thread ID from the underlying thread.
      /// </summary>
      /// <value></value>
      public int ManagedThreadId
      {
         get
         {
            return m_ThreadObj.ManagedThreadId;
         }
      }
      /// <summary>
      /// Returns the managed hash code from the underlying thread.
      /// </summary>
      /// <value></value>
      public override int GetHashCode()
      {
         return m_ThreadObj.GetHashCode();
      }
      public override bool Equals(object obj)
      {
         return m_ThreadObj.Equals(obj);
      }

      /// <summary>
      /// Returns the underlying Thread object, for calling Suspend(), Resume(), etc.
      /// </summary>
      public Thread Thread
      {
         get
         {
            return m_ThreadObj;
         }
      }
      bool EndLoop
      {
         set
         {
            m_EndLoopMutex.WaitOne();
            m_EndLoop = value;
            m_EndLoopMutex.ReleaseMutex();
         }
         get
         {
            bool result = false;
            m_EndLoopMutex.WaitOne();
            result = m_EndLoop;
            m_EndLoopMutex.ReleaseMutex();
            return result;
         }
      }
      /// <summary>
      /// Constructs an WorkerThread object, without starting the underlying thread. Must call Start() as well.
      /// </summary>
      /// <example>   
      /// <code>
      /// workerThread workerThread = new WorkerThread();
      /// workerThread.Start();
      /// /*When you are done */
      /// workerThread.Kill();
      /// </code>
      /// </example>
      public WorkerThread()
      {
         m_EndLoop = false;
         m_ThreadObj = null;
         m_EndLoopMutex = new Mutex();
         m_ThreadHandle = new ManualResetEvent(false);

         m_ThreadObj = new Thread(Run);
         m_ThreadObj.Name = "Worker Thread";
      }
      /// <summary>
      ///Constructs the WorkerThread obejct and potentially starts the underlying thread
      /// </summary>
      /// <param name="autoStart">If autoStart is true, starts the underlying thread. If autoStart is false, must call Start() as well.</param>
      /// <example>
      /// This sample shows how to use WorkerThread.
      /// Easiest:
      /// <code>
      /// workerThread workerThread = new WorkerThread(true);
      /// /*When you are done */
      /// workerThread.Kill();
      /// </code>
      /// Or:
      /// <code>
      /// workerThread workerThread = new WorkerThread(false);
      /// workerThread.Start();
      /// /*When you are done */
      /// workerThread.Kill();
      /// </code>
      /// </example>
      public WorkerThread(bool autoStart) : this()
      {
         if(autoStart)
         {
            Start();
         }
      }
      /// <summary>
      /// Provides a waitable handle representing the underlying thread. You can combine the handle in wait operations with other handles. The handle is signaled when the thread terminates. 
      /// </summary>
      public WaitHandle Handle
      {
         get
         {
            return m_ThreadHandle;
         }
      }
      /// <summary>
      ///Starts the underlying thread. 
      /// </summary>
      public void Start()
      {
         Debug.Assert(m_ThreadObj != null);
         Debug.Assert(m_ThreadObj.IsAlive == false);
         m_ThreadObj.Start();
      }
      public void Dispose()
      {
         Kill();
      }
      /// <summary>
      /// The thread method. Put your code in the while loop.
      /// </summary>
      void Run()
      {
         try
         {
            int i = 0;			
            while(EndLoop == false)
            {
               Trace.WriteLine("Thread is alive, Counter is " + i);
               i++;
               Thread.Sleep(0);
            }
         }
         finally
         {
            m_ThreadHandle.Set();
         }
      }
      
      /// <summary>
      /// Kills the underlying thread.
      /// </summary>
      public void Kill()
      { 
         //Kill is called on client thread - must use cached thread object
         Debug.Assert(m_ThreadObj != null);
         if(IsAlive == false)
         {
            return;
         }
         EndLoop = true;
         //Wait for thread to die
         Join();
         m_EndLoopMutex.Close();
         m_ThreadHandle.Close();
      }
      /// <summary>
      /// Blocks the calling thread until the underlying thread terminates.
      /// </summary>
      public void Join()
      {
         Join(Timeout.Infinite);
      }
      /// <summary>
      /// Blocks the calling thread until the underlying thread terminates or the specified time elapses
      /// </summary>
      /// <param name="millisecondsTimeout">The number of milliseconds to wait for the underlying thread to terminate</param>
      /// <returns>true if the underlying thread has terminated; false if the underlying thread has not terminated after the amount of time specified by the millisecondsTimeout parameter has elapsed.</returns>
      public bool Join(int millisecondsTimeout)
      {
         TimeSpan timeout = TimeSpan.FromMilliseconds(millisecondsTimeout);
         return Join(timeout);
      }
      /// <summary>
      /// Blocks the calling thread until the underlying thread terminates or the specified time elapses
      /// </summary>
      /// <param name="millisecondsTimeout">A TimeSpan set to the amount of time to wait for the underlying thread to terminate</param>
      /// <returns>true if the underlying thread has terminated; false if the underlying thread has not terminated after the amount of time specified by the timeout parameter has elapsed.</returns>
      public bool Join(TimeSpan timeout)
      {
         //Join is called on client thread - must use cached thread object
         Debug.Assert(m_ThreadObj != null);
         if(IsAlive == false)
         {
            return true;
         }
         Debug.Assert(Thread.CurrentThread.ManagedThreadId != m_ThreadObj.ManagedThreadId);
         return m_ThreadObj.Join(timeout);
      }
      /// <summary>
      /// Assigns or reads the name of the underlying thread 
      /// </summary>
      public string Name
      {
         get
         {
            return m_ThreadObj.Name;
         }
         set
         {
            m_ThreadObj.Name = value;
         }
      }
      public bool IsAlive
      {
         get
         {
            Debug.Assert(m_ThreadObj != null); 
            bool handleSignaled = m_ThreadHandle.WaitOne(TimeSpan.Zero,true);
            while(handleSignaled == m_ThreadObj.IsAlive)
            {
               Thread.Sleep(0);
            }
            return m_ThreadObj.IsAlive;
         }
      }
   }
}


