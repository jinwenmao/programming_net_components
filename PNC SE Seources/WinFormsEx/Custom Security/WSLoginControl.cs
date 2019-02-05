// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using System.Drawing;
using System.ComponentModel;

#endregion

namespace WinFormsEx
{
   [ToolboxBitmap(typeof(WSLoginControl),"LoginControl.bmp")]
   public partial class WSLoginControl : LoginControl
   {
      protected override IUserManager GetUserManager()
      {
         return new UserManager();
      }
   }
}
