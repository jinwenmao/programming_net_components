' © 2001 IDesign Inc. All rights reserved 
'Questions? Comments? go to 
'http://www.idesign.net
Imports System
Imports System.Windows.Forms
Imports System.Runtime.Remoting
Imports ServerAssembly.RemoteServer


Namespace RemoteServerHost
    _
   Public Class ServerHostDialog
      Inherits Form

      Public Sub New()
         InitializeComponent()
      End Sub 'New

      Private Sub InitializeComponent()
         ' 
         ' ServerHostDialog
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(312, 197)
         Me.Name = "ServerHostDialog"
         Me.Text = "Server Host"
      End Sub 'InitializeComponent

      Public Shared Sub Main() '
         RemotingConfiguration.Configure("RemoteServerHost.exe.config")

         Application.Run(New ServerHostDialog())
      End Sub
   End Class
End Namespace