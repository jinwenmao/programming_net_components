// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Diagnostics;
using System.Configuration;

namespace WinFormsEx
{
   [DebuggerStepThrough]
   [WebServiceBinding(Name = "IUserManager",Namespace = "http://SecurityServices")]
   partial class UserManager : SoapHttpClientProtocol,IUserManager
   {
      public UserManager()
      {
         CookieContainer = new System.Net.CookieContainer();
         string urlSetting = ConfigurationManager.AppSettings["UserManager"];
         if(urlSetting != null)
         {
            Url = urlSetting;
         }
         else
         {
            Trace.TraceWarning("No URL was found in application configuration file");
         }
      }
      public UserManager(string url)
      {
         CookieContainer = new System.Net.CookieContainer();
         Url = url;
      }
      [SoapDocumentMethod("http://SecurityServices/Authenticate")]
      public bool Authenticate(string applicationName,string userName,string password)
      {
         string[] parameters = {applicationName,userName,password};
         object[] results = Invoke("Authenticate",parameters);
         return ((bool)(results[0]));
      }
      [SoapDocumentMethod("http://SecurityServices/IsInRole")]
      public bool IsInRole(string applicationName,string userName,string role)
      {
         string[] parameters = {applicationName,userName,role};
         object[] results = Invoke("IsInRole",parameters);
         return ((bool)(results[0]));
      }
      [SoapDocumentMethod("http://SecurityServices/GetRoles")]
      public string[] GetRoles(string applicationName,string userName)
      {
         string[] parameters = {applicationName,userName};
         object[] results = Invoke("GetRoles",parameters);
         return ((string[])(results[0]));
      }
   }
}
