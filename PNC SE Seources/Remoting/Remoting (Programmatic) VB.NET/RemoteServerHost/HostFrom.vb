' © 2001 IDesign Inc. All rights reserved 
'Questions? Comments? go to 
'http://www.idesign.net
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports ServerAssembly.RemoteServer

Namespace RemoteServerHost
    _
   Public Class ServerHostDialog
      Inherits Form
      Friend WithEvents RegisterButton As Button
      Friend WithEvents radioSingleton As RadioButton
      Friend WithEvents radioSingleCall As RadioButton
      Private groupActivationMode As GroupBox



      Public Sub New()
         InitializeComponent()
      End Sub 'New

      Private Sub InitializeComponent()
         Me.groupActivationMode = New System.Windows.Forms.GroupBox()
         Me.radioSingleton = New System.Windows.Forms.RadioButton()
         Me.radioSingleCall = New System.Windows.Forms.RadioButton()
         Me.RegisterButton = New System.Windows.Forms.Button()
         Me.groupActivationMode.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupActivationMode
         ' 
         Me.groupActivationMode.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioSingleton, Me.radioSingleCall})
         Me.groupActivationMode.Location = New System.Drawing.Point(8, 24)
         Me.groupActivationMode.Name = "groupActivationMode"
         Me.groupActivationMode.Size = New System.Drawing.Size(128, 120)
         Me.groupActivationMode.TabIndex = 1
         Me.groupActivationMode.TabStop = False
         Me.groupActivationMode.Text = "Choose Server Activation Mode"
         ' 
         ' radioSingleton
         ' 
         Me.radioSingleton.Checked = True
         Me.radioSingleton.Location = New System.Drawing.Point(8, 80)
         Me.radioSingleton.Name = "radioSingleton"
         Me.radioSingleton.Size = New System.Drawing.Size(112, 24)
         Me.radioSingleton.TabIndex = 1
         Me.radioSingleton.TabStop = True
         Me.radioSingleton.Text = "Singleton"
         ' 
         ' radioSingleCall
         ' 
         Me.radioSingleCall.Location = New System.Drawing.Point(8, 48)
         Me.radioSingleCall.Name = "radioSingleCall"
         Me.radioSingleCall.TabIndex = 0
         Me.radioSingleCall.Text = "Single Call"
         ' 
         ' RegisterButton
         ' 
         Me.RegisterButton.Location = New System.Drawing.Point(168, 32)
         Me.RegisterButton.Name = "RegisterButton"
         Me.RegisterButton.Size = New System.Drawing.Size(112, 32)
         Me.RegisterButton.TabIndex = 2
         Me.RegisterButton.Text = "Register Objects"
         ' 
         ' ServerHostDialog
         ' 
         Me.ClientSize = New System.Drawing.Size(296, 189)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.RegisterButton, Me.groupActivationMode})
         Me.Name = "ServerHostDialog"
         Me.Text = "Server Host"
         Me.groupActivationMode.ResumeLayout(False)
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      Public Shared Sub Main()
         'Must register at least one channel
         'Registering TCP channel
         Dim tcpChannel As TcpChannel = New TcpChannel(8005)
         ChannelServices.RegisterChannel(tcpChannel,False)

         'Registering http channel
         Dim httpChannel As HttpChannel = New HttpChannel(8006)
         ChannelServices.RegisterChannel(httpChannel,False)

         Application.Run(New ServerHostDialog())

         'Does not have to, but cleaner:
         ChannelServices.UnregisterChannel(tcpChannel)
         ChannelServices.UnregisterChannel(httpChannel)
      End Sub 'Main


      Private Sub OnRegister(ByVal sender As Object, ByVal e As EventArgs) Handles RegisterButton.Click
         Dim serverType As Type
         serverType = GetType(ServerAssembly.RemoteServer.MyServer)

         'Allow client activation:
         RemotingConfiguration.RegisterActivatedServiceType(serverType)

         'Server activation: choose mode
         If radioSingleCall.Checked Then
            'Allow Server activation, single call mode:
            RemotingConfiguration.RegisterWellKnownServiceType(serverType, "CounterServer", WellKnownObjectMode.SingleCall)
         Else
            'Allow Server activation, singleton mode:
            RemotingConfiguration.RegisterWellKnownServiceType(serverType, "CounterServer", WellKnownObjectMode.Singleton)
         End If

         'Can only register once
         groupActivationMode.Enabled = False
         RegisterButton.Enabled = False
      End Sub 'OnRegister
   End Class 'ServerHostDialog
End Namespace 'RemoteServerHost