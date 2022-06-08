namespace Quick_Order
{
    partial class Form_StartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StartPage));
            this.Panel_Top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_CloseForm = new System.Windows.Forms.PictureBox();
            this.pictureBoxMaxForm = new System.Windows.Forms.PictureBox();
            this.pictureBox_MinForm = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_ProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ProjectPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LastEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Button_OpenProject = new System.Windows.Forms.Button();
            this.Button_NewProject = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CloseForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaxForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MinForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Top
            // 
            this.Panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Panel_Top.Controls.Add(this.label1);
            this.Panel_Top.Controls.Add(this.pictureBox_CloseForm);
            this.Panel_Top.Controls.Add(this.pictureBoxMaxForm);
            this.Panel_Top.Controls.Add(this.pictureBox_MinForm);
            this.Panel_Top.Controls.Add(this.pictureBox1);
            this.Panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Top.Location = new System.Drawing.Point(0, 0);
            this.Panel_Top.Name = "Panel_Top";
            this.Panel_Top.Size = new System.Drawing.Size(840, 78);
            this.Panel_Top.TabIndex = 0;
            this.Panel_Top.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Panel_Top_MouseDoubleClick);
            this.Panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Top_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(71, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quick Order";
            // 
            // pictureBox_CloseForm
            // 
            this.pictureBox_CloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_CloseForm.Image = global::Quick_Order.Properties.Resources.pic_close;
            this.pictureBox_CloseForm.Location = new System.Drawing.Point(809, 0);
            this.pictureBox_CloseForm.Name = "pictureBox_CloseForm";
            this.pictureBox_CloseForm.Size = new System.Drawing.Size(32, 30);
            this.pictureBox_CloseForm.TabIndex = 3;
            this.pictureBox_CloseForm.TabStop = false;
            this.pictureBox_CloseForm.Click += new System.EventHandler(this.pictureBox_CloseForm_Click);
            this.pictureBox_CloseForm.MouseEnter += new System.EventHandler(this.pictureBox_CloseForm_MouseEnter);
            this.pictureBox_CloseForm.MouseLeave += new System.EventHandler(this.pictureBox_CloseForm_MouseLeave);
            // 
            // pictureBoxMaxForm
            // 
            this.pictureBoxMaxForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMaxForm.Image = global::Quick_Order.Properties.Resources.pic_max;
            this.pictureBoxMaxForm.Location = new System.Drawing.Point(763, 0);
            this.pictureBoxMaxForm.Name = "pictureBoxMaxForm";
            this.pictureBoxMaxForm.Size = new System.Drawing.Size(32, 30);
            this.pictureBoxMaxForm.TabIndex = 2;
            this.pictureBoxMaxForm.TabStop = false;
            this.pictureBoxMaxForm.Click += new System.EventHandler(this.pictureBoxMaxForm_Click);
            this.pictureBoxMaxForm.MouseEnter += new System.EventHandler(this.pictureBoxMaxForm_MouseEnter);
            this.pictureBoxMaxForm.MouseLeave += new System.EventHandler(this.pictureBoxMaxForm_MouseLeave);
            // 
            // pictureBox_MinForm
            // 
            this.pictureBox_MinForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_MinForm.Image = global::Quick_Order.Properties.Resources.pic_min;
            this.pictureBox_MinForm.Location = new System.Drawing.Point(721, 0);
            this.pictureBox_MinForm.Name = "pictureBox_MinForm";
            this.pictureBox_MinForm.Size = new System.Drawing.Size(32, 30);
            this.pictureBox_MinForm.TabIndex = 1;
            this.pictureBox_MinForm.TabStop = false;
            this.pictureBox_MinForm.Click += new System.EventHandler(this.pictureBox_MinForm_Click);
            this.pictureBox_MinForm.MouseEnter += new System.EventHandler(this.pictureBox_MinForm_MouseEnter);
            this.pictureBox_MinForm.MouseLeave += new System.EventHandler(this.pictureBox_MinForm_MouseLeave);
            this.pictureBox_MinForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MinForm_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Quick_Order.Properties.Resources.QO_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(22, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 388);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(809, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(31, 388);
            this.panel5.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(252, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(588, 388);
            this.panel3.TabIndex = 16;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 51);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(588, 337);
            this.gridControl1.TabIndex = 15;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(233)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_ProjectName,
            this.gridColumn_ProjectPath,
            this.gridColumn_LastEditTime});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.RowHeight = 49;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_LastEditTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridView1_CustomDrawColumnHeader);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridColumn_ProjectName
            // 
            this.gridColumn_ProjectName.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.gridColumn_ProjectName.AppearanceHeader.Options.UseBackColor = true;
            this.gridColumn_ProjectName.Caption = "名称";
            this.gridColumn_ProjectName.FieldName = "ProjectName";
            this.gridColumn_ProjectName.Name = "gridColumn_ProjectName";
            this.gridColumn_ProjectName.Width = 204;
            // 
            // gridColumn_ProjectPath
            // 
            this.gridColumn_ProjectPath.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.gridColumn_ProjectPath.AppearanceHeader.Options.UseBackColor = true;
            this.gridColumn_ProjectPath.Caption = "名称";
            this.gridColumn_ProjectPath.FieldName = "ProjectPATH";
            this.gridColumn_ProjectPath.Name = "gridColumn_ProjectPath";
            this.gridColumn_ProjectPath.Visible = true;
            this.gridColumn_ProjectPath.VisibleIndex = 0;
            this.gridColumn_ProjectPath.Width = 425;
            // 
            // gridColumn_LastEditTime
            // 
            this.gridColumn_LastEditTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridColumn_LastEditTime.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn_LastEditTime.AppearanceCell.Options.UseFont = true;
            this.gridColumn_LastEditTime.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn_LastEditTime.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_LastEditTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_LastEditTime.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.gridColumn_LastEditTime.AppearanceHeader.Options.UseBackColor = true;
            this.gridColumn_LastEditTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_LastEditTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_LastEditTime.Caption = "编辑时间";
            this.gridColumn_LastEditTime.FieldName = "LastEditTime";
            this.gridColumn_LastEditTime.Name = "gridColumn_LastEditTime";
            this.gridColumn_LastEditTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn_LastEditTime.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn_LastEditTime.OptionsFilter.AllowFilter = false;
            this.gridColumn_LastEditTime.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridColumn_LastEditTime.Visible = true;
            this.gridColumn_LastEditTime.VisibleIndex = 1;
            this.gridColumn_LastEditTime.Width = 125;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(588, 51);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(0, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "最近编辑项目";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Button_OpenProject);
            this.panel2.Controls.Add(this.Button_NewProject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 388);
            this.panel2.TabIndex = 14;
            // 
            // Button_OpenProject
            // 
            this.Button_OpenProject.BackColor = System.Drawing.Color.White;
            this.Button_OpenProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_OpenProject.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Button_OpenProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
            this.Button_OpenProject.Location = new System.Drawing.Point(22, 118);
            this.Button_OpenProject.Name = "Button_OpenProject";
            this.Button_OpenProject.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Button_OpenProject.Size = new System.Drawing.Size(180, 38);
            this.Button_OpenProject.TabIndex = 13;
            this.Button_OpenProject.TabStop = false;
            this.Button_OpenProject.Text = "在电脑打开";
            this.Button_OpenProject.UseVisualStyleBackColor = false;
            this.Button_OpenProject.Click += new System.EventHandler(this.Button_OpenProject_Click);
            this.Button_OpenProject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_OpenProject_MouseDown);
            this.Button_OpenProject.MouseLeave += new System.EventHandler(this.Button_OpenProject_MouseLeave);
            // 
            // Button_NewProject
            // 
            this.Button_NewProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(194)))));
            this.Button_NewProject.FlatAppearance.BorderSize = 0;
            this.Button_NewProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_NewProject.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Button_NewProject.ForeColor = System.Drawing.Color.White;
            this.Button_NewProject.Image = global::Quick_Order.Properties.Resources.Icon_新建项目;
            this.Button_NewProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_NewProject.Location = new System.Drawing.Point(22, 40);
            this.Button_NewProject.Name = "Button_NewProject";
            this.Button_NewProject.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Button_NewProject.Size = new System.Drawing.Size(180, 38);
            this.Button_NewProject.TabIndex = 12;
            this.Button_NewProject.TabStop = false;
            this.Button_NewProject.Text = "   新建采购项目";
            this.Button_NewProject.UseVisualStyleBackColor = false;
            this.Button_NewProject.Click += new System.EventHandler(this.Button_NewProject_Click);
            this.Button_NewProject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_NewProject_MouseDown);
            this.Button_NewProject.MouseEnter += new System.EventHandler(this.Button_NewProject_MouseEnter);
            this.Button_NewProject.MouseLeave += new System.EventHandler(this.Button_NewProject_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "项目文件|*.qder";
            this.openFileDialog1.Title = "打开文件";
            // 
            // Form_StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 466);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_StartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_StartPage_Load);
            this.Panel_Top.ResumeLayout(false);
            this.Panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CloseForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaxForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MinForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_CloseForm;
        private System.Windows.Forms.PictureBox pictureBoxMaxForm;
        private System.Windows.Forms.PictureBox pictureBox_MinForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Button_NewProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ProjectPath;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LastEditTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Button_OpenProject;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel5;
    }
}

