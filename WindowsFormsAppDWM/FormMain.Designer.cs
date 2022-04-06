namespace WindowsFormsAppDWM
{
    partial class FormMain
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
            this.buttonReg = new System.Windows.Forms.Button();
            this.textBoxWindow = new System.Windows.Forms.TextBox();
            this.buttonUnReg = new System.Windows.Forms.Button();
            this.buttonCap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(108, 4);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(75, 23);
            this.buttonReg.TabIndex = 0;
            this.buttonReg.Text = "订阅窗体";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // textBoxWindow
            // 
            this.textBoxWindow.Location = new System.Drawing.Point(2, 6);
            this.textBoxWindow.Name = "textBoxWindow";
            this.textBoxWindow.Size = new System.Drawing.Size(100, 20);
            this.textBoxWindow.TabIndex = 2;
            this.textBoxWindow.Text = "OUTLOOK";
            // 
            // buttonUnReg
            // 
            this.buttonUnReg.Location = new System.Drawing.Point(189, 4);
            this.buttonUnReg.Name = "buttonUnReg";
            this.buttonUnReg.Size = new System.Drawing.Size(75, 23);
            this.buttonUnReg.TabIndex = 3;
            this.buttonUnReg.Text = "取消订阅";
            this.buttonUnReg.UseVisualStyleBackColor = true;
            this.buttonUnReg.Click += new System.EventHandler(this.buttonUnReg_Click);
            // 
            // buttonCap
            // 
            this.buttonCap.Location = new System.Drawing.Point(270, 3);
            this.buttonCap.Name = "buttonCap";
            this.buttonCap.Size = new System.Drawing.Size(75, 23);
            this.buttonCap.TabIndex = 4;
            this.buttonCap.Text = "截图";
            this.buttonCap.UseVisualStyleBackColor = true;
            this.buttonCap.Click += new System.EventHandler(this.buttonCap_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(2, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 781);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCap);
            this.Controls.Add(this.buttonUnReg);
            this.Controls.Add(this.textBoxWindow);
            this.Controls.Add(this.buttonReg);
            this.Name = "FormMain";
            this.Text = "DWM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.TextBox textBoxWindow;
        private System.Windows.Forms.Button buttonUnReg;
        private System.Windows.Forms.Button buttonCap;
        private System.Windows.Forms.Panel panel1;
    }
}

