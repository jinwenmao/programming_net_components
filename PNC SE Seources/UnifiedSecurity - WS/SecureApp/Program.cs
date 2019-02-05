// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Principal;

#endregion

namespace SecureApp
{
   static class Program
   {
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         

         Application.Run(new MainForm());
      }
   }
}