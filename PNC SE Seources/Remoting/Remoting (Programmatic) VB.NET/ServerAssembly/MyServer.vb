' © 2001 IDesign Inc. All rights reserved 
'Questions? Comments? go to 
'http://www.idesign.net
Imports System
Imports System.Windows.Forms


Namespace RemoteServer

   Public Class MyServer
      Inherits MarshalByRefObject

      Public Sub New()
         Dim appName As String = AppDomain.CurrentDomain.FriendlyName
         MessageBox.Show("Constructor", appName)
         Counter = 0
      End Sub 'New
      Protected Counter As Integer

      Public Sub Count()
         Counter += 1
         Dim appName As String = AppDomain.CurrentDomain.FriendlyName
         MessageBox.Show("Counter value is " + Counter.ToString(), appName)
      End Sub
   End Class
End Namespace