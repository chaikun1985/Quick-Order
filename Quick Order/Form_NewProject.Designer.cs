namespace Quick_Order
{
    partial class Form_NewProject
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
            this.myButton1 = new Quick_Order.MyButton();
            this.TextBox_ProjectName = new DevExpress.XtraEditors.TextEdit();
            this.TextBox_ProjectFolder = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.Label_ProjectFolder = new System.Windows.Forms.Label();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_ProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_ProjectFolder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.Button_Cancel);
            this.panel2.Controls.Add(this.Button_Save);
            this.panel2.Controls.Add(this.myButton1);
            this.panel2.Controls.Add(this.TextBox_ProjectName);
            this.panel2.Controls.Add(this.TextBox_ProjectFolder);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.Label_ProjectFolder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 239);
            this.panel2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 182);
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
            this.Button_Cancel.Location = new System.Drawing.Point(199, 198);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(88, 28);
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
            this.Button_Save.Location = new System.Drawing.Point(312, 198);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(88, 28);
            this.Button_Save.TabIndex = 53;
            this.Button_Save.Text = "保存";
            this.Button_Save.UseVisualStyleBackColor = false;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // myButton1
            // 
            this.myButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
            this.myButton1.FlatAppearance.BorderSize = 0;
            this.myButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton1.ForeColor = System.Drawing.Color.White;
            this.myButton1.Location = new System.Drawing.Point(339, 130);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(61, 36);
            this.myButton1.TabIndex = 52;
            this.myButton1.Text = "浏览";
            this.myButton1.UseVisualStyleBackColor = false;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // TextBox_ProjectName
            // 
            this.TextBox_ProjectName.EditValue = "";
            this.TextBox_ProjectName.Location = new System.Drawing.Point(20, 50);
            this.TextBox_ProjectName.Name = "TextBox_ProjectName";
            this.TextBox_ProjectName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TextBox_ProjectName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_ProjectName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.TextBox_ProjectName.Properties.Appearance.Options.UseBackColor = true;
            this.TextBox_ProjectName.Properties.Appearance.Options.UseFont = true;
            this.TextBox_ProjectName.Properties.Appearance.Options.UseForeColor = true;
            this.TextBox_ProjectName.Properties.AutoHeight = false;
            this.TextBox_ProjectName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TextBox_ProjectName.Size = new System.Drawing.Size(380, 36);
            this.TextBox_ProjectName.TabIndex = 1;
            // 
            // TextBox_ProjectFolder
            // 
            this.TextBox_ProjectFolder.EditValue = "";
            this.TextBox_ProjectFolder.Enabled = false;
            this.TextBox_ProjectFolder.Location = new System.Drawing.Point(20, 130);
            this.TextBox_ProjectFolder.Name = "TextBox_ProjectFolder";
            this.TextBox_ProjectFolder.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TextBox_ProjectFolder.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_ProjectFolder.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.TextBox_ProjectFolder.Properties.Appearance.Options.UseBackColor = true;
            this.TextBox_ProjectFolder.Properties.Appearance.Options.UseFont = true;
            this.TextBox_ProjectFolder.Properties.Appearance.Options.UseForeColor = true;
            this.TextBox_ProjectFolder.Properties.AutoHeight = false;
            this.TextBox_ProjectFolder.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TextBox_ProjectFolder.Properties.ReadOnly = true;
            this.TextBox_ProjectFolder.Size = new System.Drawing.Size(318, 36);
            this.TextBox_ProjectFolder.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label9.Location = new System.Drawing.Point(20, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "更改项目名";
            // 
            // Label_ProjectFolder
            // 
            this.Label_ProjectFolder.AutoSize = true;
            this.Label_ProjectFolder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.Label_ProjectFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.Label_ProjectFolder.Location = new System.Drawing.Point(21, 111);
            this.Label_ProjectFolder.Name = "Label_ProjectFolder";
            this.Label_ProjectFolder.Size = new System.Drawing.Size(55, 14);
            this.Label_ProjectFolder.TabIndex = 17;
            this.Label_ProjectFolder.Tag = "Project Folder";
            this.Label_ProjectFolder.Text = "项目路径";
            // 
            // Form_NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(420, 239);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form_NewProject";
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox_ProjectFolder.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit TextBox_ProjectName;
        private DevExpress.XtraEditors.TextEdit TextBox_ProjectFolder;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label Label_ProjectFolder;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private MyButton Button_Cancel;
        private MyButton Button_Save;
        private MyButton myButton1;
        private System.Windows.Forms.Panel panel1;
    }
}