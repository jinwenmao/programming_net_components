// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using MyNamespace;

namespace MyApp
{
	public class AppDomainDemo : Form
	{
      private Button m_NewButton;

		public AppDomainDemo()
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
         this.m_NewButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // m_NewButton
         // 
         this.m_NewButton.Location = new System.Drawing.Point(104, 72);
         this.m_NewButton.Name = "m_NewButton";
         this.m_NewButton.Size = new System.Drawing.Size(96, 23);
         this.m_NewButton.TabIndex = 0;
         this.m_NewButton.Text = "New Object";
         this.m_NewButton.Click += new System.EventHandler(this.OnNew);
         // 
         // AppDomainDemo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_NewButton});
         this.Name = "AppDomainDemo";
         this.Text = "New object in current App Domain";
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new AppDomainDemo());
		}

      private void OnNew(object sender,EventArgs e)
      {
         AppDomain currentAppDomain;
         currentAppDomain = AppDomain.CurrentDomain;
         Trace.WriteLine(currentAppDomain.FriendlyName);

         MyClass obj;
         obj = (MyClass)currentAppDomain.CreateInstanceAndUnwrap("MyClassLibrary","MyNamespace.MyClass");
         obj.TraceAppDomain();
      }
	}
}
