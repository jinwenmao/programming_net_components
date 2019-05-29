// ?2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;

using RemoteServer;


namespace RemoteServerHost
{
	public class ServerHostDialog : Form
	{
		Button m_RegisterButton;
		RadioButton m_SingletonRadio;
		RadioButton m_SingleCallRadio;
		GroupBox m_ActivationModeGroup;


		public ServerHostDialog()
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
         this.m_ActivationModeGroup = new System.Windows.Forms.GroupBox();
         this.m_SingletonRadio = new System.Windows.Forms.RadioButton();
         this.m_SingleCallRadio = new System.Windows.Forms.RadioButton();
         this.m_RegisterButton = new System.Windows.Forms.Button();
         this.m_ActivationModeGroup.SuspendLayout();
         this.SuspendLayout();
         // 
         // m_ActivationModeGroup
         // 
         this.m_ActivationModeGroup.Controls.Add(this.m_SingletonRadio);
         this.m_ActivationModeGroup.Controls.Add(this.m_SingleCallRadio);
         this.m_ActivationModeGroup.Location = new System.Drawing.Point(8, 24);
         this.m_ActivationModeGroup.Name = "m_ActivationModeGroup";
         this.m_ActivationModeGroup.Size = new System.Drawing.Size(128, 120);
         this.m_ActivationModeGroup.TabIndex = 1;
         this.m_ActivationModeGroup.TabStop = false;
         this.m_ActivationModeGroup.Text = "Choose Server Activation Mode";
         // 
         // m_SingletonRadio
         // 
         this.m_SingletonRadio.Checked = true;
         this.m_SingletonRadio.Location = new System.Drawing.Point(8, 80);
         this.m_SingletonRadio.Name = "m_SingletonRadio";
         this.m_SingletonRadio.Size = new System.Drawing.Size(112, 24);
         this.m_SingletonRadio.TabIndex = 1;
         this.m_SingletonRadio.TabStop = true;
         this.m_SingletonRadio.Text = "Singleton";
         // 
         // m_SingleCallRadio
         // 
         this.m_SingleCallRadio.Location = new System.Drawing.Point(8, 48);
         this.m_SingleCallRadio.Name = "m_SingleCallRadio";
         this.m_SingleCallRadio.TabIndex = 0;
         this.m_SingleCallRadio.Text = "Single Call";
         // 
         // m_RegisterButton
         // 
         this.m_RegisterButton.Location = new System.Drawing.Point(168, 32);
         this.m_RegisterButton.Name = "m_RegisterButton";
         this.m_RegisterButton.Size = new System.Drawing.Size(112, 32);
         this.m_RegisterButton.TabIndex = 2;
         this.m_RegisterButton.Text = "Register Type";
         this.m_RegisterButton.Click += new System.EventHandler(this.OnRegister);
         // 
         // ServerHostDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(296, 189);
         this.Controls.Add(this.m_RegisterButton);
         this.Controls.Add(this.m_ActivationModeGroup);
         this.Name = "ServerHostDialog";
         this.Text = "Server Host";
         this.m_ActivationModeGroup.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main() 
		{
			//Must register at least one channel

			//Registering TCP channel
         IChannel tcpChannel = new TcpChannel(8005);
         ChannelServices.RegisterChannel(tcpChannel,false);
						
         //Registering http channel
			IChannel httpChannel = new HttpChannel(8006);
         ChannelServices.RegisterChannel(httpChannel,false);

         //Registering IPC channel
         IChannel ipcChannel = new IpcChannel("MyHost");
         ChannelServices.RegisterChannel(ipcChannel,false);

         Application.Run(new ServerHostDialog());

         //Does not have to, but cleaner:
			ChannelServices.UnregisterChannel(tcpChannel);
         ChannelServices.UnregisterChannel(httpChannel);
         ChannelServices.UnregisterChannel(ipcChannel);
      }

      void OnRegister(object sender,EventArgs e)
		{
			Type serverType;
			serverType = typeof(MyServer);

			//Allow client activation:
			RemotingConfiguration.RegisterActivatedServiceType(serverType);

			//Server activation: choose mode
			if(m_SingleCallRadio.Checked)
			{
				//Allow Server activation, single call mode:
            RemotingConfiguration.RegisterWellKnownServiceType(serverType,"CounterServer",WellKnownObjectMode.SingleCall);
         }
			else
			{
				//Allow Server activation, singleton mode:
            RemotingConfiguration.RegisterWellKnownServiceType(serverType,"CounterServer",WellKnownObjectMode.Singleton);
         }

    		//Can only register once
			m_ActivationModeGroup.Enabled = false;
			m_RegisterButton.Enabled = false;
		}
	}
}
