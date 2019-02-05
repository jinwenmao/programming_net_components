// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Reflection;
using System.Web.Security;

namespace WinFormsEx
{
   class AspNetUserManager : IUserManager
   {
      public bool Authenticate(string applicationName,string userName,string password)
      {
         Membership.ApplicationName = applicationName;
         return Membership.ValidateUser(userName,password);
      }
      public bool IsInRole(string applicationName,string userName,string role)
      {
         Roles.ApplicationName = applicationName;
         return Roles.IsUserInRole(userName,role);
      }
      public string[] GetRoles(string applicationName,string userName)
      {
         Roles.ApplicationName = applicationName;
         return Roles.GetRolesForUser(userName);
      }
   }
}
