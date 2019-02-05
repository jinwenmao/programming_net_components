// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Threading;
using WinFormsEx;
using System.Windows.Forms;
using System.Diagnostics;

namespace BackgroundWorkerClient
{ 
   public class AsyncClient : Form
   {
      Label m_StatusLabel;
      Button m_StartButton;
      Button m_CancelButton;
      ProgressBar m_ProgressBar;
      BackgroundWorker m_BackgroundWorker;
		
      public AsyncClient()
		{
			InitializeComponent();
  		}

		#region Windows Form Designer generated code
		void InitializeComponent()
		{
         this.m_StatusLabel = new System.Windows.Forms.Label();
         this.m_ProgressBar = new System.Windows.Forms.ProgressBar();
         this.m_CancelButton = new System.Windows.Forms.Button();
         this.m_StartButton = new System.Windows.Forms.Button();
         this.m_BackgroundWorker = new WinFormsEx.BackgroundWorker();
         this.SuspendLayout();
         // 
         // m_StatusLabel
         // 
         this.m_StatusLabel.Location = new System.Drawing.Point(27, 99);
         this.m_StatusLabel.Name = "m_StatusLabel";
         this.m_StatusLabel.Size = new System.Drawing.Size(169, 15);
         this.m_StatusLabel.TabIndex = 0;
         this.m_StatusLabel.Text = "Status: Not Started";
         // 
         // m_ProgressBar
         // 
         this.m_ProgressBar.Location = new System.Drawing.Point(29, 60);
         this.m_ProgressBar.Name = "m_ProgressBar";
         this.m_ProgressBar.Size = new System.Drawing.Size(215, 21);
         this.m_ProgressBar.TabIndex = 1;
         // 
         // m_CancelButton
         // 
         this.m_CancelButton.Enabled = false;
         this.m_CancelButton.Location = new System.Drawing.Point(169, 16);
         this.m_CancelButton.Name = "m_CancelButton";
         this.m_CancelButton.TabIndex = 2;
         this.m_CancelButton.Text = "Cancel";
         this.m_CancelButton.Click += new System.EventHandler(this.OnCancel);
         // 
         // m_StartButton
         // 
         this.m_StartButton.Location = new System.Drawing.Point(29, 16);
         this.m_StartButton.Name = "m_StartButton";
         this.m_StartButton.TabIndex = 3;
         this.m_StartButton.Text = "Start";
         this.m_StartButton.Click += new System.EventHandler(this.OnStart);
         // 
         // m_BackgroundWorker
         // 
         this.m_BackgroundWorker.WorkerReportsProgress = true;
         this.m_BackgroundWorker.WorkerSupportsCancellation = true;
         this.m_BackgroundWorker.DoWork += new WinFormsEx.DoWorkEventHandler(this.OnDoWork);
         this.m_BackgroundWorker.RunWorkerCompleted += new WinFormsEx.RunWorkerCompletedEventHandler(this.OnCompleted);
         this.m_BackgroundWorker.ProgressChanged += new WinFormsEx.ProgressChangedEventHandler(this.OnProgressChanged);
         // 
         // AsyncClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(287, 142);
         this.Controls.Add(this.m_StatusLabel);
         this.Controls.Add(this.m_StartButton);
         this.Controls.Add(this.m_CancelButton);
         this.Controls.Add(this.m_ProgressBar);
         this.Name = "AsyncClient";
         this.Text = "Async Client";
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main()
		{
         Application.Run(new AsyncClient());
      }

      void OnDoWork(object sender,DoWorkEventArgs doWorkArgs)
      {
         Debug.Assert(doWorkArgs.Argument != null);
         BackgroundWorker backgroundWorker = sender as BackgroundWorker;
         Debug.Assert(backgroundWorker != null);

         int count = (int)doWorkArgs.Argument;
         doWorkArgs.Result = null;

         for(int progress=0;progress<=count;progress+=count/10)
         {
            if(backgroundWorker.CancellationPending)
            {
               doWorkArgs.Cancel = true;
               break;
            }
            Thread.Sleep(500);

            backgroundWorker.ReportProgress(progress);
         }       
      }

      void OnProgressChanged(object sender,ProgressChangedEventArgs progressArgs)
      {
         m_ProgressBar.Value = progressArgs.ProgressPercentage; 
      }

      void OnCompleted(object sender,RunWorkerCompletedEventArgs completedArgs)
      {
         if(completedArgs.Cancelled)
         {
            m_StatusLabel.Text = "Status: Cancelled";
         }
         else
         {
            m_StatusLabel.Text = "Status: Completed";
         }
         m_CancelButton.Enabled = false;
         m_StartButton.Enabled  = true;
      }
      void OnCancel(object sender,System.EventArgs e)
      {
         m_BackgroundWorker.CancelAsync();
         m_CancelButton.Enabled = false;
         m_StartButton.Enabled  = true;
      }

      void OnStart(object sender,EventArgs e)
      {
         m_ProgressBar.Value = 0;
         m_StatusLabel.Text = "Status: In Progress";
         m_BackgroundWorker.RunWorkerAsync(100);

         m_CancelButton.Enabled = true;
         m_StartButton.Enabled = false;
      }
	}
}