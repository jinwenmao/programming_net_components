// ?2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsEx
{
   /// <summary>
   /// Provides thread-safe access way to set the Text property
   /// </summary>
//#pragma warning disable 1911
   [ToolboxBitmap(typeof(SafeTextBox),"SafeTextbox.bmp")]
   public class SafeTextBox : TextBox
   {
      delegate void SetString(string text);
      delegate string GetString();

      override public string Text
      {
         set
         {
            if(InvokeRequired)
            {
               SetString setTextDel =  delegate(string text)
                                       {
                                          base.Text = text;
                                       };
               try
               {
                  Invoke(setTextDel,new object[]{value});
               }
               catch
               {
               }
            }
            else
            {
               base.Text = value;
            }
         }
         get
         {
            if(InvokeRequired)
            {
               GetString getTextDel =  delegate()
                                       {
                                          return base.Text;
                                       };
               string text = String.Empty;
               try
               {
                  text = (string)Invoke(getTextDel,null);
               }
               catch
               {
               }
               return text;
            }
            else
            {
               return base.Text;
            }
         }
      }
   }
  // #pragma warning restore 1911
}
