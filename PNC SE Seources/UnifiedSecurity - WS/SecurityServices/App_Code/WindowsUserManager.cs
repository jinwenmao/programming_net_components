// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Security.Principal;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Management;


[WebService(Namespace="http://SecurityServices",Description="Implements the <a href=\"IUserManager.asmx\">IUserManager</a> interface. Over access to Windows credentials, useful when there is no trust relationship between two Windows domains. This web service should be accessed over https.")]
class WindowsUserManager : IUserManager
{
   HttpSessionState Session = HttpContext.Current.Session;

   int Token
   {
      get
      {
         object state = Session["Token"];
         if(state != null)
         {
            return (int)state;
         }
         return 0;
      }
      set
      {
         Session["Token"] = value;
      }
   }
   [WebMethod(EnableSession = true)]
   public bool Authenticate(string applicationName,string userName,string password)
   {
      if(HttpContext.Current.Request.IsSecureConnection == false)
      {
         HttpContext.Current.Trace.Warn("You should use HTTPS to avoid sending passwords in clear text");
      }
      int token;
      bool authenticated = WindowsSecurity.LogonUser(applicationName,userName,password,out token);
      Token = token;
      return authenticated;
   }
   [WebMethod(EnableSession = true)]
   public bool IsInRole(string applicationName,string userName,string role)
   {
      IntPtr ptr = new IntPtr(Token);
      WindowsIdentity identity = new WindowsIdentity(ptr);
      IPrincipal principal = new WindowsPrincipal(identity);
      return principal.IsInRole(role);
   }
   [WebMethod(EnableSession = true)]
   public string[] GetRoles(string applicationName,string userName)
   {
      ObjectQuery query = new ObjectQuery("select * from win32_group");
      ManagementObjectSearcher groups = new ManagementObjectSearcher(query);

      List<string> roleList = new List<string>();

      foreach(ManagementObject group in groups.Get())
      {
         string role = group.Properties["name"].Value.ToString();
         roleList.Add(role);
      }
      Predicate<string> isInRole =  delegate(string role)
                                    {
                                       return IsInRole(applicationName,userName,role);
                                    };
      List<string> roles = roleList.FindAll(isInRole);
      return roles.ToArray();
   }
}