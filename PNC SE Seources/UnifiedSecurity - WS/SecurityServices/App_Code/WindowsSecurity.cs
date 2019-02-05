using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security;
using System.Diagnostics;

class WindowsSecurity 
{
   //From Winbase.h 
   private const int NetworkLogon = 3;		
   private const int DefaultLogonProvider = 0;		

	[DllImport("advapi32.dll")]
	[SuppressUnmanagedCodeSecurity]
	static extern bool LogonUser(string userName, string userDomain, string userPassword, int logonType, int logonProvider, out int token);

   [SecurityPermission(SecurityAction.Demand,ControlPrincipal = true)]
   public static bool LogonUser(string userDomain, string userName,string userPassword, out int token)
	{
		return LogonUser(userName,userDomain,userPassword,NetworkLogon,DefaultLogonProvider,out token);
	}
}


