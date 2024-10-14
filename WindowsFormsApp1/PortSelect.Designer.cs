namespace WindowsFormsApp1
{
    partial class PortSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortSelect));
            this.comboxPortsList = new System.Windows.Forms.ComboBox();
            this.btnSelectPort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.parity = new System.Windows.Forms.ComboBox();
            this.dataBits = new System.Windows.Forms.ComboBox();
            this.stopBits = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboxPortsList
            // 
            this.comboxPortsList.FormattingEnabled = true;
            this.comboxPortsList.Location = new System.Drawing.Point(124, 19);
            this.comboxPortsList.Name = "comboxPortsList";
            this.comboxPortsList.Size = new System.Drawing.Size(121, 20);
            this.comboxPortsList.TabIndex = 0;
            // 
            // btnSelectPort
            // 
            this.btnSelectPort.Location = new System.Drawing.Point(94, 157);
            this.btnSelectPort.Name = "btnSelectPort";
            this.btnSelectPort.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPort.TabIndex = 1;
            this.btnSelectPort.Text = "选择";
            this.btnSelectPort.UseVisualStyleBackColor = true;
            this.btnSelectPort.Click += new System.EventHandler(this.selectPort);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bard rate:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parity:";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data bits:";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Stop bits:";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelectPort);
            this.groupBox1.Controls.Add(this.stopBits);
            this.groupBox1.Controls.Add(this.dataBits);
            this.groupBox1.Controls.Add(this.parity);
            this.groupBox1.Controls.Add(this.baudRate);
            this.groupBox1.Controls.Add(this.comboxPortsList);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 191);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial port";
            // 
            // baudRate
            // 
            this.baudRate.FormattingEnabled = true;
            this.baudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200",
            "128000",
            "256000"});
            this.baudRate.Location = new System.Drawing.Point(124, 46);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(121, 20);
            this.baudRate.TabIndex = 0;
            this.baudRate.Text = "4800";
            // 
            // parity
            // 
            this.parity.FormattingEnabled = true;
            this.parity.Items.AddRange(new object[] {
            "no parity",
            "odd parity",
            "even parity"});
            this.parity.Location = new System.Drawing.Point(124, 73);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(121, 20);
            this.parity.TabIndex = 0;
            this.parity.Text = "even parity";
            // 
            // dataBits
            // 
            this.dataBits.FormattingEnabled = true;
            this.dataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.dataBits.Location = new System.Drawing.Point(124, 100);
            this.dataBits.Name = "dataBits";
            this.dataBits.Size = new System.Drawing.Size(121, 20);
            this.dataBits.TabIndex = 0;
            this.dataBits.Text = "8";
            // 
            // stopBits
            // 
            this.stopBits.FormattingEnabled = true;
            this.stopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.stopBits.Location = new System.Drawing.Point(124, 127);
            this.stopBits.Name = "stopBits";
            this.stopBits.Size = new System.Drawing.Size(121, 20);
            this.stopBits.TabIndex = 0;
            this.stopBits.Text = "1";
            // 
            // PortSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 217);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortSelect";
            this.Load += new System.EventHandler(this.PortSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboxPortsList;
        private System.Windows.Forms.Button btnSelectPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox stopBits;
        private System.Windows.Forms.ComboBox dataBits;
        private System.Windows.Forms.ComboBox parity;
        private System.Windows.Forms.ComboBox baudRate;
    }
}