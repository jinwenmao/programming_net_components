// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SecureApp
{
	public class ChildForm : Form
	{
      MainMenu m_MainMenu;
      MenuItem m_MenuItem;

		public ChildForm()
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
         this.m_MainMenu = new System.Windows.Forms.MainMenu();
         this.m_MenuItem = new System.Windows.Forms.MenuItem();
// 
// m_MainMenu
// 
         this.m_MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_MenuItem
         });
         this.m_MainMenu.Name = "m_MainMenu";
// 
// m_MenuItem
// 
         this.m_MenuItem.Index = 0;
         this.m_MenuItem.Name = "m_MenuItem";
         this.m_MenuItem.Text = "Some Opp";
// 
// ChildForm
// 
         
         this.BackColor = System.Drawing.SystemColors.Window;
         this.ClientSize = new System.Drawing.Size(287,209);
         this.Menu = this.m_MainMenu;
         this.Name = "ChildForm";
         this.Text = "Child Form";

      }
		#endregion
	}
}
