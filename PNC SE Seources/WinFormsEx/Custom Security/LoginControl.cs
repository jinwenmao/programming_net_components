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
   using LoginEventHandler = GenericEventHandler<LoginControl,LoginEventArgs>;

   [DefaultEvent("LoginEvent")]
   [ToolboxBitmap(typeof(LoginControl),"LoginControl.bmp")]
   public abstract partial class LoginControl : UserControl
   {
      string m_ApplicationName = String.Empty;
      bool m_CacheRoles = false;
      public event LoginEventHandler LoginEvent;

      public LoginControl() 
      {
         InitializeComponent();
      }

      [Category("Credentials")]
      public bool CacheRoles
      {
         get
         {
            return m_CacheRoles;
         }
         set
         {
            m_CacheRoles = value;
         }
      }
      [Category("Credentials")]
      public string ApplicationName
      {
         get
         {
            return m_ApplicationName;
         }

         set
         {
            m_ApplicationName = value;
         }
      }

      string GetAppName()
      {
         if(ApplicationName != String.Empty)
         {
            return ApplicationName;
         }
         Assembly clientAssembly = Assembly.GetEntryAssembly();
         AssemblyName assemblyName = clientAssembly.GetName();
         return assemblyName.Name;
      }
      static public void Logout()
      {
         CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
         if(customPrincipal != null)
         {
            customPrincipal.Detach();
         }
      }
      static public bool IsLoggedIn
      {
         get
         {
            return Thread.CurrentPrincipal is CustomPrincipal;
         }
      }

      protected virtual void OnLogin(object sender,EventArgs e)
      {
         string userName = m_UserNameBox.Text;
         string password = m_PasswordBox.Text;

         if(userName == String.Empty)
         {
            m_ErrorProvider.SetError(m_UserNameBox,"Please Enter User Name");
            return;
         }
         else
         {
            m_ErrorProvider.SetError(m_UserNameBox,String.Empty);
         }
         if(password == String.Empty)
         {
            m_ErrorProvider.SetError(m_PasswordBox,"Please Enter Password");
            return;
         }
         else
         {
            m_ErrorProvider.SetError(m_PasswordBox,String.Empty);
         }
         string applicationName = GetAppName();     
         IUserManager userManager = GetUserManager();

         bool authenticated = userManager.Authenticate(applicationName,userName,password);
         if(authenticated)
         {
            IIdentity identity = new GenericIdentity(userName);
            CustomPrincipal.Attach(identity,applicationName,userManager,CacheRoles);
         }
         LoginEventArgs loginEventArgs = new LoginEventArgs(authenticated);
         EventsHelper.Fire(LoginEvent,this,loginEventArgs);
      }
      protected abstract IUserManager GetUserManager();
   }
}
