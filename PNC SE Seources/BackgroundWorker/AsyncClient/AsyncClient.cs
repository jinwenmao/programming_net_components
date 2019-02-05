// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace AsyncWinForms
{
   public class AsyncClient : Form
   {
      delegate void SetInt(int value);
      delegate void SetBoolean(Control control,bool value);
      delegate void SetString(string str);
      delegate void DoWork(int iterations);

      Button m_StartButton;
      Button m_CancelButton;
      ProgressBar m_ProgressBar;
      Label m_StatusLabel;
      bool m_CancelPending = false;

      public AsyncClient()
      {
         InitializeComponent();
      }
      bool CancelPending
      {
         get
         {
            lock(this)
            {
               return m_CancelPending;
            }
         }
         set
         {
            lock(this)
            {
               m_CancelPending = value;
            }
         }
      }
      #region Windows Form Designer generated code
      void InitializeComponent()
      {
         this.m_ProgressBar = new System.Windows.Forms.ProgressBar();
         this.m_StartButton = new System.Windows.Forms.Button();
         this.m_CancelButton = new System.Windows.Forms.Button();
         this.m_StatusLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // m_ProgressBar
         // 
         this.m_ProgressBar.Location = new System.Drawing.Point(32, 64);
         this.m_ProgressBar.Name = "m_ProgressBar";
         this.m_ProgressBar.Size = new System.Drawing.Size(224, 23);
         this.m_ProgressBar.TabIndex = 0;
         // 
         // m_StartButton
         // 
         this.m_StartButton.Location = new System.Drawing.Point(32, 16);
         this.m_StartButton.Name = "m_StartButton";
         this.m_StartButton.TabIndex = 1;
         this.m_StartButton.Text = "Start";
         this.m_StartButton.Click += new System.EventHandler(this.OnStart);
         // 
         // m_CancelButton
         // 
         this.m_CancelButton.Enabled = false;
         this.m_CancelButton.Location = new System.Drawing.Point(184, 16);
         this.m_CancelButton.Name = "m_CancelButton";
         this.m_CancelButton.TabIndex = 4;
         this.m_CancelButton.Text = "Cancel";
         this.m_CancelButton.Click += new System.EventHandler(this.OnCancel);
         // 
         // m_StatusLabel
         // 
         this.m_StatusLabel.Location = new System.Drawing.Point(32, 104);
         this.m_StatusLabel.Name = "m_StatusLabel";
         this.m_StatusLabel.TabIndex = 3;
         this.m_StatusLabel.Text = "Status: Not Started";
         // 
         // AsyncClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(288, 141);
         this.Controls.Add(this.m_StatusLabel);
         this.Controls.Add(this.m_CancelButton);
         this.Controls.Add(this.m_StartButton);
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
      void OnStart(object sender,EventArgs e)
      {
         CancelPending = false;
         m_ProgressBar.Value = 0;
         m_StatusLabel.Text = "Status: In Progress";

         DoWork doWork = new DoWork(DoBackgroundProcessing);
         AsyncCallback callback = new AsyncCallback(OnCompleted);
         doWork.BeginInvoke(100,callback,null);

         m_CancelButton.Enabled = true;
         m_StartButton.Enabled   = false;
      }
      void OnCompleted(IAsyncResult asyncResult)
      {
         //Must call EndInvoke() to prevent resource leaks
         AsyncResult result = (AsyncResult)asyncResult;
         DoWork doWork = (DoWork)result.AsyncDelegate;
         doWork.EndInvoke(asyncResult);

         if(CancelPending)
         {
            UpdateStatus("Status: Cancelled");
         }
         else
         {
            UpdateStatus("Status: Completed");
         }
         CancelPending = false;

         EnableControl(m_CancelButton,false);
         EnableControl(m_StartButton,true);
      }
      void OnCancel(object sender,EventArgs e)
      {
         CancelPending = true;

         m_CancelButton.Enabled = false;
         m_StartButton.Enabled   = true;
      }
      void DoBackgroundProcessing(int iterations)
      {
         for(int progress = 0;progress<=iterations;progress+=10)
         {
            if(CancelPending)
            {
               break;
            }
            Thread.Sleep(500);
            //Update progress UI:
            ReportProgress(progress);
         }
      }
      //Note the degree of internal coupling
      void ReportProgress(int value)
      {
         ISynchronizeInvoke synchronizer  = m_ProgressBar;
         if(synchronizer.InvokeRequired == false)
         {
            SetProgress(value);
            return;
         }
         SetInt del = new SetInt(SetProgress);
         try
         {
            synchronizer.Invoke(del,new object[]{value});
         }
         catch
         {}
      }
      void SetProgress(int value)
      {
         m_ProgressBar.Value = value;
      }
      void UpdateStatus(string status)
      {
         ISynchronizeInvoke synchronizer  = m_StatusLabel;
         if(synchronizer.InvokeRequired == false)
         {
            SetStatus(status);
            return;
         }
         SetString del = new SetString(SetStatus);
         try
         {
            synchronizer.Invoke(del,new object[]{status});
         }
         catch
         {}
      }
      void SetStatus(string status)
      {
         m_StatusLabel.Text = status;
      }
      void EnableControl(Control control,bool enabled)
      {
         ISynchronizeInvoke synchronizer = control;
         if(synchronizer.InvokeRequired == false)
         {
            SetEnabled(control,enabled);
            return;
         }
         SetBoolean del = new SetBoolean(SetEnabled);
         try
         {
            synchronizer.Invoke(del,new object[]{control,enabled});
         }
         catch
         {
         }
      }
      void SetEnabled(Control control,bool enabled)
      {
         control.Enabled = enabled;
      }
   }
}
