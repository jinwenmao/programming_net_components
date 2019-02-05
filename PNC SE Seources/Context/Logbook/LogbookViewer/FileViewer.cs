// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using ContextLogger;

namespace LogbookViewer
{
	public class FileViewer : Form
	{
      DataView m_View;
      GroupBox m_FilterGroup;
      RadioButton m_AllRadioButton;
      RadioButton m_ErrorRadioButton;
      RadioButton m_EventsRadioButton;
      DataGridView m_EntriesGridView;
      Button m_CloseButton;

		public FileViewer(string fileName)
		{
			InitializeComponent();
         Text += fileName;
         this.Width = SystemInformation.VirtualScreen.Width;

         ContextLogger.EntriesDataSet dataSet = new ContextLogger.EntriesDataSet();
         dataSet.ReadXml(fileName);

         m_View.Table = dataSet.Entries;
         m_EntriesGridView.DataSource = m_View;
         OnFilter(this,EventArgs.Empty);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
         this.m_View = new System.Data.DataView();
         this.m_FilterGroup = new System.Windows.Forms.GroupBox();
         this.m_EventsRadioButton = new System.Windows.Forms.RadioButton();
         this.m_ErrorRadioButton = new System.Windows.Forms.RadioButton();
         this.m_AllRadioButton = new System.Windows.Forms.RadioButton();
         this.m_CloseButton = new System.Windows.Forms.Button();
         this.m_EntriesGridView = new System.Windows.Forms.DataGridView();
         ((System.ComponentModel.ISupportInitialize)(this.m_View)).BeginInit();
         this.m_FilterGroup.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.m_EntriesGridView)).BeginInit();
         this.SuspendLayout();
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
         this.m_FilterGroup.Location = new System.Drawing.Point(8,304);
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
// m_CloseButton
// 
         this.m_CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.m_CloseButton.Location = new System.Drawing.Point(936,312);
         this.m_CloseButton.Name = "m_CloseButton";
         this.m_CloseButton.TabIndex = 4;
         this.m_CloseButton.Text = "Close";
         this.m_CloseButton.Click += new System.EventHandler(this.OnClose);
// 
// m_EntriesGridView
// 
         this.m_EntriesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.m_EntriesGridView.Location = new System.Drawing.Point(8,12);
         this.m_EntriesGridView.Name = "m_EntriesGridView";
         this.m_EntriesGridView.Size = new System.Drawing.Size(1008,269);
         this.m_EntriesGridView.TabIndex = 5;
// 
// FileViewer
// 
         
         this.CancelButton = this.m_CloseButton;
         this.ClientSize = new System.Drawing.Size(1024,443);
         this.Controls.Add(this.m_EntriesGridView);
         this.Controls.Add(this.m_CloseButton);
         this.Controls.Add(this.m_FilterGroup);
         this.Name = "FileViewer";
         this.Text = "Logbook File Viewer - ";
         this.Load += new System.EventHandler(this.OnLoad);
         ((System.ComponentModel.ISupportInitialize)(this.m_View)).EndInit();
         this.m_FilterGroup.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.m_EntriesGridView)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

      private void OnClose(object sender,EventArgs e)
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
         ResizeGrid(m_EntriesGridView);
      }

      static void ResizeGrid(DataGridView grid)
      {
         for(int i = 0;i < grid.ColumnCount;i++)
         {
            grid.AutoResizeColumn(i,DataGridViewAutoSizeColumnMode.AllCells);
         }
      }
      void OnLoad(object sender,EventArgs e)
      {
         m_EntriesGridView.AutoGenerateColumns = true;
         ResizeGrid(m_EntriesGridView);
      }
   }
}

