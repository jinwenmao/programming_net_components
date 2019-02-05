// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

#endregion

namespace WinFormsEx
{
   public class LoginEventArgs : EventArgs
   {
      bool m_Authenticated;
      public LoginEventArgs(bool authenticated)
      {
         Authenticated = authenticated;
      }
      public bool Authenticated
      {
         get
         {
            return m_Authenticated;
         }
         internal set
         {
            m_Authenticated = value;
         }
      }
   }
}
