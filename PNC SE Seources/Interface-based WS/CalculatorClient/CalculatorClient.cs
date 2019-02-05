// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using WSInterfacesDemo.localhost;
using WSInterfacesDemo.localhost1;
using WinFormsEx;

namespace WSInterfacesDemo
{
	/// <summary>
	/// Summary description for CalculatorClient.
	/// </summary>
	public class CalculatorClient : Form
	{
		GroupBox m_ServiceSelectionGroup;
		RadioButton m_SimpleRadio;
		RadioButton m_ScientificRadio;
		Button m_ExitButton;
		Button m_AddNotBasedButton;
		Button m_AddBasedButton;
		TextBox m_Num1TextBox;
		TextBox m_Num2TextBox;
		TextBox m_ResultTextBox;
		Label m_Num1Label;
		Label m_Num2Label;
		Label m_ResultLabel;
		Label m_NotBasedLabel;
		Button m_AsyncAddButton;
		Label m_BasedLabel;

		public CalculatorClient()
		{
			InitializeComponent();
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static void Main(string[] args)
		{
			Application.Run(new CalculatorClient());
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
			this.m_BasedLabel = new System.Windows.Forms.Label();
			this.m_Num2TextBox = new System.Windows.Forms.TextBox();
			this.m_ServiceSelectionGroup = new System.Windows.Forms.GroupBox();
			this.m_ScientificRadio = new System.Windows.Forms.RadioButton();
			this.m_SimpleRadio = new System.Windows.Forms.RadioButton();
			this.m_Num1TextBox = new System.Windows.Forms.TextBox();
			this.m_Num1Label = new System.Windows.Forms.Label();
			this.m_Num2Label = new System.Windows.Forms.Label();
			this.m_AddBasedButton = new System.Windows.Forms.Button();
			this.m_ResultLabel = new System.Windows.Forms.Label();
			this.m_ResultTextBox = new SafeTextBox();
			this.m_ExitButton = new System.Windows.Forms.Button();
			this.m_AddNotBasedButton = new System.Windows.Forms.Button();
			this.m_NotBasedLabel = new System.Windows.Forms.Label();
			this.m_AsyncAddButton = new System.Windows.Forms.Button();
			this.m_ServiceSelectionGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_BasedLabel
			// 
			this.m_BasedLabel.Location = new System.Drawing.Point(168,144);
			this.m_BasedLabel.Name = "m_BasedLabel";
			this.m_BasedLabel.Size = new System.Drawing.Size(136,32);
			this.m_BasedLabel.TabIndex = 3;
			this.m_BasedLabel.Text = "Calculator Service - Interface-Based";
			// 
			// m_Num2TextBox
			// 
			this.m_Num2TextBox.Location = new System.Drawing.Point(280,32);
			this.m_Num2TextBox.Name = "m_Num2TextBox";
			this.m_Num2TextBox.Size = new System.Drawing.Size(80,20);
			this.m_Num2TextBox.TabIndex = 1;
			this.m_Num2TextBox.Text = "0";
			// 
			// m_ServiceSelectionGroup
			// 
			this.m_ServiceSelectionGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                              this.m_ScientificRadio,
                                                                                              this.m_SimpleRadio});
			this.m_ServiceSelectionGroup.Location = new System.Drawing.Point(8,8);
			this.m_ServiceSelectionGroup.Name = "m_ServiceSelectionGroup";
			this.m_ServiceSelectionGroup.Size = new System.Drawing.Size(160,112);
			this.m_ServiceSelectionGroup.TabIndex = 0;
			this.m_ServiceSelectionGroup.TabStop = false;
			this.m_ServiceSelectionGroup.Text = "Select the Interface-Based Calculation Service";
			// 
			// m_ScientificRadio
			// 
			this.m_ScientificRadio.Location = new System.Drawing.Point(8,80);
			this.m_ScientificRadio.Name = "m_ScientificRadio";
			this.m_ScientificRadio.Size = new System.Drawing.Size(128,24);
			this.m_ScientificRadio.TabIndex = 1;
			this.m_ScientificRadio.Text = "Scientific Calculator";
			// 
			// m_SimpleRadio
			// 
			this.m_SimpleRadio.Checked = true;
			this.m_SimpleRadio.Location = new System.Drawing.Point(8,48);
			this.m_SimpleRadio.Name = "m_SimpleRadio";
			this.m_SimpleRadio.Size = new System.Drawing.Size(128,16);
			this.m_SimpleRadio.TabIndex = 0;
			this.m_SimpleRadio.TabStop = true;
			this.m_SimpleRadio.Text = "Simple Calculator";
			// 
			// m_Num1TextBox
			// 
			this.m_Num1TextBox.Location = new System.Drawing.Point(176,32);
			this.m_Num1TextBox.Name = "m_Num1TextBox";
			this.m_Num1TextBox.Size = new System.Drawing.Size(80,20);
			this.m_Num1TextBox.TabIndex = 1;
			this.m_Num1TextBox.Text = "0";
			// 
			// m_Num1Label
			// 
			this.m_Num1Label.Location = new System.Drawing.Point(176,8);
			this.m_Num1Label.Name = "m_Num1Label";
			this.m_Num1Label.TabIndex = 2;
			this.m_Num1Label.Text = "Number 1:";
			// 
			// m_Num2Label
			// 
			this.m_Num2Label.Location = new System.Drawing.Point(280,8);
			this.m_Num2Label.Name = "m_Num2Label";
			this.m_Num2Label.TabIndex = 2;
			this.m_Num2Label.Text = "Number 2:";
			// 
			// m_AddBasedButton
			// 
			this.m_AddBasedButton.Location = new System.Drawing.Point(168,184);
			this.m_AddBasedButton.Name = "m_AddBasedButton";
			this.m_AddBasedButton.TabIndex = 4;
			this.m_AddBasedButton.Text = "Add";
			this.m_AddBasedButton.Click += new System.EventHandler(this.OnAddBased);
			// 
			// m_ResultLabel
			// 
			this.m_ResultLabel.Location = new System.Drawing.Point(416,8);
			this.m_ResultLabel.Name = "m_ResultLabel";
			this.m_ResultLabel.TabIndex = 2;
			this.m_ResultLabel.Text = "Result:";
			// 
			// m_ResultTextBox
			// 
			this.m_ResultTextBox.Location = new System.Drawing.Point(416,32);
			this.m_ResultTextBox.Name = "m_ResultTextBox";
			this.m_ResultTextBox.Size = new System.Drawing.Size(80,20);
			this.m_ResultTextBox.TabIndex = 1;
			this.m_ResultTextBox.Text = "0";
			// 
			// m_ExitButton
			// 
			this.m_ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_ExitButton.Location = new System.Drawing.Point(416,184);
			this.m_ExitButton.Name = "m_ExitButton";
			this.m_ExitButton.TabIndex = 5;
			this.m_ExitButton.Text = "Exit";
			this.m_ExitButton.Click += new System.EventHandler(this.OnExit);
			// 
			// m_AddNotBasedButton
			// 
			this.m_AddNotBasedButton.Location = new System.Drawing.Point(8,184);
			this.m_AddNotBasedButton.Name = "m_AddNotBasedButton";
			this.m_AddNotBasedButton.TabIndex = 4;
			this.m_AddNotBasedButton.Text = "Add";
			this.m_AddNotBasedButton.Click += new System.EventHandler(this.OnAddNotBased);
			// 
			// m_NotBasedLabel
			// 
			this.m_NotBasedLabel.Location = new System.Drawing.Point(8,144);
			this.m_NotBasedLabel.Name = "m_NotBasedLabel";
			this.m_NotBasedLabel.Size = new System.Drawing.Size(136,32);
			this.m_NotBasedLabel.TabIndex = 3;
			this.m_NotBasedLabel.Text = "Calculator Service - Not Interface-Based";
			// 
			// m_AsyncAddButton
			// 
			this.m_AsyncAddButton.Location = new System.Drawing.Point(8,248);
			this.m_AsyncAddButton.Name = "m_AsyncAddButton";
			this.m_AsyncAddButton.TabIndex = 6;
			this.m_AsyncAddButton.Text = "Async Add";
			this.m_AsyncAddButton.Click += new System.EventHandler(this.OnAsyncAdd);
			// 
			// CalculatorClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(5,13);
			this.CancelButton = this.m_ExitButton;
			this.ClientSize = new System.Drawing.Size(528,293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_AsyncAddButton,
                                                                      this.m_ExitButton,
                                                                      this.m_AddNotBasedButton,
                                                                      this.m_NotBasedLabel,
                                                                      this.m_Num1Label,
                                                                      this.m_Num1TextBox,
                                                                      this.m_ServiceSelectionGroup,
                                                                      this.m_Num2Label,
                                                                      this.m_Num2TextBox,
                                                                      this.m_ResultLabel,
                                                                      this.m_ResultTextBox,
                                                                      this.m_AddBasedButton,
                                                                      this.m_BasedLabel});
			this.Name = "CalculatorClient";
			this.Text = "CalculatorClient";
			this.m_ServiceSelectionGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		ICalculator GetCalculator()
		{
			if(m_ScientificRadio.Checked)
			{
				return new ScientificCalculator();
			}
			else
			{
				Debug.Assert(m_SimpleRadio.Checked);
				return new SimpleCalculator();
			}
		}

		void OnAddNotBased(object sender,EventArgs e)
		{
			//This client code is not polymorphic with any other provider on the same service. 
			SimpleCalculator simpleCalc;
			simpleCalc = new SimpleCalculator();

			int num1 = Convert.ToInt32(m_Num1TextBox.Text);
			int num2 = Convert.ToInt32(m_Num2TextBox.Text);
			int result;
			result = simpleCalc.Add(num1,num2);
			m_ResultTextBox.Text = result.ToString();
		}
		void OnAddBased(object sender,EventArgs e)
		{
			ICalculator calc;
			calc = GetCalculator();

			int num1 = Convert.ToInt32(m_Num1TextBox.Text);
			int num2 = Convert.ToInt32(m_Num2TextBox.Text);
			int result;
			result = calc.Add(num1,num2);

			m_ResultTextBox.Text = result.ToString();
		}

		void OnExit(object sender,EventArgs e)
		{
			Close();
		}

		void OnAsyncAdd(object sender,EventArgs e)
		{
			SimpleCalculator calc;
			calc  = new SimpleCalculator();
			AsyncCallback callback;
			callback = new AsyncCallback(OnMethodCompletion);
			int num1 = Convert.ToInt32(m_Num1TextBox.Text);
			int num2 = Convert.ToInt32(m_Num2TextBox.Text);

			calc.BeginAdd(num1,num2,callback,null);
		}
		void OnMethodCompletion(IAsyncResult asyncResult)
		{
			SimpleCalculator calc = new SimpleCalculator();

			int result;
			result = calc.EndAdd(asyncResult);
			Trace.WriteLine("Operation returned " + result.ToString());
			m_ResultTextBox.Text = result.ToString();
		}
	}
}
