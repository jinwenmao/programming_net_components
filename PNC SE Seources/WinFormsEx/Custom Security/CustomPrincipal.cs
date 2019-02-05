// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Threading;
using System.Diagnostics;
using System.Security.Principal;

namespace WinFormsEx
{
   internal class CustomPrincipal : IPrincipal
   {
      IIdentity m_User;
      IPrincipal m_OldPrincipal;
      IUserManager m_UserManager;
      string m_ApplicationName;
      string[] m_Roles;
      static bool m_ThreadPolicySet = false;

      CustomPrincipal(IIdentity user,string applicationName,IUserManager userManager,bool cacheRoles)
      {
         m_OldPrincipal = Thread.CurrentPrincipal;

         m_User = user;
         m_ApplicationName = applicationName;
         m_UserManager = userManager;

         if(cacheRoles)
         {
            m_Roles = m_UserManager.GetRoles(m_ApplicationName,m_User.Name);
         }
         //Make this object the principal for this thread
         Thread.CurrentPrincipal = this;
      }
      static public void Attach(IIdentity user,string applicationName,IUserManager userManager)
      {
         Attach(user,applicationName,userManager,false);
      }
      static public void Attach(IIdentity user,string applicationName,IUserManager userManager,bool cacheRoles)
      {
         Debug.Assert(user.IsAuthenticated);

         IPrincipal customPrincipal = new CustomPrincipal(user,applicationName,userManager,cacheRoles);

         AppDomain currentDomain = AppDomain.CurrentDomain;
         currentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

         //Make sure all future threads in this app domain use this principal
         //but because default principal cannot be set twice:
         if(m_ThreadPolicySet == false)
         {
            currentDomain.SetThreadPrincipal(customPrincipal);
            m_ThreadPolicySet = true;
         }
      }
      public void Detach()
      {
         Thread.CurrentPrincipal = m_OldPrincipal;
      }

      public IIdentity Identity
      {
         get
         {
            return m_User;
         }
      }
      public bool IsInRole(string role)
      {
         if(m_Roles != null)
         {
            Predicate<string> exists = delegate(string roleToMatch)
                                       {
                                          return roleToMatch == role;
                                       };
            return Array.Exists(m_Roles,exists);
         }
         else
         {
            return m_UserManager.IsInRole(m_ApplicationName,m_User.Name,role);
         }
      }
   }
}
