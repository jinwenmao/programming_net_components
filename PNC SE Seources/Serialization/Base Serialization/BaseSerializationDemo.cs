// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;


namespace Serialization
{
	public class SerializationDemo : Form
	{
		private Button m_SerializeButton;
		private Button m_DeserializeButton;
		private GroupBox groupBox1;
		private RadioButton m_BinaryRadio;
		private RadioButton m_SoapRadio;
		private GroupBox groupBox2;
		private Label label3;
		private Label label2;
		private TextBox m_Int1;
		private TextBox m_Int2;
		private Label label5;
		private TextBox m_FileName;

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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.m_BinaryRadio = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.m_Int1 = new System.Windows.Forms.TextBox();
         this.m_Int2 = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.m_FileName = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.m_SerializeButton = new System.Windows.Forms.Button();
         this.m_DeserializeButton = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // m_SoapRadio
         // 
         this.m_SoapRadio.Location = new System.Drawing.Point(8, 56);
         this.m_SoapRadio.Name = "m_SoapRadio";
         this.m_SoapRadio.Size = new System.Drawing.Size(64, 24);
         this.m_SoapRadio.TabIndex = 0;
         this.m_SoapRadio.Text = "SOAP";
         this.m_SoapRadio.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.m_BinaryRadio,
                                                                                this.m_SoapRadio});
         this.groupBox1.Location = new System.Drawing.Point(8, 16);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(104, 100);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Formatter";
         // 
         // m_BinaryRadio
         // 
         this.m_BinaryRadio.Checked = true;
         this.m_BinaryRadio.Location = new System.Drawing.Point(8, 24);
         this.m_BinaryRadio.Name = "m_BinaryRadio";
         this.m_BinaryRadio.Size = new System.Drawing.Size(56, 24);
         this.m_BinaryRadio.TabIndex = 0;
         this.m_BinaryRadio.TabStop = true;
         this.m_BinaryRadio.Text = "Binary";
         this.m_BinaryRadio.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.label3,
                                                                                this.m_Int1,
                                                                                this.m_Int2,
                                                                                this.label2});
         this.groupBox2.Location = new System.Drawing.Point(264, 16);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(192, 104);
         this.groupBox2.TabIndex = 4;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Object State";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 56);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(40, 23);
         this.label3.TabIndex = 3;
         this.label3.Text = "Int2";
         // 
         // m_Int1
         // 
         this.m_Int1.Location = new System.Drawing.Point(64, 24);
         this.m_Int1.Name = "m_Int1";
         this.m_Int1.TabIndex = 2;
         this.m_Int1.Text = "1";
         // 
         // m_Int2
         // 
         this.m_Int2.Location = new System.Drawing.Point(64, 56);
         this.m_Int2.Name = "m_Int2";
         this.m_Int2.TabIndex = 2;
         this.m_Int2.Text = "2";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 24);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(40, 23);
         this.label2.TabIndex = 3;
         this.label2.Text = "Int1";
         // 
         // m_FileName
         // 
         this.m_FileName.Location = new System.Drawing.Point(16, 160);
         this.m_FileName.Name = "m_FileName";
         this.m_FileName.Size = new System.Drawing.Size(192, 20);
         this.m_FileName.TabIndex = 6;
         this.m_FileName.Text = "C:\\Temp\\Obj.bin";
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 136);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(96, 24);
         this.label5.TabIndex = 5;
         this.label5.Text = "File Name";
         // 
         // m_SerializeButton
         // 
         this.m_SerializeButton.Location = new System.Drawing.Point(128, 24);
         this.m_SerializeButton.Name = "m_SerializeButton";
         this.m_SerializeButton.TabIndex = 0;
         this.m_SerializeButton.Text = "Serialize";
         this.m_SerializeButton.Click += new System.EventHandler(this.OnSerialize);
         // 
         // m_DeserializeButton
         // 
         this.m_DeserializeButton.Location = new System.Drawing.Point(128, 64);
         this.m_DeserializeButton.Name = "m_DeserializeButton";
         this.m_DeserializeButton.TabIndex = 0;
         this.m_DeserializeButton.Text = "Deserialize";
         this.m_DeserializeButton.Click += new System.EventHandler(this.OnDeserialize);
         // 
         // SerializationDemo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
         this.ClientSize = new System.Drawing.Size(472, 205);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.m_FileName,
                                                                      this.label5,
                                                                      this.groupBox2,
                                                                      this.groupBox1,
                                                                      this.m_SerializeButton,
                                                                      this.m_DeserializeButton});
         this.Name = "SerializationDemo";
         this.Text = "Base Serialization Demo";
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

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

		void OnSerialize(object sender,EventArgs e)
		{
			MyClass obj = new MyClass();
			obj.m_PublicNum = Convert.ToInt32(m_Int1.Text);
			obj.Num = Convert.ToInt32(m_Int2.Text);

			IFormatter formatter = GetFormatter();
			Stream stream = new FileStream(m_FileName.Text,FileMode.Create,FileAccess.Write);
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

         m_Int1.Text = obj.m_PublicNum.ToString();
         m_Int2.Text = obj.Num.ToString();
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

      void OnCheckedChanged(object sender,EventArgs e)
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
