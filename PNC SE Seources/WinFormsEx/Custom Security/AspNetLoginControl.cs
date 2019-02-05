// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using System.Drawing;

#endregion

namespace WinFormsEx
{
   [ToolboxBitmap(typeof(AspNetLoginControl),"LoginControl.bmp")]
   public partial class AspNetLoginControl : LoginControl
   {
      protected override IUserManager GetUserManager()
      {
         return new AspNetUserManager();
      }
   }
}
