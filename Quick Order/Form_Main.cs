using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using DevExpress.XtraSplashScreen;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;

namespace Quick_Order
{
    public partial class Form_Main : Form
    {
        public delegate void BackToStartDelegate();
        public BackToStartDelegate DoBackToStart;
        public int ComboBox_NewPanel_POMCount_OldIndex = 0;

        public Form_Main()
        {
            SplashScreenManager.ShowForm(null, typeof(Form_Wait), false, false, false);
            InitializeComponent();
            //InitFont();

            CustomStringFormatNear.FormatFlags = StringFormatFlags.NoWrap;
            CustomStringFormatNear.Trimming = StringTrimming.EllipsisPath;
            CustomStringFormatNear.Alignment = StringAlignment.Near;
            CustomStringFormatNear.LineAlignment = StringAlignment.Center;

            CustomStringFormatMiddle.FormatFlags = StringFormatFlags.NoWrap;
            CustomStringFormatMiddle.Trimming = StringTrimming.EllipsisPath;
            CustomStringFormatMiddle.Alignment = StringAlignment.Center;
            CustomStringFormatMiddle.LineAlignment = StringAlignment.Center;
        }

        private void InitFont()
        {
            CustomFonts.GetInstance().SetFontToCtrlRecursion(this);
            GridControl_FittingSettingsList.Font = CustomFonts.GetInstance().GetFont0(GridControl_FittingSettingsList.Font.Size, GridControl_FittingSettingsList.Font.Bold);
            GridView_FittingSettingsList.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_FittingSettingsList.Appearance.FocusedRow.Font.Size, GridView_FittingSettingsList.Appearance.FocusedRow.Font.Bold);
            GridView_FittingSettingsList.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_FittingSettingsList.Appearance.FocusedCell.Font.Size, GridView_FittingSettingsList.Appearance.FocusedCell.Font.Bold);
            GridView_FittingSettingsList.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_FittingSettingsList.Appearance.HeaderPanel.Font.Size, GridView_FittingSettingsList.Appearance.HeaderPanel.Font.Bold);
            GridView_FittingSettingsList.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_FittingSettingsList.Appearance.Row.Font.Size, GridView_FittingSettingsList.Appearance.Row.Font.Bold);

            GridControl_LeftPage_FittingBrand.Font = CustomFonts.GetInstance().GetFont0(GridControl_LeftPage_FittingBrand.Font.Size, GridControl_LeftPage_FittingBrand.Font.Bold);
            GridView_LeftPage_FittingSystem.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingSystem.Appearance.FocusedRow.Font.Size, GridView_LeftPage_FittingSystem.Appearance.FocusedRow.Font.Bold);
            GridView_LeftPage_FittingSystem.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingSystem.Appearance.FocusedCell.Font.Size, GridView_LeftPage_FittingSystem.Appearance.FocusedCell.Font.Bold);
            GridView_LeftPage_FittingSystem.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingSystem.Appearance.HeaderPanel.Font.Size, GridView_LeftPage_FittingSystem.Appearance.HeaderPanel.Font.Bold);
            GridView_LeftPage_FittingSystem.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingSystem.Appearance.Row.Font.Size, GridView_LeftPage_FittingSystem.Appearance.Row.Font.Bold);

            GridView_LeftPage_FittingBrandDetail.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingBrandDetail.Appearance.FocusedRow.Font.Size, GridView_LeftPage_FittingBrandDetail.Appearance.FocusedRow.Font.Bold);
            GridView_LeftPage_FittingBrandDetail.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingBrandDetail.Appearance.FocusedCell.Font.Size, GridView_LeftPage_FittingBrandDetail.Appearance.FocusedCell.Font.Bold);
            GridView_LeftPage_FittingBrandDetail.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingBrandDetail.Appearance.HeaderPanel.Font.Size, GridView_LeftPage_FittingBrandDetail.Appearance.HeaderPanel.Font.Bold);
            GridView_LeftPage_FittingBrandDetail.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_LeftPage_FittingBrandDetail.Appearance.Row.Font.Size, GridView_LeftPage_FittingBrandDetail.Appearance.Row.Font.Bold);

            GridControl_MiddleFittingList.Font = CustomFonts.GetInstance().GetFont0(GridControl_MiddleFittingList.Font.Size, GridControl_MiddleFittingList.Font.Bold);
            GridView_MiddleFittingList.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_MiddleFittingList.Appearance.FocusedRow.Font.Size, GridView_MiddleFittingList.Appearance.FocusedRow.Font.Bold);
            GridView_MiddleFittingList.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_MiddleFittingList.Appearance.FocusedCell.Font.Size, GridView_MiddleFittingList.Appearance.FocusedCell.Font.Bold);
            GridView_MiddleFittingList.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_MiddleFittingList.Appearance.HeaderPanel.Font.Size, GridView_MiddleFittingList.Appearance.HeaderPanel.Font.Bold);
            GridView_MiddleFittingList.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_MiddleFittingList.Appearance.Row.Font.Size, GridView_MiddleFittingList.Appearance.Row.Font.Bold);

            GridControl_PanelList.Font = CustomFonts.GetInstance().GetFont0(GridControl_PanelList.Font.Size, GridControl_PanelList.Font.Bold);
            GridView_PanelList.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelList.Appearance.FocusedRow.Font.Size, GridView_PanelList.Appearance.FocusedRow.Font.Bold);
            GridView_PanelList.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelList.Appearance.FocusedCell.Font.Size, GridView_PanelList.Appearance.FocusedCell.Font.Bold);
            GridView_PanelList.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelList.Appearance.HeaderPanel.Font.Size, GridView_PanelList.Appearance.HeaderPanel.Font.Bold);
            GridView_PanelList.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelList.Appearance.Row.Font.Size, GridView_PanelList.Appearance.Row.Font.Bold);

            GridControl_PanelMenu.Font = CustomFonts.GetInstance().GetFont0(GridControl_PanelMenu.Font.Size, GridControl_PanelMenu.Font.Bold);
            GridView_PanelMenu.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelMenu.Appearance.FocusedRow.Font.Size, GridView_PanelMenu.Appearance.FocusedRow.Font.Bold);
            GridView_PanelMenu.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelMenu.Appearance.FocusedCell.Font.Size, GridView_PanelMenu.Appearance.FocusedCell.Font.Bold);
            GridView_PanelMenu.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelMenu.Appearance.HeaderPanel.Font.Size, GridView_PanelMenu.Appearance.HeaderPanel.Font.Bold);
            GridView_PanelMenu.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelMenu.Appearance.Row.Font.Size, GridView_PanelMenu.Appearance.Row.Font.Bold);

            GridControl_PanelSettingList.Font = CustomFonts.GetInstance().GetFont0(GridControl_PanelSettingList.Font.Size, GridControl_PanelSettingList.Font.Bold);
            GridView_PanelSettingList.Appearance.FocusedRow.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelSettingList.Appearance.FocusedRow.Font.Size, GridView_PanelSettingList.Appearance.FocusedRow.Font.Bold);
            GridView_PanelSettingList.Appearance.FocusedCell.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelSettingList.Appearance.FocusedCell.Font.Size, GridView_PanelSettingList.Appearance.FocusedCell.Font.Bold);
            GridView_PanelSettingList.Appearance.HeaderPanel.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelSettingList.Appearance.HeaderPanel.Font.Size, GridView_PanelSettingList.Appearance.HeaderPanel.Font.Bold);
            GridView_PanelSettingList.Appearance.Row.Font = CustomFonts.GetInstance().GetFont0(GridView_PanelSettingList.Appearance.Row.Font.Size, GridView_PanelSettingList.Appearance.Row.Font.Bold);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            ShowProjectMenu(false);

            XtraTabControl_LeftPage.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            XtraTabControl_MainPage.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            XtraTabControl_RightPage.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            GridControl_PanelList.DataSource = DBClass.GetInstance().ProjectMemoryTable;
            GridView_PanelList.ActiveFilterString = string.Format("[Cat] = 'Panel'");
            GridControl_PanelMenu.DataSource = DBClass.GetInstance().ProjectMemoryTable;
            GridView_PanelMenu.ActiveFilterString = string.Format("[Cat] = 'Panel'");


            GridControl_LeftPage_FittingBrand.DataSource = CommonUsages.SystemTable;
            if (GridView_LeftPage_FittingSystem.RowCount > 0)
            {
                GridView_LeftPage_FittingSystem.ExpandMasterRow(0, 0);
            }

            GridControl_MiddleFittingList.DataSource = CommonUsages.FittingPriceTable;

            GridControl_PanelSettingList.DataSource = DBClass.GetInstance().ModelSettingsMemoryTable;
            GridView_PanelSettingList.ActiveFilterString = string.Format("[Cat] = 'Panel'"); ;
            GridControl_FittingSettingsList.DataSource = DBClass.GetInstance().ModelSettingsMemoryTable;
            GridView_FittingSettingsList.ActiveFilterString = string.Format("[Cat] = 'Fittings'"); ;

            OpenProject(CommonUsages.CurrentProjectPath);

            Label_TabHeader_Panel_Click(Label_TabHeader_Panel, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

            AddCustomClickToCtrlRecursion(this);

            rItemComboBox_MiddleFittings_Count.Items.Clear();
            for (int ii = 0; ii <= 100; ii++)
                rItemComboBox_MiddleFittings_Count.Items.Add(ii);

            PictureSize.Add("LCM-2PG", FrontOpenLCMSize);
            PictureSize.Add("NCM-F-6P", new Size(39, 30));//光纤网卡
            PictureSize.Add("NCM-WF-6P", FrontOpenNetCardMediumSize); //中速网卡
            PictureSize.Add("NCM-W-6P", FrontOpenNetCardLowSize);//低速网卡
            PictureSize.Add("LPI-MODBUS-V3", new Size(39, 30)); //回路设备接口卡 
            PictureSize.Add("FECBUS", new Size(39, 30)); //FECBUS
            PictureSize.Add("uPRT-6P-KIT", new Size(39, 13)); //打印机
            PictureSize.Add("BB-6000P", FrontOpenBlackBoxSize); //黑盒子

            SplashScreenManager.CloseForm(false);
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
                pictureBoxMaxForm.Image = Properties.Resources.pic_min1;
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

        #region "Project"
        private void OpenProject(string curProjectPath)
        {
            if (curProjectPath == "")
            {
                Label_Title.Text = CommonUsages.SoftwareName;
                Label_ProjectName.Text = "新建项目";
                CloseProject();
                return;
            }

            //Load datas to table
            string errMsg = "";
            bool result = DBClass.GetInstance().LoadAllDataToMemory(curProjectPath, ref errMsg);
            if (result == false)
            {
                SplashScreenManager.CloseForm(false);
                CommonUsages.MyMsgBox(errMsg, CommonUsages.MsgBoxTypeEnum.Error);
                return;
            }

            string curName = Path.GetFileNameWithoutExtension(curProjectPath);
            Label_Title.Text = string.Format("{0}_{1}", CommonUsages.SoftwareName, curName);
            Label_ProjectName.Text = curName;

            if (GridView_PanelList.RowCount > 0)
                GridView_PanelList.FocusedRowHandle = 0;

            CommonUsages.RecentProjectClassInst.RefreshProjectEditTime(curProjectPath);
        }

        private void PictureBox_SaveProject_Click(object sender, EventArgs e)
        {
            //if (!System.IO.File.Exists(Form_NewProject.SelectedProjectPath))
            //{
            //File.Delete();
            //Form_NewProject newForm = new Form_NewProject();
            //newForm.Button_Save.Text = "另存";
            //newForm.TextBox_ProjectName.Text = Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
            //newForm.TextBox_ProjectFolder.Text = Path.GetDirectoryName(CommonUsages.CurrentProjectPath);
            //if (newForm.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            
            //if (!System.IO.File.Exists(Form_NewProject.SelectedProjectPath))
            //{
            //    //删掉已经更新的文件
            //    File.Delete(CommonUsages.CurrentProjectPath);
            //    CommonUsages.RecentProjectClassInst.DeleteProjectrow(CommonUsages.CurrentProjectPath);

            //    string errMsg = "";
            //    if (NewAProject(Form_NewProject.SelectedProjectPath, ref errMsg) == false)
            //    {
            //        CommonUsages.MyMsgBox(string.Format("新建项目出错。 {0}", errMsg), CommonUsages.MsgBoxTypeEnum.Error);
            //        return;
            //    }
            //}
            //}
            //目前这里只是单纯的保存功能
            SaveProject();
        }

        private void userControl_MenuItem_Save_Click(object sender, EventArgs e)
        {
            PictureBox_SaveProject_Click(PictureBox_SaveProject, e);
        }

        private bool NewAProject(string newProjectPath, ref string errMsg)
        {
            CommonUsages.CurrentProjectPath = newProjectPath;

            SQLiteCreatClassProject.SQLiteCreatClassInit(newProjectPath);

            string curName = Path.GetFileNameWithoutExtension(newProjectPath);
            Label_Title.Text = string.Format("{0}_{1}", CommonUsages.SoftwareName, curName);
            Label_ProjectName.Text = curName;

            if (DBClass.GetInstance().LoadSqliteTableDatas(newProjectPath, ref errMsg) == false) return false;

            CommonUsages.RecentProjectClassInst.AddANewProject(newProjectPath);
            return true;
        }

        private void CloseProject()
        {
            DBClass.GetInstance().InitTableData();
        }

        private void SaveProject()
        {
            SplashScreenManager.ShowForm(null, typeof(Form_Wait), false, false, false);

            string errMsg = "";
            bool result = DBClass.GetInstance().SaveAllDataToSqlite(CommonUsages.CurrentProjectPath, ref errMsg);

            CommonUsages.RecentProjectClassInst.RefreshProjectEditTime(CommonUsages.CurrentProjectPath);

            SplashScreenManager.CloseForm(false);

            if (result == false) CommonUsages.MyMsgBox(errMsg, CommonUsages.MsgBoxTypeEnum.Error);

            AddTitleFix(false);
        }

        #endregion

        #region "页面切换"
        private void pictureBox_CloseForm_Click(object sender, EventArgs e)
        {
            if (Label_Title.Text.EndsWith("*") == true)
            {
                string msg = "还有未保存的修改，确认要现在退出程序吗？";
                if (MessageBox.Show(this, msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                return;
            }

            if (MessageBox.Show("确认要退出吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void PictureBox_Home_Click(object sender, EventArgs e)
        {
            if (Label_Title.Text.EndsWith("*") == true)
            {
                string msg = "还有未保存的修改，确认返回上级页面吗？";
                if (MessageBox.Show(this, msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }

            DoBackToStart?.Invoke();
            DBClass.GetInstance().ModelSettingsMemoryTable.Clear();
            DBClass.GetInstance().ProjectMemoryTable.Clear();
            
            this.Close();
        }

        private void Label_TabHeader_Panel_Click(object sender, EventArgs e)
        {
            Label_TabHeader_Panel.ForeColor = Color.Black;
            Label_TabHeader_Fittings.ForeColor = Color.FromArgb(96, 96, 96);
            Panel_TabHeader_Focus.Location = new Point(0, 38);
            // Panel_TabHeader_Focus.Location = new Point(151, 44);

            XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_Panel;
            XtraTabControl_MainPage.SelectedTabPage = XtraTabPage_MainPage_Panel;
            XtraTabControl_RightPage.SelectedTabPage = XtraTabPage_RightPage_PanelList;
        }

        private void Label_TabHeader_Cards_Click(object sender, EventArgs e)
        {
            Label_TabHeader_Panel.ForeColor = Color.FromArgb(96, 96, 96);
            Label_TabHeader_Fittings.ForeColor = Color.Black;
            Panel_TabHeader_Focus.Location = new Point(116, 38);

            XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_Fittings;
            XtraTabControl_MainPage.SelectedTabPage = XtraTabPage_MainPage_Fittings;
            XtraTabControl_RightPage.SelectedTabPage = XtraTabPage_RightPage_FittingsList;

            PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Menu;
            PictureBox_ConetextMenu.Tag = "Menu";
        }

        private void Button_NewPanelSettings_Click(object sender, EventArgs e)
        {
            Form_NewPanelType form_new = new Quick_Order.Form_NewPanelType();
            if (form_new.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
            PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
            PictureBox_ConetextMenu.Tag = "Back";
            CheckEdit_NewPanelPrinter.Checked = false;
            CheckEdit_NewPanelBlackBox.Checked = false;

            Int64 id = DBClass.GetInstance().GetCurrentMaxProjectID();
            if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                CurrentPanelSettings = new Quick_Order.N6000PPanelSettings(id, Form_NewPanelType.SelectedProjectLabel);
            }
            if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                CurrentPanelSettings = new Quick_Order.N6000PBiGuaSettings(id, Form_NewPanelType.SelectedProjectLabel);
            }

            DBClass.GetInstance().AddANewPanel(CurrentPanelSettings);
            GridView_PanelList.FocusedRowHandle = GridView_PanelList.RowCount - 1;
            AddTitleFix(true);
        }

        private void Button_Menu_NewPanelSettings_Click(object sender, EventArgs e)
        {
            Form_NewPanelType form_new = new Quick_Order.Form_NewPanelType();
            if (form_new.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            CheckEdit_NewPanelPrinter.Checked = false;
            CheckEdit_NewPanelBlackBox.Checked = false;

            Int64 id = DBClass.GetInstance().GetCurrentMaxProjectID();
            if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                CurrentPanelSettings = new N6000PPanelSettings(id, Form_NewPanelType.SelectedProjectLabel);
            }
            if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                CurrentPanelSettings = new N6000PBiGuaSettings(id, Form_NewPanelType.SelectedProjectLabel);
            }

            DBClass.GetInstance().AddANewPanel(CurrentPanelSettings);
            GridView_PanelList.FocusedRowHandle = GridView_PanelList.RowCount - 1;
            AddTitleFix(true);
        }

        private void PictureBox_ConetextMenu_Click(object sender, EventArgs e)
        {
            if (PictureBox_ConetextMenu.Tag.ToString() == "Back")
            {
                XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_Panel;
                PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Menu;
                PictureBox_ConetextMenu.Tag = "Menu";
                return;
            }

            if (PictureBox_ConetextMenu.Tag.ToString() == "Menu")
            {
                Panel_MainMenu.Location = new Point(0, 32);
                Panel_MainMenu.Visible = true;
            }
        }

        private void PictureBox_ConetextMenu2_Click(object sender, EventArgs e)
        {
            Panel_MainMenu.Visible = false;
        }

        private void ShowProjectMenu(bool show)
        {
            if (show == true)
            {
                Panel_ProjectMenu.Height = 312;
                Panel_Line_MenuLeft.Visible = true;
                Panel_Line_MenuTop.Visible = true;
                Panel_Line_MenuRight.Visible = true;
                Panel_Line_MenuRightTop.Visible = true;
                Panel_Line_MenuDownLeft.Visible = true;
                Panel_Line_MenuDownRight.Visible = true;
                Panel_Line_MenuDownBottom.Visible = true;
            }
            else
            {
                Panel_ProjectMenu.Height = Panel_Menu_Top.Height;
                Panel_Line_MenuLeft.Visible = false;
                Panel_Line_MenuTop.Visible = false;
                Panel_Line_MenuRight.Visible = false;
                Panel_Line_MenuRightTop.Visible = false;
                Panel_Line_MenuDownLeft.Visible = false;
                Panel_Line_MenuDownRight.Visible = false;
                Panel_Line_MenuDownBottom.Visible = false;
            }
        }

        private void XtraTabControl_LeftPage_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            ShowProjectMenu(false);

            if (XtraTabControl_LeftPage.SelectedTabPage == XtraTabPage_LeftPage_Panel)
            {
                PictureBox_Menu_Xiala.Visible = false;
            }
            if (XtraTabControl_LeftPage.SelectedTabPage == XtraTabPage_LeftPage_SpecPanel)
            {
                PictureBox_Menu_Xiala.Visible = true;
            }
            if (XtraTabControl_LeftPage.SelectedTabPage == XtraTabPage_LeftPage_Fittings)
            {
                PictureBox_Menu_Xiala.Visible = false;
            }
        }

        private void PictureBox_Menu_Xiala_Click(object sender, EventArgs e)
        {
            if (Panel_ProjectMenu.Height == Panel_Menu_Top.Height)
            {
                ShowProjectMenu(true);
            }
            else
            {
                ShowProjectMenu(false);
            }
        }

        private void Label_ProjectName_Click(object sender, EventArgs e)
        {
            if (PictureBox_Menu_Xiala.Visible == true)
                InvokeOnClick(PictureBox_Menu_Xiala, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
        }

        private void GridView_PanelMenu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //sync to GridView_PanelList
        }

        private void GridView_PanelMenu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //No use
            if (e.Clicks == 1)
            {
                Int64 curID = Convert.ToInt64(GridView_PanelMenu.GetRowCellValue(e.RowHandle, "ID"));
                if (curID != CurrentPanelSettings.ID)  //no way
                {
                    if (MessageBox.Show(this, "确认要切换控制器页面吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int index = GridView_PanelMenu.FocusedRowHandle;

                        GridView_PanelList.FocusedRowHandle = index;
                    }
                }
            }
        }

        private void GridView_PanelMenu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Row)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                e.Handled = true;
            }
        }
        #endregion

        #region "左面页面"
        private void GridView_PanelList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Row)
            {
                if (e.RowHandle == GridView_PanelList.FocusedRowHandle || GridView_PanelList.IsRowSelected(e.RowHandle))
                {
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(23, 146, 229), 2), new Point(e.Bounds.Right - 2, e.Bounds.Top - 1), new Point(e.Bounds.Right - 2, e.Bounds.Bottom - 1));
                }
                e.Handled = true;
            }
        }

        private void GridView_PanelList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                Int64 panelID = Convert.ToInt64(GridView_PanelList.GetRowCellValue(e.FocusedRowHandle, "ID"));
                string cat = GridView_PanelList.GetRowCellValue(e.FocusedRowHandle, "Cat").ToString();
                if (cat != "Panel")
                {
                    CurrentPanelSettings = null;
                }
                else
                {
                    CurrentPanelSettings = DBClass.GetInstance().ReadPanelSettingsFromTable(panelID);
                }

                RefreshLeftSpecPanel();
                RefreshMainPage(AimPage.All);
                GridView_PanelSettingList.ActiveFilterString = string.Format("[ItemID] = '{0}'", panelID);

                Panel_Pages.Visible = true;
                GridControl_PanelSettingList.Visible = true;
            }
            else
            {
                Panel_Pages.Visible = false;
                GridControl_PanelSettingList.Visible = false;
            }
        }

        private void rItemButtonEdit_PanelEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (GridView_PanelList.SelectedRowsCount == 1)
            {
                Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));

                XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
                PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
                PictureBox_ConetextMenu.Tag = "Back";

                CurrentPanelSettings = DBClass.GetInstance().ReadPanelSettingsFromTable(id);

                RefreshLeftSpecPanel();
                RefreshMainPage(AimPage.All);
                GridView_PanelSettingList.ActiveFilterString = string.Format("[ItemID] = '{0}'", id);
            }
        }

        private void rItemButtonEdit_PanelDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (GridView_PanelList.SelectedRowsCount == 1)
            {
                Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));
                string warnString = string.Format("确认要删除当前控制器吗？");
                if (MessageBox.Show(warnString, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DBClass.GetInstance().DeleteAPanel(id);

                    AddTitleFix(true);
                }
            }
        }




        #region "配件brand"
        private void GridView_LeftPage_FittingSystem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void TextEdit_SearchFittingsType_EditValueChanged(object sender, EventArgs e)
        {
            GridControl_LeftPage_FittingBrand.FocusedView = GridView_LeftPage_FittingSystem;
            GridView_LeftPage_FittingBrandDetail.FocusedRowHandle = -1;

            string filterString = string.Format("[Model] like '{0}%'", TextEdit_SearchFittingsType.Text);
            GridView_MiddleFittingList.ActiveFilterString = filterString;
        }

        private void GridControl_LeftPage_FittingBrand_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            TextEdit_SearchFittingsType.Text = "";
            if (e.View == null) return;
            if (e.View.IsDetailView == true)
            {
                DevExpress.XtraGrid.Views.Grid.GridView dView = GridView_LeftPage_FittingSystem.GetDetailView(GridView_LeftPage_FittingSystem.FocusedRowHandle, 0) as DevExpress.XtraGrid.Views.Grid.GridView;
                if (dView == null) return;
                if (dView.RowCount > 0)
                {
                    dView.FocusedRowHandle = 0;
                    string brand = dView.GetFocusedRowCellValue("Brand").ToString();
                    string systemName = dView.GetFocusedRowCellValue("SystemName").ToString();
                    string filterString = string.Format("[Brand] = '{0}' And [SystemName] = '{1}'", brand, systemName);
                    GridView_MiddleFittingList.ActiveFilterString = filterString;
                }
            }
            else
            {
                DevExpress.XtraGrid.Views.Grid.GridView dView = e.PreviousView as DevExpress.XtraGrid.Views.Grid.GridView;
                dView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GridView_LeftPage_FittingBrandDetail_CustomDrawCell);
                GridView_LeftPage_FittingSystem.RefreshData();
                //string systemName = GridView_LeftPage_FittingSystem.GetFocusedRowCellValue("SystemName").ToString();
                //string filterString = string.Format("[SystemName] = '{0}'", systemName);
                //GridView_MiddleFittingList.ActiveFilterString = filterString;
            }
        }

        private void GridView_LeftPage_FittingSystem_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            TextEdit_SearchFittingsType.Text = "";
            DevExpress.XtraGrid.Views.Grid.GridView dView = GridView_LeftPage_FittingSystem.GetDetailView(e.RowHandle, 0) as DevExpress.XtraGrid.Views.Grid.GridView;
            if (dView == null) return;
            dView.Appearance.FocusedRow.BackColor = Color.FromArgb(23, 146, 229);
            dView.Appearance.FocusedCell.BackColor = Color.FromArgb(23, 146, 229);
            dView.Columns["SystemName"].Visible = false;
            dView.Columns["Brand"].OptionsColumn.ReadOnly = true;
            dView.Columns["Brand"].OptionsColumn.AllowEdit = false;
            dView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(GridView_LeftPage_FittingBrandDetail_FocusedRowChanged);
        }

        private void GridView_LeftPage_FittingBrandDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TextEdit_SearchFittingsType.Text = "";
            DevExpress.XtraGrid.Views.Grid.GridView dView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (dView == null) return;
            string brand = dView.GetFocusedRowCellValue("Brand").ToString();
            string systemName = dView.GetFocusedRowCellValue("SystemName").ToString();
            string filterString = string.Format("[Brand] = '{0}' And [SystemName] = '{1}'", brand, systemName);
            GridView_MiddleFittingList.ActiveFilterString = filterString;
        }

        private void rItemButtonEdit_LeftPage_FittingPicture_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (GridView_LeftPage_FittingSystem.GetMasterRowExpanded(GridView_LeftPage_FittingSystem.FocusedRowHandle))
            {
                GridView_LeftPage_FittingSystem.CollapseMasterRow(GridView_LeftPage_FittingSystem.FocusedRowHandle);
            }
            else
            {
                GridView_LeftPage_FittingSystem.ExpandMasterRow(GridView_LeftPage_FittingSystem.FocusedRowHandle);
                string systemName = GridView_LeftPage_FittingSystem.GetFocusedRowCellValue("SystemName").ToString();
                string filterString = string.Format("[SystemName] = '{0}'", systemName);
                GridView_MiddleFittingList.ActiveFilterString = filterString;
            }
        }
        #endregion

        #endregion

        #region "Fill Main Page Pictures"
        // private string PictureName = string.Empty;
        private Dictionary<string, Size> PictureSize = new Dictionary<string, Size>();
        private List<Point> FrontPOMPrinterLocation = new List<Point> {new Point(0,0), new Point(0,0), new Point(31, 156), new Point(31, 198), new Point(31, 241), new Point(31, 282),
                                               new Point(31, 328), new Point(31, 370), new Point(31, 413), new Point(31, 453)};
        private Size FrontPOMACMSize = new Size(137, 33);

        private Size FrontPrinterSize = new Size(139, 35);

        private List<Point> FrontOpenLCMLocation = new List<Point> {new Point(0,0), new Point(0,0), new Point(86, 46), new Point(113, 46), new Point(140, 46),
                                                new Point(59, 134), new Point(86, 134), new Point(113, 134), new Point(140, 134)};
        private Size FrontOpenLCMSize = new Size(27, 31);

        private List<Point> FrontOpenBeibanLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(24, 126), new Point(24, 206), new Point(24, 286) };
        private Size FrontOpenBeibanSize = new Size(152, 61);
        private List<Point> FrontOpenXianChaoLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(24, 189), new Point(24, 269), new Point(24, 349) };
        private Size FrontOpenXianChaoSize = new Size(152, 19);

        private List<Point> FrontOpenLeft = new List<Point> { new Point(0, 0), new Point(26, 58), new Point(26, 141) };
        private Size FrontOpenNetCardLowSize = new Size(25, 37);
        private Size FrontOpenNetCardMediumSize = new Size(25, 37);   //new Size(25, 44)
        private Size FrontOpenBlackBoxSize = new Size(25, 37);

        private Point FrontOpenBaseBoardPoint = new Point(51, 160);
        private Size FrontOpenBaseBoardSize = new Size(123, 18);


        private List<Point> BackOpenBeibanLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(22, 178), new Point(22, 265), new Point(22, 333) };
        private Size BackOpenBeibanSize = new Size(156, 49);
        private List<Point> BackOpenXianChaoLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(22, 228), new Point(22, 247), new Point(22, 315), new Point(22, 383) };
        private Size BackOpenXianChaoSize = new Size(156, 19);

        private List<Point> BackLeftLocation = new List<Point> { new Point(0, 0), new Point(28, 110), new Point(28, 183), new Point(28, 270), new Point(28, 338) };
        private Size BackNetworkCardHighSize = new Size(65, 39);
        private Size BackLPIModbusSize = new Size(65, 39);
        private Size BackFecbusSize = new Size(65, 39);

        private List<Point> BackRightLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(95, 183), new Point(95, 270), new Point(95, 338) };
        private Size BackPOMSize = new Size(76, 39);  //new Size(76, 42);


        private List<Point> BiGuaFrontPOMPrinterLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(31, 144), new Point(31, 185) };
        private Size BiGuaFrontPOMACMPrinterSize = new Size(137, 33);

        private List<Point> BiGuaFrontOpenLCMLocation = new List<Point> {new Point(0,0), new Point(0,0), new Point(89, 23), new Point(116, 23), new Point(143, 23),
                                                new Point(62, 95), new Point(89, 95), new Point(116, 95), new Point(143, 95)};
        private Point BiGuaFrontOpenBaseBoardPoint = new Point(55, 126);

        private List<Point> BiGuaFrontOpenBeibanLocation = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(17, 91), new Point(17, 164) };
        private Size BiGuaFrontOpenBeibanSize = new Size(166, 57);

        private List<Point> BiGuaFrontOpenLeft = new List<Point> { new Point(0, 0), new Point(25, 35), new Point(25, 107), new Point(25, 173) };
        private List<Point> BiGuaFrontOpenRight = new List<Point> { new Point(0, 0), new Point(0, 0), new Point(112, 104), new Point(112, 174) };

        enum AimPage
        {
            LeftPage,
            MiddlePage,
            RightPage,
            All,
            Inside
        }

        private void RefreshMainPage(AimPage pageNo)
        {
            if (CurrentPanelSettings == null) return;

            if (CurrentPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                PictureBox_BackBasic.Visible = true;
                lbInnerBack.Visible = true;
            }
            if (CurrentPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                PictureBox_BackBasic.Visible = false;
                lbInnerBack.Visible = false;
            }

            if (pageNo == AimPage.LeftPage || pageNo == AimPage.All)
            {
                if (CurrentPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    int acmPOMCount = CurrentPanelSettings.POMCount + CurrentPanelSettings.ACMCount + CurrentPanelSettings.PrinterCount;
                    if (acmPOMCount > 5)
                    {
                        PictureBox_FrontBasic.Image = Properties.Resources.主机正面_基础配置02;
                    }
                    else
                    {
                        PictureBox_FrontBasic.Image = Properties.Resources.主机正面_基础配置01;
                    }
                }
                if (CurrentPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    PictureBox_FrontBasic.Image = Properties.Resources._6000P_壁挂_主机正面_基础配置;
                }
                PictureBox_FrontBasic.Invalidate();
            }
            if (pageNo == AimPage.MiddlePage || pageNo == AimPage.All || pageNo == AimPage.Inside)
            {
                if (CurrentPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    PictureBox_FrontOpenBasic.Image = Properties.Resources.主机开机正面_基础配置;
                }
                if (CurrentPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    PictureBox_FrontOpenBasic.Image = Properties.Resources._6000P_壁挂_主机开机正面__基础配置;
                }
                PictureBox_FrontOpenBasic.Invalidate();
            }
            if (pageNo == AimPage.RightPage || pageNo == AimPage.All || pageNo == AimPage.Inside)
            {
                if (PictureBox_BackBasic.Visible == true)
                    PictureBox_BackBasic.Invalidate();
            }
        }

        public BasicPanelSettings CurrentPanelSettings = null;
        private void PictureBox_FrontBasic_Paint(object sender, PaintEventArgs e)
        {
            DrawFrontBasic(e.Graphics, CurrentPanelSettings);
        }

        private void PictureBox_FrontOpenBasic_Paint(object sender, PaintEventArgs e)
        {
            DrawFrontOpen(e.Graphics, CurrentPanelSettings);
        }

        private void PictureBox_BackBasic_Paint(object sender, PaintEventArgs e)
        {
            DrawBackBasic(e.Graphics, CurrentPanelSettings);
        }

        private void DrawFrontBasic(Graphics g, BasicPanelSettings curPanelSettings)
        {
            int index = 1;
            if (curPanelSettings != null)
            {
                if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    for (int ii = 2; ii <= curPanelSettings.POMCount; ii++)
                    {
                        index++;
                        g.DrawImage(Properties.Resources.主机正面_Pow, FrontPOMPrinterLocation[index].X, FrontPOMPrinterLocation[index].Y, FrontPOMACMSize.Width, FrontPOMACMSize.Height);
                    }
                    for (int ii = 1; ii <= curPanelSettings.ACMCount; ii++)
                    {
                        index++;
                        g.DrawImage(Properties.Resources.主机正面_ACM, FrontPOMPrinterLocation[index].X, FrontPOMPrinterLocation[index].Y, FrontPOMACMSize.Width, FrontPOMACMSize.Height);
                    }

                    if (curPanelSettings.PrinterCount > 0)
                    {
                        index++;
                        g.DrawImage(Properties.Resources.主机正面_打印机, FrontPOMPrinterLocation[index].X, FrontPOMPrinterLocation[index].Y, FrontPrinterSize.Width, FrontPrinterSize.Height);
                    }
                }

                if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    if (curPanelSettings.ACMCount > 0)
                    {
                        index++;
                        g.DrawImage(Properties.Resources.主机正面_ACM, BiGuaFrontPOMPrinterLocation[index].X, BiGuaFrontPOMPrinterLocation[index].Y, BiGuaFrontPOMACMPrinterSize.Width, BiGuaFrontPOMACMPrinterSize.Height);
                    }

                    if (curPanelSettings.PrinterCount > 0)
                    {
                        index++;
                        g.DrawImage(Properties.Resources.主机正面_打印机, BiGuaFrontPOMPrinterLocation[index].X, BiGuaFrontPOMPrinterLocation[index].Y, BiGuaFrontPOMACMPrinterSize.Width, BiGuaFrontPOMACMPrinterSize.Height);
                    }
                }
            }
        }

        private void DrawFrontOpen(Graphics g, BasicPanelSettings curPanelSettings)
        {
            //主机正面开门
            if (curPanelSettings != null)
            {
                if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    //画背板、线槽
                    int beibanCount = (curPanelSettings as N6000PPanelSettings).GetFrontOpenBeibanCount();
                    for (int ii = 2; ii <= beibanCount; ii++)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面__背板_有设备, FrontOpenBeibanLocation[ii].X, FrontOpenBeibanLocation[ii].Y, FrontOpenBeibanSize.Width, FrontOpenBeibanSize.Height);
                        g.DrawImage(Properties.Resources.主机开机正面__线槽_有设备, FrontOpenXianChaoLocation[ii].X, FrontOpenXianChaoLocation[ii].Y, FrontOpenXianChaoSize.Width, FrontOpenXianChaoSize.Height);
                    }

                    //画第二基板
                    if (curPanelSettings.LCMCardCount > 4)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_MB, FrontOpenBaseBoardPoint.X, FrontOpenBaseBoardPoint.Y, FrontOpenBaseBoardSize.Width, FrontOpenBaseBoardSize.Height);
                    }

                    //画LCM卡
                    for (int ii = 2; ii <= curPanelSettings.LCMCardCount; ii++)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_LCM, FrontOpenLCMLocation[ii].X, FrontOpenLCMLocation[ii].Y, FrontOpenLCMSize.Width, FrontOpenLCMSize.Height);
                    }

                    //画中低速网卡
                    if (curPanelSettings.NCMLowCount > 0)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_低速网卡, FrontOpenLeft[1].X, FrontOpenLeft[1].Y, FrontOpenNetCardLowSize.Width, FrontOpenNetCardLowSize.Height);
                    }
                    if (curPanelSettings.NCMMediumCount > 0)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_中速网卡, FrontOpenLeft[1].X, FrontOpenLeft[1].Y, FrontOpenNetCardMediumSize.Width, FrontOpenNetCardMediumSize.Height);
                    }

                    //画BB
                    if ((curPanelSettings as N6000PPanelSettings).HaveNCMLowMedium() == true && curPanelSettings.BlackBoxCount > 0)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_黑盒子, FrontOpenLeft[2].X, FrontOpenLeft[2].Y, FrontOpenBlackBoxSize.Width, FrontOpenBlackBoxSize.Height);
                    }
                    else
                    {
                        if (curPanelSettings.BlackBoxCount > 0)
                        {
                            g.DrawImage(Properties.Resources.主机开机正面_黑盒子, FrontOpenLeft[1].X, FrontOpenLeft[1].Y, FrontOpenBlackBoxSize.Width, FrontOpenBlackBoxSize.Height);
                        }

                    }
                }
                if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    //画背板、线槽
                    int beibanCount = (curPanelSettings as N6000PBiGuaSettings).GetFrontOpenBeibanCount();
                    for (int ii = 2; ii <= beibanCount; ii++)
                    {
                        g.DrawImage(Properties.Resources._6000P_壁挂_主机开机正面__背板, BiGuaFrontOpenBeibanLocation[ii].X, BiGuaFrontOpenBeibanLocation[ii].Y, BiGuaFrontOpenBeibanSize.Width, BiGuaFrontOpenBeibanSize.Height);
                    }

                    //画第二基板
                    if (curPanelSettings.LCMCardCount > 4)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_MB, BiGuaFrontOpenBaseBoardPoint.X, BiGuaFrontOpenBaseBoardPoint.Y, FrontOpenBaseBoardSize.Width, FrontOpenBaseBoardSize.Height);
                    }

                    //画LCM卡
                    for (int ii = 2; ii <= curPanelSettings.LCMCardCount; ii++)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_LCM, BiGuaFrontOpenLCMLocation[ii].X, BiGuaFrontOpenLCMLocation[ii].Y, FrontOpenLCMSize.Width, FrontOpenLCMSize.Height);
                    }

                    //画中低速网卡
                    if (curPanelSettings.NCMLowCount > 0)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_低速网卡, BiGuaFrontOpenLeft[1].X, BiGuaFrontOpenLeft[1].Y, FrontOpenNetCardLowSize.Width, FrontOpenNetCardLowSize.Height);
                    }
                    if (curPanelSettings.NCMMediumCount > 0)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_中速网卡, BiGuaFrontOpenLeft[1].X, BiGuaFrontOpenLeft[1].Y, FrontOpenNetCardMediumSize.Width, FrontOpenNetCardMediumSize.Height);
                    }

                    //画BB
                    if ((curPanelSettings as N6000PBiGuaSettings).HaveNCMLowMedium() == true && curPanelSettings.BlackBoxCount > 0)
                    {
                        g.DrawImage(Properties.Resources.主机开机正面_黑盒子, BiGuaFrontOpenLeft[2].X, BiGuaFrontOpenLeft[2].Y, FrontOpenBlackBoxSize.Width, FrontOpenBlackBoxSize.Height);
                    }
                    else
                    {
                        if (curPanelSettings.BlackBoxCount > 0)
                        {
                            g.DrawImage(Properties.Resources.主机开机正面_黑盒子, BiGuaFrontOpenLeft[1].X, BiGuaFrontOpenLeft[1].Y, FrontOpenBlackBoxSize.Width, FrontOpenBlackBoxSize.Height);
                        }
                        //g.DrawImage(Properties.Resources.主机开机正面_黑盒子, BiGuaFrontOpenLeft[1].X, BiGuaFrontOpenLeft[1].Y, FrontOpenBlackBoxSize.Width, FrontOpenBlackBoxSize.Height);
                    }

                    //画POM卡
                    int pomPOSBoard = (curPanelSettings as N6000PBiGuaSettings).GetPOMPositionBoard();
                    if (pomPOSBoard == 2)
                    {
                        g.DrawImage(Properties.Resources.主机背面__POM, BiGuaFrontOpenLeft[2].X, BiGuaFrontOpenLeft[2].Y, BackPOMSize.Width, BackPOMSize.Height);
                    }
                    else
                    {
                        g.DrawImage(Properties.Resources.主机背面__POM, BiGuaFrontOpenLeft[3].X, BiGuaFrontOpenLeft[3].Y, BackPOMSize.Width, BackPOMSize.Height);
                    }

                    //画高速网卡、LPI、Fecbus复合卡
                    int nonePomIndex = 0;
                    Point nonePOMPoint = new Point(BiGuaFrontOpenRight[3].X, BiGuaFrontOpenRight[3].Y);
                    for (int ii = 1; ii <= curPanelSettings.LPIModbusCount; ii++)
                    {
                        nonePomIndex++;
                        nonePOMPoint = GetNonePOMPositionBiGua(nonePomIndex, pomPOSBoard);
                        g.DrawImage(Properties.Resources.LPI_modbus_3_0_1, nonePOMPoint.X, nonePOMPoint.Y, BackLPIModbusSize.Width, BackLPIModbusSize.Height);
                    }
                    for (int ii = 1; ii <= curPanelSettings.FecbusModuleCount; ii++)
                    {
                        nonePomIndex++;
                        nonePOMPoint = GetNonePOMPositionBiGua(nonePomIndex, pomPOSBoard);
                        g.DrawImage(Properties.Resources.主机背面__Model, nonePOMPoint.X, nonePOMPoint.Y, BackLPIModbusSize.Width, BackLPIModbusSize.Height);
                    }
                    for (int ii = 1; ii <= curPanelSettings.NCMHighCount; ii++)
                    {
                        nonePomIndex++;
                        nonePOMPoint = GetNonePOMPositionBiGua(nonePomIndex, pomPOSBoard);
                        g.DrawImage(Properties.Resources.主机背面___光纤网卡, nonePOMPoint.X, nonePOMPoint.Y, BackLPIModbusSize.Width, BackLPIModbusSize.Height);
                    }
                }
            }
        }

        private void DrawBackBasic(Graphics g, BasicPanelSettings curPanelSettings)
        {
            //主机背面
            if (curPanelSettings != null)
            {
                if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    //画背板
                    int beibanCount = (curPanelSettings as N6000PPanelSettings).GetBackBeiBanCount();
                    for (int ii = 2; ii <= beibanCount; ii++)
                    {
                        g.DrawImage(Properties.Resources.主机背面__背板_有设备, BackOpenBeibanLocation[ii].X, BackOpenBeibanLocation[ii].Y, BackOpenBeibanSize.Width, BackOpenBeibanSize.Height);
                    }
                    //画线槽
                    int xiancaoCount = (curPanelSettings as N6000PPanelSettings).GetBackXianCaoCount();
                    for (int ii = 2; ii <= xiancaoCount; ii++)
                    {
                        g.DrawImage(Properties.Resources.主机背面__线槽_有设备, BackOpenXianChaoLocation[ii].X, BackOpenXianChaoLocation[ii].Y, BackOpenXianChaoSize.Width, BackOpenXianChaoSize.Height);
                    }

                    //画POM卡
                    for (int ii = 2; ii <= curPanelSettings.POMCount; ii++)
                    {
                        g.DrawImage(Properties.Resources.主机背面__POM, BackRightLocation[ii].X, BackRightLocation[ii].Y, BackPOMSize.Width, BackPOMSize.Height);
                    }

                    //非POM板卡
                    int nonePomIndex = 0;
                    Point nonePOMPoint = new Point(BackLeftLocation[1].X, BackLeftLocation[1].Y);
                    for (int ii = 1; ii <= curPanelSettings.LPIModbusCount; ii++)
                    {
                        nonePomIndex++;
                        nonePOMPoint = GetBackNonePOMLocation(nonePomIndex, curPanelSettings.POMCount);
                        g.DrawImage(Properties.Resources.LPI_modbus_3_0_1, nonePOMPoint.X, nonePOMPoint.Y, BackLPIModbusSize.Width, BackLPIModbusSize.Height);
                    }
                    for (int ii = 1; ii <= curPanelSettings.FecbusModuleCount; ii++)
                    {
                        nonePomIndex++;
                        nonePOMPoint = GetBackNonePOMLocation(nonePomIndex, curPanelSettings.POMCount);
                        g.DrawImage(Properties.Resources.主机背面__Model, nonePOMPoint.X, nonePOMPoint.Y, BackLPIModbusSize.Width, BackLPIModbusSize.Height);
                    }
                    for (int ii = 1; ii <= curPanelSettings.NCMHighCount; ii++)
                    {
                        nonePomIndex++;
                        nonePOMPoint = GetBackNonePOMLocation(nonePomIndex, curPanelSettings.POMCount);
                        g.DrawImage(Properties.Resources.主机背面___光纤网卡, nonePOMPoint.X, nonePOMPoint.Y, BackLPIModbusSize.Width, BackLPIModbusSize.Height);
                    }
                }
            }
        }

        private Point GetBackNonePOMLocation(int nonePOMIndex, int POMCount)
        {
            //非POM最多4块，可站位右面，现在可以有5块
            Point nonePOMPoint = new Point(BackLeftLocation[1].X, BackLeftLocation[1].Y);

            if (nonePOMIndex <= 2)
            {
                nonePOMPoint = new Point(BackLeftLocation[nonePOMIndex].X, BackLeftLocation[nonePOMIndex].Y);
            }
            if (nonePOMIndex == 3)
            {
                if (POMCount == 1)
                {
                    nonePOMPoint = new Point(BackRightLocation[2].X, BackRightLocation[2].Y);
                }
                else
                {
                    nonePOMPoint = new Point(BackLeftLocation[nonePOMIndex].X, BackLeftLocation[nonePOMIndex].Y);
                }
            }
            if (nonePOMIndex == 4)
            {
                if (POMCount == 1)
                {
                    nonePOMPoint = new Point(BackLeftLocation[3].X, BackLeftLocation[3].Y);
                }
                else if (POMCount == 2)
                {
                    nonePOMPoint = new Point(BackRightLocation[3].X, BackRightLocation[3].Y);
                }
                else
                {
                    nonePOMPoint = new Point(BackLeftLocation[4].X, BackLeftLocation[4].Y);
                }
            }
            if (nonePOMIndex == 5)
            {
                if (POMCount == 1)
                {
                    nonePOMPoint = new Point(BackRightLocation[3].X, BackRightLocation[3].Y);
                }
                else if (POMCount == 2)
                {
                    nonePOMPoint = new Point(BackLeftLocation[4].X, BackLeftLocation[4].Y);
                }
                else   //pom卡只能有3个
                {
                    nonePOMPoint = new Point(BackRightLocation[4].X, BackRightLocation[4].Y);
                }
            }

            return nonePOMPoint;
        }

        private Point GetNonePOMPositionBiGua(int nonePOMIndex, int POMPosBoard)
        {
            Point nonePOMPoint = new Point(BiGuaFrontOpenRight[3].X, BiGuaFrontOpenRight[3].Y);
            if (POMPosBoard == 3)
            {
                return nonePOMPoint;
            }
            if (POMPosBoard == 2)
            {
                switch (nonePOMIndex)
                {
                    case 1:
                        nonePOMPoint = new Point(BiGuaFrontOpenRight[2].X, BiGuaFrontOpenRight[2].Y);
                        break;
                    case 2:
                        nonePOMPoint = new Point(BiGuaFrontOpenLeft[3].X, BiGuaFrontOpenLeft[3].Y);
                        break;
                    case 3:
                        nonePOMPoint = new Point(BiGuaFrontOpenRight[3].X, BiGuaFrontOpenRight[3].Y);
                        break;
                    default:
                        return nonePOMPoint;
                }
            }

            return nonePOMPoint;
        }

        #region "保存图片"
        public Bitmap SaveAPanelLeftImage(BasicPanelSettings curPanelSettings)
        {
            Bitmap image = null;
            if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                int acmPOMCount = curPanelSettings.POMCount + curPanelSettings.ACMCount + curPanelSettings.PrinterCount;
                if (acmPOMCount > 5)
                {
                    image = Properties.Resources.主机正面_基础配置02;
                }
                else
                {
                    image = Properties.Resources.主机正面_基础配置01;
                }
            }
            if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                image = new Bitmap(Properties.Resources._6000P_壁挂_主机正面_基础配置);

            Graphics g = Graphics.FromImage(image);

            DrawFrontBasic(g, curPanelSettings);

            return image;
        }

        public Bitmap SaveAPanelMiddleImage(BasicPanelSettings curPanelSettings)
        {
            Bitmap image = null;
            if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                image = new Bitmap(Properties.Resources.主机开机正面_基础配置);
            if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                image = new Bitmap(Properties.Resources._6000P_壁挂_主机开机正面__基础配置);

            Graphics g = Graphics.FromImage(image);

            DrawFrontOpen(g, curPanelSettings);

            return image;
        }

        public Bitmap SaveAPanelRightImage(BasicPanelSettings curPanelSettings)
        {
            Bitmap image = new Bitmap(Properties.Resources.主机背面__基础配置);
            Graphics g = Graphics.FromImage(image);

            DrawBackBasic(g, curPanelSettings);

            return image;
        }
        #endregion

        #endregion

        #region "New/Edit Panel Page"

        private void RefreshLeftPanelCombobox(string panelType)
        {
            ComboBox_NewPanel_ACMCount.Properties.Items.Clear();
            ComboBox_NewPanel_POMCount.Properties.Items.Clear();

            int maxACM = 4, maxPOM = 4;
            if (panelType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                maxACM = N6000PPanelSettings.ACMMaxCount;
                maxPOM = N6000PPanelSettings.POMMaxCount;
            }
            if (panelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                maxACM = N6000PBiGuaSettings.ACMMaxCount;
                maxPOM = N6000PBiGuaSettings.POMMaxCount;
            }

            for (int ii = 0; ii <= maxACM; ii++)
            {
                ComboBox_NewPanel_ACMCount.Properties.Items.Add(ii);
            }
            for (int ii = 1; ii <= maxPOM; ii++)
            {
                ComboBox_NewPanel_POMCount.Properties.Items.Add(ii);
            }
        }

        private void RefreshLeftSpecPanel()
        {
            if (CurrentPanelSettings == null) return;

            IsInLoading = true;

            RefreshLeftPanelCombobox(CurrentPanelSettings.PanelType);

            ComboBox_NewPanel_PanelType.Text = CurrentPanelSettings.PanelType;
            TextBox_NewPanel_ProjectName.Text = CurrentPanelSettings.PanelLabel;
            ComboBox_NewPanel_LCMCount.Text = CurrentPanelSettings.LCMCardCount.ToString();

            if (CurrentPanelSettings.NCMHighCount > 0)
            {
                CheckEdit_NewPanel_NCMHigh.Checked = true;
                ComboBox_NewPanel_NCMHighCount.Text = CurrentPanelSettings.NCMHighCount.ToString();
            }
            else
                CheckEdit_NewPanel_NCMHigh.Checked = false;

            CheckEdit_NewPanel_NCMMedium.Checked = CurrentPanelSettings.NCMMediumCount > 0 ? true : false;
            CheckEdit_NewPanel_NCMLow.Checked = CurrentPanelSettings.NCMLowCount > 0 ? true : false;

            ComboBox_NewPanel_ACMCount.Text = CurrentPanelSettings.ACMCount.ToString();
            ComboBox_NewPanel_POMCount.Text = CurrentPanelSettings.POMCount.ToString();
            ComboBox_NewPanel_LPICount.Text = CurrentPanelSettings.LPIModbusCount.ToString();
            ComboBox_NewPanel_FecbusCount.Text = CurrentPanelSettings.FecbusModuleCount.ToString();
            if (CurrentPanelSettings.PrinterCount > 0)
            {
                CheckEdit_NewPanelPrinter.Checked = true;
            }
            else
            {
                CheckEdit_NewPanelPrinter.Checked = false;
            }
            if (CurrentPanelSettings.BlackBoxCount > 0)
            {
                CheckEdit_NewPanelBlackBox.Checked = true;
            }
            else
            {
                CheckEdit_NewPanelBlackBox.Checked = false;
            }
            IsInLoading = false;
        }

        private void ComboBox_NewPanel_LCMCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            CurrentPanelSettings.LCMCardCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_LCMCount.Text);
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.LCM, CurrentPanelSettings, CurrentPanelSettings.LCMCardCount);
            RefreshMainPage(AimPage.Inside);

            AddTitleFix(true);
        }

        private void ComboBox_NewPanel_ACMCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            CurrentPanelSettings.ACMCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_ACMCount.Text);

            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.ACM, CurrentPanelSettings, CurrentPanelSettings.ACMCount);
            RefreshMainPage(AimPage.LeftPage);

            AddTitleFix(true);
        }

        private void ComboBox_NewPanel_POMCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            if (CurrentPanelSettings.FecbusModuleCount + CurrentPanelSettings.LPIModbusCount + CurrentPanelSettings.NCMHighCount > 4 && ComboBox_NewPanel_POMCount.SelectedIndex == 3) //当多线控制卡满配时候，其他卡的数量只能是4个
            {
                CommonUsages.MyMsgBox("已没有空余位置放置板卡！。\n\r", CommonUsages.MsgBoxTypeEnum.Error);
                //int OldValue = ComboBox_NewPanel_POMCount_OldIndex;
                ComboBox_NewPanel_POMCount.SelectedIndex = ComboBox_NewPanel_POMCount_OldIndex;
                return;
            }
            CurrentPanelSettings.POMCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_POMCount.Text);
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.POM, CurrentPanelSettings, CurrentPanelSettings.POMCount);
            RefreshMainPage(AimPage.All);

            AddTitleFix(true);
            ComboBox_NewPanel_POMCount_OldIndex = ComboBox_NewPanel_POMCount.SelectedIndex;
        }

        private void ComboBox_NewPanel_LPICount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_LPICount.Text);

            CurrentPanelSettings.LPIModbusCount = curCount;
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.LPI, CurrentPanelSettings, CurrentPanelSettings.LPIModbusCount);
            RefreshMainPage(AimPage.Inside);

            AddTitleFix(true);
        }

        private void ComboBox_NewPanel_FecbusCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_FecbusCount.Text);

            CurrentPanelSettings.FecbusModuleCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_FecbusCount.Text);
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.FECBUS, CurrentPanelSettings, CurrentPanelSettings.FecbusModuleCount);
            RefreshMainPage(AimPage.Inside);

            AddTitleFix(true);
        }

        private void ComboBox_NewPanel_NCMHighCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(ComboBox_NewPanel_NCMHighCount.Text);

            if (curCount == 0)
            {
                CheckEdit_NewPanel_NCMHigh.Checked = false;
            }

            CurrentPanelSettings.NCMHighCount = curCount;
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.NCM_High, CurrentPanelSettings, CurrentPanelSettings.NCMHighCount);
            RefreshMainPage(AimPage.Inside);

            AddTitleFix(true);
        }

        private void ComboBox_NewPanel_NCMHighCount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(e.NewValue.ToString());
            int formerValue = CurrentPanelSettings.NCMHighCount;
            CurrentPanelSettings.NCMHighCount = curCount;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.NCMHighCount = formerValue;
                e.Cancel = true;
            }
        }

        private void ComboBox_NewPanel_LPICount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(e.NewValue.ToString());
            int formerValue = CurrentPanelSettings.LPIModbusCount;
            CurrentPanelSettings.LPIModbusCount = curCount;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.LPIModbusCount = formerValue;
                e.Cancel = true;
            }
        }

        private void ComboBox_NewPanel_FecbusCount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(e.NewValue.ToString());
            int formerValue = CurrentPanelSettings.FecbusModuleCount;
            CurrentPanelSettings.FecbusModuleCount = curCount;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.FecbusModuleCount = formerValue;
                e.Cancel = true;
            }
        }

        private void ComboBox_NewPanel_LCMCount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = CommonUsages.GetIntegerFromString(e.NewValue.ToString());
            int formerValue = CurrentPanelSettings.LCMCardCount;
            CurrentPanelSettings.LCMCardCount = curCount;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.LCMCardCount = formerValue;
                e.Cancel = true;
            }
        }

        private void CheckEdit_NewPanel_NCMMedium_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = (bool)e.NewValue == true ? 1 : 0;
            int formerValue = CurrentPanelSettings.NCMMediumCount;
            int fomerValue2 = CurrentPanelSettings.NCMLowCount;
            CurrentPanelSettings.NCMMediumCount = curCount;
            if (curCount == 1) CurrentPanelSettings.NCMLowCount = 0;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.NCMMediumCount = formerValue;
                CurrentPanelSettings.NCMLowCount = fomerValue2;
                e.Cancel = true;
            }
        }

        private void CheckEdit_NewPanel_NCMLow_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = (bool)e.NewValue == true ? 1 : 0;
            int formerValue = CurrentPanelSettings.NCMLowCount;
            int fomerValue2 = CurrentPanelSettings.NCMMediumCount;
            CurrentPanelSettings.NCMLowCount = curCount;
            if (curCount == 1) CurrentPanelSettings.NCMMediumCount = 0;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.NCMLowCount = formerValue;
                CurrentPanelSettings.NCMMediumCount = fomerValue2;
                e.Cancel = true;
            }
        }

        private void CheckEdit_NewPanel_NCMHigh_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            int curCount = (bool)e.NewValue == true ? 1 : 0;
            int formerValue = CurrentPanelSettings.NCMHighCount;
            CurrentPanelSettings.NCMHighCount = curCount;
            try
            {
                CurrentPanelSettings.CheckError();
            }
            catch (Exception ee)
            {
                CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Warning);
                CurrentPanelSettings.NCMHighCount = formerValue;
                e.Cancel = true;
            }
        }

        private void CheckEdit_NewPanel_NCMMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            if (CheckEdit_NewPanel_NCMMedium.Checked == true)
            {
                CheckEdit_NewPanel_NCMLow.Checked = false;

                CurrentPanelSettings.NCMMediumCount = 1;
                CurrentPanelSettings.NCMLowCount = 0;
            }
            else
            {
                CurrentPanelSettings.NCMMediumCount = 0;
            }

            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.NCM_Medium, CurrentPanelSettings, CurrentPanelSettings.NCMMediumCount);
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.NCM_Low, CurrentPanelSettings, CurrentPanelSettings.NCMLowCount);

            RefreshMainPage(AimPage.MiddlePage);

            AddTitleFix(true);
        }

        private void CheckEdit_NewPanel_NCMLow_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            if (CheckEdit_NewPanel_NCMLow.Checked == true)
            {
                CheckEdit_NewPanel_NCMMedium.Checked = false;

                CurrentPanelSettings.NCMLowCount = 1;
                CurrentPanelSettings.NCMMediumCount = 0;
            }
            else
            {
                CurrentPanelSettings.NCMLowCount = 0;
            }

            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.NCM_Medium, CurrentPanelSettings, CurrentPanelSettings.NCMMediumCount);
            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.NCM_Low, CurrentPanelSettings, CurrentPanelSettings.NCMLowCount);
            RefreshMainPage(AimPage.MiddlePage);

            AddTitleFix(true);
        }

        private void CheckEdit_NewPanel_NCMHigh_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            if (CheckEdit_NewPanel_NCMHigh.Checked == true)
            {
                ComboBox_NewPanel_NCMHighCount.Text = "1";
                CurrentPanelSettings.NCMHighCount = 1;
                ComboBox_NewPanel_NCMHighCount.Enabled = true;
            }
            else
            {
                ComboBox_NewPanel_NCMHighCount.Text = "0";
                ComboBox_NewPanel_NCMHighCount.Enabled = false;
                CurrentPanelSettings.NCMHighCount = 0;
            }

            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.NCM_High, CurrentPanelSettings, CurrentPanelSettings.NCMHighCount);
            RefreshMainPage(AimPage.Inside);

            AddTitleFix(true);
        }

        private void CheckEdit_NewPanelPrinter_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;

            if (CheckEdit_NewPanelPrinter.Checked == true)
            {
                CurrentPanelSettings.PrinterCount = 1;
            }
            else
            {
                CurrentPanelSettings.PrinterCount = 0;
            }

            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.Printer, CurrentPanelSettings, CurrentPanelSettings.PrinterCount);
            RefreshMainPage(AimPage.LeftPage);

            AddTitleFix(true);
        }

        private void CheckEdit_NewPanelBlackBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentPanelSettings == null) return;
            if (CheckEdit_NewPanelBlackBox.Checked == true)
            {
                CurrentPanelSettings.BlackBoxCount = 1;
            }
            else
            {
                CurrentPanelSettings.BlackBoxCount = 0;
            }

            DBClass.GetInstance().RefreshPanelSettingRowByModelType(ModelTypeEnum.BlackBox, CurrentPanelSettings, CurrentPanelSettings.BlackBoxCount);
            RefreshMainPage(AimPage.MiddlePage);
            //RefreshMainPage(AimPage.Inside);

            AddTitleFix(true);
        }

        private void CheckEdit_NewPanelPrinter_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if ((bool)e.NewValue == false)
            //{
            //    CommonUsages.MyMsgBox("请添加至少一个打印机。", CommonUsages.MsgBoxTypeEnum.Warning);
            //    e.Cancel = true;
            //}
        }

        private void CheckEdit_NewPanelBlackBox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if ((bool)e.NewValue == false)
            //{
            //    CommonUsages.MyMsgBox("请添加至少一个黑盒子。", CommonUsages.MsgBoxTypeEnum.Warning);
            //    e.Cancel = true;
            //}
        }

        private void TextBox_NewPanel_ProjectName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString().Trim() == "")
            {
                CommonUsages.MyMsgBox("控制器系统名不能为空！", CommonUsages.MsgBoxTypeEnum.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void TextBox_NewPanel_ProjectName_EditValueChanged(object sender, EventArgs e)
        {
            if (TextBox_NewPanel_ProjectName.Text.Trim() != "")
            {
                DBClass.GetInstance().RefreshPanelNameByID(CurrentPanelSettings.ID, TextBox_NewPanel_ProjectName.Text.Trim());
            }

            AddTitleFix(true);
        }
        #endregion

        #region "中间页面"
        private void GridView_MiddleFittingList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Model")
            {
                string comment = GridView_MiddleFittingList.GetRowCellValue(e.RowHandle, "Label").ToString();
                Rectangle rectModel = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 4, e.Bounds.Width - 4, e.Bounds.Height / 2 - 4);
                Rectangle rectComment = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + e.Bounds.Height / 2 + 2, e.Bounds.Width - 4, e.Bounds.Height / 2 - 4);
                e.Graphics.DrawString(e.CellValue.ToString(), new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.Black), rectModel, CustomStringFormatNear);
                e.Graphics.DrawString(comment, new Font("Microsoft YaHei UI", 12, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(48, 48, 48)), rectComment, CustomStringFormatNear);
                e.Handled = true;
            }
            if (e.Column.FieldName == "Button")
            {
                Rectangle rect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 3, e.Bounds.Width - 5, e.Bounds.Height - 6);
                if (e.RowHandle == GridView_MiddleFittingList.FocusedRowHandle)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(23, 146, 229)), rect);
                    e.Graphics.DrawString("加入配置单", new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.White), rect, CustomStringFormatMiddle);
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(211, 211, 211), 1), rect);
                    e.Graphics.DrawString("加入配置单", new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(176, 176, 176)), rect, CustomStringFormatMiddle);
                }
                e.Handled = true;
            }

            if (e.Column.FieldName == "Picture")
            {
                if (e.CellValue != DBNull.Value)
                {
                    int height = ((Image)e.CellValue).Height;
                    int width = ((Image)e.CellValue).Width;
                    if (height < e.Bounds.Height - 1 && width < e.Bounds.Width)
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - width) / 2), e.Bounds.Top + ((e.Bounds.Height - height) / 2), width, height));
                    }
                    else if (height > e.Bounds.Height - 1 && width < e.Bounds.Width)
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - ((39 * width) / height)) / 2), e.Bounds.Top + ((e.Bounds.Height - e.Bounds.Height) / 2), (39 * width) / height, e.Bounds.Height));
                    }
                    else if (height < e.Bounds.Height - 1 && width > e.Bounds.Width)
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - e.Bounds.Width) / 2), e.Bounds.Top + ((e.Bounds.Height - ((50 * height) / width + 4)) / 2), e.Bounds.Width, (50 * height) / width + 4));
                    }
                    else
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 4, e.Bounds.Width - 8, e.Bounds.Height - 8));
                    }

                    //  e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left +4, e.Bounds.Top +4, e.Bounds.Width - 8, e.Bounds.Height -8));


                    //e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + 18, e.Bounds.Top + 10, e.Bounds.Width - 36, e.Bounds.Height - 20));
                    //e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left , e.Bounds.Top, e.Bounds.Width , e.Bounds.Height));
                }
                e.Handled = true;
            }

            if (e.Column.FieldName == "UnitPrice")
            {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240), 1), new Point(e.Bounds.Left + 2, e.Bounds.Top + 8), new Point(e.Bounds.Left + 2, e.Bounds.Bottom - 8));
                //e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240), 1), new Point(e.Bounds.Right - 2, e.Bounds.Top + 8), new Point(e.Bounds.Right + 2, e.Bounds.Bottom - 8));
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240), 1), new Point(e.Bounds.Right - 2, e.Bounds.Top + 8), new Point(e.Bounds.Right - 2, e.Bounds.Bottom - 8));
            }
        }

        private void GridView_MiddleFittingList_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "UnitPrice")
            {
                e.DisplayText = string.Format("￥{0}", e.Value.ToString());
            }
        }

        private void GridView_MiddleFittingList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "Button")
            {
                int count = Convert.ToInt32(GridView_MiddleFittingList.GetFocusedRowCellValue("Count").ToString());
                string model = GridView_MiddleFittingList.GetFocusedRowCellValue("Model").ToString();
                DBClass.GetInstance().RefreshAFittingSetitingRow(model, count);
                AddTitleFix(true);
                GridView_MiddleFittingList.SetFocusedRowCellValue("Count", "1");
            }
        }
        #endregion

        #region "右面页面"
        StringFormat CustomStringFormatNear = new StringFormat();
        StringFormat CustomStringFormatMiddle = new StringFormat();
        private void GridView_PanelSettingList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Row)
            {
                if (e.RowHandle == GridView_PanelSettingList.FocusedRowHandle)
                {
                    e.Cache.FillRectangle(new SolidBrush(Color.FromArgb(248, 248, 248)), e.Bounds);
                }
                else
                {
                    e.Cache.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }

                e.Cache.DrawString(string.Format("  {0}", e.RowHandle + 1), new Font("Microsoft YaHei UI", 13, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(48, 48, 48)), e.Bounds, CustomStringFormatNear);
                e.Handled = true;
            }
        }

        private void GridView_PanelSettingList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Model")
            {
                string comment = GridView_PanelSettingList.GetRowCellValue(e.RowHandle, "Label").ToString();
                Rectangle rectModel = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height / 2 - 4);
                Rectangle rectComment = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + e.Bounds.Height / 2 + 2, e.Bounds.Width - 4, e.Bounds.Height / 2 - 4);
                e.Graphics.DrawString(e.CellValue.ToString(), new Font("Microsoft YaHei UI", 12, GraphicsUnit.Pixel), new SolidBrush(Color.Black), rectModel, CustomStringFormatNear);
                e.Graphics.DrawString(comment, new Font("Microsoft YaHei UI", 10, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(176, 176, 176)), rectComment, CustomStringFormatNear);
                e.Handled = true;
            }
            if (e.Column.FieldName == "Count")
            {
                Rectangle rect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height - 4);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(223, 223, 223), 1), rect);
                e.Graphics.DrawString(e.CellValue.ToString(), new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(128, 128, 128)), rect, CustomStringFormatMiddle);
                e.Handled = true;
            }
            if (e.Column.FieldName == "Picture")
            {
                if (e.CellValue != DBNull.Value)
                {
                    string PictureName = this.GridView_PanelSettingList.GetRowCellValue(e.RowHandle, "Model").ToString();
                    if (PictureSize.ContainsKey(PictureName))
                    {
                        Size picSize = PictureSize.Where(S => S.Key == PictureName).Select(S => S.Value).First();
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - picSize.Width) / 2), e.Bounds.Top + ((e.Bounds.Height - picSize.Height) / 2), picSize.Width, picSize.Height));
                        //e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(new Point((e.Bounds.Width - picSize.Width) / 2, (e.Bounds.Height - picSize.Height) / 2) , picSize));
                        //e.Graphics.DrawImage((Image)e.CellValue, new Point());
                    }
                    else
                    {
                        int height = ((Image)e.CellValue).Height;
                        int width = ((Image)e.CellValue).Width;
                        if (height < e.Bounds.Height && width < e.Bounds.Width)
                        {
                            e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - width) / 2), e.Bounds.Top + ((e.Bounds.Height - height) / 2), width, height));
                        }
                        else if (height > e.Bounds.Height && width < e.Bounds.Width)
                        {
                            e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - ((39 * width) / height)) / 2), e.Bounds.Top + ((e.Bounds.Height - e.Bounds.Height) / 2), (39 * width) / height, e.Bounds.Height));
                        }
                        else if (height < e.Bounds.Height && width > e.Bounds.Width)
                        {
                            e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - e.Bounds.Width) / 2), e.Bounds.Top + ((e.Bounds.Height - ((50 * height) / width + 4)) / 2), e.Bounds.Width, (50 * height) / width + 4));
                        }
                        else
                        {
                            e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 4, e.Bounds.Width - 8, e.Bounds.Height - 8));
                        }

                        //  e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left +4, e.Bounds.Top +4, e.Bounds.Width - 8, e.Bounds.Height -8));

                    }

                }
                e.Handled = true;
            }
        }

        private void GridView_FittingSettingsList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Model")
            {
                string comment = GridView_FittingSettingsList.GetRowCellValue(e.RowHandle, "Label").ToString();
                Rectangle rectModel = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height / 2 - 4);
                Rectangle rectComment = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + e.Bounds.Height / 2 + 2, e.Bounds.Width - 4, e.Bounds.Height / 2 - 4);
                e.Graphics.DrawString(e.CellValue.ToString(), new Font("Microsoft YaHei UI", 12, GraphicsUnit.Pixel), new SolidBrush(Color.Black), rectModel, CustomStringFormatNear);
                e.Graphics.DrawString(comment, new Font("Microsoft YaHei UI", 10, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(176, 176, 176)), rectComment, CustomStringFormatNear);
                e.Handled = true;
            }
            if (e.Column.FieldName == "Count")
            {
                Rectangle rect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height - 4);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(223, 223, 223), 1), rect);
                e.Graphics.DrawString(e.CellValue.ToString(), new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(128, 128, 128)), rect, CustomStringFormatMiddle);
                e.Handled = true;
            }
            if (e.Column.FieldName == "Picture")
            {
                if (e.CellValue != DBNull.Value)
                {
                    int height = ((Image)e.CellValue).Height;
                    int width = ((Image)e.CellValue).Width;
                    if (height < e.Bounds.Height && width < e.Bounds.Width)
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - width) / 2), e.Bounds.Top + ((e.Bounds.Height - height) / 2), width, height));
                    }
                    else if (height > e.Bounds.Height && width < e.Bounds.Width)
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - ((39 * width) / height)) / 2), e.Bounds.Top + ((e.Bounds.Height - e.Bounds.Height) / 2), (39 * width) / height, e.Bounds.Height));
                    }
                    else if (height < e.Bounds.Height && width > e.Bounds.Width)
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - e.Bounds.Width) / 2), e.Bounds.Top + ((e.Bounds.Height - ((50 * height) / width + 4)) / 2), e.Bounds.Width, (50 * height) / width + 4));
                    }
                    else
                    {
                        e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 4, e.Bounds.Width - 8, e.Bounds.Height - 8));
                    }


                    //e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + 18, e.Bounds.Top + 10, e.Bounds.Width - 36, e.Bounds.Height - 20));
                    //e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 4, e.Bounds.Width -8 , e.Bounds.Height -8));

                    //e.Graphics.DrawImage((Image)e.CellValue, new Rectangle(e.Bounds.Left , e.Bounds.Top , e.Bounds.Width , e.Bounds.Height ));
                }

            }
            if (e.Column.FieldName == "delete")
            {
                int height = Properties.Resources.删除.Height;
                int width = Properties.Resources.删除.Width;
                //e.Graphics.DrawImage(Properties.Resources.删除, new Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 4, e.Bounds.Width - 8, e.Bounds.Height - 8));
                e.Graphics.DrawImage(Properties.Resources.删除, new Rectangle(e.Bounds.Left + ((e.Bounds.Width - width) / 2), e.Bounds.Top + ((e.Bounds.Height - height) / 2), width, height));
            }
            e.Handled = true;
        }

        private void GridView_FittingSettingsList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Row)
            {
                if (e.RowHandle == GridView_FittingSettingsList.FocusedRowHandle)
                {
                    e.Cache.FillRectangle(new SolidBrush(Color.FromArgb(248, 248, 248)), e.Bounds);
                }
                else
                {
                    e.Cache.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }
                e.Cache.DrawString(string.Format(" {0}", e.RowHandle + 1), new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(48, 48, 48)), e.Bounds, CustomStringFormatNear);

                e.Handled = true;
            }
        }

        private void GridView_FittingSettingsList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                Panel_FitingsSettingFocusRowPage.Visible = false;
                return;
            }

            int cout = Convert.ToInt32(GridView_FittingSettingsList.GetFocusedRowCellValue("Count"));
            if (cout == 0)
            {
                Panel_FitingsSettingFocusRowPage.Visible = false;
                return;
            }
            //Label_FittingSettingCount.Text = cout.ToString();
            //int y = GridControl_FittingSettingsList.Location.Y + e.FocusedRowHandle * 39;
            //Panel_FitingsSettingFocusRowPage.Location = new Point(255, y);
            ////Panel_FitingsSettingFocusRowPage.Visible = true;
        }

        private void PictureBox_Button_DeleteFittingSetting_Click(object sender, EventArgs e)
        {
            string model = GridView_FittingSettingsList.GetFocusedRowCellValue("Model").ToString();
            if (MessageBox.Show(this, "确认要删除当前型号吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            DBClass.GetInstance().DeleteAFittingSetitingRow(model);

            AddTitleFix(true);
        }

        private void Label_Button_AddFittingSetting_Click(object sender, EventArgs e)
        {
            int curCount = Convert.ToInt32(Label_FittingSettingCount.Text);
            Label_FittingSettingCount.Text = (++curCount).ToString();

            string model = GridView_FittingSettingsList.GetFocusedRowCellValue("Model").ToString();
            DBClass.GetInstance().RefreshAFittingSetitingRow(model, curCount);

            AddTitleFix(true);
        }

        private void Label_Button_MinusFittingSetting_Click(object sender, EventArgs e)
        {
            int curCount = Convert.ToInt32(Label_FittingSettingCount.Text);
            if (curCount > 0) curCount--;
            Label_FittingSettingCount.Text = curCount.ToString();

            string model = GridView_FittingSettingsList.GetFocusedRowCellValue("Model").ToString();
            DBClass.GetInstance().RefreshAFittingSetitingRow(model, curCount);

            AddTitleFix(true);
        }

        #endregion

        #region "Report"
        private void Button_ProjectSettingPrice_Click(object sender, EventArgs e)
        {
            Form_Report form_report = new Form_Report();
            form_report.GeneratePanelImages = new Form_Report.GeneratePanelImagesDelegate(GeneratePanelImages);
            form_report.ShowDialog();
            if (form_report.IsSave)
            {
                SaveProject();
            }
        }

        private bool GeneratePanelImages()
        {
            bool result = true;

            for (int index = 0; index < DBClass.GetInstance().ProjectMemoryTable.Rows.Count; index++)
            {
                long panelID = Convert.ToInt64(DBClass.GetInstance().ProjectMemoryTable.Rows[index]["ID"]);
                BasicPanelSettings curSettings = DBClass.GetInstance().ReadPanelSettingsFromTable(panelID);
                if (curSettings == null)
                    continue;
                DBClass.GetInstance().ProjectMemoryTable.Rows[index]["LeftPanel"] = SaveAPanelLeftImage(curSettings);
                DBClass.GetInstance().ProjectMemoryTable.Rows[index]["MiddlePanel"] = SaveAPanelMiddleImage(curSettings);
                if (curSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    DBClass.GetInstance().ProjectMemoryTable.Rows[index]["RightPanel"] = null;
                }
                if (curSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    DBClass.GetInstance().ProjectMemoryTable.Rows[index]["RightPanel"] = SaveAPanelRightImage(curSettings);
                }
            }

            //foreach (DataRow itemRow in DBClass.GetInstance().ProjectMemoryTable.Rows)
            //{
            //    long panelID = Convert.ToInt64(itemRow["ID"]);
            //    BasicPanelSettings curSettings = DBClass.GetInstance().ReadPanelSettingsFromTable(panelID);
            //    if (curSettings == null)
            //        continue;
            //    itemRow["LeftPanel"] = SaveAPanelLeftImage(curSettings);
            //    itemRow["MiddlePanel"] = SaveAPanelMiddleImage(curSettings);
            //    if (curSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            //    {
            //        itemRow["RightPanel"] = null;
            //    }
            //    if (curSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
            //    {
            //        itemRow["RightPanel"] = SaveAPanelRightImage(curSettings);
            //    }
            //}

            return result;
        }

        #endregion

        public void AddCustomClickToCtrlRecursion(Control ctrl)
        {
            foreach (Control item in ctrl.Controls)
            {
                if ((item.AccessibleDescription != null && item.AccessibleDescription.ToString() == "CustomMenuItem")) { }
                else
                {
                    item.Click += Panel_Menu_OnutSide_Click; ;
                }

                if ((item.AccessibleDescription != null && item.AccessibleDescription.ToString() == "ProjectMenuItem")) { }
                else
                {
                    item.Click += Project_Menu_OnutSide_Click; ;
                }

                AddCustomClickToCtrlRecursion(item);
            }
        }

        private void Panel_Menu_OnutSide_Click(object sender, EventArgs e)
        {
            Panel_MainMenu.Visible = false;
        }

        private void Project_Menu_OnutSide_Click(object sender, EventArgs e)
        {
            ShowProjectMenu(false);
        }

        private void userControl_MenuItem_SoftwareVersion_Click(object sender, EventArgs e)
        {
            //CommonUsages.GrayMainFormWhenPopup(this, () =>
            //{
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
            //});
        }

        private void userControl_MenuItem_PriceBookVersion_Click(object sender, EventArgs e)
        {
            string priceBookVersion = Path.GetFileName(CommonUsages.PriceBookPath);
            CommonUsages.MyMsgBox(priceBookVersion, CommonUsages.MsgBoxTypeEnum.Info);
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Panel_MainMenu.Visible = false;
                ShowProjectMenu(false);
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                PictureBox_SaveProject_Click(PictureBox_SaveProject, e);
            }
        }

        private void XtraTabPage_MainPage_Panel_SizeChanged(object sender, EventArgs e)
        {
            int x = (XtraTabPage_MainPage_Panel.Width - Panel_Pages.Width) / 2;
            int y = (XtraTabPage_MainPage_Panel.Height - Panel_Pages.Height) / 2 - 3;
            Panel_Pages.Location = new Point(x, y);
        }

        private void Panel_ToolBar_SizeChanged(object sender, EventArgs e)
        {
            int x = (Panel_ToolBar.Width - Panel_ProjectMenu.Width) / 2;
            Panel_ProjectMenu.Location = new Point(x, 38);
        }

        private bool IsInLoading = false;

        private void AddTitleFix(bool toAdd)
        {
            if (IsInLoading == true)
                return;

            if (toAdd == true)
            {
                if (Label_Title.Text.EndsWith("*") == false)
                {
                    Label_Title.Text = Label_Title.Text + "*";
                }
                if (PictureBox_SaveProject.Image != Properties.Resources.组663)
                {
                    PictureBox_SaveProject.Image = Properties.Resources.组663;
                }
            }
            else
            {
                if (Label_Title.Text.EndsWith("*") == true)
                {
                    Label_Title.Text = Label_Title.Text.TrimEnd('*');
                }
                PictureBox_SaveProject.Image = Properties.Resources.icon_保存1;
                //if (PictureBox_SaveProject.Image == Properties.Resources.组663)
                //{
                //    PictureBox_SaveProject.Image = Properties.Resources.icon_保存1;
                //}
            }
        }

        private void pictureBox_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("控制器配置单中单品的数量为去掉“控制器套件”中默认配置后的数量，如套件中自带一个回路卡，当选配3块回路卡时,列表中回路卡的数量显示为2。");
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //根据ContextMenuStrip Item 的name来判断
            //编辑控制器
            if ((e.ClickedItem).Name == "MenuItemEdit")
            {
                if (GridView_PanelList.SelectedRowsCount == 1)
                {
                    Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));

                    XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
                    PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
                    PictureBox_ConetextMenu.Tag = "Back";

                    CurrentPanelSettings = DBClass.GetInstance().ReadPanelSettingsFromTable(id);

                    RefreshLeftSpecPanel();
                    RefreshMainPage(AimPage.All);
                    GridView_PanelSettingList.ActiveFilterString = string.Format("[ItemID] = '{0}'", id);
                }
            }
            //新建控制器
            else if ((e.ClickedItem).Name == "MenuItemNew")
            {
                Form_NewPanelType form_new = new Quick_Order.Form_NewPanelType();
                if (form_new.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
                PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
                PictureBox_ConetextMenu.Tag = "Back";
                CheckEdit_NewPanelPrinter.Checked = false;
                CheckEdit_NewPanelBlackBox.Checked = false;

                Int64 id = DBClass.GetInstance().GetCurrentMaxProjectID();
                if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    CurrentPanelSettings = new Quick_Order.N6000PPanelSettings(id, Form_NewPanelType.SelectedProjectLabel);
                }
                if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    CurrentPanelSettings = new Quick_Order.N6000PBiGuaSettings(id, Form_NewPanelType.SelectedProjectLabel);
                }

                DBClass.GetInstance().AddANewPanel(CurrentPanelSettings);
                GridView_PanelList.FocusedRowHandle = GridView_PanelList.RowCount - 1;
                AddTitleFix(true);
            }
            //复制
            else if ((e.ClickedItem).Name == "MenuItemCopySingle")
            {
                //Clipboard.SetData("Controler", "1");
                Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));
                CopyControler(id, "1");
            }
            //复制多个控制器
            else if ((e.ClickedItem).Name == "MenuItemCopyMore")
            {
                //Clipboard.SetData("Controler", this.GridView_PanelList.GetFocusedRowCellValue("Other").ToString());
                Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));
                CopyControler(id, this.GridView_PanelList.GetFocusedRowCellValue("Other").ToString());
            }
            //修改控制器数量
            else if ((e.ClickedItem).Name == "MenuItemEditAmount")
            {
                Form_EditControlCount form_EditControlCount = new Form_EditControlCount(this.GridView_PanelList.GetFocusedRowCellValue("Other").ToString());
                if (form_EditControlCount.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                this.GridView_PanelList.SetFocusedRowCellValue("Other", form_EditControlCount.ControlCount);
                this.GridView_PanelList.RefreshData();
                AddTitleFix(true);
            }
            //重命名
            else if ((e.ClickedItem).Name == "MenuItemRename")
            {
                Form_NewName form_NewName = new Form_NewName(this.GridView_PanelList.GetFocusedRowCellValue("Name").ToString());
                if (form_NewName.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                this.GridView_PanelList.SetFocusedRowCellValue("Name", form_NewName.ControlName);
                this.GridView_PanelList.RefreshData();
                AddTitleFix(true);
            }
            //删除
            else if ((e.ClickedItem).Name == "MenuItemDelete")
            {
                if (GridView_PanelList.SelectedRowsCount == 1)
                {
                    Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));
                    string warnString = string.Format("确认要删除当前控制器吗？");
                    if (MessageBox.Show(warnString, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DBClass.GetInstance().DeleteAPanel(id);

                        AddTitleFix(true);
                    }
                }
            }


        }

        private void GridView_PanelList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Other" && (e.CellValue != null))
            {
                Rectangle rect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, e.Bounds.Width - 4, e.Bounds.Height - 4);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(223, 223, 223), 1), rect);
                e.Graphics.DrawString(e.CellValue.ToString(), new Font("Microsoft YaHei UI", 14, GraphicsUnit.Pixel), new SolidBrush(Color.FromArgb(128, 128, 128)), rect, CustomStringFormatMiddle);
                e.Handled = true;
            }
        }

        private void GridView_PanelList_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) && e.KeyCode == Keys.V)
            {
                string others = Clipboard.GetData("Controler").ToString();
                if (others.Equals("0"))
                {
                    return;

                }
                //Form_NewPanelType form_new = new Quick_Order.Form_NewPanelType();
                //if (form_new.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}

                XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
                PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
                PictureBox_ConetextMenu.Tag = "Back";

                Int64 id = DBClass.GetInstance().GetCurrentMaxProjectID();
                if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    CurrentPanelSettings = new Quick_Order.N6000PPanelSettings(id, Form_NewPanelType.SelectedProjectLabel);
                }
                if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    CurrentPanelSettings = new Quick_Order.N6000PBiGuaSettings(id, Form_NewPanelType.SelectedProjectLabel);
                }

                DBClass.GetInstance().AddANewPanel(CurrentPanelSettings, others);
                GridView_PanelList.FocusedRowHandle = GridView_PanelList.RowCount - 1;
                AddTitleFix(true);


                //复制完之后将剪切板归0
                Clipboard.SetData("Controler", "0");
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) && e.KeyCode == Keys.V)
            {
                string others = Clipboard.GetData("Controler").ToString();
                if (others.Equals("0"))
                {
                    return;

                }
                //Form_NewPanelType form_new = new Quick_Order.Form_NewPanelType();
                //if (form_new.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}

                XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
                PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
                PictureBox_ConetextMenu.Tag = "Back";

                Int64 id = DBClass.GetInstance().GetCurrentMaxProjectID();
                if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000P)
                {
                    CurrentPanelSettings = new Quick_Order.N6000PPanelSettings(id, Form_NewPanelType.SelectedProjectLabel);
                }
                if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                {
                    CurrentPanelSettings = new Quick_Order.N6000PBiGuaSettings(id, Form_NewPanelType.SelectedProjectLabel);
                }

                DBClass.GetInstance().AddANewPanel(CurrentPanelSettings, others);
                GridView_PanelList.FocusedRowHandle = GridView_PanelList.RowCount - 1;
                AddTitleFix(true);


                //复制完之后将剪切板归0
                Clipboard.SetData("Controler", "0");
            }
        }

        private void CopyControler(Int64 Itemid, string others)
        {
            //string others = Clipboard.GetData("Controler").ToString();
            //if (others.Equals("0"))
            //{
            //    return;

            //}
            //Form_NewPanelType form_new = new Quick_Order.Form_NewPanelType();
            //if (form_new.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            DBClass.GetInstance().AddADatatableRow(Itemid, others);


            //XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
            //PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
            //PictureBox_ConetextMenu.Tag = "Back";

            //Int64 id = DBClass.GetInstance().GetCurrentMaxProjectID();
            //if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000P)
            //{
            //    CurrentPanelSettings = new Quick_Order.N6000PPanelSettings(id, Form_NewPanelType.SelectedProjectLabel);
            //}
            //if (Form_NewPanelType.SelectedProjectType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            //{
            //    CurrentPanelSettings = new Quick_Order.N6000PBiGuaSettings(id, Form_NewPanelType.SelectedProjectLabel);
            //}

            //DBClass.GetInstance().AddANewPanel(CurrentPanelSettings, others);
            GridView_PanelList.FocusedRowHandle = GridView_PanelList.RowCount - 1;
            AddTitleFix(true);


            //复制完之后将剪切板归0
            //Clipboard.SetData("Controler", "0");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.GridView_PanelList.GetFocusedRowCellValue("Other").ToString().Trim().Equals("1"))
            {
                contextMenuStrip1.Items[3].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[3].Enabled = true;
            }
        }

        private void GridView_PanelList_DoubleClick(object sender, EventArgs e)
        {
            Int64 id = Convert.ToInt64(GridView_PanelList.GetFocusedRowCellValue("ID"));

            XtraTabControl_LeftPage.SelectedTabPage = XtraTabPage_LeftPage_SpecPanel;
            PictureBox_ConetextMenu.Image = Properties.Resources.Icon_Back;
            PictureBox_ConetextMenu.Tag = "Back";

            CurrentPanelSettings = DBClass.GetInstance().ReadPanelSettingsFromTable(id);

            RefreshLeftSpecPanel();
            RefreshMainPage(AimPage.All);
            GridView_PanelSettingList.ActiveFilterString = string.Format("[ItemID] = '{0}'", id);
        }

        private void GridView_LeftPage_FittingBrandDetail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (dView.GetRow(e.RowHandle) == null)
            {
                return;
            }
            else
            {
                if (e.RowHandle == dView.FocusedRowHandle)
                {
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));//设置此行的背景颜色
                }
            }
        }

        private void GridView_FittingSettingsList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string model = GridView_FittingSettingsList.GetFocusedRowCellValue("Model").ToString();
            int curCount = int.Parse(GridView_FittingSettingsList.GetFocusedRowCellValue("Count").ToString());
            DBClass.GetInstance().RefreshAFittingSetitingRow(model, curCount);

            AddTitleFix(true);
        }

        private void GridView_FittingSettingsList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "delete")
            {
                string model = GridView_FittingSettingsList.GetFocusedRowCellValue("Model").ToString();
                //int curCount = int.Parse(GridView_FittingSettingsList.GetFocusedRowCellValue("Count").ToString());
                DBClass.GetInstance().RefreshAFittingSetitingRow(model, 0);

                AddTitleFix(true);
            }
        }

        private void rItemPictureEdit_RightPanelCount_Enter(object sender, EventArgs e)
        {
            TextBoxMaskBox innerEditor = GetInnerEdit(sender as TextEdit);
            if (innerEditor != null)
                innerEditor.ImeMode = ImeMode.Disable;
        }
        TextBoxMaskBox GetInnerEdit(BaseEdit editor)
        {
            foreach (Control innerEditor in editor.Controls)
                if (innerEditor is TextBoxMaskBox)
                    return innerEditor as TextBoxMaskBox;
            return null;
        }

        private void userControl_MenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            //if (!System.IO.File.Exists(Form_NewProject.SelectedProjectPath))
            //{
            //File.Delete();
            Form_NewProject newForm = new Form_NewProject();
            newForm.Button_Save.Text = "另存";
            newForm.TextBox_ProjectName.Text = Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
            newForm.TextBox_ProjectFolder.Text = Path.GetDirectoryName(CommonUsages.CurrentProjectPath);
            if (newForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!System.IO.File.Exists(Form_NewProject.SelectedProjectPath))
            {
                //删掉已经更新的文件
                File.Delete(CommonUsages.CurrentProjectPath);
                CommonUsages.RecentProjectClassInst.DeleteProjectrow(CommonUsages.CurrentProjectPath);

                string errMsg = "";
                if (NewAProject(Form_NewProject.SelectedProjectPath, ref errMsg) == false)
                {
                    CommonUsages.MyMsgBox(string.Format("新建项目出错。 {0}", errMsg), CommonUsages.MsgBoxTypeEnum.Error);
                    return;
                }
            }

            //}
            SaveProject();
        }

        private void pictureBox_MinForm_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox_MinForm.BackColor = System.Drawing.Color.Silver;
        }

        private void pictureBox_MinForm_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox_MinForm.BackColor = System.Drawing.Color.White;
        }

        private void pictureBoxMaxForm_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxMaxForm.BackColor = System.Drawing.Color.Silver;
        }

        private void pictureBoxMaxForm_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxMaxForm.BackColor = System.Drawing.Color.White;
        }

        private void pictureBox_CloseForm_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox_CloseForm.BackColor = System.Drawing.Color.Silver;
        }

        private void pictureBox_CloseForm_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox_CloseForm.BackColor = System.Drawing.Color.White;
        }
    }
}
