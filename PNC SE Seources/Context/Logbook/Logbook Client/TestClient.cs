// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;
using System.Runtime.Remoting;

namespace LogbookDemo
{
	public class TestClient : Form
	{
      Button m_MethodButton;
      Button m_SetPropertyButton;
      Button m_GetPropertyButton;
      Button m_SetFieldButton;
      Button m_GetFieldButton;
      Button m_NewButton;
      Button m_ErrorButton;
      Button m_EventSubs;
      Button m_EventUnsubs;
      Button m_SetInderxer;
      Button m_GetInderxer;
      Button m_EventButton;
            
      TestClass m_Obj;

      public TestClient()
      {
         Thread.CurrentThread.Name = "Client Thread";
         InitializeComponent();  

         OnCreate(this,EventArgs.Empty);
      }
		#region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this.m_MethodButton = new System.Windows.Forms.Button();
         this.m_SetPropertyButton = new System.Windows.Forms.Button();
         this.m_GetPropertyButton = new System.Windows.Forms.Button();
         this.m_SetFieldButton = new System.Windows.Forms.Button();
         this.m_GetFieldButton = new System.Windows.Forms.Button();
         this.m_ErrorButton = new System.Windows.Forms.Button();
         this.m_NewButton = new System.Windows.Forms.Button();
         this.m_EventSubs = new System.Windows.Forms.Button();
         this.m_EventUnsubs = new System.Windows.Forms.Button();
         this.m_SetInderxer = new System.Windows.Forms.Button();
         this.m_GetInderxer = new System.Windows.Forms.Button();
         this.m_EventButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // m_MethodButton
         // 
         this.m_MethodButton.Location = new System.Drawing.Point(120, 24);
         this.m_MethodButton.Name = "m_MethodButton";
         this.m_MethodButton.Size = new System.Drawing.Size(80, 23);
         this.m_MethodButton.TabIndex = 0;
         this.m_MethodButton.Text = "Call Method";
         this.m_MethodButton.Click += new System.EventHandler(this.OnMethod);
         // 
         // m_SetPropertyButton
         // 
         this.m_SetPropertyButton.Location = new System.Drawing.Point(224, 24);
         this.m_SetPropertyButton.Name = "m_SetPropertyButton";
         this.m_SetPropertyButton.TabIndex = 1;
         this.m_SetPropertyButton.Text = "Set Property";
         this.m_SetPropertyButton.Click += new System.EventHandler(this.OnSetProperty);
         // 
         // m_GetPropertyButton
         // 
         this.m_GetPropertyButton.Location = new System.Drawing.Point(224, 72);
         this.m_GetPropertyButton.Name = "m_GetPropertyButton";
         this.m_GetPropertyButton.TabIndex = 2;
         this.m_GetPropertyButton.Text = "Get Property";
         this.m_GetPropertyButton.Click += new System.EventHandler(this.OnGetProperty);
         // 
         // m_SetFieldButton
         // 
         this.m_SetFieldButton.Location = new System.Drawing.Point(328, 24);
         this.m_SetFieldButton.Name = "m_SetFieldButton";
         this.m_SetFieldButton.TabIndex = 3;
         this.m_SetFieldButton.Text = "Set Field";
         this.m_SetFieldButton.Click += new System.EventHandler(this.OnSetField);
         // 
         // m_GetFieldButton
         // 
         this.m_GetFieldButton.Location = new System.Drawing.Point(328, 72);
         this.m_GetFieldButton.Name = "m_GetFieldButton";
         this.m_GetFieldButton.TabIndex = 4;
         this.m_GetFieldButton.Text = "Get Field";
         this.m_GetFieldButton.Click += new System.EventHandler(this.OnGetField);
         // 
         // m_ErrorButton
         // 
         this.m_ErrorButton.Location = new System.Drawing.Point(120, 72);
         this.m_ErrorButton.Name = "m_ErrorButton";
         this.m_ErrorButton.Size = new System.Drawing.Size(80, 23);
         this.m_ErrorButton.TabIndex = 5;
         this.m_ErrorButton.Text = "Trigger Error";
         this.m_ErrorButton.Click += new System.EventHandler(this.OnError);
         // 
         // m_NewButton
         // 
         this.m_NewButton.Location = new System.Drawing.Point(8, 24);
         this.m_NewButton.Name = "m_NewButton";
         this.m_NewButton.Size = new System.Drawing.Size(88, 23);
         this.m_NewButton.TabIndex = 6;
         this.m_NewButton.Text = "Construct new";
         this.m_NewButton.Click += new System.EventHandler(this.OnCreate);
         // 
         // m_EventSubs
         // 
         this.m_EventSubs.Location = new System.Drawing.Point(528, 24);
         this.m_EventSubs.Name = "m_EventSubs";
         this.m_EventSubs.Size = new System.Drawing.Size(80, 23);
         this.m_EventSubs.TabIndex = 7;
         this.m_EventSubs.Text = "Event Subs";
         this.m_EventSubs.Click += new System.EventHandler(this.OnSubscribe);
         // 
         // m_EventUnsubs
         // 
         this.m_EventUnsubs.Location = new System.Drawing.Point(528, 72);
         this.m_EventUnsubs.Name = "m_EventUnsubs";
         this.m_EventUnsubs.Size = new System.Drawing.Size(80, 23);
         this.m_EventUnsubs.TabIndex = 8;
         this.m_EventUnsubs.Text = "Event Unsubs";
         this.m_EventUnsubs.Click += new System.EventHandler(this.OnUnsubscribe);
         // 
         // m_SetInderxer
         // 
         this.m_SetInderxer.Location = new System.Drawing.Point(432, 24);
         this.m_SetInderxer.Name = "m_SetInderxer";
         this.m_SetInderxer.TabIndex = 9;
         this.m_SetInderxer.Text = "Set Indexer";
         this.m_SetInderxer.Click += new System.EventHandler(this.OnSetIndexer);
         // 
         // m_GetInderxer
         // 
         this.m_GetInderxer.Location = new System.Drawing.Point(432, 72);
         this.m_GetInderxer.Name = "m_GetInderxer";
         this.m_GetInderxer.TabIndex = 9;
         this.m_GetInderxer.Text = "Get Indexer";
         this.m_GetInderxer.Click += new System.EventHandler(this.OnGetIndexer);
         // 
         // m_EventButton
         // 
         this.m_EventButton.Location = new System.Drawing.Point(120, 120);
         this.m_EventButton.Name = "m_EventButton";
         this.m_EventButton.Size = new System.Drawing.Size(80, 23);
         this.m_EventButton.TabIndex = 10;
         this.m_EventButton.Text = "Log Event";
         this.m_EventButton.Click += new System.EventHandler(this.OnLogEvent);
         // 
         // TestClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(616, 165);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_EventButton,
                                                                      this.m_SetInderxer,
                                                                      this.m_EventUnsubs,
                                                                      this.m_EventSubs,
                                                                      this.m_NewButton,
                                                                      this.m_ErrorButton,
                                                                      this.m_GetFieldButton,
                                                                      this.m_SetFieldButton,
                                                                      this.m_GetPropertyButton,
                                                                      this.m_SetPropertyButton,
                                                                      this.m_MethodButton,
                                                                      this.m_GetInderxer});
         this.Name = "TestClient";
         this.Text = "Logbook Test Client";
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]      
      static void Main() 
      {
         RemotingConfiguration.Configure("TestClient.exe.config",false);

         //To get user name logged as well:
         AppDomain currentDomain = AppDomain.CurrentDomain;
         currentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

         Application.Run(new TestClient());
		}
      private void OnMethod(object sender,EventArgs e)
      {
         m_Obj.SomeMethod();
      }
      private void OnSetProperty(object sender,EventArgs e)
      {
         m_Obj.SomeProperty = 0;
      }

      private void OnGetProperty(object sender,EventArgs e)
      {
         int i = m_Obj.SomeProperty;
      }

      private void OnSetField(object sender,EventArgs e)
      {
         m_Obj.m_MyMember = 0;
      }

      void OnGetField(object sender,EventArgs e)
      {
         int i = m_Obj.m_MyMember;
      }
      void OnError(object sender,EventArgs e)
      {
         try
         {
            m_Obj.SomeMethodWithError();
         }
         catch{}
      }

      void OnCreate(object sender,EventArgs e)
      {
         m_Obj = new TestClass();
      }

      void OnSubscribe(object sender,EventArgs e)
      {
         m_Obj.SomeEvent += new EventHandler(OnEvent);
      }
      void OnEvent(object sender,EventArgs e)
      {
      }

      void OnUnsubscribe(object sender,EventArgs e)
      {
         m_Obj.SomeEvent -= new EventHandler(OnEvent);
      }

      void OnSetIndexer(object sender,EventArgs e)
      {
          m_Obj[0] = 0;
      }

      void OnGetIndexer(object sender,EventArgs e)
      {
         int i = m_Obj[0];
      }

      void OnLogEvent(object sender,EventArgs e)
      {
         m_Obj.LogEvent();
      }
	}
}
