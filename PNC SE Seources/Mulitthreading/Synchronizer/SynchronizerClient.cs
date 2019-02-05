// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

public class SynchronizerClient : Form
{
   Button m_BeginButton;
   Button m_EndButton;
   Button m_SynchButton;
   IAsyncResult m_Result;
   TextBox m_Arg1;
   TextBox m_Arg2;
   TextBox m_Sum;
   Label m_Arg1Label;
   Label m_Arg2Label;
   Label m_SumLabel;
   CalculatorEx m_Calculator;

	public SynchronizerClient()
	{
		InitializeComponent();
      m_Result = null;
      int threadID = 0;
      threadID = Thread.CurrentThread.ManagedThreadId;
      Text = "Main thread ID is " + threadID.ToString();
      m_Calculator = new CalculatorEx();
	}

	#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	void InitializeComponent()
	{
      this.m_SynchButton = new System.Windows.Forms.Button();
      this.m_BeginButton = new System.Windows.Forms.Button();
      this.m_EndButton = new System.Windows.Forms.Button();
      this.m_Arg1 = new System.Windows.Forms.TextBox();
      this.m_Arg2 = new System.Windows.Forms.TextBox();
      this.m_Sum = new System.Windows.Forms.TextBox();
      this.m_Arg1Label = new System.Windows.Forms.Label();
      this.m_Arg2Label = new System.Windows.Forms.Label();
      this.m_SumLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // m_SynchButton
      // 
      this.m_SynchButton.Location = new System.Drawing.Point(16, 32);
      this.m_SynchButton.Name = "m_SynchButton";
      this.m_SynchButton.Size = new System.Drawing.Size(104, 23);
      this.m_SynchButton.TabIndex = 0;
      this.m_SynchButton.Text = "Add Synch";
      this.m_SynchButton.Click += new System.EventHandler(this.OnCallSynch);
      // 
      // m_BeginButton
      // 
      this.m_BeginButton.Location = new System.Drawing.Point(16, 80);
      this.m_BeginButton.Name = "m_BeginButton";
      this.m_BeginButton.Size = new System.Drawing.Size(104, 23);
      this.m_BeginButton.TabIndex = 1;
      this.m_BeginButton.Text = "Begin Add";
      this.m_BeginButton.Click += new System.EventHandler(this.OnCallBeginInvoke);
      // 
      // m_EndButton
      // 
      this.m_EndButton.Location = new System.Drawing.Point(16, 128);
      this.m_EndButton.Name = "m_EndButton";
      this.m_EndButton.Size = new System.Drawing.Size(104, 23);
      this.m_EndButton.TabIndex = 2;
      this.m_EndButton.Text = "End Add";
      this.m_EndButton.Click += new System.EventHandler(this.OnCallEndInvoke);
      // 
      // m_Arg1
      // 
      this.m_Arg1.Location = new System.Drawing.Point(232, 32);
      this.m_Arg1.Name = "m_Arg1";
      this.m_Arg1.TabIndex = 3;
      this.m_Arg1.Text = "2";
      // 
      // m_Arg2
      // 
      this.m_Arg2.Location = new System.Drawing.Point(232, 72);
      this.m_Arg2.Name = "m_Arg2";
      this.m_Arg2.TabIndex = 4;
      this.m_Arg2.Text = "3";
      // 
      // m_Sum
      // 
      this.m_Sum.Location = new System.Drawing.Point(232, 120);
      this.m_Sum.Name = "m_Sum";
      this.m_Sum.TabIndex = 5;
      this.m_Sum.Text = String.Empty;
      // 
      // m_Arg1Label
      // 
      this.m_Arg1Label.Location = new System.Drawing.Point(184, 32);
      this.m_Arg1Label.Name = "m_Arg1Label";
      this.m_Arg1Label.Size = new System.Drawing.Size(40, 23);
      this.m_Arg1Label.TabIndex = 6;
      this.m_Arg1Label.Text = "Arg1:";
      // 
      // m_Arg2Label
      // 
      this.m_Arg2Label.Location = new System.Drawing.Point(184, 72);
      this.m_Arg2Label.Name = "m_Arg2Label";
      this.m_Arg2Label.Size = new System.Drawing.Size(32, 23);
      this.m_Arg2Label.TabIndex = 6;
      this.m_Arg2Label.Text = "Arg2:";
      // 
      // m_SumLabel
      // 
      this.m_SumLabel.Location = new System.Drawing.Point(184, 120);
      this.m_SumLabel.Name = "m_SumLabel";
      this.m_SumLabel.Size = new System.Drawing.Size(32, 23);
      this.m_SumLabel.TabIndex = 6;
      this.m_SumLabel.Text = "Sum:";
      // 
      // SynchronizerClient
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
      this.ClientSize = new System.Drawing.Size(360, 181);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                   this.m_Arg1Label,
                                                                   this.m_Sum,
                                                                   this.m_Arg2,
                                                                   this.m_Arg1,
                                                                   this.m_EndButton,
                                                                   this.m_BeginButton,
                                                                   this.m_SynchButton,
                                                                   this.m_Arg2Label,
                                                                   this.m_SumLabel});
      this.Name = "SynchronizerClient";
      this.Text = "Synchronizer Client";
      this.Closed += new System.EventHandler(this.OnClose);
      this.ResumeLayout(false);

   }
	#endregion
	[STAThread]
	static void Main() 
	{
       Application.Run(new SynchronizerClient());
	}

   void OnCallSynch(object sender,EventArgs e)
   {
      m_Sum.Text = String.Empty; 

      AddDelegate addDelegate = m_Calculator.Add;
      object[] arguments = new object[]{int.Parse(m_Arg1.Text),int.Parse(m_Arg2.Text)};
      object sum = 0;

      ISynchronizeInvoke synchronizer = m_Calculator;
      sum = synchronizer.Invoke(addDelegate,arguments);
      m_Sum.Text = sum.ToString(); 
   }

   void OnCallBeginInvoke(object sender,EventArgs e)
   {
      m_Sum.Text = String.Empty;

      Calculator  calc   = new Calculator();
      AddDelegate addDelegate = new AddDelegate(calc.Add);
      object[] arr = new object[2];
      arr[0] = Convert.ToInt32(m_Arg1.Text);
      arr[1] = Convert.ToInt32(m_Arg2.Text);
      ISynchronizeInvoke synchronizer = m_Calculator;
      m_Result  = synchronizer.BeginInvoke(addDelegate,arr);
   }

   void OnCallEndInvoke(object sender,EventArgs e)
   {
      if(m_Result != null)
      {
         ISynchronizeInvoke synchronizer = m_Calculator;
         object sum = synchronizer.EndInvoke(m_Result);
         m_Sum.Text = sum.ToString(); 
      }
   }
   void OnClose(object sender,EventArgs e)
   {
      m_Calculator.Dispose();
   }
}
