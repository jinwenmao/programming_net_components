// ?2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;
using RemoteServer;

namespace Client
{
    //public class MySubscriber : MarshalByRefObject
    //{
    //    //[OneWay]//Makes remote events robust and asynchronous 
    //    public void OnNewNumber(int num)
    //    {
    //        string threadID = Thread.CurrentThread.ManagedThreadId.ToString();
    //        string appName = AppDomain.CurrentDomain.FriendlyName;
    //        MessageBox.Show("New Value: " + num.ToString(), appName + " Thread ID: " + threadID.ToString());
    //    }
    //}

   public class SubscriberForm : Form
   {
      Button m_FireButton;
      Button m_SubscribeButton;
      Button m_UnsubscribeButton;
      TextBox m_NumberValue;
      
      MyPublisher  m_Publisher;
      MySubscriber m_Subscriber; 

      public SubscriberForm()
      {
         InitializeComponent();

         m_Publisher  = new MyPublisher();
         m_Subscriber = new MySubscriber();

         Text = "Main Thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString();
      }
	
		#region Windows Form Designer generated code
      void InitializeComponent()
      {
         this.m_FireButton = new System.Windows.Forms.Button();
         this.m_SubscribeButton = new System.Windows.Forms.Button();
         this.m_UnsubscribeButton = new System.Windows.Forms.Button();
         this.m_NumberValue = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // m_FireButton
         // 
         this.m_FireButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.m_FireButton.Location = new System.Drawing.Point(128, 16);
         this.m_FireButton.Name = "m_FireButton";
         this.m_FireButton.Size = new System.Drawing.Size(80, 24);
         this.m_FireButton.TabIndex = 0;
         this.m_FireButton.Text = "Fire Event";
         this.m_FireButton.Click += new System.EventHandler(this.OnFire);
         // 
         // m_SubscribeButton
         // 
         this.m_SubscribeButton.Location = new System.Drawing.Point(16, 16);
         this.m_SubscribeButton.Name = "m_SubscribeButton";
         this.m_SubscribeButton.Size = new System.Drawing.Size(80, 24);
         this.m_SubscribeButton.TabIndex = 1;
         this.m_SubscribeButton.Text = "Subscribe";
         this.m_SubscribeButton.Click += new System.EventHandler(this.OnSubscribe);
         // 
         // m_UnsubscribeButton
         // 
         this.m_UnsubscribeButton.Enabled = false;
         this.m_UnsubscribeButton.Location = new System.Drawing.Point(16, 64);
         this.m_UnsubscribeButton.Name = "m_UnsubscribeButton";
         this.m_UnsubscribeButton.Size = new System.Drawing.Size(80, 24);
         this.m_UnsubscribeButton.TabIndex = 1;
         this.m_UnsubscribeButton.Text = "Unsubscribe";
         this.m_UnsubscribeButton.Click += new System.EventHandler(this.OnUnsubscribe);
         // 
         // m_NumberValue
         // 
         this.m_NumberValue.Location = new System.Drawing.Point(128, 64);
         this.m_NumberValue.Name = "m_NumberValue";
         this.m_NumberValue.Size = new System.Drawing.Size(80, 20);
         this.m_NumberValue.TabIndex = 2;
         this.m_NumberValue.Text = "3";
         // 
         // SubscriberForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(400, 221);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_NumberValue,
                                                                      this.m_SubscribeButton,
                                                                      this.m_FireButton,
                                                                      this.m_UnsubscribeButton});
         this.Name = "SubscriberForm";
         this.Text = "Remote Events Demo";
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         RemotingConfiguration.Configure("Client.exe.config",false);
         Application.Run(new SubscriberForm());
      } 
      private void OnFire(object sender,EventArgs e)
      {
         int num = Convert.ToInt32(m_NumberValue.Text);
         m_Publisher.FireEvent(num);
      }
      private void OnUnsubscribe(object sender,EventArgs e)
      {
         m_Publisher.NumberChanged -= m_Subscriber.OnNewNumber;
         m_SubscribeButton.Enabled = true;
         m_UnsubscribeButton.Enabled = false;;
      }
      private void OnSubscribe(object sender,EventArgs e)
      {
         m_Publisher.NumberChanged += m_Subscriber.OnNewNumber;
        // m_Publisher.NumberChanged += new GenericEventHandler<int>(m_Publisher_NumberChanged);
         m_SubscribeButton.Enabled = false;
         m_UnsubscribeButton.Enabled = true;;
      }

      void m_Publisher_NumberChanged(int t)
      {
          MessageBox.Show("ttttt");
          throw new NotImplementedException();
      }
   }
}

