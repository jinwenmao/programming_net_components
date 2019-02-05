' © 2001 IDesign Inc. All rights reserved 
'Questions? Comments? go to 
'http://www.idesign.net
Imports System
Imports System.Windows.Forms
Imports System.Runtime.Remoting
Imports ServerAssembly.RemoteServer


Namespace Client
    _
   Public Class ClientForm
      Inherits Form
      Friend WithEvents m_NewButton As Button


      Public Sub New()
         InitializeComponent()
      End Sub 'New

      Private Sub InitializeComponent()

         Me.m_NewButton = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' m_NewButton
         ' 
         Me.m_NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
         Me.m_NewButton.Location = New System.Drawing.Point(72, 40)
         Me.m_NewButton.Name = "m_NewButton"
         Me.m_NewButton.Size = New System.Drawing.Size(112, 32)
         Me.m_NewButton.TabIndex = 0
         Me.m_NewButton.Text = "new"
         ' 
         ' ClientForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(248, 117)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.m_NewButton})
         Me.Name = "ClientForm"
         Me.Text = "Client of Remote Object"
         Me.ResumeLayout(False)
      End Sub

      Public Shared Sub Main()
         RemotingConfiguration.Configure("Client.exe.config")

         Application.Run(New ClientForm)
      End Sub 'Main

      Private Sub OnNew(ByVal sender As Object, ByVal e As EventArgs) Handles m_NewButton.Click
         Dim obj As MyServer
         obj = New MyServer
         obj.Count()
         obj.Count()
      End Sub
   End Class
End Namespace





