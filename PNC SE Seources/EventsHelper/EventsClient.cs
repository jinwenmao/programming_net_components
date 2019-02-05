// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventsDemo
{
	public class EventsClient : Form
	{
		Button m_FireButton;
      Button m_FireParallelButton;
      Button m_FireAsyncButton;

      Label m_FireLabel;
      Label m_ParallelLabel;
      Label m_AsyncLabel;
      ProgressBar m_ProgressBar;

      MySubscriber m_Subscriber;
      Timer m_Timer;
      MyPublisher m_Publisher;

		public EventsClient()
		{
			InitializeComponent();

         m_Publisher   = new MyPublisher();
         m_Subscriber  = new MySubscriber();

         m_Publisher.MyEvent += m_Subscriber.OnMyEvent;
         m_Publisher.MyEvent += m_Subscriber.OnMyEvent;
      }
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
         this.m_FireButton = new System.Windows.Forms.Button();
         this.m_FireParallelButton = new System.Windows.Forms.Button();
         this.m_FireAsyncButton = new System.Windows.Forms.Button();
         this.m_FireLabel = new System.Windows.Forms.Label();
         this.m_ParallelLabel = new System.Windows.Forms.Label();
         this.m_AsyncLabel = new System.Windows.Forms.Label();
         this.m_ProgressBar = new System.Windows.Forms.ProgressBar();
         this.m_Timer = new System.Windows.Forms.Timer();
         this.SuspendLayout();
         // 
         // m_FireButton
         // 
         this.m_FireButton.Location = new System.Drawing.Point(21,12);
         this.m_FireButton.Name = "m_FireButton";
         this.m_FireButton.Size = new System.Drawing.Size(96,23);
         this.m_FireButton.TabIndex = 0;
         this.m_FireButton.Text = "Fire";
         this.m_FireButton.Click += new System.EventHandler(this.OnFire);
         // 
         // m_FireParallelButton
         // 
         this.m_FireParallelButton.Location = new System.Drawing.Point(21,50);
         this.m_FireParallelButton.Name = "m_FireParallelButton";
         this.m_FireParallelButton.Size = new System.Drawing.Size(96,23);
         this.m_FireParallelButton.TabIndex = 1;
         this.m_FireParallelButton.Text = "Fire In Parallel";
         this.m_FireParallelButton.Click += new System.EventHandler(this.OnFireInParallel);
         // 
         // m_FireAsyncButton
         // 
         this.m_FireAsyncButton.Location = new System.Drawing.Point(21,88);
         this.m_FireAsyncButton.Name = "m_FireAsyncButton";
         this.m_FireAsyncButton.Size = new System.Drawing.Size(96,23);
         this.m_FireAsyncButton.TabIndex = 2;
         this.m_FireAsyncButton.Text = "Fire Async";
         this.m_FireAsyncButton.Click += new System.EventHandler(this.OnFireAsync);
         // 
         // m_FireLabel
         // 
         this.m_FireLabel.AutoSize = true;
         this.m_FireLabel.Location = new System.Drawing.Point(145,16);
         this.m_FireLabel.Name = "m_FireLabel";
         this.m_FireLabel.Size = new System.Drawing.Size(226,13);
         this.m_FireLabel.TabIndex = 3;
         this.m_FireLabel.Text = "Client is blocked, events are fired one at a time.";
         // 
         // m_ParallelLabel
         // 
         this.m_ParallelLabel.AutoSize = true;
         this.m_ParallelLabel.Location = new System.Drawing.Point(145,55);
         this.m_ParallelLabel.Name = "m_ParallelLabel";
         this.m_ParallelLabel.Size = new System.Drawing.Size(223,13);
         this.m_ParallelLabel.TabIndex = 4;
         this.m_ParallelLabel.Text = "Client is blocked, events are fired concurrently.";
         // 
         // m_AsyncLabel
         // 
         this.m_AsyncLabel.AutoSize = true;
         this.m_AsyncLabel.Location = new System.Drawing.Point(145,93);
         this.m_AsyncLabel.Name = "m_AsyncLabel";
         this.m_AsyncLabel.Size = new System.Drawing.Size(241,13);
         this.m_AsyncLabel.TabIndex = 5;
         this.m_AsyncLabel.Text = "Client is not blocked, events are fired concurrently.";
         // 
         // m_ProgressBar
         // 
         this.m_ProgressBar.Location = new System.Drawing.Point(21,139);
         this.m_ProgressBar.Name = "m_ProgressBar";
         this.m_ProgressBar.Size = new System.Drawing.Size(365,23);
         this.m_ProgressBar.TabIndex = 6;
         // 
         // m_Timer
         // 
         this.m_Timer.Enabled = true;
         this.m_Timer.Interval = 30;
         this.m_Timer.Tick += new System.EventHandler(this.OnTick);
         // 
         // EventsClient
         // 
         this.ClientSize = new System.Drawing.Size(412,174);
         this.Controls.Add(this.m_ProgressBar);
         this.Controls.Add(this.m_AsyncLabel);
         this.Controls.Add(this.m_ParallelLabel);
         this.Controls.Add(this.m_FireLabel);
         this.Controls.Add(this.m_FireAsyncButton);
         this.Controls.Add(this.m_FireParallelButton);
         this.Controls.Add(this.m_FireButton);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EventsClient";
         this.Text = "EventsHelper Demo";
         this.ResumeLayout(false);
         this.PerformLayout();

      }
		#endregion

		static void Main() 
		{
			Application.Run(new EventsClient());
		}
      void OnFire(object sender,EventArgs e)
      {
         m_Publisher.Fire();
      }
      void OnFireInParallel(object sender,EventArgs e)
      {
         m_Publisher.FireInParallel();
      }
      void OnFireAsync(object sender,EventArgs e)
      {
         m_Publisher.FireAsync();
      }
      void OnTick(object sender,EventArgs e)
      {
         m_ProgressBar.Value = ++m_ProgressBar.Value % 100;
      }
	}
}
