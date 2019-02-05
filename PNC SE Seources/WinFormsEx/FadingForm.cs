// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

#endregion


namespace WinFormsEx
{
   public enum Rate
   {
      High,
      Medium,
      Low
   }   
   public partial class FadingForm : Form
   {

      Rate m_CollapseRate = Rate.High;
      Rate m_FadeRate = Rate.High;
      bool m_Collapse;

      public FadingForm(bool collapsable)
      {
         m_Collapse = collapsable;
         InitializeComponent();
      }
      public FadingForm() : this(true)
      {}

      [Category("Appearance")]
      public Rate CollapseRate
      {
         get
         {
            return m_CollapseRate;
         }

         set
         {
            m_CollapseRate = value;
         }
      }

      [Category("Appearance")]
      public Rate FadeRate
      {
         get
         {
            return m_FadeRate;
         }

         set
         {
            m_FadeRate = value;
         }
      }


      protected override void OnClosing(CancelEventArgs e)
      {
         if(Opacity >= 0.999)
         {
            ControlBox = false;
            m_Timer.Enabled = true;
            e.Cancel = true;
         }
         else
         {
            base.OnClosing(e);
         }
      }
      void OnTick(object sender, EventArgs e)
      {
         if(Opacity <= 0.05 || ClientSize.Width < 1 || ClientSize.Height <1)
         {
            m_Timer.Enabled = false;
            Close();
         }
         else
         {
            double opacityDelta = 0;
            switch(FadeRate)
            {
               case Rate.High:
               {
                  opacityDelta = 0.03;
                  break;
               }
               case Rate.Medium:
               {
                  opacityDelta = 0.02;
                  break;
               }
               case Rate.Low:
               {
                  opacityDelta = 0.01;
                  break;
               }
               default:
               {
                  Debug.Assert(false);
                  break;
               }
            }
            int collapseDelta = 0;
            switch(CollapseRate)
            {
               case Rate.High:
               {
                  collapseDelta = ClientSize.Width/30;
                  break;
               }
               case Rate.Medium:
               {
                  collapseDelta = ClientSize.Width /15;
                  break;
               }
               case Rate.Low:
               {
                  collapseDelta = 1;
                  break;
               }
               default:
               {
                  Debug.Assert(false);
                  break;
               }
            }
            Opacity -= opacityDelta;
            ClientSize = new Size(ClientSize.Width - collapseDelta,ClientSize.Height - collapseDelta);
            Location = new Point(Location.X + collapseDelta/2,Location.Y + collapseDelta/2);
         }
      }
   }
}