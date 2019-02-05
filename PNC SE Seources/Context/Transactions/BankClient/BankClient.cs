// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BankAccountServer;

namespace TransactionDemo
{
   public class BankClient : Form
   {
      Button m_TransferButton;
      TextBox m_SourceBox;
      Label m_SourceLabel;
      Label m_DestLabel;
      TextBox m_DestBox;
      TextBox m_AmountBox;
      Label m_AmountLabel;
      PictureBox m_PictureBox;
      BankDataSet m_BankDataSet;
      BindingSource m_BankAccountsBindingSource;
      BankDataSetTableAdapters.BankAccountsTableAdapter m_BankAccountsTableAdapter;
      DataGridView m_AccountsGrid;
      DataGridViewTextBoxColumn m_NumberDataGridViewTextBoxColumn;
      DataGridViewTextBoxColumn m_BalanceDataGridViewTextBoxColumn;
      DataGridViewTextBoxColumn m_NameDataGridViewTextBoxColumn;
      IContainer components;

      public BankClient()
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankClient));
         this.m_DestLabel = new System.Windows.Forms.Label();
         this.m_TransferButton = new System.Windows.Forms.Button();
         this.m_DestBox = new System.Windows.Forms.TextBox();
         this.m_AmountBox = new System.Windows.Forms.TextBox();
         this.m_SourceLabel = new System.Windows.Forms.Label();
         this.m_AmountLabel = new System.Windows.Forms.Label();
         this.m_SourceBox = new System.Windows.Forms.TextBox();
         this.m_PictureBox = new System.Windows.Forms.PictureBox();
         this.m_BankDataSet = new TransactionDemo.BankDataSet();
         this.m_BankAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.m_BankAccountsTableAdapter = new TransactionDemo.BankDataSetTableAdapters.BankAccountsTableAdapter();
         this.m_AccountsGrid = new System.Windows.Forms.DataGridView();
         this.m_NumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.m_BalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.m_NameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.m_BankDataSet)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.m_BankAccountsBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.m_AccountsGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // m_DestLabel
         // 
         this.m_DestLabel.Location = new System.Drawing.Point(144,16);
         this.m_DestLabel.Name = "m_DestLabel";
         this.m_DestLabel.Size = new System.Drawing.Size(104,23);
         this.m_DestLabel.TabIndex = 3;
         this.m_DestLabel.Text = "Destination Acount:";
         // 
         // m_TransferButton
         // 
         this.m_TransferButton.Location = new System.Drawing.Point(427,40);
         this.m_TransferButton.Name = "m_TransferButton";
         this.m_TransferButton.Size = new System.Drawing.Size(75,23);
         this.m_TransferButton.TabIndex = 1;
         this.m_TransferButton.Text = "Transfer";
         this.m_TransferButton.Click += new System.EventHandler(this.OnTransfer);
         // 
         // m_DestBox
         // 
         this.m_DestBox.Location = new System.Drawing.Point(144,40);
         this.m_DestBox.Name = "m_DestBox";
         this.m_DestBox.Size = new System.Drawing.Size(100,20);
         this.m_DestBox.TabIndex = 2;
         this.m_DestBox.Text = "456";
         // 
         // m_AmountBox
         // 
         this.m_AmountBox.Location = new System.Drawing.Point(272,40);
         this.m_AmountBox.Name = "m_AmountBox";
         this.m_AmountBox.Size = new System.Drawing.Size(80,20);
         this.m_AmountBox.TabIndex = 2;
         this.m_AmountBox.Text = "100";
         // 
         // m_SourceLabel
         // 
         this.m_SourceLabel.Location = new System.Drawing.Point(8,16);
         this.m_SourceLabel.Name = "m_SourceLabel";
         this.m_SourceLabel.Size = new System.Drawing.Size(100,23);
         this.m_SourceLabel.TabIndex = 3;
         this.m_SourceLabel.Text = "Source Acount:";
         // 
         // m_AmountLabel
         // 
         this.m_AmountLabel.Location = new System.Drawing.Point(272,16);
         this.m_AmountLabel.Name = "m_AmountLabel";
         this.m_AmountLabel.Size = new System.Drawing.Size(192,23);
         this.m_AmountLabel.TabIndex = 3;
         this.m_AmountLabel.Text = "Amount:";
         // 
         // m_SourceBox
         // 
         this.m_SourceBox.Location = new System.Drawing.Point(8,40);
         this.m_SourceBox.Name = "m_SourceBox";
         this.m_SourceBox.Size = new System.Drawing.Size(100,20);
         this.m_SourceBox.TabIndex = 2;
         this.m_SourceBox.Text = "123";
         // 
         // m_PictureBox
         // 
         this.m_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.m_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.Image")));
         this.m_PictureBox.Location = new System.Drawing.Point(358,104);
         this.m_PictureBox.Name = "m_PictureBox";
         this.m_PictureBox.Size = new System.Drawing.Size(144,128);
         this.m_PictureBox.TabIndex = 0;
         this.m_PictureBox.TabStop = false;
         // 
         // m_BankDataSet
         // 
         this.m_BankDataSet.DataSetName = "BankDataSet";
         // 
         // m_BankAccountsBindingSource
         // 
         this.m_BankAccountsBindingSource.DataMember = "BankAccounts";
         this.m_BankAccountsBindingSource.DataSource = this.m_BankDataSet;
         // 
         // m_BankAccountsTableAdapter
         // 
         this.m_BankAccountsTableAdapter.ClearBeforeFill = true;
         // 
         // m_AccountsGrid
         // 
         this.m_AccountsGrid.AutoGenerateColumns = false;
         this.m_AccountsGrid.Columns.Add(this.m_NumberDataGridViewTextBoxColumn);
         this.m_AccountsGrid.Columns.Add(this.m_BalanceDataGridViewTextBoxColumn);
         this.m_AccountsGrid.Columns.Add(this.m_NameDataGridViewTextBoxColumn);
         this.m_AccountsGrid.DataSource = this.m_BankAccountsBindingSource;
         this.m_AccountsGrid.Location = new System.Drawing.Point(9,104);
         this.m_AccountsGrid.Name = "m_AccountsGrid";
         this.m_AccountsGrid.ReadOnly = true;
         this.m_AccountsGrid.Size = new System.Drawing.Size(343,128);
         this.m_AccountsGrid.TabIndex = 9;
         // 
         // m_NumberDataGridViewTextBoxColumn
         // 
         this.m_NumberDataGridViewTextBoxColumn.DataPropertyName = "Number";
         this.m_NumberDataGridViewTextBoxColumn.HeaderText = "Number";
         this.m_NumberDataGridViewTextBoxColumn.Name = "Number";
         this.m_NumberDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // m_BalanceDataGridViewTextBoxColumn
         // 
         this.m_BalanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
         this.m_BalanceDataGridViewTextBoxColumn.HeaderText = "Balance";
         this.m_BalanceDataGridViewTextBoxColumn.Name = "Balance";
         this.m_BalanceDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // m_NameDataGridViewTextBoxColumn
         // 
         this.m_NameDataGridViewTextBoxColumn.DataPropertyName = "Name";
         this.m_NameDataGridViewTextBoxColumn.HeaderText = "Name";
         this.m_NameDataGridViewTextBoxColumn.Name = "Name";
         this.m_NameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // BankClient
         // 
         this.ClientSize = new System.Drawing.Size(512,246);
         this.Controls.Add(this.m_AccountsGrid);
         this.Controls.Add(this.m_SourceLabel);
         this.Controls.Add(this.m_SourceBox);
         this.Controls.Add(this.m_TransferButton);
         this.Controls.Add(this.m_PictureBox);
         this.Controls.Add(this.m_DestLabel);
         this.Controls.Add(this.m_DestBox);
         this.Controls.Add(this.m_AmountLabel);
         this.Controls.Add(this.m_AmountBox);
         this.Name = "BankClient";
         this.Text = "Bank Client";
         this.Load += new System.EventHandler(this.OnLoad);
         ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.m_BankDataSet)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.m_BankAccountsBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.m_AccountsGrid)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.Run(new BankClient());
      }

      void OnTransfer(object sender,EventArgs e)
      {
         int debitAccount;
         int creditAccount;
         decimal amount;

         debitAccount = Convert.ToInt32(m_SourceBox.Text);
         creditAccount = Convert.ToInt32(m_DestBox.Text);
         amount = Convert.ToDecimal(m_AmountBox.Text);
         try
         {
            IAccountManager accountManager;
            accountManager = new AccountManager();
            accountManager.Transfer(debitAccount,creditAccount,amount);
         }
         catch(Exception exception)
         {
            MessageBox.Show("Some error occurred: " + exception.Message,"Bank Client");
         }
         finally
         {
            m_BankAccountsTableAdapter.Fill(m_BankDataSet.BankAccounts);
         }
      }
      void OnLoad(object sender,EventArgs e)
      {
         m_BankAccountsTableAdapter.Fill(m_BankDataSet.BankAccounts);
      }
      void OnBindingNavigatorSaveItem(object sender,EventArgs e)
      {
         if(this.Validate())
         {
            m_BankAccountsBindingSource.EndEdit();
            m_BankAccountsTableAdapter.Update(this.m_BankDataSet.BankAccounts);
         }
         else
         {
            MessageBox.Show(this,"Validation errors occurred.","Save",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
         }
      }
   }
}
