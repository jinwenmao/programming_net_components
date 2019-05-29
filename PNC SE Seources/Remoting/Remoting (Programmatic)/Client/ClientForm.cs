// ?2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using RemoteServer;

namespace Client
{
   public class ClientForm : Form
   {
      GroupBox m_ChannelsGroup;
      RadioButton m_HttpRadio;
      RadioButton m_TcpRadio;
      RadioButton m_IpcRadio;
      RadioButton m_ClientRadio;
      RadioButton m_ServerRadio;
      Button m_CreateInstanceButton;
      Button m_NewButton;
      Button m_GetObjectButton;
      Button m_RegisterButton;
      GroupBox m_ActivationGroup;

      public ClientForm()
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
         this.m_ClientRadio = new System.Windows.Forms.RadioButton();
         this.m_ServerRadio = new System.Windows.Forms.RadioButton();
         this.m_HttpRadio = new System.Windows.Forms.RadioButton();
         this.m_NewButton = new System.Windows.Forms.Button();
         this.m_ChannelsGroup = new System.Windows.Forms.GroupBox();
         this.m_TcpRadio = new System.Windows.Forms.RadioButton();
         this.m_GetObjectButton = new System.Windows.Forms.Button();
         this.m_CreateInstanceButton = new System.Windows.Forms.Button();
         this.m_RegisterButton = new System.Windows.Forms.Button();
         this.m_ActivationGroup = new System.Windows.Forms.GroupBox();
         this.m_IpcRadio = new System.Windows.Forms.RadioButton();
         this.m_ChannelsGroup.SuspendLayout();
         this.m_ActivationGroup.SuspendLayout();
         this.SuspendLayout();
// 
// m_ClientRadio
// 
         this.m_ClientRadio.Location = new System.Drawing.Point(8,48);
         this.m_ClientRadio.Name = "m_ClientRadio";
         this.m_ClientRadio.TabIndex = 0;
         this.m_ClientRadio.Text = "Client Activated";
         this.m_ClientRadio.CheckedChanged += new System.EventHandler(this.OnActivationChanged);
// 
// m_ServerRadio
// 
         this.m_ServerRadio.Checked = true;
         this.m_ServerRadio.Location = new System.Drawing.Point(8,80);
         this.m_ServerRadio.Name = "m_ServerRadio";
         this.m_ServerRadio.Size = new System.Drawing.Size(112,24);
         this.m_ServerRadio.TabIndex = 1;
         this.m_ServerRadio.TabStop = true;
         this.m_ServerRadio.Text = "Server Activated";
// 
// m_HttpRadio
// 
         this.m_HttpRadio.Location = new System.Drawing.Point(8,24);
         this.m_HttpRadio.Name = "m_HttpRadio";
         this.m_HttpRadio.Size = new System.Drawing.Size(64,24);
         this.m_HttpRadio.TabIndex = 0;
         this.m_HttpRadio.Text = "http";
// 
// m_NewButton
// 
         this.m_NewButton.Font = new System.Drawing.Font("Microsoft Sans Serif",8.5F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
         this.m_NewButton.Location = new System.Drawing.Point(160,192);
         this.m_NewButton.Name = "m_NewButton";
         this.m_NewButton.Size = new System.Drawing.Size(112,32);
         this.m_NewButton.TabIndex = 0;
         this.m_NewButton.Text = "new";
         this.m_NewButton.Click += new System.EventHandler(this.OnNew);
// 
// m_ChannelsGroup
// 
         this.m_ChannelsGroup.Controls.Add(this.m_IpcRadio);
         this.m_ChannelsGroup.Controls.Add(this.m_TcpRadio);
         this.m_ChannelsGroup.Controls.Add(this.m_HttpRadio);
         this.m_ChannelsGroup.Location = new System.Drawing.Point(8,16);
         this.m_ChannelsGroup.Name = "m_ChannelsGroup";
         this.m_ChannelsGroup.Size = new System.Drawing.Size(128,121);
         this.m_ChannelsGroup.TabIndex = 1;
         this.m_ChannelsGroup.TabStop = false;
         this.m_ChannelsGroup.Text = "Choose Channel";
// 
// m_TcpRadio
// 
         this.m_TcpRadio.Checked = true;
         this.m_TcpRadio.Location = new System.Drawing.Point(8,56);
         this.m_TcpRadio.Name = "m_TcpRadio";
         this.m_TcpRadio.Size = new System.Drawing.Size(48,24);
         this.m_TcpRadio.TabIndex = 1;
         this.m_TcpRadio.TabStop = true;
         this.m_TcpRadio.Text = "TCP";
// 
// m_GetObjectButton
// 
         this.m_GetObjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif",8.5F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
         this.m_GetObjectButton.Location = new System.Drawing.Point(160,232);
         this.m_GetObjectButton.Name = "m_GetObjectButton";
         this.m_GetObjectButton.Size = new System.Drawing.Size(112,32);
         this.m_GetObjectButton.TabIndex = 0;
         this.m_GetObjectButton.Text = "GetObject()";
         this.m_GetObjectButton.Click += new System.EventHandler(this.OnGetObject);
// 
// m_CreateInstanceButton
// 
         this.m_CreateInstanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif",8.5F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
         this.m_CreateInstanceButton.Location = new System.Drawing.Point(160,272);
         this.m_CreateInstanceButton.Name = "m_CreateInstanceButton";
         this.m_CreateInstanceButton.Size = new System.Drawing.Size(112,32);
         this.m_CreateInstanceButton.TabIndex = 0;
         this.m_CreateInstanceButton.Text = "CreateInstance()";
         this.m_CreateInstanceButton.Click += new System.EventHandler(this.OnCreateInstance);
// 
// m_RegisterButton
// 
         this.m_RegisterButton.Location = new System.Drawing.Point(160,24);
         this.m_RegisterButton.Name = "m_RegisterButton";
         this.m_RegisterButton.Size = new System.Drawing.Size(112,32);
         this.m_RegisterButton.TabIndex = 1;
         this.m_RegisterButton.Text = "Register";
         this.m_RegisterButton.Click += new System.EventHandler(this.OnRegister);
// 
// m_ActivationGroup
// 
         this.m_ActivationGroup.Controls.Add(this.m_ServerRadio);
         this.m_ActivationGroup.Controls.Add(this.m_ClientRadio);
         this.m_ActivationGroup.Location = new System.Drawing.Point(8,184);
         this.m_ActivationGroup.Name = "m_ActivationGroup";
         this.m_ActivationGroup.Size = new System.Drawing.Size(128,120);
         this.m_ActivationGroup.TabIndex = 1;
         this.m_ActivationGroup.TabStop = false;
         this.m_ActivationGroup.Text = "Choose Activation Mode";
// 
// m_IpcRadio
// 
         this.m_IpcRadio.Location = new System.Drawing.Point(8,80);
         this.m_IpcRadio.Name = "m_IpcRadio";
         this.m_IpcRadio.Size = new System.Drawing.Size(48,35);
         this.m_IpcRadio.TabIndex = 2;
         this.m_IpcRadio.Text = "IPC";
// 
// ClientForm
// 
         
         this.ClientSize = new System.Drawing.Size(296,325);
         this.Controls.Add(this.m_RegisterButton);
         this.Controls.Add(this.m_ChannelsGroup);
         this.Controls.Add(this.m_GetObjectButton);
         this.Controls.Add(this.m_ActivationGroup);
         this.Controls.Add(this.m_CreateInstanceButton);
         this.Controls.Add(this.m_NewButton);
         this.Name = "ClientForm";
         this.Text = "Client of Remote Object";
         this.m_ChannelsGroup.ResumeLayout(false);
         this.m_ActivationGroup.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      [STAThread]
      static void Main()
      {
         Application.Run(new ClientForm());
      }

      string GetActivationURL()
      {
         if(m_TcpRadio.Checked)
         {
            if(m_ServerRadio.Checked)
            {
               //Server activation over TCP. Note object URI
              // return "tcp://localhost:8005/CounterServer";
               return "tcp://10.10.10.20:8005/CounterServer";
            }
            else
            {
               //Client activation over tcp
               //return "tcp://localhost:8005";
                return "tcp://10.10.10.20:8005";
            }
         }
         if(m_HttpRadio.Checked)//http channel 
         {
            if(m_ServerRadio.Checked)
            {
               //Server activation over http. Note object URI
              ///// //return "http://localhost:8006/CounterServer";
                return "http://10.10.10.20:8006/CounterServer";
            }
            else
            {
               //Client activation over http
              ////// return "http://localhost:8006";
                return "http://10.10.10.20:8006";
            }
         }
         else//IPC channel 
         {
            if(m_ServerRadio.Checked)
            {
               //Server activation. Note object URI
               return "ipc://MyHost/CounterServer";
            }
            else
            {
               //Client activation
               return "ipc://MyHost";
            }
         }

      }
      void OnRegister(object sender,EventArgs e)
      {
         Type serverType = typeof(MyServer);
         string url = GetActivationURL();

         if(m_ServerRadio.Checked)
         {
            RemotingConfiguration.RegisterWellKnownClientType(serverType,url);

            //Enable GetObject() if in server mode
            m_GetObjectButton.Enabled = true;
         }
         else //Client activation mode
         {
            //Register just once:
            RemotingConfiguration.RegisterActivatedClientType(serverType,url);
         }
         //Disable registration, to disable calling it more than once
         m_RegisterButton.Enabled = false;

         //Disable activation selection
         m_ActivationGroup.Enabled = false;
      }

      void OnActivationChanged(object sender,EventArgs e)
      {
         m_GetObjectButton.Enabled = m_ServerRadio.Checked;
      }

      void OnNew(object sender,EventArgs e)
      {
         MyServer obj;
         obj = new MyServer();
         obj.Count();
         obj.Count();
      }
      void OnCreateInstance(object sender,EventArgs e)
      {
         ObjectHandle handle;
         handle = Activator.CreateInstance("ServerAssembly","RemoteServer.MyServer");
         MyServer obj = (MyServer)handle.Unwrap();
         obj.Count();
         obj.Count();
      }
      void OnGetObject(object sender,EventArgs e)
      {
         string url = GetActivationURL();
         //URL must have obejct URI it it 

         Type serverType = typeof(MyServer);
         MyServer obj;
         obj = (MyServer)Activator.GetObject(serverType,url);
         obj.Count();
         obj.Count();
      }
   }
}


