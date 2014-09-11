namespace Elab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AnalogReadButton = new System.Windows.Forms.Button();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.LEDcheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AnalogReadButton
            // 
            this.AnalogReadButton.Location = new System.Drawing.Point(218, 126);
            this.AnalogReadButton.Name = "AnalogReadButton";
            this.AnalogReadButton.Size = new System.Drawing.Size(108, 50);
            this.AnalogReadButton.TabIndex = 0;
            this.AnalogReadButton.Text = "Analog Read";
            this.AnalogReadButton.UseVisualStyleBackColor = true;
            this.AnalogReadButton.Click += new System.EventHandler(this.AnalogRead_Click);
            // 
            // PortComboBox
            // 
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.PortComboBox.Location = new System.Drawing.Point(92, 43);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(121, 24);
            this.PortComboBox.TabIndex = 2;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(257, 29);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(108, 50);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Click);
            // 
            // LEDcheckBox
            // 
            this.LEDcheckBox.AutoSize = true;
            this.LEDcheckBox.Location = new System.Drawing.Point(369, 142);
            this.LEDcheckBox.Name = "LEDcheckBox";
            this.LEDcheckBox.Size = new System.Drawing.Size(57, 21);
            this.LEDcheckBox.TabIndex = 4;
            this.LEDcheckBox.Text = "LED";
            this.LEDcheckBox.UseVisualStyleBackColor = true;
            this.LEDcheckBox.CheckedChanged += new System.EventHandler(this.LEDcheckBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 22);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 243);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LEDcheckBox);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.AnalogReadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AnalogReadButton;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.CheckBox LEDcheckBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

