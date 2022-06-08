namespace Quick_Order
{
    partial class Form_EditControlCount
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Button_Cancel = new Quick_Order.MyButton();
            this.Button_Save = new Quick_Order.MyButton();
            this.TextBox_ProjectName = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_ProjectName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.Button_Cancel);
            this.panel2.Controls.Add(this.Button_Save);
            this.panel2.Controls.Add(this.TextBox_ProjectName);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 221);
            this.panel2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 2);
            this.panel1.TabIndex = 55;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.FlatAppearance.BorderSize = 0;
            this.Button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Cancel.ForeColor = System.Drawing.Color.White;
            this.Button_Cancel.Location = new System.Drawing.Point(199, 183);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(88, 26);
            this.Button_Cancel.TabIndex = 54;
            this.Button_Cancel.Text = "取消";
            this.Button_Cancel.UseVisualStyleBackColor = false;
            // 
            // Button_Save
            // 
            this.Button_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
            this.Button_Save.FlatAppearance.BorderSize = 0;
            this.Button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Save.ForeColor = System.Drawing.Color.White;
            this.Button_Save.Location = new System.Drawing.Point(312, 183);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(88, 26);
            this.Button_Save.TabIndex = 53;
            this.Button_Save.Text = "保存";
            this.Button_Save.UseVisualStyleBackColor = false;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // TextBox_ProjectName
            // 
            this.TextBox_ProjectName.EditValue = "1";
            this.TextBox_ProjectName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TextBox_ProjectName.Location = new System.Drawing.Point(20, 46);
            this.TextBox_ProjectName.Name = "TextBox_ProjectName";
            this.TextBox_ProjectName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TextBox_ProjectName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_ProjectName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.TextBox_ProjectName.Properties.Appearance.Options.UseBackColor = true;
            this.TextBox_ProjectName.Properties.Appearance.Options.UseFont = true;
            this.TextBox_ProjectName.Properties.Appearance.Options.UseForeColor = true;
            this.TextBox_ProjectName.Properties.AutoHeight = false;
            this.TextBox_ProjectName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TextBox_ProjectName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TextBox_ProjectName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TextBox_ProjectName.Properties.Mask.EditMask = "###############";
            this.TextBox_ProjectName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextBox_ProjectName.Size = new System.Drawing.Size(380, 36);
            this.TextBox_ProjectName.TabIndex = 1;
            this.TextBox_ProjectName.EditValueChanged += new System.EventHandler(this.TextBox_ProjectName_EditValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label9.Location = new System.Drawing.Point(20, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 21);
            this.label9.TabIndex = 49;
            this.label9.Text = "修改控制器数量为：";
            // 
            // Form_EditControlCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(420, 221);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form_EditControlCount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_NewProject";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_NewProject_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_NewProject_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_ProjectName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit TextBox_ProjectName;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private MyButton Button_Cancel;
        private MyButton Button_Save;
        private System.Windows.Forms.Panel panel1;
    }
}