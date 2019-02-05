// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Data;
using ContextLogger;

namespace LogbookViewer
{
	public class LogViewer : Form
	{
      Logbook m_Logbook;
      DataView m_View;
      Button m_ReloadButton;
      Button m_ClearButton;
      GroupBox m_FilterGroup;
      RadioButton m_AllRadioButton;
      RadioButton m_ErrorRadioButton;
      RadioButton m_EventsRadioButton;
      MainMenu m_MainMenu;
      MenuItem m_FileMenuItem;
      MenuItem m_SaveMenuItem;
      MenuItem m_ExitMenuItem;
      DataGridView m_EntriesGridView;
      MenuItem m_DisplayMenuItem;

		public LogViewer()
		{
			InitializeComponent();
         this.Width = SystemInformation.VirtualScreen.Width;

         m_Logbook = new Logbook();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
         this.m_ReloadButton = new System.Windows.Forms.Button();
         this.m_ClearButton = new System.Windows.Forms.Button();
         this.m_View = new System.Data.DataView();
         this.m_FilterGroup = new System.Windows.Forms.GroupBox();
         this.m_EventsRadioButton = new System.Windows.Forms.RadioButton();
         this.m_ErrorRadioButton = new System.Windows.Forms.RadioButton();
         this.m_AllRadioButton = new System.Windows.Forms.RadioButton();
         this.m_MainMenu = new System.Windows.Forms.MainMenu();
         this.m_FileMenuItem = new System.Windows.Forms.MenuItem();
         this.m_SaveMenuItem = new System.Windows.Forms.MenuItem();
         this.m_DisplayMenuItem = new System.Windows.Forms.MenuItem();
         this.m_ExitMenuItem = new System.Windows.Forms.MenuItem();
         this.m_EntriesGridView = new System.Windows.Forms.DataGridView();
         ((System.ComponentModel.ISupportInitialize)(this.m_View)).BeginInit();
         this.m_FilterGroup.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.m_EntriesGridView)).BeginInit();
         this.SuspendLayout();
// 
// m_ReloadButton
// 
         this.m_ReloadButton.Location = new System.Drawing.Point(136,288);
         this.m_ReloadButton.Name = "m_ReloadButton";
         this.m_ReloadButton.TabIndex = 1;
         this.m_ReloadButton.Text = "Refresh";
         this.m_ReloadButton.Click += new System.EventHandler(this.OnReload);
// 
// m_ClearButton
// 
         this.m_ClearButton.Location = new System.Drawing.Point(264,288);
         this.m_ClearButton.Name = "m_ClearButton";
         this.m_ClearButton.TabIndex = 2;
         this.m_ClearButton.Text = "Clear";
         this.m_ClearButton.Click += new System.EventHandler(this.OnClear);
// 
// m_View
// 
         this.m_View.RowFilter = "ExceptionName <> \'\'";
// 
// m_FilterGroup
// 
         this.m_FilterGroup.Controls.Add(this.m_EventsRadioButton);
         this.m_FilterGroup.Controls.Add(this.m_ErrorRadioButton);
         this.m_FilterGroup.Controls.Add(this.m_AllRadioButton);
         this.m_FilterGroup.Location = new System.Drawing.Point(8,280);
         this.m_FilterGroup.Name = "m_FilterGroup";
         this.m_FilterGroup.Size = new System.Drawing.Size(104,120);
         this.m_FilterGroup.TabIndex = 3;
         this.m_FilterGroup.TabStop = false;
         this.m_FilterGroup.Text = "View Filter:";
// 
// m_EventsRadioButton
// 
         this.m_EventsRadioButton.Location = new System.Drawing.Point(16,88);
         this.m_EventsRadioButton.Name = "m_EventsRadioButton";
         this.m_EventsRadioButton.Size = new System.Drawing.Size(64,24);
         this.m_EventsRadioButton.TabIndex = 2;
         this.m_EventsRadioButton.Text = "Events";
         this.m_EventsRadioButton.CheckedChanged += new System.EventHandler(this.OnFilter);
// 
// m_ErrorRadioButton
// 
         this.m_ErrorRadioButton.Location = new System.Drawing.Point(16,56);
         this.m_ErrorRadioButton.Name = "m_ErrorRadioButton";
         this.m_ErrorRadioButton.Size = new System.Drawing.Size(80,24);
         this.m_ErrorRadioButton.TabIndex = 1;
         this.m_ErrorRadioButton.Text = "Errors Only";
         this.m_ErrorRadioButton.CheckedChanged += new System.EventHandler(this.OnFilter);
// 
// m_AllRadioButton
// 
         this.m_AllRadioButton.Checked = true;
         this.m_AllRadioButton.Location = new System.Drawing.Point(16,24);
         this.m_AllRadioButton.Name = "m_AllRadioButton";
         this.m_AllRadioButton.Size = new System.Drawing.Size(40,24);
         this.m_AllRadioButton.TabIndex = 0;
         this.m_AllRadioButton.TabStop = true;
         this.m_AllRadioButton.Text = "All";
         this.m_AllRadioButton.CheckedChanged += new System.EventHandler(this.OnFilter);
// 
// m_MainMenu
// 
         this.m_MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_FileMenuItem
         });
         this.m_MainMenu.Name = "m_MainMenu";
// 
// m_FileMenuItem
// 
         this.m_FileMenuItem.Index = 0;
         this.m_FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_SaveMenuItem,
            this.m_DisplayMenuItem,
            this.m_ExitMenuItem});
         this.m_FileMenuItem.Name = "m_FileMenuItem";
         this.m_FileMenuItem.Text = "File";
// 
// m_SaveMenuItem
// 
         this.m_SaveMenuItem.Index = 0;
         this.m_SaveMenuItem.Name = "m_SaveMenuItem";
         this.m_SaveMenuItem.Text = "Save Logbook Entries...";
         this.m_SaveMenuItem.Click += new System.EventHandler(this.OnSave);
// 
// m_DisplayMenuItem
// 
         this.m_DisplayMenuItem.Index = 1;
         this.m_DisplayMenuItem.Name = "m_DisplayMenuItem";
         this.m_DisplayMenuItem.Text = "Display Entries File...";
         this.m_DisplayMenuItem.Click += new System.EventHandler(this.OnDisplay);
// 
// m_ExitMenuItem
// 
         this.m_ExitMenuItem.Index = 2;
         this.m_ExitMenuItem.Name = "m_ExitMenuItem";
         this.m_ExitMenuItem.Text = "Exit";
         this.m_ExitMenuItem.Click += new System.EventHandler(this.OnExit);
// 
// m_EntriesGridView
// 
         this.m_EntriesGridView.DataSource = this.m_View;
         this.m_EntriesGridView.Location = new System.Drawing.Point(8,13);
         this.m_EntriesGridView.Name = "m_EntriesGridView";
         this.m_EntriesGridView.Size = new System.Drawing.Size(1004,255);
         this.m_EntriesGridView.TabIndex = 4;
// 
// LogViewer
// 
         
         this.ClientSize = new System.Drawing.Size(1024,417);
         this.Controls.Add(this.m_EntriesGridView);
         this.Controls.Add(this.m_FilterGroup);
         this.Controls.Add(this.m_ClearButton);
         this.Controls.Add(this.m_ReloadButton);
         this.Menu = this.m_MainMenu;
         this.Name = "LogViewer";
         this.Text = "Logbook Viewer";
         this.Load += new System.EventHandler(this.OnLoad);
         ((System.ComponentModel.ISupportInitialize)(this.m_View)).EndInit();
         this.m_FilterGroup.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.m_EntriesGridView)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
         RemotingConfiguration.Configure("LogbookViewer.exe.config",false);

			Application.Run(new LogViewer());
		}

      static void ResizeGrid(DataGridView grid)
      {
         for(int i = 0;i < grid.ColumnCount;i++)
         {
            grid.AutoResizeColumn(i,DataGridViewAutoSizeColumnMode.AllCells);
         }
      }
      private void OnReload(object sender,EventArgs e)
      {
         DataTable table = m_Logbook.GetEntries().Entries;
         if(table.Rows.Count > 0)
         {
            m_View.Table = table;
            m_EntriesGridView.DataSource = m_View;
         }
         else
         {
            m_EntriesGridView.DataSource = null;
         }
         OnFilter(this,EventArgs.Empty);
         ResizeGrid(m_EntriesGridView);
      }

      private void OnClear(object sender,EventArgs e)
      {
         DialogResult result = MessageBox.Show("Are you sure you want to clear the content of the logbook?","Logbook Viewer",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
         if(result == DialogResult.Yes)
         {
            m_Logbook.Clear();
            OnReload(this,e);
         }
      }

      private void OnSave(object sender,EventArgs e)
      {
         SaveFileDialog saveFileDialog = new SaveFileDialog();
 
         saveFileDialog.Filter = "Log files (*.log)|*.log|XML files (*.xml)|*.xml|All files (*.*)|*.*"  ;
         saveFileDialog.FilterIndex = 1;
         saveFileDialog.RestoreDirectory = true ;
 
         DialogResult result = saveFileDialog.ShowDialog();
         if(result != DialogResult.OK)
         {
            return;
         }
         DataView view = (DataView)m_EntriesGridView.DataSource;
         DataSet dataSet = view.Table.DataSet;
         dataSet.WriteXml(saveFileDialog.FileName);
      }

      private void OnDisplay(object sender,EventArgs e)
      {
         OpenFileDialog openFileDialog = new OpenFileDialog();
 
         openFileDialog.Filter = "Log files (*.log)|*.log|XML files (*.xml)|*.xml|All files (*.*)|*.*"  ;
         openFileDialog.FilterIndex = 1;
         openFileDialog.RestoreDirectory = true ;
 
         DialogResult result = openFileDialog.ShowDialog();
         if(result != DialogResult.OK)
         {
            return;
         }
         FileViewer fileViewer = new FileViewer(openFileDialog.FileName);
         fileViewer.ShowDialog();
      }

      private void OnExit(object sender,EventArgs e)
      {
         Close();
      }

      private void OnFilter(object sender,EventArgs e)
      {
         if(m_AllRadioButton.Checked)
         {
            m_View.RowFilter = "";
         }
         if(m_ErrorRadioButton.Checked)
         {
            m_View.RowFilter = "ExceptionName <> ''";
         }
         if(m_EventsRadioButton.Checked)
         {
            m_View.RowFilter = "Event <> ''";
         }
         m_EntriesGridView.Refresh();
      }

      void OnLoad(object sender, EventArgs e)
      {
         m_EntriesGridView.AutoGenerateColumns = true;
         OnReload(this,EventArgs.Empty);
      }
	}
}
