namespace Quick_Order
{
    partial class Form_Report
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
            this.Panel_Botton = new System.Windows.Forms.Panel();
            this.CheckEdit_ShowPanelPicture = new DevExpress.XtraEditors.CheckEdit();
            this.Button_Print = new System.Windows.Forms.Button();
            this.Button_ExportExcel = new System.Windows.Forms.Button();
            this.Panel_Title = new System.Windows.Forms.Panel();
            this.pictureBox_CloseForm = new System.Windows.Forms.PictureBox();
            this.Panel_Checkbox_Sort = new System.Windows.Forms.Panel();
            this.Button_Checkbox_SortByDevice = new System.Windows.Forms.Button();
            this.Button_CheckBox_SortByPanel = new System.Windows.Forms.Button();
            this.Panel_Report = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();
            this.Panel_Botton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_ShowPanelPicture.Properties)).BeginInit();
            this.Panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CloseForm)).BeginInit();
            this.Panel_Checkbox_Sort.SuspendLayout();
            this.Panel_Report.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Botton
            // 
            this.Panel_Botton.Controls.Add(this.CheckEdit_ShowPanelPicture);
            this.Panel_Botton.Controls.Add(this.Button_Print);
            this.Panel_Botton.Controls.Add(this.Button_ExportExcel);
            this.Panel_Botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Botton.Location = new System.Drawing.Point(0, 668);
            this.Panel_Botton.Name = "Panel_Botton";
            this.Panel_Botton.Size = new System.Drawing.Size(1024, 52);
            this.Panel_Botton.TabIndex = 0;
            // 
            // CheckEdit_ShowPanelPicture
            // 
            this.CheckEdit_ShowPanelPicture.Location = new System.Drawing.Point(878, 5);
            this.CheckEdit_ShowPanelPicture.Name = "CheckEdit_ShowPanelPicture";
            this.CheckEdit_ShowPanelPicture.Properties.Caption = "显示控制器参考图";
            this.CheckEdit_ShowPanelPicture.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.CheckEdit_ShowPanelPicture.Properties.PictureChecked = global::Quick_Order.Properties.Resources.Icon_Checked;
            this.CheckEdit_ShowPanelPicture.Properties.PictureUnchecked = global::Quick_Order.Properties.Resources.Icon_UnChecked;
            this.CheckEdit_ShowPanelPicture.Size = new System.Drawing.Size(143, 40);
            this.CheckEdit_ShowPanelPicture.TabIndex = 50;
            this.CheckEdit_ShowPanelPicture.CheckedChanged += new System.EventHandler(this.CheckEdit_ShowPanelPicture_CheckedChanged);
            // 
            // Button_Print
            // 
            this.Button_Print.BackColor = System.Drawing.Color.Transparent;
            this.Button_Print.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.Button_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Print.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Button_Print.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.Button_Print.Image = global::Quick_Order.Properties.Resources.Icon_打印机;
            this.Button_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Print.Location = new System.Drawing.Point(147, 7);
            this.Button_Print.Name = "Button_Print";
            this.Button_Print.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Button_Print.Size = new System.Drawing.Size(120, 32);
            this.Button_Print.TabIndex = 14;
            this.Button_Print.TabStop = false;
            this.Button_Print.Text = "   打印";
            this.Button_Print.UseVisualStyleBackColor = false;
            this.Button_Print.Click += new System.EventHandler(this.Button_Print_Click);
            // 
            // Button_ExportExcel
            // 
            this.Button_ExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
            this.Button_ExportExcel.FlatAppearance.BorderSize = 0;
            this.Button_ExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_ExportExcel.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Button_ExportExcel.ForeColor = System.Drawing.Color.White;
            this.Button_ExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_ExportExcel.Location = new System.Drawing.Point(17, 7);
            this.Button_ExportExcel.Name = "Button_ExportExcel";
            this.Button_ExportExcel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Button_ExportExcel.Size = new System.Drawing.Size(120, 32);
            this.Button_ExportExcel.TabIndex = 13;
            this.Button_ExportExcel.TabStop = false;
            this.Button_ExportExcel.Text = "导出";
            this.Button_ExportExcel.UseVisualStyleBackColor = false;
            this.Button_ExportExcel.Click += new System.EventHandler(this.Button_ExportExcel_Click);
            // 
            // Panel_Title
            // 
            this.Panel_Title.Controls.Add(this.pictureBox_CloseForm);
            this.Panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Title.Location = new System.Drawing.Point(0, 0);
            this.Panel_Title.Name = "Panel_Title";
            this.Panel_Title.Size = new System.Drawing.Size(1024, 31);
            this.Panel_Title.TabIndex = 1;
            this.Panel_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Top_MouseDown);
            // 
            // pictureBox_CloseForm
            // 
            this.pictureBox_CloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_CloseForm.Image = global::Quick_Order.Properties.Resources.pic_close;
            this.pictureBox_CloseForm.Location = new System.Drawing.Point(968, 0);
            this.pictureBox_CloseForm.Name = "pictureBox_CloseForm";
            this.pictureBox_CloseForm.Size = new System.Drawing.Size(31, 31);
            this.pictureBox_CloseForm.TabIndex = 4;
            this.pictureBox_CloseForm.TabStop = false;
            this.pictureBox_CloseForm.Click += new System.EventHandler(this.pictureBox_CloseForm_Click_1);
            // 
            // Panel_Checkbox_Sort
            // 
            this.Panel_Checkbox_Sort.Controls.Add(this.Button_Checkbox_SortByDevice);
            this.Panel_Checkbox_Sort.Controls.Add(this.Button_CheckBox_SortByPanel);
            this.Panel_Checkbox_Sort.Location = new System.Drawing.Point(810, 63);
            this.Panel_Checkbox_Sort.Name = "Panel_Checkbox_Sort";
            this.Panel_Checkbox_Sort.Size = new System.Drawing.Size(148, 25);
            this.Panel_Checkbox_Sort.TabIndex = 2;
            // 
            // Button_Checkbox_SortByDevice
            // 
            this.Button_Checkbox_SortByDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Button_Checkbox_SortByDevice.FlatAppearance.BorderSize = 0;
            this.Button_Checkbox_SortByDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Checkbox_SortByDevice.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Button_Checkbox_SortByDevice.ForeColor = System.Drawing.Color.Gray;
            this.Button_Checkbox_SortByDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Checkbox_SortByDevice.Location = new System.Drawing.Point(74, 0);
            this.Button_Checkbox_SortByDevice.Name = "Button_Checkbox_SortByDevice";
            this.Button_Checkbox_SortByDevice.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Button_Checkbox_SortByDevice.Size = new System.Drawing.Size(74, 25);
            this.Button_Checkbox_SortByDevice.TabIndex = 15;
            this.Button_Checkbox_SortByDevice.TabStop = false;
            this.Button_Checkbox_SortByDevice.Text = "设备  ↓";
            this.Button_Checkbox_SortByDevice.UseVisualStyleBackColor = false;
            this.Button_Checkbox_SortByDevice.Click += new System.EventHandler(this.Button_Checkbox_Device_Click);
            // 
            // Button_CheckBox_SortByPanel
            // 
            this.Button_CheckBox_SortByPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
            this.Button_CheckBox_SortByPanel.FlatAppearance.BorderSize = 0;
            this.Button_CheckBox_SortByPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CheckBox_SortByPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Button_CheckBox_SortByPanel.ForeColor = System.Drawing.Color.White;
            this.Button_CheckBox_SortByPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_CheckBox_SortByPanel.Location = new System.Drawing.Point(0, 0);
            this.Button_CheckBox_SortByPanel.Name = "Button_CheckBox_SortByPanel";
            this.Button_CheckBox_SortByPanel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Button_CheckBox_SortByPanel.Size = new System.Drawing.Size(74, 25);
            this.Button_CheckBox_SortByPanel.TabIndex = 14;
            this.Button_CheckBox_SortByPanel.TabStop = false;
            this.Button_CheckBox_SortByPanel.Text = "控制器  ↓";
            this.Button_CheckBox_SortByPanel.UseVisualStyleBackColor = false;
            this.Button_CheckBox_SortByPanel.Click += new System.EventHandler(this.Button_CheckBox_Panel_Click);
            // 
            // Panel_Report
            // 
            this.Panel_Report.Controls.Add(this.panel1);
            this.Panel_Report.Controls.Add(this.printControl1);
            this.Panel_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Report.Location = new System.Drawing.Point(0, 31);
            this.Panel_Report.Name = "Panel_Report";
            this.Panel_Report.Size = new System.Drawing.Size(1024, 637);
            this.Panel_Report.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 17);
            this.panel1.TabIndex = 1;
            // 
            // printControl1
            // 
            this.printControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.printControl1.ForeColor = System.Drawing.Color.Empty;
            this.printControl1.IsMetric = true;
            this.printControl1.Location = new System.Drawing.Point(0, 0);
            this.printControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.printControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.printControl1.Name = "printControl1";
            this.printControl1.PageBorderVisibility = DevExpress.XtraPrinting.Control.PageBorderVisibility.None;
            this.printControl1.ShowPageMargins = false;
            this.printControl1.Size = new System.Drawing.Size(1024, 637);
            this.printControl1.TabIndex = 0;
            this.printControl1.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.printControl1.Visible = false;
            // 
            // Form_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.Panel_Checkbox_Sort);
            this.Controls.Add(this.Panel_Report);
            this.Controls.Add(this.Panel_Title);
            this.Controls.Add(this.Panel_Botton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form_Report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Report";
            this.Load += new System.EventHandler(this.Form_Report_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Report_KeyDown);
            this.Panel_Botton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_ShowPanelPicture.Properties)).EndInit();
            this.Panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CloseForm)).EndInit();
            this.Panel_Checkbox_Sort.ResumeLayout(false);
            this.Panel_Report.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Botton;
        private System.Windows.Forms.Button Button_Print;
        private System.Windows.Forms.Button Button_ExportExcel;
        private DevExpress.XtraEditors.CheckEdit CheckEdit_ShowPanelPicture;
        private System.Windows.Forms.Panel Panel_Title;
        private System.Windows.Forms.PictureBox pictureBox_CloseForm;
        private System.Windows.Forms.Panel Panel_Checkbox_Sort;
        private System.Windows.Forms.Button Button_Checkbox_SortByDevice;
        private System.Windows.Forms.Button Button_CheckBox_SortByPanel;
        private System.Windows.Forms.Panel Panel_Report;
        private DevExpress.XtraPrinting.Control.PrintControl printControl1;
        private System.Windows.Forms.Panel panel1;
    }
}