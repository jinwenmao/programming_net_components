// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace ContextAttributeDemo
{
	public class ContextAttributeDemoClient : Form
	{
		private Button Exp1;
		private Button Exp2;
		private Button Exp3;
		private TextBox m_ContextTrace;
		private Label m_outputLabel;
		private Label m_ExpSelection;
		private PictureBox m_ExpImage;

		public ContextAttributeDemoClient()
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContextAttributeDemoClient));
         this.m_ExpSelection = new System.Windows.Forms.Label();
         this.m_outputLabel = new System.Windows.Forms.Label();
         this.m_ExpImage = new System.Windows.Forms.PictureBox();
         this.Exp2 = new System.Windows.Forms.Button();
         this.Exp3 = new System.Windows.Forms.Button();
         this.m_ContextTrace = new System.Windows.Forms.TextBox();
         this.Exp1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // m_ExpSelection
         // 
         this.m_ExpSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.m_ExpSelection.ForeColor = System.Drawing.SystemColors.ActiveCaption;
         this.m_ExpSelection.Location = new System.Drawing.Point(16, 8);
         this.m_ExpSelection.Name = "m_ExpSelection";
         this.m_ExpSelection.Size = new System.Drawing.Size(288, 24);
         this.m_ExpSelection.TabIndex = 2;
         this.m_ExpSelection.Text = "Please Select Experiment:";
         // 
         // m_outputLabel
         // 
         this.m_outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.m_outputLabel.Location = new System.Drawing.Point(136, 56);
         this.m_outputLabel.Name = "m_outputLabel";
         this.m_outputLabel.Size = new System.Drawing.Size(208, 24);
         this.m_outputLabel.TabIndex = 2;
         this.m_outputLabel.Text = "Context Trace Output:";
         // 
         // m_ExpImage
         // 
         this.m_ExpImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.m_ExpImage.Image = ((System.Drawing.Bitmap)(resources.GetObject("m_ExpImage.Image")));
         this.m_ExpImage.Location = new System.Drawing.Point(136, 216);
         this.m_ExpImage.Name = "m_ExpImage";
         this.m_ExpImage.Size = new System.Drawing.Size(364, 388);
         this.m_ExpImage.TabIndex = 3;
         this.m_ExpImage.TabStop = false;
         // 
         // Exp2
         // 
         this.Exp2.Location = new System.Drawing.Point(16, 128);
         this.Exp2.Name = "Exp2";
         this.Exp2.Size = new System.Drawing.Size(104, 23);
         this.Exp2.TabIndex = 0;
         this.Exp2.Text = "Experiment 2";
         this.Exp2.Click += new System.EventHandler(this.OnExp2);
         // 
         // Exp3
         // 
         this.Exp3.Location = new System.Drawing.Point(16, 176);
         this.Exp3.Name = "Exp3";
         this.Exp3.Size = new System.Drawing.Size(104, 23);
         this.Exp3.TabIndex = 0;
         this.Exp3.Text = "Experiment 3";
         this.Exp3.Click += new System.EventHandler(this.OnExp3);
         // 
         // m_ContextTrace
         // 
         this.m_ContextTrace.AcceptsReturn = true;
         this.m_ContextTrace.Location = new System.Drawing.Point(136, 80);
         this.m_ContextTrace.Multiline = true;
         this.m_ContextTrace.Name = "m_ContextTrace";
         this.m_ContextTrace.Size = new System.Drawing.Size(360, 120);
         this.m_ContextTrace.TabIndex = 1;
         this.m_ContextTrace.Text = "";
         // 
         // Exp1
         // 
         this.Exp1.Location = new System.Drawing.Point(16, 80);
         this.Exp1.Name = "Exp1";
         this.Exp1.Size = new System.Drawing.Size(104, 23);
         this.Exp1.TabIndex = 0;
         this.Exp1.Text = "Experiment 1";
         this.Exp1.Click += new System.EventHandler(this.OnExp1);
         // 
         // ContextAttributeDemoClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(536, 613);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_ExpImage,
                                                                      this.m_outputLabel,
                                                                      this.m_ContextTrace,
                                                                      this.Exp1,
                                                                      this.Exp2,
                                                                      this.Exp3,
                                                                      this.m_ExpSelection});
         this.Name = "ContextAttributeDemoClient";
         this.Text = "Context Demo";
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ContextAttributeDemoClient());
		}

		private void OnExp1(object sender,EventArgs e)
		{
			UpdateForm(1);
			string trace;			
			int contextID = Thread.CurrentContext.ContextID;
			trace =  "Default context is " + contextID.ToString();
			trace += System.Environment.NewLine;

			A a = new A();
			trace += a.TraceContext();
			trace += a.CreateObjects();

			m_ContextTrace.Text = trace;
		}

		private void OnExp2(object sender,EventArgs e)
		{
			UpdateForm(2);
			int contextID = Thread.CurrentContext.ContextID;
			string trace;
			
			trace = "Creating context is " + contextID.ToString();
			trace += System.Environment.NewLine;
			
			C c = new C();
			trace += c.TraceContext();
			trace += c.CreateObjects();

			m_ContextTrace.Text = trace;
		}

		private void OnExp3(object sender,EventArgs e)
		{
			UpdateForm(3);
			string trace;
			
			C c = new C();
			A a = new A();

			trace = c.TraceContext();
			trace += c.TraceA(a);
			B b = new B();
			trace += c.TraceB(b);

			D d = new D();
			trace += c.TraceD(d);
	
			m_ContextTrace.Text = trace;
		}
		private void UpdateForm(int expNumber)
		{
			m_outputLabel.Text = "Experiment # " + expNumber.ToString()+ "output:";

			string fileName = @"..\..\Exp";
			switch(expNumber)
			{
				case 1:
					fileName +="1.bmp";
				break;
				case 2:
					fileName +="2.bmp";
				break;
				case 3:
					fileName +="3.bmp";
				break;
				default:
					Debug.Assert(false);
				break;
			}
			Bitmap bmp = new Bitmap(fileName);
			m_ExpImage.Image = bmp;
		}
	}
}
