// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Serialization
{
	public class SerializationDemo : Form
	{
		Button m_SerializeButton;
		Button m_DeserializeButton;
		RadioButton m_BinaryRadio;
		RadioButton m_SoapRadio;
      TextBox m_TBox;
      TextBox m_NameBox;
      GroupBox m_FormatGroup;
      GroupBox m_ObjectGroup;
      Label m_NameLabel;
      Label m_GenericLabel;
      Label m_FileLabel;
		TextBox m_FileName;

      public SerializationDemo()
		{
			InitializeComponent();
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
         this.m_SoapRadio = new System.Windows.Forms.RadioButton();
         this.m_FormatGroup = new System.Windows.Forms.GroupBox();
         this.m_BinaryRadio = new System.Windows.Forms.RadioButton();
         this.m_ObjectGroup = new System.Windows.Forms.GroupBox();
         this.m_NameLabel = new System.Windows.Forms.Label();
         this.m_TBox = new System.Windows.Forms.TextBox();
         this.m_NameBox = new System.Windows.Forms.TextBox();
         this.m_GenericLabel = new System.Windows.Forms.Label();
         this.m_FileName = new System.Windows.Forms.TextBox();
         this.m_FileLabel = new System.Windows.Forms.Label();
         this.m_SerializeButton = new System.Windows.Forms.Button();
         this.m_DeserializeButton = new System.Windows.Forms.Button();
         this.m_FormatGroup.SuspendLayout();
         this.m_ObjectGroup.SuspendLayout();
         this.SuspendLayout();

         // 
         // m_SoapRadio
         // 
         this.m_SoapRadio.Location = new System.Drawing.Point(8,56);
         this.m_SoapRadio.Name = "m_SoapRadio";
         this.m_SoapRadio.Size = new System.Drawing.Size(64,24);
         this.m_SoapRadio.TabIndex = 0;
         this.m_SoapRadio.Text = "SOAP";
         this.m_SoapRadio.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);

         // 
         // m_FormatGroup
         // 
         this.m_FormatGroup.Controls.Add(this.m_BinaryRadio);
         this.m_FormatGroup.Controls.Add(this.m_SoapRadio);
         this.m_FormatGroup.Location = new System.Drawing.Point(8,16);
         this.m_FormatGroup.Name = "m_FormatGroup";
         this.m_FormatGroup.Size = new System.Drawing.Size(104,100);
         this.m_FormatGroup.TabIndex = 1;
         this.m_FormatGroup.TabStop = false;
         this.m_FormatGroup.Text = "Formatter";

         // 
         // m_BinaryRadio
         // 
         this.m_BinaryRadio.Checked = true;
         this.m_BinaryRadio.Location = new System.Drawing.Point(8,24);
         this.m_BinaryRadio.Name = "m_BinaryRadio";
         this.m_BinaryRadio.Size = new System.Drawing.Size(56,24);
         this.m_BinaryRadio.TabIndex = 0;
         this.m_BinaryRadio.TabStop = true;
         this.m_BinaryRadio.Text = "Binary";
         this.m_BinaryRadio.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);

         // 
         // m_ObjectGroup
         // 
         this.m_ObjectGroup.Controls.Add(this.m_NameLabel);
         this.m_ObjectGroup.Controls.Add(this.m_TBox);
         this.m_ObjectGroup.Controls.Add(this.m_NameBox);
         this.m_ObjectGroup.Controls.Add(this.m_GenericLabel);
         this.m_ObjectGroup.Location = new System.Drawing.Point(259,16);
         this.m_ObjectGroup.Name = "m_ObjectGroup";
         this.m_ObjectGroup.Size = new System.Drawing.Size(197,104);
         this.m_ObjectGroup.TabIndex = 4;
         this.m_ObjectGroup.TabStop = false;
         this.m_ObjectGroup.Text = "Object State";

         // 
         // m_NameLabel
         // 
         this.m_NameLabel.Location = new System.Drawing.Point(8,56);
         this.m_NameLabel.Name = "m_NameLabel";
         this.m_NameLabel.Size = new System.Drawing.Size(56,23);
         this.m_NameLabel.TabIndex = 3;
         this.m_NameLabel.Text = "m_Name";

         // 
         // m_TBox
         // 
         this.m_TBox.Location = new System.Drawing.Point(70,22);
         this.m_TBox.Name = "m_TBox";
         this.m_TBox.TabIndex = 2;
         this.m_TBox.Text = "1";

         // 
         // m_NameBox
         // 
         this.m_NameBox.Location = new System.Drawing.Point(70,54);
         this.m_NameBox.Name = "m_NameBox";
         this.m_NameBox.TabIndex = 2;
         this.m_NameBox.Text = "AAA";

         // 
         // m_GenericLabel
         // 
         this.m_GenericLabel.Location = new System.Drawing.Point(8,24);
         this.m_GenericLabel.Name = "m_GenericLabel";
         this.m_GenericLabel.Size = new System.Drawing.Size(40,23);
         this.m_GenericLabel.TabIndex = 3;
         this.m_GenericLabel.Text = "m_T";

         // 
         // m_FileName
         // 
         this.m_FileName.Location = new System.Drawing.Point(16,160);
         this.m_FileName.Name = "m_FileName";
         this.m_FileName.Size = new System.Drawing.Size(192,19);
         this.m_FileName.TabIndex = 6;
         this.m_FileName.Text = "C:\\Temp\\Obj.bin";

         // 
         // m_FileLabel
         // 
         this.m_FileLabel.Location = new System.Drawing.Point(16,136);
         this.m_FileLabel.Name = "m_FileLabel";
         this.m_FileLabel.Size = new System.Drawing.Size(96,24);
         this.m_FileLabel.TabIndex = 5;
         this.m_FileLabel.Text = "File Name";

         // 
         // m_SerializeButton
         // 
         this.m_SerializeButton.Location = new System.Drawing.Point(128,24);
         this.m_SerializeButton.Name = "m_SerializeButton";
         this.m_SerializeButton.TabIndex = 0;
         this.m_SerializeButton.Text = "Serialize";
         this.m_SerializeButton.Click += new System.EventHandler(this.OnSerialize);

         // 
         // m_DeserializeButton
         // 
         this.m_DeserializeButton.Location = new System.Drawing.Point(128,64);
         this.m_DeserializeButton.Name = "m_DeserializeButton";
         this.m_DeserializeButton.TabIndex = 0;
         this.m_DeserializeButton.Text = "Deserialize";
         this.m_DeserializeButton.Click += new System.EventHandler(this.OnDeserialize);

         // 
         // SerializationDemo
         // 
         
         this.ClientSize = new System.Drawing.Size(472,205);
         this.Controls.Add(this.m_FileName);
         this.Controls.Add(this.m_FileLabel);
         this.Controls.Add(this.m_ObjectGroup);
         this.Controls.Add(this.m_FormatGroup);
         this.Controls.Add(this.m_SerializeButton);
         this.Controls.Add(this.m_DeserializeButton);
         this.Name = "SerializationDemo";
         this.Text = "Generic Serialization Demo";
         this.m_FormatGroup.ResumeLayout(false);
         this.m_ObjectGroup.ResumeLayout(false);
         this.m_ObjectGroup.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();
      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SerializationDemo());
		}

		private void OnSerialize(object sender,EventArgs e)
		{
			MyClass<int> obj = new MyClass<int>();
         obj.m_T = Convert.ToInt32(m_TBox.Text);
         obj.m_Name = m_NameBox.Text;
 
			IFormatter formatter = GetFormatter();
			Stream stream = new FileStream(m_FileName.Text,FileMode.Create,FileAccess.Write);
         using(stream)
         {
            formatter.Serialize(stream,obj);
         }
      }
      private void OnDeserialize(object sender,EventArgs e)
      {
         IFormatter formatter = GetFormatter();
         Stream stream = new FileStream(m_FileName.Text,FileMode.Open,FileAccess.Read);

         MyClass<int> obj;//No new!!!
         using(stream)
         {
            obj = (MyClass<int>)formatter.Deserialize(stream);
         }

         m_TBox.Text = obj.m_T.ToString();
         m_NameBox.Text = obj.m_Name;
      }
      private IFormatter GetFormatter()
		{
			if(m_BinaryRadio.Checked)
			{
				return new BinaryFormatter();
			}
			else
			{
				return new SoapFormatter();
			}
		}

      private void OnCheckedChanged(object sender,EventArgs e)
      {
         if(m_BinaryRadio.Checked)
         {
            m_FileName.Text = @"C:\Temp\Obj.bin";
         }
         if(m_SoapRadio.Checked)
         {
            m_FileName.Text = @"C:\Temp\Obj.xml";
         }
      }
	}
}
