// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sinking_Interfaces
{
	public class Publisher : Form
	{
		private Button Publish;
		public Publisher()
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
         this.Publish = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // Publish
         // 
         this.Publish.Location = new System.Drawing.Point(72, 88);
         this.Publish.Name = "Publish";
         this.Publish.Size = new System.Drawing.Size(112, 32);
         this.Publish.TabIndex = 0;
         this.Publish.Text = "Publish Events";
         this.Publish.Click += new System.EventHandler(this.OnPublish);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.Publish});
         this.Name = "Form1";
         this.Text = "Sinking Interfaces Demo";
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Publisher());
		}

		void OnPublish(object sender,EventArgs e)
		{
			MyPublisher publisher = new MyPublisher();
			IMyEvents  subscriber   = (IMyEvents)new MySubscriber();

			publisher.Subscribe(subscriber,EventType.OnEvent1|EventType.OnEvent2);
			publisher.SomeMethod(1);
			publisher.Unsubscribe(subscriber,EventType.OnEvent1);
			publisher.SomeMethod(2);
			publisher.Unsubscribe(subscriber,EventType.OnEvent2);
			publisher.SomeMethod(3);
			publisher.Subscribe(subscriber,EventType.OnAllEvents);
			publisher.SomeMethod(4);
			publisher.Unsubscribe(subscriber,EventType.OnAllEvents);
		}
	}
}
