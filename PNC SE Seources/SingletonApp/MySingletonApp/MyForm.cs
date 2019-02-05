// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsEx;


namespace MySingletonApp
{
	public class MyForm : Form
	{
      Label m_Label;

		public MyForm()
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
         this.m_Label = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // m_Label
         // 
         this.m_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.m_Label.ForeColor = System.Drawing.SystemColors.HotTrack;
         this.m_Label.Location = new System.Drawing.Point(32, 48);
         this.m_Label.Name = "m_Label";
         this.m_Label.Size = new System.Drawing.Size(328, 120);
         this.m_Label.TabIndex = 0;
         this.m_Label.Text = "There is only one copy of this app running";
         // 
         // MyForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(352, 173);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_Label});
         this.Name = "MyForm";
         this.Text = "My Singleton App";
         this.ResumeLayout(false);

      }
		#endregion
      
      static void Main() 
		{
			SingletonApp.Run(new MyForm());
		}
	}
}
