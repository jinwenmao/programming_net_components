// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Windows.Forms;
using WinFormsEx;

namespace SecureApp
{
   public partial class LoginDialog : Form
   {
      PictureBox m_PictureBox;
      AspNetLoginControl m_LogInControl;

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
         this.m_PictureBox = new System.Windows.Forms.PictureBox();
         this.m_LogInControl = new WinFormsEx.AspNetLoginControl();
         ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // m_PictureBox
         // 
         this.m_PictureBox.AutoSize = true;
         this.m_PictureBox.Image = SecureApp.Properties.Resources.Security;
         this.m_PictureBox.Location = new System.Drawing.Point(223,22);
         this.m_PictureBox.Name = "m_PictureBox";
         this.m_PictureBox.Size = new System.Drawing.Size(75,75);
         this.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.m_PictureBox.TabIndex = 1;
         this.m_PictureBox.TabStop = false;
         // 
         // m_LogInControl
         // 
         this.m_LogInControl.AccessibleName = "";
         this.m_LogInControl.ApplicationName = "/";
         this.m_LogInControl.CacheRoles = false;
         this.m_LogInControl.Location = new System.Drawing.Point(13,13);
         this.m_LogInControl.Name = "m_LogInControl";
         this.m_LogInControl.Size = new System.Drawing.Size(203,116);
         this.m_LogInControl.TabIndex = 2;
         this.m_LogInControl.LoginEvent += new GenericEventHandler<WinFormsEx.LoginControl,WinFormsEx.LoginEventArgs>(this.OnLogin);
         // 
         // LoginDialog
         // 
         this.AccessibleName = "MyApp";
         this.ClientSize = new System.Drawing.Size(310,141);
         this.Controls.Add(this.m_LogInControl);
         this.Controls.Add(this.m_PictureBox);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginDialog";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Log In";
         ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion
   }
}