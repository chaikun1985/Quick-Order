using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace Quick_Order
{
    public partial class Form_Report : Form
    {
        public Form_Report()
        {
            InitializeComponent();

            
        }

        public delegate bool GeneratePanelImagesDelegate();
        public GeneratePanelImagesDelegate GeneratePanelImages;
        private bool PanelImageStatus = false;

        private XtraReport_QD QD_Report;
        private XtraReport_QDMasterDetail QDMD_Report;

        private XtraReport_QD QD_Report_Excel;
        private XtraReport_QDMasterDetail QDMD_Report_Excel;

        private string CurrentSortMode = "Device";

        private void Form_Report_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(Form_Wait), false, false, false);

            if (GeneratePanelImages != null)
            {
                PanelImageStatus = GeneratePanelImages();
            }

            GenerateReport();
            Button_CheckBox_SortByPanel.PerformClick();

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

        private void pictureBox_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        private void Button_CheckBox_Panel_Click(object sender, EventArgs e)
        {
            Button_CheckBox_SortByPanel.ForeColor = Color.White;
            Button_CheckBox_SortByPanel.BackColor = Color.FromArgb(23, 146, 229);

            Button_Checkbox_SortByDevice.ForeColor = Color.Gray;
            Button_Checkbox_SortByDevice.BackColor = Color.FromArgb(240, 240, 240);

            CurrentSortMode = "Panel";
            ChangeFocusdReport();
        }

        private void Button_Checkbox_Device_Click(object sender, EventArgs e)
        {
            Button_CheckBox_SortByPanel.ForeColor = Color.Gray;
            Button_CheckBox_SortByPanel.BackColor = Color.FromArgb(240, 240, 240);

            Button_Checkbox_SortByDevice.ForeColor = Color.White;
            Button_Checkbox_SortByDevice.BackColor = Color.FromArgb(23, 146, 229);

            CurrentSortMode = "Device";
            ChangeFocusdReport();
        }

        private void CheckEdit_ShowPanelPicture_CheckedChanged(object sender, EventArgs e)
        {
            GenerateReport();
            ChangeFocusdReport();
        }

        private void ChangeFocusdReport()
        {
            if (CurrentSortMode == "Panel")
            {
                printControl1.Visible = true;
                printControl1.PrintingSystem = QDMD_Report.PrintingSystem;
            }
            if (CurrentSortMode == "Device")
            {
                printControl1.Visible = true;
                printControl1.PrintingSystem = QD_Report.PrintingSystem;
            }            
        }

        private void GenerateReport(bool forExcel = false)
        {
            //Sort by Panels
            if (forExcel == false)   
            {
                QDMD_Report = new XtraReport_QDMasterDetail();
                QDMD_Report.InitPage(CheckEdit_ShowPanelPicture.Checked);

                decimal allTotalPrice = DBClass.GetInstance().FillPanelReportTable();               
                QDMD_Report.DataSource = DBClass.GetInstance().DataSetAll;
                
                string projectName = System.IO.Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
                QDMD_Report.Label_HeadTitle.Text = string.Format("项目配置清单：{0}", projectName);
                QDMD_Report.Label_HeadTitle2.Text = projectName;
                QDMD_Report.Label_HeadTotalPrice.Text = string.Format("￥{0}", allTotalPrice);

                QDMD_Report.CreateDocument();
            }
            else
            {
                QDMD_Report_Excel = new XtraReport_QDMasterDetail();
                QDMD_Report_Excel.InitPage(CheckEdit_ShowPanelPicture.Checked, true);

                decimal allTotalPrice = DBClass.GetInstance().FillPanelReportTable();
                QDMD_Report_Excel.DataSource = DBClass.GetInstance().DataSetAll;

                string projectName = System.IO.Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
                QDMD_Report_Excel.Label_HeadTitle.Text = string.Format("项目配置清单：{0}", projectName);
                QDMD_Report_Excel.Label_HeadTitle2.Text = projectName;
                QDMD_Report_Excel.Label_HeadTotalPrice.Text = string.Format("￥{0}", allTotalPrice);

                QDMD_Report_Excel.CreateDocument();
            }

            //Sort by Devices
            if (forExcel == false)  
            {
                QD_Report = new XtraReport_QD();
                QD_Report.InitPage(CheckEdit_ShowPanelPicture.Checked);

                decimal allTotalPrice = DBClass.GetInstance().FillDevicesReportTable();

                string projectName = System.IO.Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
                QD_Report.Label_HeadTitle.Text = string.Format("项目配置清单：{0}", projectName);
                QD_Report.Label_HeadTitle2.Text = projectName;
                QD_Report.Label_HeadTotalPrice.Text = string.Format("￥{0}", allTotalPrice);

                QD_Report.CreateDocument();
            }
            else
            {
                QD_Report_Excel = new XtraReport_QD();
                QD_Report_Excel.InitPage(CheckEdit_ShowPanelPicture.Checked, true);

                decimal allTotalPrice = DBClass.GetInstance().FillDevicesReportTable();

                string projectName = System.IO.Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
                QD_Report_Excel.Label_HeadTitle.Text = string.Format("项目配置清单：{0}", projectName);
                QD_Report_Excel.Label_HeadTitle2.Text = projectName;
                QD_Report_Excel.Label_HeadTotalPrice.Text = string.Format("￥{0}", allTotalPrice);

                QD_Report_Excel.CreateDocument();
            }
        }


        private void Button_ExportExcel_Click(object sender, EventArgs e)
        {
            if (printControl1.Visible == false) return;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel File|*.xlsx";
            saveDialog.DefaultExt = "xlsx";
            saveDialog.AddExtension = true;
            saveDialog.ValidateNames = true;

            if (saveDialog.ShowDialog()==DialogResult.OK)
            {
                string excel1Path = CommonUsages.PathCombine(CommonUsages.TempFolder, string.Format("e1_{0}", DateTime.Now.ToString("yy_MM_dd_HH_mm_ss")));
                string excel2Path = CommonUsages.PathCombine(CommonUsages.TempFolder, string.Format("e2_{0}", DateTime.Now.ToString("yy_MM_dd_HH_mm_ss")));
                try
                {
                    SplashScreenManager.ShowForm(null, typeof(Form_Wait), false, false, false);                   

                    //Combine Excel Sheets

                    if (Directory.Exists(CommonUsages.TempFolder) == false)
                        Directory.CreateDirectory(CommonUsages.TempFolder);

                    GenerateReport(true);

                    QDMD_Report_Excel.ExportToXlsx(excel1Path, new DevExpress.XtraPrinting.XlsxExportOptions() { SheetName = "按控制器排列" });
                    QD_Report_Excel.ExportToXlsx(excel2Path, new DevExpress.XtraPrinting.XlsxExportOptions() { SheetName = "按设备排列" });

                    CombineExcel(excel1Path, excel2Path, saveDialog.FileName);

                    SplashScreenManager.CloseForm(false);
                    CommonUsages.MyMsgBox("导出成功。", CommonUsages.MsgBoxTypeEnum.Info);
                }
                catch (Exception ee)
                {
                    SplashScreenManager.CloseForm(false);
                    CommonUsages.MyMsgBox(ee.Message, CommonUsages.MsgBoxTypeEnum.Error);
                }
                finally
                {
                    if (File.Exists(excel1Path) == true)
                        File.Delete(excel1Path);
                    if (File.Exists(excel2Path) == true)
                        File.Delete(excel2Path);
                }
            }
        }

        private bool CombineExcel(string excel1, string excel2, string excelAim)
        {
            _Excel.Application Eapp = new _Excel.Application();
            _Excel.Workbook wbk = null;
            _Excel.Workbook wbk1 = null;
            _Excel.Workbook wbk2 = null;

            try
            {
                 wbk = Eapp.Workbooks.Add();
                _Excel._Worksheet sheet = wbk.Sheets[1];

                //打开一个Excel并复制
                wbk1 = Eapp.Workbooks.Open(excel2);
                _Excel._Worksheet sheet1 = wbk1.Sheets[1];
                sheet1.Copy(Type.Missing, sheet);//sheet1复制在sheet的后面 sheet1.Copy(sheet,Type.Missing,); sheet1复制在sheet的前面
                wbk1.Close(0);

                //再打开复制一个
                wbk2 = Eapp.Workbooks.Open(excel1);
                _Excel._Worksheet sheet2 = wbk2.Sheets[1];
                sheet2.Copy(Type.Missing, sheet);
                wbk2.Close(0);

                sheet.Delete();
                wbk.SaveAs(excelAim);
                wbk.Close(0);   //EXCEL.exe always in the backup apps

                //Eapp.Visible = true;

                return true;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                if (wbk != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(wbk);
                if (wbk1 != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(wbk1);
                if (wbk2 != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(wbk2);
                Eapp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Eapp);
            }            
        }

        private void Button_Print_Click(object sender, EventArgs e)
        {
            if (printControl1.Visible == false) return;

            if (CurrentSortMode == "Panel")
            {
                QDMD_Report.PrintingSystem.ShowMarginsWarning = false;
                QDMD_Report.PrintDialog();
            }
            if (CurrentSortMode == "Device")
            {
                QD_Report.PrintingSystem.ShowMarginsWarning = false;
                QD_Report.PrintDialog();
            }            
        }

        private void pictureBox_CloseForm_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void Form_Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
