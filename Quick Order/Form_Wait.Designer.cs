namespace Quick_Order
{
    partial class Form_Wait
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
            this.components = new System.ComponentModel.Container();
            this.Panel_ProgressBar = new System.Windows.Forms.Panel();
            this.Panel_ProgressSlider = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Panel_ProgressBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_ProgressBar
            // 
            this.Panel_ProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Panel_ProgressBar.Controls.Add(this.Panel_ProgressSlider);
            this.Panel_ProgressBar.Location = new System.Drawing.Point(25, 34);
            this.Panel_ProgressBar.Name = "Panel_ProgressBar";
            this.Panel_ProgressBar.Size = new System.Drawing.Size(300, 6);
            this.Panel_ProgressBar.TabIndex = 6;
            // 
            // Panel_ProgressSlider
            // 
            this.Panel_ProgressSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(165)))), ((int)(((byte)(237)))));
            this.Panel_ProgressSlider.Location = new System.Drawing.Point(0, 0);
            this.Panel_ProgressSlider.Name = "Panel_ProgressSlider";
            this.Panel_ProgressSlider.Size = new System.Drawing.Size(60, 6);
            this.Panel_ProgressSlider.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(110, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "程序运行中，请稍后.......";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Wait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 53);
            this.Controls.Add(this.Panel_ProgressBar);
            this.Controls.Add(this.label1);
            this.Name = "Form_Wait";
            this.Text = "Form_Wait";
            this.Load += new System.EventHandler(this.Form_Wait_Load);
            this.Panel_ProgressBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_ProgressBar;
        private System.Windows.Forms.Panel Panel_ProgressSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}