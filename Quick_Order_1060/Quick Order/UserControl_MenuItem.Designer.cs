namespace Quick_Order
{
    partial class UserControl_MenuItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Label_Title = new System.Windows.Forms.Label();
            this.Label_Arrow = new System.Windows.Forms.Label();
            this.Label_ShortKey = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.AutoEllipsis = true;
            this.Label_Title.AutoSize = true;
            this.Label_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Label_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Label_Title.Location = new System.Drawing.Point(8, 13);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(34, 17);
            this.Label_Title.TabIndex = 4;
            this.Label_Title.Text = "新建";
            this.Label_Title.Click += new System.EventHandler(this.Label_Title_Click);
            // 
            // Label_Arrow
            // 
            this.Label_Arrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Arrow.AutoSize = true;
            this.Label_Arrow.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Label_Arrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Label_Arrow.Location = new System.Drawing.Point(132, 13);
            this.Label_Arrow.Name = "Label_Arrow";
            this.Label_Arrow.Size = new System.Drawing.Size(18, 17);
            this.Label_Arrow.TabIndex = 5;
            this.Label_Arrow.Text = ">";
            this.Label_Arrow.Visible = false;
            this.Label_Arrow.Click += new System.EventHandler(this.Label_Arrow_Click);
            // 
            // Label_ShortKey
            // 
            this.Label_ShortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_ShortKey.AutoSize = true;
            this.Label_ShortKey.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Label_ShortKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Label_ShortKey.Location = new System.Drawing.Point(63, 13);
            this.Label_ShortKey.Name = "Label_ShortKey";
            this.Label_ShortKey.Size = new System.Drawing.Size(69, 17);
            this.Label_ShortKey.TabIndex = 6;
            this.Label_ShortKey.Text = "Ctrl+Shift";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 5000;
            // 
            // UserControl_MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.Label_Arrow);
            this.Controls.Add(this.Label_ShortKey);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Name = "UserControl_MenuItem";
            this.Size = new System.Drawing.Size(150, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Label Label_Arrow;
        private System.Windows.Forms.Label Label_ShortKey;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
