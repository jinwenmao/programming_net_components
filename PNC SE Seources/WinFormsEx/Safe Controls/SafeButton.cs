// ?2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsEx
{
	/// <summary>
	/// Provides thread-safe enabling of the button
	/// </summary>
   [ToolboxBitmap(typeof(SafeButton),"SafeButton.bmp")]
//#pragma warning disable 1911
   public class SafeButton : Button
   {
      delegate void SetBoolean(bool enabled);
      delegate bool GetBoolean();

      public bool SafeEnabled
      {
         set
         {
            if(InvokeRequired)
            {
               SetBoolean setBoolean = delegate(bool enabled)
                                       {
                                          base.Enabled = enabled;
                                       };
               try
               {
                  Invoke(setBoolean,new object[]{value});
               }
               catch{}
            }
            else
            {
               base.Enabled = value;
            }
         }
         get
         {
            if(InvokeRequired)
            {
               GetBoolean getBoolean = delegate()
                                       {
                                          return base.Enabled;
                                       };
               bool enabled = true;
               try
               {
                  enabled = (bool)Invoke(getBoolean,null);
               }
               catch{}
               return enabled;
            }
            else
            {
               return base.Enabled;
            }
         }
      }
   }
//#pragma warning restore 1911
}
