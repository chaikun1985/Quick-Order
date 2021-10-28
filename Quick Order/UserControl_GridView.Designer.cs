namespace Quick_Order
{
    partial class UserControl_GridView
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
            this.CustomScrollbar1 = new Quick_Order.CustomScrollbar();
            this.GridControl1 = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomScrollbar1
            // 
            this.CustomScrollbar1.BackColor = System.Drawing.Color.Transparent;
            this.CustomScrollbar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.CustomScrollbar1.LargeLength = 0;
            this.CustomScrollbar1.Location = new System.Drawing.Point(95, 0);
            this.CustomScrollbar1.Maximum = 100;
            this.CustomScrollbar1.Minimum = 0;
            this.CustomScrollbar1.MinimumSize = new System.Drawing.Size(5, 56);
            this.CustomScrollbar1.Name = "CustomScrollbar1";
            this.CustomScrollbar1.Size = new System.Drawing.Size(5, 600);
            this.CustomScrollbar1.SmallChange = 1;
            this.CustomScrollbar1.TabIndex = 0;
            this.CustomScrollbar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.CustomScrollbar1.Value = 0;
            this.CustomScrollbar1.Scroll += new System.EventHandler(this.CustomScrollbar1_Scroll);
            // 
            // GridControl1
            // 
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(0, 0);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(95, 600);
            this.GridControl1.TabIndex = 1;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.Appearance.Empty.BackColor = System.Drawing.Color.Black;
            this.GridView1.Appearance.Empty.Options.UseBackColor = true;
            this.GridView1.Appearance.Row.BackColor = System.Drawing.Color.Black;
            this.GridView1.Appearance.Row.Options.UseBackColor = true;
            this.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsBehavior.ReadOnly = true;
            this.GridView1.OptionsCustomization.AllowSort = false;
            this.GridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.GridView1.OptionsView.ShowColumnHeaders = false;
            this.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.OptionsView.ShowIndicator = false;
            this.GridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.GridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridView1_KeyDown);
            this.GridView1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.GridView1_MouseWheel);
            this.GridView1.RowCountChanged += new System.EventHandler(this.GridView1_RowCountChanged);
            // 
            // UserControl_GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl1);
            this.Controls.Add(this.CustomScrollbar1);
            this.Name = "UserControl_GridView";
            this.Size = new System.Drawing.Size(100, 600);
            this.Load += new System.EventHandler(this.UserControl_Gridview_Load);
            this.SizeChanged += new System.EventHandler(this.UserControl_Gridview_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomScrollbar CustomScrollbar1;
        private DevExpress.XtraGrid.GridControl GridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView1;
    }
}
