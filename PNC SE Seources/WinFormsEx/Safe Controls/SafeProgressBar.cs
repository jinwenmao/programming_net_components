// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsEx
{
	/// <summary>
	/// Provides thread-safe access to some methods and properties
	/// </summary>
#pragma warning disable 1911
   [ToolboxBitmap(typeof(SafeProgressBar),"SafeProgressBar.bmp")]
   public class SafeProgressBar : ProgressBar
   {
      delegate int GetInt();
      delegate void SetInt(int value);
      public int GetValue()
      {
         if(InvokeRequired)
         {
            GetInt getInt =   delegate()
                              {
                                 return base.Value;
                              };
            return (int)Invoke(getInt,null);
         }
         else
         {
            return base.Value;
         }
      }
      public void SetValue(int progress)
      {
         if(InvokeRequired)
         {
            SetInt setInt = delegate(int value)
            {
               base.Value = value;
            };
            try
            {
               Invoke(setInt,new object[]{progress});
            }
            catch
            {}
         }
         else
         {
            base.Value = progress;
         }
      }
   }
   #pragma warning restore 1911
}
