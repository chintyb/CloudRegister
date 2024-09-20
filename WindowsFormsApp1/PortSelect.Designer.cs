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
            this.SuspendLayout();
            // 
            // comboxPortsList
            // 
            this.comboxPortsList.FormattingEnabled = true;
            this.comboxPortsList.Location = new System.Drawing.Point(29, 32);
            this.comboxPortsList.Name = "comboxPortsList";
            this.comboxPortsList.Size = new System.Drawing.Size(121, 20);
            this.comboxPortsList.TabIndex = 0;
            // 
            // btnSelectPort
            // 
            this.btnSelectPort.Location = new System.Drawing.Point(186, 30);
            this.btnSelectPort.Name = "btnSelectPort";
            this.btnSelectPort.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPort.TabIndex = 1;
            this.btnSelectPort.Text = "选择";
            this.btnSelectPort.UseVisualStyleBackColor = true;
            this.btnSelectPort.Click += new System.EventHandler(this.selectPort);
            // 
            // PortSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 90);
            this.Controls.Add(this.btnSelectPort);
            this.Controls.Add(this.comboxPortsList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortSelect";
            this.Load += new System.EventHandler(this.PortSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboxPortsList;
        private System.Windows.Forms.Button btnSelectPort;
    }
}