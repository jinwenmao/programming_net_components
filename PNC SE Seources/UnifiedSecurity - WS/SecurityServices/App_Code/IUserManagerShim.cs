// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services;

[WebService(Name = "IUserManager",Namespace = "http://SecurityServices",Description = "Defines credentials store access interface.")]
abstract class IUserManagerShim : IUserManager
{
   [WebMethod(Description = "Authenticates the user.")]
   public abstract bool Authenticate(string applicationName,string userName,string password);
   
   [WebMethod(Description = "Verifies user role's membership.")]
   public abstract bool IsInRole(string applicationName,string userName,string role);
   
   [WebMethod(Description = "Returns all roleList the user is a member of.")]
   public abstract string[] GetRoles(string applicationName,string userName);
}

