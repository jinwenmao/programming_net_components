// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace LogbookHost
{
	public class  LogbookHostForm : Form
	{
		public LogbookHostForm()
		{
			InitializeComponent();
      }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
         // 
         // LogbookHostForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(232, 157);
         this.Name = "LogbookHostForm";
         this.Text = "Logbook Host";
         this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

      }
		#endregion

		[STAThread]
		static void Main() 
		{
         RemotingConfiguration.Configure("LogbookHost.exe.config",false);
			Application.Run(new LogbookHostForm());
		}
	}
}
