// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Security.Permissions;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsEx;

namespace SecureApp
{
	public class MainForm : Form
	{
		MainMenu m_MainMenu;
      MenuItem m_FileItem;
      MenuItem m_NewWindow;
      MenuItem m_LogInItem;
      MenuItem m_SecurityMenuItem;
      MenuItem m_LogOutItem;
      StatusBar m_StatusBar;
		private IContainer components;
      Timer m_Timer;

		public MainForm()
		{
         InitializeComponent();
         OnTick(this,EventArgs.Empty);
      }
		#region Windows Form Designer generated code
      void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.m_MainMenu = new System.Windows.Forms.MainMenu(this.components);
         this.m_FileItem = new System.Windows.Forms.MenuItem();
         this.m_NewWindow = new System.Windows.Forms.MenuItem();
         this.m_SecurityMenuItem = new System.Windows.Forms.MenuItem();
         this.m_LogInItem = new System.Windows.Forms.MenuItem();
         this.m_LogOutItem = new System.Windows.Forms.MenuItem();
         this.m_StatusBar = new System.Windows.Forms.StatusBar();
         this.m_Timer = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // m_MainMenu
         // 
         this.m_MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_FileItem,
            this.m_SecurityMenuItem});
         // 
         // m_FileItem
         // 
         this.m_FileItem.Index = 0;
         this.m_FileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_NewWindow});
         this.m_FileItem.Text = "File";
         // 
         // m_NewWindow
         // 
         this.m_NewWindow.Index = 0;
         this.m_NewWindow.Text = "New";
         this.m_NewWindow.Click += new System.EventHandler(this.OnFileNew);
         // 
         // m_SecurityMenuItem
         // 
         this.m_SecurityMenuItem.Index = 1;
         this.m_SecurityMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_LogInItem,
            this.m_LogOutItem});
         this.m_SecurityMenuItem.Text = "Security";
         // 
         // m_LogInItem
         // 
         this.m_LogInItem.Index = 0;
         this.m_LogInItem.Text = "Log In";
         this.m_LogInItem.Click += new System.EventHandler(this.OnLogIn);
         // 
         // m_LogOutItem
         // 
         this.m_LogOutItem.Enabled = false;
         this.m_LogOutItem.Index = 1;
         this.m_LogOutItem.Text = "Log Out";
         this.m_LogOutItem.Click += new System.EventHandler(this.OnLogOut);
         // 
         // m_StatusBar
         // 
         this.m_StatusBar.Location = new System.Drawing.Point(0,353);
         this.m_StatusBar.Name = "m_StatusBar";
         this.m_StatusBar.Padding = new System.Windows.Forms.Padding(0,0,12,0);
         this.m_StatusBar.Size = new System.Drawing.Size(532,22);
         this.m_StatusBar.TabIndex = 1;
         this.m_StatusBar.Text = "Current Status: ";
         // 
         // m_Timer
         // 
         this.m_Timer.Enabled = true;
         this.m_Timer.Interval = 500;
         this.m_Timer.Tick += new System.EventHandler(this.OnTick);
         // 
         // MainForm
         // 
         this.ClientSize = new System.Drawing.Size(532,375);
         this.Controls.Add(this.m_StatusBar);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this.m_MainMenu;
         this.Name = "MainForm";
         this.Text = "My Secure App";
         this.ResumeLayout(false);

      }
		#endregion

      [PrincipalPermission(SecurityAction.Demand,Role = "Manager")]
      void OnFileNew(object sender,EventArgs args)
      {
			ChildForm childForm = new ChildForm();
			childForm.MdiParent = this;
			childForm.Show();
		}

      void OnLogIn(object sender,EventArgs args)
      {
         LoginDialog logInDialog = new LoginDialog();
         logInDialog.ShowDialog();
         if(logInDialog.Authenticated)
         {
            m_LogInItem.Enabled  = false;
            m_LogOutItem.Enabled = true;
         }
      }

      void OnLogOut(object sender,EventArgs args)
      {
         m_LogOutItem.Enabled = false;
         m_LogInItem.Enabled = true;
         LoginDialog.Logout();
      }

      void OnTick(object sender,EventArgs args)
      {
         m_StatusBar.Text = "Current Status: ";
         if(LoginDialog.IsLoggedIn)
         {
            m_StatusBar.Text += "Logged-In";
         }
         else
         {
            m_StatusBar.Text += "Logged-Out";
         }
      }
	}
}
