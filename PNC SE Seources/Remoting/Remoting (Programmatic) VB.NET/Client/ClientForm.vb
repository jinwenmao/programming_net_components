' © 2001 IDesign Inc. All rights reserved 
'Questions? Comments? go to 
'http://www.idesign.net
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports ServerAssembly.RemoteServer


Namespace Client
    _
   Public Class ClientForm
      Inherits Form
      Private groupBox1 As GroupBox
      Friend WithEvents radioHttp As RadioButton
      Friend WithEvents radioTCP As RadioButton
      Friend WithEvents NewButton As Button
      Friend WithEvents GetObjectButton As Button
      Friend WithEvents RegisterButton As Button
      Friend WithEvents groupActivation As GroupBox
      Friend WithEvents radioServer As RadioButton
      Friend WithEvents radioClient As RadioButton


      Public Sub New()
         InitializeComponent()
      End Sub 'New

      Private Sub InitializeComponent()
         Me.radioClient = New System.Windows.Forms.RadioButton()
         Me.radioServer = New System.Windows.Forms.RadioButton()
         Me.radioHttp = New System.Windows.Forms.RadioButton()
         Me.NewButton = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.radioTCP = New System.Windows.Forms.RadioButton()
         Me.GetObjectButton = New System.Windows.Forms.Button()
         Me.RegisterButton = New System.Windows.Forms.Button()
         Me.groupActivation = New System.Windows.Forms.GroupBox()
         Me.groupBox1.SuspendLayout()
         Me.groupActivation.SuspendLayout()
         Me.SuspendLayout()
         '
         'radioClient
         '
         Me.radioClient.Location = New System.Drawing.Point(8, 48)
         Me.radioClient.Name = "radioClient"
         Me.radioClient.TabIndex = 0
         Me.radioClient.Text = "Client Activated"
         '
         'radioServer
         '
         Me.radioServer.Checked = True
         Me.radioServer.Location = New System.Drawing.Point(8, 80)
         Me.radioServer.Name = "radioServer"
         Me.radioServer.Size = New System.Drawing.Size(112, 24)
         Me.radioServer.TabIndex = 1
         Me.radioServer.TabStop = True
         Me.radioServer.Text = "Server Activated"
         '
         'radioHttp
         '
         Me.radioHttp.Location = New System.Drawing.Point(8, 24)
         Me.radioHttp.Name = "radioHttp"
         Me.radioHttp.Size = New System.Drawing.Size(64, 24)
         Me.radioHttp.TabIndex = 0
         Me.radioHttp.Text = "http"
         '
         'NewButton
         '
         Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.NewButton.Location = New System.Drawing.Point(160, 152)
         Me.NewButton.Name = "NewButton"
         Me.NewButton.Size = New System.Drawing.Size(112, 32)
         Me.NewButton.TabIndex = 0
         Me.NewButton.Text = "new"
         '
         'groupBox1
         '
         Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioTCP, Me.radioHttp})
         Me.groupBox1.Location = New System.Drawing.Point(8, 16)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(128, 100)
         Me.groupBox1.TabIndex = 1
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Choose Channel"
         '
         'radioTCP
         '
         Me.radioTCP.Checked = True
         Me.radioTCP.Location = New System.Drawing.Point(8, 56)
         Me.radioTCP.Name = "radioTCP"
         Me.radioTCP.Size = New System.Drawing.Size(48, 24)
         Me.radioTCP.TabIndex = 1
         Me.radioTCP.TabStop = True
         Me.radioTCP.Text = "TCP"
         '
         'GetObjectButton
         '
         Me.GetObjectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.GetObjectButton.Location = New System.Drawing.Point(160, 192)
         Me.GetObjectButton.Name = "GetObjectButton"
         Me.GetObjectButton.Size = New System.Drawing.Size(112, 32)
         Me.GetObjectButton.TabIndex = 0
         Me.GetObjectButton.Text = "GetObject()"
         '
         'RegisterButton
         '
         Me.RegisterButton.Location = New System.Drawing.Point(160, 24)
         Me.RegisterButton.Name = "RegisterButton"
         Me.RegisterButton.Size = New System.Drawing.Size(112, 32)
         Me.RegisterButton.TabIndex = 1
         Me.RegisterButton.Text = "Register"
         '
         'groupActivation
         '
         Me.groupActivation.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioServer, Me.radioClient})
         Me.groupActivation.Location = New System.Drawing.Point(8, 144)
         Me.groupActivation.Name = "groupActivation"
         Me.groupActivation.Size = New System.Drawing.Size(128, 120)
         Me.groupActivation.TabIndex = 1
         Me.groupActivation.TabStop = False
         Me.groupActivation.Text = "Choose Activation Mode"
         '
         'ClientForm
         '
         Me.ClientSize = New System.Drawing.Size(296, 285)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.RegisterButton, Me.groupBox1, Me.GetObjectButton, Me.groupActivation, Me.NewButton})
         Me.Name = "ClientForm"
         Me.Text = "Client of Remote Object"
         Me.groupBox1.ResumeLayout(False)
         Me.groupActivation.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub 'InitializeComponent

      Public Shared Sub Main()
         'No port number as parameter. Input it in activation URI
         Dim tcpChannel As IChannel = New TcpChannel()
         'Done only once per app domain:
         ChannelServices.RegisterChannel(tcpChannel, False)

         Dim httpChannel As IChannel = New HttpChannel()
         'Done only once per app domain:
         ChannelServices.RegisterChannel(httpChannel, False)

         Application.Run(New ClientForm())
      End Sub 'Main


      Private Function GetActivationURL() As String
         If radioTCP.Checked Then
            If radioServer.Checked Then
               'Server activation over TCP. Note object URI
               Return "tcp://localhost:8005/CounterServer"
            Else
               'Client activation over tcp
               Return "tcp://localhost:8005"
            End If
            'http channel 
         Else
            If radioServer.Checked Then
               'Server activation over http. Note object URI
               Return "http://localhost:8006/CounterServer"
            Else
               'Client activation over http
               Return "http://localhost:8006"
            End If
         End If
      End Function 'GetActivationURL


      Private Sub OnRegister(ByVal sender As Object, ByVal e As EventArgs) Handles RegisterButton.Click
         Dim serverType As Type = GetType(ServerAssembly.RemoteServer.MyServer)
         Dim url As String = GetActivationURL()

         If radioServer.Checked Then
            RemotingConfiguration.RegisterWellKnownClientType(serverType, url)

            'Enable GetObject() if in server mode
            GetObjectButton.Enabled = True
            'Client activation mode
         Else
            'Register just once:
            RemotingConfiguration.RegisterActivatedClientType(serverType, url)
         End If
         'Disable registration, to disable calling it more than once
         RegisterButton.Enabled = False

         'Disable activation selection
         groupActivation.Enabled = False

         'Enable new and CreateInstance()
         NewButton.Enabled = True
      End Sub 'OnRegister


      Private Sub OnActivationChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioClient.CheckedChanged
         GetObjectButton.Enabled = radioServer.Checked
      End Sub 'OnActivationChanged


      Private Sub OnNew(ByVal sender As Object, ByVal e As EventArgs) Handles NewButton.Click
         Dim obj As MyServer
         obj = New MyServer()
         obj.Count()
         obj.Count()
      End Sub 'OnNew

      Private Sub OnCreateInstance(ByVal sender As System.Object, ByVal e As System.EventArgs)
         Dim handle As ObjectHandle
         handle = Activator.CreateInstance("ServerAssembly", "RemoteServer.MyServer")
         Dim obj As MyServer = CType(handle.Unwrap(), MyServer)
         obj.Count()
         obj.Count()
      End Sub 'OnCreateInstance

      Private Sub OnGetObject(ByVal sender As Object, ByVal e As EventArgs) Handles GetObjectButton.Click
         Dim url As String = GetActivationURL()
         'url must have obejct URI it it 
         Dim serverType As Type = GetType(ServerAssembly.RemoteServer.MyServer)
         Dim obj As MyServer
         obj = CType(Activator.GetObject(serverType, url), MyServer)
         obj.Count()
         obj.Count()
      End Sub 'OnGetObject
   End Class 'ClientForm
End Namespace 'Client

