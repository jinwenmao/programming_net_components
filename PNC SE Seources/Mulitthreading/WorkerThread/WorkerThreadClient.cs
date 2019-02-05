// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using ThreadingEx;
using System.Windows.Forms;

using System.Threading;

namespace WorkerThreadDemo
{
	public class WorkerThreadClient : Form
	{
      Button m_CreateThreadButton;
      Button m_KillThreadButton;
      WorkerThread m_WorkerThread;

		public WorkerThreadClient()
		{
         InitializeComponent();
         Thread.CurrentThread.Name = "UI Thread";
		}


		#region Windows Form Designer generated code
		void InitializeComponent()
		{
         this.m_CreateThreadButton = new System.Windows.Forms.Button();
         this.m_KillThreadButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // m_CreateThreadButton
         // 
         this.m_CreateThreadButton.Location = new System.Drawing.Point(96, 56);
         this.m_CreateThreadButton.Name = "m_CreateThreadButton";
         this.m_CreateThreadButton.Size = new System.Drawing.Size(112, 32);
         this.m_CreateThreadButton.TabIndex = 2;
         this.m_CreateThreadButton.Text = "Create Thread";
         this.m_CreateThreadButton.Click += new System.EventHandler(this.OnCreate);
         // 
         // m_KillThreadButton
         // 
         this.m_KillThreadButton.Enabled = false;
         this.m_KillThreadButton.Location = new System.Drawing.Point(96, 104);
         this.m_KillThreadButton.Name = "m_KillThreadButton";
         this.m_KillThreadButton.Size = new System.Drawing.Size(112, 32);
         this.m_KillThreadButton.TabIndex = 1;
         this.m_KillThreadButton.Text = "Kill Thread";
         this.m_KillThreadButton.Click += new System.EventHandler(this.OnKillThread);
         // 
         // WorkerThreadClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.Add(this.m_KillThreadButton);
         this.Controls.Add(this.m_CreateThreadButton);
         this.Name = "WorkerThreadClient";
         this.Text = "WorkerThread Demo";
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
			WorkerThreadClient form = new WorkerThreadClient();
			Application.Run(form);
		}

		void OnCreate(object sender,EventArgs e)
		{
		   m_WorkerThread = new WorkerThread(true);
			
			m_CreateThreadButton.Enabled = false;
			m_KillThreadButton.Enabled = true;
		}
		void OnKillThread(object sender,EventArgs e)
		{  
			m_WorkerThread.Kill();
			m_CreateThreadButton.Enabled = true;
			m_KillThreadButton.Enabled = false;

		}
	}
}
