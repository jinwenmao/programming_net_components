// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Windows.Forms;

namespace WinFormsEx
{
   partial class FadingForm
   {
      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this.m_Timer = new System.Windows.Forms.Timer();
// 
// m_Timer
// 
         this.m_Timer.Interval = 50;
         this.m_Timer.Tick += new System.EventHandler(this.OnTick);
// 
// FadingForm
// 
         
         this.ClientSize = new System.Drawing.Size(336,260);
         this.Name = "FadingForm";
         this.Text = "Fading Window";

      }

      #endregion

      Timer m_Timer;
   }
}

