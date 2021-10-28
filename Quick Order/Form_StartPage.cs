using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Quick_Order
{
    public partial class Form_StartPage : Form
    {
        public Form_StartPage()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            InitializeComponent();

            CommonUsages.Init();            
        }

        private void Form_StartPage_Load(object sender, EventArgs e)
        {
            try
            {
                CommonUsages.RecentProjectClassInst = new Quick_Order.RecentProjectClass();
                DBClass.GetInstance();

                CustomFonts.GetInstance().SetFontToCtrlRecursion(this);
                gridControl1.Font = CustomFonts.GetInstance().GetFont0(gridControl1.Font.Size, gridControl1.Font.Bold);
                gridView1.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(gridView1.Appearance.FocusedRow.Font.Size, gridView1.Appearance.FocusedRow.Font.Bold);
                gridView1.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(gridView1.Appearance.FocusedCell.Font.Size, gridView1.Appearance.FocusedCell.Font.Bold);
                gridView1.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(gridView1.Appearance.HeaderPanel.Font.Size, gridView1.Appearance.HeaderPanel.Font.Bold);
                gridView1.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(gridView1.Appearance.Row.Font.Size, gridView1.Appearance.Row.Font.Bold);
                
                SetForm();

                gridControl1.DataSource = CommonUsages.RecentProjectClassInst.RecentTable;
                RefreshHistoryGridView();

                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ee)
            {
                SplashScreenManager.CloseForm(false);
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Error);
            }
        }

        #region "标题栏"
        #region "winform中设置FormBorderStyle为None后点击任务栏自动最小化实现"
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);
        public void SetForm()
        {
            int WS_SYSMENU = 0x00080000; // 系统菜单
            int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮
            int windowLong = (GetWindowLong(new HandleRef(this, this.Handle), -16));
            SetWindowLong(new HandleRef(this, this.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义   
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作   
                return cp;
            }
        }
        #endregion

        #region "C#-Winform窗体类型为None，非最大化状态设置移动效果(鼠标拖动标题栏)"
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;
        private void Panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                return;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }
        #endregion

        private void pictureBoxMaxForm_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                pictureBoxMaxForm.Image = Properties.Resources.pic_nomalform;
                toolTip1.SetToolTip(pictureBoxMaxForm, "恢复");
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                pictureBoxMaxForm.Image = Properties.Resources.pic_max;
                toolTip1.SetToolTip(pictureBoxMaxForm, "最大化");
            }
        }

        private void Panel_Top_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pictureBoxMaxForm_Click(pictureBoxMaxForm, e);
        }

        private void pictureBox_MinForm_Click(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void pictureBox_CloseForm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要退出吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            //去掉标题栏的边框
            e.Cache.FillRectangle(Color.White, e.Bounds);
            e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect);
            // Draw the filter and sort buttons.
            foreach (DrawElementInfo info in e.Info.InnerElements)
            {
                if (!info.Visible) continue;
                ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
            }
            e.Graphics.DrawLine(new Pen(Color.FromArgb(216,216,216), 1), new Point(e.Bounds.X, e.Bounds.Bottom - 1), new Point(e.Bounds.Right + 1, e.Bounds.Bottom - 1));
            e.Handled = true;
        }      

        private void Button_NewProject_Click(object sender, EventArgs e)
        {
            CommonUsages.CurrentProjectPath = "";
            ShowEventMain();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == RecentProjectClass.COLNAME_RECENTPROJECT_EDITEEDTIME)
            {
                DateTime curTime;
                string timeString = e.Value.ToString();
                if (timeString == "")
                {
                    return;
                }
                if (DateTime.TryParse(timeString, out curTime)==false)
                {
                    return;
                }
                if (curTime.Date == DateTime.Now.Date)
                {
                    e.DisplayText = curTime.ToString("HH:mm");
                }
                else
                {
                    e.DisplayText = curTime.ToString("yyyy/MM/dd");
                }
            }
        }

        private void ShowEventMain()
        {
            Form_Main evtForm = new Form_Main();           
            evtForm.DoBackToStart = new Form_Main.BackToStartDelegate(UnHide);
            this.Hide();
            evtForm.Show();
        }

        private void UnHide()
        {
            RefreshHistoryGridView();
            this.Show();
        }

        private void RefreshHistoryGridView()
        {
            CommonUsages.RecentProjectClassInst.LoadRecentProjects();
            gridControl1.DataSource = CommonUsages.RecentProjectClassInst.RecentTable;
        }

        private void Button_OpenProject_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string tmpPath = openFileDialog1.FileName;
                if (tmpPath != "")
                {
                    CommonUsages.CurrentProjectPath = tmpPath;
                    ShowEventMain();
                }
                else
                {
                    CommonUsages.MyMsgBox("请先选择正确的文件。", CommonUsages.MsgBoxTypeEnum.Warning);
                }
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName== RecentProjectClass.COLNAME_RECENTPROJECT_PATH)
            {
                if (e.CellValue == null) return;
               
                string path = e.CellValue.ToString();
                string name = System.IO.Path.GetFileNameWithoutExtension(path);
                string folder = System.IO.Path.GetDirectoryName(path);
                StringFormat format0 = new StringFormat();
                format0.FormatFlags = StringFormatFlags.NoWrap;
                format0.Trimming = StringTrimming.EllipsisPath;
                format0.Alignment = StringAlignment.Near;
                format0.LineAlignment = StringAlignment.Near;
                Rectangle drawBoundsName = new Rectangle(1, e.Bounds.Y + 5, e.Bounds.Width, e.Bounds.Height / 2);
                Rectangle drawBoundsFolder = new Rectangle(1, e.Bounds.Y + 25, e.Bounds.Width, e.Bounds.Height / 2);

                e.Graphics.DrawString(name, new Font("Microsoft YaHei", 14, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(67, 67, 67)), drawBoundsName, format0);
                e.Graphics.DrawString(folder, new Font("Microsoft YaHei", 11, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(128, 128, 128)), drawBoundsFolder, format0);

                e.Handled = true;
            }
            
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                string tmpPath = gridView1.GetFocusedRowCellValue(RecentProjectClass.COLNAME_RECENTPROJECT_PATH).ToString();
                if (System.IO.File.Exists(tmpPath) == true)
                {
                    CommonUsages.CurrentProjectPath = tmpPath;
                    ShowEventMain();
                }
                else
                {
                    CommonUsages.MyMsgBox("该项目文件不存在。", CommonUsages.MsgBoxTypeEnum.Warning);
                }
            }
        }
    }
}
