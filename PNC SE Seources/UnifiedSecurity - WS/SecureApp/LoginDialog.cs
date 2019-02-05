// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using WinFormsEx;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace SecureApp
{
   public partial class LoginDialog : Form
   {
      bool m_Authenticated;
      public LoginDialog()
      {
         Authenticated = false;
         InitializeComponent();
      }     
      public bool Authenticated
      {
         get
         {
            return m_Authenticated;
         }
         protected set
         {
            m_Authenticated = value;
         }
      }
      void OnLogin(LoginControl sender,LoginEventArgs args)
      {
         bool successful = args.Authenticated;
         if(successful == false)
         {
            MessageBox.Show("Invalid user name or password. Please try again","Log In",MessageBoxButtons.OK,MessageBoxIcon.Hand);
         }
         else
         {
            Authenticated = true;
            Close();
         }
      }
      static public void Logout()
      {
         LoginControl.Logout();
      }
      static public bool IsLoggedIn
      {
         get
         {
            return LoginControl.IsLoggedIn;
         }
      }
   }
}