// � 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services;

[WebServiceBinding(Name = "IUserManager")]
public interface IUserManager
{
   [WebMethod(Description = "Authenticates the user.")]
   bool Authenticate(string applicationName,string userName,string password);

   [WebMethod(Description = "Verifies user role's membership.")]
   bool IsInRole(string applicationName,string userName,string role);
   
   [WebMethod(Description = "Returns all roleList the user is a member of.")]
   string[] GetRoles(string applicationName,string userName);
}

