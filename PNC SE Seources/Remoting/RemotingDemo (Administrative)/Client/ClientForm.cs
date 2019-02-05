// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using RemoteServer;

namespace Client
{
	public class ClientForm : Form
	{
		private Button m_NewButton;

		public ClientForm()
		{
			InitializeComponent();
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
         this.m_NewButton.Text = "new";
         this.m_NewButton.Click += new System.EventHandler(this.OnNew);
         // 
         // ClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(248, 117);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_NewButton});
         this.Name = "ClientForm";
         this.Text = "Client of Remote Object";
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
         RemotingConfiguration.Configure("Client.exe.config",false);
			Application.Run(new ClientForm());
		} 
      private void OnNew(object sender,EventArgs e)
		{
         MyServer obj;
         obj = new MyServer();
         obj.Count();
         obj.Count();
      }
	}
}






