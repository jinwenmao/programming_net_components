// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net


using System;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

public delegate int AddDelegate(int arg1,int arg2);

public class Calculator
{
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
} 
