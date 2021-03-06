// � 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using RemoteServer;
using RemotingEx;

namespace Client
{
	public class ClientForm : Form
	{
		Button m_NewButton;
      SponsorshipManager m_SponsorshipManager;
      MyClass m_Obj;

		public ClientForm()
		{
			InitializeComponent();

         m_SponsorshipManager = new SponsorshipManager();
         Application.ApplicationExit += new EventHandler(m_SponsorshipManager.OnExit);
         
         m_Obj = new MyClass();

         //Register the sponsor
         m_SponsorshipManager.Register(m_Obj);
		}
	
		#region Windows Form Designer generated code
		void InitializeComponent()
		{
         this.m_NewButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // m_NewButton
         // 
         this.m_NewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.m_NewButton.Location = new System.Drawing.Point(72, 40);
         this.m_NewButton.Name = "m_NewButton";
         this.m_NewButton.Size = new System.Drawing.Size(112, 32);
         this.m_NewButton.TabIndex = 0;
         this.m_NewButton.Text = "Call Object";
         this.m_NewButton.Click += new System.EventHandler(this.OnCall);
         // 
         // ClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(248, 117);
         this.Controls.Add(this.m_NewButton);
         this.Name = "ClientForm";
         this.Text = "Client of Remote Object";
         this.ResumeLayout(false);

      }
		#endregion

		static void Main() 
		{
         RemotingConfigurationEx.Configure();
			Application.Run(new ClientForm());
		} 
      private void OnCall(object sender,EventArgs e)
		{
         m_Obj.Count();
      }
	}
}


