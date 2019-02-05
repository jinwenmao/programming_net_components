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
		GroupBox m_FormatterGroupBox;
		RadioButton m_BinaryRadio;
		RadioButton m_SoapRadio;
		GroupBox m_MembersGroupBox;
		Label m_Int2Label;
		Label m_StringLabel;
		Label m_Int1Label;
		TextBox m_Int1;
		TextBox m_Int2;
		TextBox m_String;
		TextBox m_Int3;
		Label m_Int3Label;
		Label m_FileNameLabel;
		TextBox m_FileName;
		PictureBox m_Picture;

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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerializationDemo));
         this.m_SoapRadio = new System.Windows.Forms.RadioButton();
         this.m_FormatterGroupBox = new System.Windows.Forms.GroupBox();
         this.m_BinaryRadio = new System.Windows.Forms.RadioButton();
         this.m_MembersGroupBox = new System.Windows.Forms.GroupBox();
         this.m_Int2Label = new System.Windows.Forms.Label();
         this.m_Int1 = new System.Windows.Forms.TextBox();
         this.m_Int2 = new System.Windows.Forms.TextBox();
         this.m_String = new System.Windows.Forms.TextBox();
         this.m_StringLabel = new System.Windows.Forms.Label();
         this.m_Int1Label = new System.Windows.Forms.Label();
         this.m_Int3 = new System.Windows.Forms.TextBox();
         this.m_Int3Label = new System.Windows.Forms.Label();
         this.m_FileName = new System.Windows.Forms.TextBox();
         this.m_FileNameLabel = new System.Windows.Forms.Label();
         this.m_SerializeButton = new System.Windows.Forms.Button();
         this.m_Picture = new System.Windows.Forms.PictureBox();
         this.m_DeserializeButton = new System.Windows.Forms.Button();
         this.m_FormatterGroupBox.SuspendLayout();
         this.m_MembersGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.m_Picture)).BeginInit();
         this.SuspendLayout();
         // 
         // m_SoapRadio
         // 
         this.m_SoapRadio.Location = new System.Drawing.Point(8,56);
         this.m_SoapRadio.Name = "m_SoapRadio";
         this.m_SoapRadio.Size = new System.Drawing.Size(64,24);
         this.m_SoapRadio.TabIndex = 0;
         this.m_SoapRadio.Text = "SOAP";
         this.m_SoapRadio.CheckedChanged += new System.EventHandler(this.OnSOAPChanged);
         // 
         // m_FormatterGroupBox
         // 
         this.m_FormatterGroupBox.Controls.Add(this.m_BinaryRadio);
         this.m_FormatterGroupBox.Controls.Add(this.m_SoapRadio);
         this.m_FormatterGroupBox.Location = new System.Drawing.Point(8,16);
         this.m_FormatterGroupBox.Name = "m_FormatterGroupBox";
         this.m_FormatterGroupBox.Size = new System.Drawing.Size(104,100);
         this.m_FormatterGroupBox.TabIndex = 1;
         this.m_FormatterGroupBox.TabStop = false;
         this.m_FormatterGroupBox.Text = "Formatter";
         // 
         // m_BinaryRadio
         // 
         this.m_BinaryRadio.Checked = true;
         this.m_BinaryRadio.Location = new System.Drawing.Point(8,24);
         this.m_BinaryRadio.Name = "m_BinaryRadio";
         this.m_BinaryRadio.Size = new System.Drawing.Size(56,24);
         this.m_BinaryRadio.TabIndex = 0;
         this.m_BinaryRadio.Text = "Binary";
         this.m_BinaryRadio.CheckedChanged += new System.EventHandler(this.OnBinaryChanged);
         // 
         // m_MembersGroupBox
         // 
         this.m_MembersGroupBox.Controls.Add(this.m_Int2Label);
         this.m_MembersGroupBox.Controls.Add(this.m_Int1);
         this.m_MembersGroupBox.Controls.Add(this.m_Int2);
         this.m_MembersGroupBox.Controls.Add(this.m_String);
         this.m_MembersGroupBox.Controls.Add(this.m_StringLabel);
         this.m_MembersGroupBox.Controls.Add(this.m_Int1Label);
         this.m_MembersGroupBox.Controls.Add(this.m_Int3);
         this.m_MembersGroupBox.Controls.Add(this.m_Int3Label);
         this.m_MembersGroupBox.Location = new System.Drawing.Point(264,16);
         this.m_MembersGroupBox.Name = "m_MembersGroupBox";
         this.m_MembersGroupBox.Size = new System.Drawing.Size(192,168);
         this.m_MembersGroupBox.TabIndex = 4;
         this.m_MembersGroupBox.TabStop = false;
         this.m_MembersGroupBox.Text = "Object State";
         // 
         // m_Int2Label
         // 
         this.m_Int2Label.Location = new System.Drawing.Point(8,88);
         this.m_Int2Label.Name = "m_Int2Label";
         this.m_Int2Label.Size = new System.Drawing.Size(40,23);
         this.m_Int2Label.TabIndex = 3;
         this.m_Int2Label.Text = "Int2:";
         // 
         // m_Int1
         // 
         this.m_Int1.Location = new System.Drawing.Point(64,56);
         this.m_Int1.Name = "m_Int1";
         this.m_Int1.Size = new System.Drawing.Size(100,20);
         this.m_Int1.TabIndex = 2;
         this.m_Int1.Text = "1";
         // 
         // m_Int2
         // 
         this.m_Int2.Location = new System.Drawing.Point(64,88);
         this.m_Int2.Name = "m_Int2";
         this.m_Int2.Size = new System.Drawing.Size(100,20);
         this.m_Int2.TabIndex = 2;
         this.m_Int2.Text = "2";
         // 
         // m_String
         // 
         this.m_String.Location = new System.Drawing.Point(64,24);
         this.m_String.Name = "m_String";
         this.m_String.Size = new System.Drawing.Size(100,20);
         this.m_String.TabIndex = 2;
         this.m_String.Text = "My String";
         // 
         // m_StringLabel
         // 
         this.m_StringLabel.Location = new System.Drawing.Point(8,24);
         this.m_StringLabel.Name = "m_StringLabel";
         this.m_StringLabel.Size = new System.Drawing.Size(40,23);
         this.m_StringLabel.TabIndex = 3;
         this.m_StringLabel.Text = "String:";
         // 
         // m_Int1Label
         // 
         this.m_Int1Label.Location = new System.Drawing.Point(8,56);
         this.m_Int1Label.Name = "m_Int1Label";
         this.m_Int1Label.Size = new System.Drawing.Size(40,23);
         this.m_Int1Label.TabIndex = 3;
         this.m_Int1Label.Text = "Int1:";
         // 
         // m_Int3
         // 
         this.m_Int3.Location = new System.Drawing.Point(64,128);
         this.m_Int3.Name = "m_Int3";
         this.m_Int3.Size = new System.Drawing.Size(100,20);
         this.m_Int3.TabIndex = 2;
         this.m_Int3.Text = "3333";
         // 
         // m_Int3Label
         // 
         this.m_Int3Label.Location = new System.Drawing.Point(8,128);
         this.m_Int3Label.Name = "m_Int3Label";
         this.m_Int3Label.Size = new System.Drawing.Size(40,23);
         this.m_Int3Label.TabIndex = 3;
         this.m_Int3Label.Text = "Int3:";
         // 
         // m_FileName
         // 
         this.m_FileName.Location = new System.Drawing.Point(16,160);
         this.m_FileName.Name = "m_FileName";
         this.m_FileName.Size = new System.Drawing.Size(192,20);
         this.m_FileName.TabIndex = 6;
         this.m_FileName.Text = "C:\\Temp\\Obj.bin";
         // 
         // m_FileNameLabel
         // 
         this.m_FileNameLabel.Location = new System.Drawing.Point(16,136);
         this.m_FileNameLabel.Name = "m_FileNameLabel";
         this.m_FileNameLabel.Size = new System.Drawing.Size(96,24);
         this.m_FileNameLabel.TabIndex = 5;
         this.m_FileNameLabel.Text = "File Name:";
         // 
         // m_SerializeButton
         // 
         this.m_SerializeButton.Location = new System.Drawing.Point(128,24);
         this.m_SerializeButton.Name = "m_SerializeButton";
         this.m_SerializeButton.Size = new System.Drawing.Size(75,23);
         this.m_SerializeButton.TabIndex = 0;
         this.m_SerializeButton.Text = "Serialize";
         this.m_SerializeButton.Click += new System.EventHandler(this.OnSerialize);
         // 
         // m_Picture
         // 
         this.m_Picture.Image = ((System.Drawing.Image)(resources.GetObject("m_Picture.Image")));
         this.m_Picture.Location = new System.Drawing.Point(16,232);
         this.m_Picture.Name = "m_Picture";
         this.m_Picture.Size = new System.Drawing.Size(448,144);
         this.m_Picture.TabIndex = 7;
         this.m_Picture.TabStop = false;
         // 
         // m_DeserializeButton
         // 
         this.m_DeserializeButton.Location = new System.Drawing.Point(128,64);
         this.m_DeserializeButton.Name = "m_DeserializeButton";
         this.m_DeserializeButton.Size = new System.Drawing.Size(75,23);
         this.m_DeserializeButton.TabIndex = 0;
         this.m_DeserializeButton.Text = "Deserialize";
         this.m_DeserializeButton.Click += new System.EventHandler(this.OnDeserialize);
         // 
         // SerializationDemo
         // 
         this.ClientSize = new System.Drawing.Size(472,381);
         this.Controls.Add(this.m_Picture);
         this.Controls.Add(this.m_FileName);
         this.Controls.Add(this.m_FileNameLabel);
         this.Controls.Add(this.m_MembersGroupBox);
         this.Controls.Add(this.m_FormatterGroupBox);
         this.Controls.Add(this.m_SerializeButton);
         this.Controls.Add(this.m_DeserializeButton);
         this.Name = "SerializationDemo";
         this.Text = "Serialization Demo";
         this.m_FormatterGroupBox.ResumeLayout(false);
         this.m_MembersGroupBox.ResumeLayout(false);
         this.m_MembersGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.m_Picture)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
		#endregion

		static void Main() 
		{
			Application.Run(new SerializationDemo());
		}

		void OnSerialize(object sender,EventArgs e)
		{
         MyClass obj = new MyClass();
         obj.m_Int1 = Convert.ToInt32(m_Int1.Text);
			obj.Int2 = Convert.ToInt32(m_Int2.Text);;
			obj.m_Int3 = Convert.ToInt32(m_Int3.Text);;
			obj.m_String = m_String.Text;

         IFormatter formatter = GetFormatter();
         Stream stream = new FileStream(m_FileName.Text,FileMode.Create);
         using(stream)
         {
            formatter.Serialize(stream,obj);
         }
      }
		void OnDeserialize(object sender,EventArgs e)
		{
         IFormatter formatter = GetFormatter();

         Stream stream = new FileStream(m_FileName.Text,FileMode.Open,FileAccess.Read);

         MyClass obj;//No new!!!
         using(stream)
         {
            obj = (MyClass)formatter.Deserialize(stream);
         }
			m_Int1.Text = obj.m_Int1.ToString();
			m_Int2.Text = obj.Int2.ToString();
			m_Int3.Text = obj.m_Int3.ToString();
			m_String.Text = obj.m_String;
		}
		IFormatter GetFormatter()
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
		void OnBinaryChanged(object sender,EventArgs e)
		{
			m_FileName.Text = @"C:\Temp\Obj.bin";
			Bitmap bmp = new Bitmap(@"..\..\bin.bmp");
			m_Picture.Image = bmp;
		}
      void OnSOAPChanged(object sender,EventArgs e)
      {
 			m_FileName.Text = @"C:\Temp\Obj.xml";
			Bitmap bmp = new Bitmap(@"..\..\Soap.bmp");
			m_Picture.Image = bmp;
      }
	}
}