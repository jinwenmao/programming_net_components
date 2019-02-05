// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Runtime.Remoting;


namespace RemoteServerHost
{
   public class ServerHostDialog : Form
   {
	   public ServerHostDialog()
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
         // ServerHostDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(312, 197);
         this.Name = "ServerHostDialog";
         this.Text = "Server Host";
         this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

      }
	   #endregion

	   static void Main() 
	   {
         RemotingConfiguration.Configure("RemoteServerHost.exe.config",false);

         Application.Run(new ServerHostDialog());
	   }
   }
}
