// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Threading;
using ThreeadingEx;

namespace RendezvousDemo
{
	class EntryPoint
	{
		static void Main(string[] args)
		{
         RendezvousClient client = new RendezvousClient();
         Thread thread1 = new Thread(client.ThreadMethod1);
         thread1.Start();

         Thread thread2 = new Thread(client.ThreadMethod2);
         thread2.Start();
         Console.ReadLine();
      }
	}
}

public class RendezvousClient 
{
   Rendezvous m_Rendezvous = new Rendezvous();

   public void ThreadMethod1()
   {
      Thread.Sleep(1234);
      m_Rendezvous.Wait();
      Console.WriteLine("Thread 1: " + DateTime.Now.Millisecond);
   }
   public void ThreadMethod2()
   {
      Thread.Sleep(5678);
      m_Rendezvous.Wait();
      Console.WriteLine("Thread 2: " + DateTime.Now.Millisecond);
   }
}
