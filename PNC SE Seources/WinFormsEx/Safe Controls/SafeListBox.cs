// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsEx
{
   /// <summary>
   /// Provides thread-safe access way to add items
   /// </summary>
#pragma warning disable 1911
   [ToolboxBitmap(typeof(SafeListBox),"SafeListBox.bmp")]
   public class SafeListBox : ListBox
   {
      public void AddItem(string item)
      {
         if(InvokeRequired)
         {
            GenericEventHandler<string> setTextDel =  delegate(string text)
                                                      {
                                                         base.Items.Add(text);
                                                      };
            try
            {
               Invoke(setTextDel,new object[]{item});
            }
            catch{}
         }
         else
         {
            base.Items.Add(item);
         }
      }
   }
   #pragma warning restore 1911
}
