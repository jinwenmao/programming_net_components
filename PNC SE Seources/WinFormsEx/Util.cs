// � 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;


namespace WinFormsEx
{
   public class Util
   {
      public const int HWND_BROADCAST = 0xffff;
      public const int WM_USER = 0x400;

      [SuppressUnmanagedCodeSecurity]
      [DllImport("user32",EntryPoint = "SendMessage")]
      public static extern int SendMessage(IntPtr hwnd,int msg,int wparam,int lparam);

      [SuppressUnmanagedCodeSecurity]
      [DllImport("user32",EntryPoint = "PostMessage")]
      public static extern bool PostMessage(IntPtr hwnd,int msg,int wparam,int lparam);

      [SuppressUnmanagedCodeSecurity]
      [DllImport("user32",EntryPoint = "RegisterWindowMessage")]
      public static extern int RegisterWindowMessage(string msgString);
    }
}
