namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.stateText = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.portState = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stateText
            // 
            this.stateText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stateText.Location = new System.Drawing.Point(-1, 73);
            this.stateText.Margin = new System.Windows.Forms.Padding(0);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(801, 100);
            this.stateText.TabIndex = 0;
            this.stateText.Text = "select port";
            this.stateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(687, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Port status";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // portState
            // 
            this.portState.AutoSize = true;
            this.portState.Location = new System.Drawing.Point(65, 181);
            this.portState.Name = "portState";
            this.portState.Size = new System.Drawing.Size(29, 12);
            this.portState.TabIndex = 2;
            this.portState.Text = "port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 202);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.portState);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.stateText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CHINT NB Cloud Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stateText;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label portState;
        private System.Windows.Forms.Button button1;
    }
}

