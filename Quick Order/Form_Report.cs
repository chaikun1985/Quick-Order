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

        private decimal CopyTotalPrice = 0;

        public static DataSet ds = new DataSet();

        public bool IsSave = false;
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
                
                //DataSet ds = DBClass.GetInstance().DataSetAll;            
                //QDMD_Report.DataSource = ds;
                QDMD_Report.DataSource = FillDataSource();

                string projectName = System.IO.Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
                QDMD_Report.Label_HeadTitle.Text = string.Format("项目配置清单：{0}", projectName);
                QDMD_Report.Label_HeadTitle2.Text = projectName;
                //QDMD_Report.Label_HeadTotalPrice.Text = string.Format("￥{0}", allTotalPrice); CopyTotalPrice

                QDMD_Report.Label_HeadTotalPrice.Text = string.Format("￥{0}", CopyTotalPrice);

                QDMD_Report.CreateDocument();
            }
            else
            {
                QDMD_Report_Excel = new XtraReport_QDMasterDetail();
                QDMD_Report_Excel.InitPage(CheckEdit_ShowPanelPicture.Checked, true);

                decimal allTotalPrice = DBClass.GetInstance().FillPanelReportTable();
                //QDMD_Report_Excel.DataSource = DBClass.GetInstance().DataSetAll;

                QDMD_Report_Excel.DataSource = FillDataSource();

                string projectName = System.IO.Path.GetFileNameWithoutExtension(CommonUsages.CurrentProjectPath);
                QDMD_Report_Excel.Label_HeadTitle.Text = string.Format("项目配置清单：{0}", projectName);
                QDMD_Report_Excel.Label_HeadTitle2.Text = projectName;
                //QDMD_Report_Excel.Label_HeadTotalPrice.Text = string.Format("￥{0}", allTotalPrice);
                QDMD_Report_Excel.Label_HeadTotalPrice.Text = string.Format("￥{0}", CopyTotalPrice);

                QDMD_Report_Excel.CreateDocument();
            }

            //Sort by Devices
            if (forExcel == false)  
            {
                QD_Report = new XtraReport_QD();
                QD_Report.InitPage(CheckEdit_ShowPanelPicture.Checked);

                //decimal allTotalPrice = DBClass.GetInstance().FillDevicesReportTable();
                decimal allTotalPrice = FillDevicesDataSource();
                //QDMD_Report.DataSource = ds.Tables[2];
                //QD_Report.DataSource = ds;

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

                //decimal allTotalPrice = DBClass.GetInstance().FillDevicesReportTable();
                decimal allTotalPrice = FillDevicesDataSource();
                //QD_Report_Excel.DataSource = ds;

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
                string excel1Path = CommonUsages.PathCombine(CommonUsages.TempFolder, string.Format("e1_{0}.xlsx", DateTime.Now.ToString("yy_MM_dd_HH_mm_ss")));
                string excel2Path = CommonUsages.PathCombine(CommonUsages.TempFolder, string.Format("e2_{0}.xlsx", DateTime.Now.ToString("yy_MM_dd_HH_mm_ss")));
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

                    //保存配置
                    IsSave = true;
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
        private DataSet FillDataSource()
        {
            
            DataSet dsTemp = DBClass.GetInstance().DataSetAll;

            DataTable dtProjectTemp = dsTemp.Tables[0];
            //DataTable dtProject = dtProjectTemp.Copy() ; //不知道为什么copy时候，price那一列数据复制不过去，是否跟数据类型有关系？？？
            DataTable dtProject = dtProjectTemp.Clone();
            dtProject.PrimaryKey = null;
            dtProject.Columns.Add("sortId", typeof(Int64));
            int tempRowHandle = 0;
            foreach (DataRow item in dtProjectTemp.Rows)
            {
                dtProject.Rows.Add(item.ItemArray);
                dtProject.Rows[tempRowHandle]["sortId"] = item["ID"]; //sortId对应原先老的id
                tempRowHandle++;
                //dtProject.ImportRow(item);
            }

            DataTable dtModelSettingsTemp = dsTemp.Tables[1];
            DataTable dtModelSettings = dtModelSettingsTemp.Copy();

            DataTable dtmodelDevicesTemp = dsTemp.Tables[2];
            DataTable dtmodelDevices = dtmodelDevicesTemp.Copy();

            // 处理下数量的问题
            int id = 1;
            foreach (DataRow item in dtProject.Rows)
            {
                 //id从1开始
                if (item["Cat"].ToString() == "Panel")
                {
                    int Others = int.Parse(item["Other"].ToString());
                    
                    //先修改关联的  ModelSettings表的值
                    DataRow[] drs = dtModelSettings.Select(string.Format("ItemID = {0}", Convert.ToInt64(item["ID"]) ));
                    foreach (DataRow itemModelSettings in drs)
                    {
                        itemModelSettings["ItemID"] = 10000 +id;
                    }
                    item["ID"] = 10000 + id;
                    id = id + Others; //这个id是下一行数据的id值

                }
            }
            foreach (DataRow item in dtProject.Rows)
            {
                if (item["Cat"].ToString() == "Panel")
                {
                    item["ID"] =int.Parse(item["ID"].ToString())  - 10000;
                }
            }
            foreach (DataRow item in dtModelSettings.Rows)
            {
                if (item["Cat"].ToString() == "Panel")
                {
                    item["ItemID"] = int.Parse(item["ItemID"].ToString()) - 10000;
                }              
            }

            //以下将复制的给
            Int64 IdChang = 0;
            int OtherChang = 0;
            foreach (DataRow drProjecttemp in dtProjectTemp.Rows)
            {
                if (drProjecttemp["Cat"].ToString() == "Panel" && !string.IsNullOrEmpty(drProjecttemp["Other"].ToString())  && Int64.Parse(drProjecttemp["Other"].ToString())  > 1)
                {
                    //drProjecttemp["sortId"] = GetCurrentTableIDColumn(dtProject);  //sortId这里表示的是排序
                    Int64 SortIdFont = Int64.Parse(drProjecttemp["ID"].ToString());
                    string TempName = drProjecttemp["Name"].ToString();
                    //drProjecttemp["Name"] = drProjecttemp["Name"] + "-" + "1";
                     //IdChang = Convert.ToInt16(SortIdFont)  + OtherChang ;

                    DataRow[] drs = dtProject.Select(string.Format("sortId = {0}", SortIdFont.ToString()));
                    drs[0]["Name"] = drProjecttemp["Name"] + "-" + "1";
                    IdChang = Convert.ToInt64(drs[0]["ID"]);
                    Int64 IdSource = Int64.Parse(drProjecttemp["ID"].ToString()) ;
                    
                    for (int i = 1; i < Int64.Parse(drProjecttemp["Other"].ToString()); i++)
                    {
                        DataRow dr = dtProject.NewRow();
                        //dr = drProject.ItemArray as DataRow;
                        //Int64 Id = GetCurrentTableID(dtProject);
                        dr["ID"] = IdChang + i;
                        dr["SystemType"] = drProjecttemp["SystemType"].ToString();
                        dr["ItemType"] = drProjecttemp["ItemType"].ToString();
                        dr["Name"] = TempName + "-" + (i +1) .ToString();

                        dr["Picture"] = drProjecttemp["Picture"];
                        dr["LeftPanel"] = drProjecttemp["LeftPanel"];
                        dr["MiddlePanel"] = drProjecttemp["MiddlePanel"];
                        dr["RightPanel"] = drProjecttemp["RightPanel"];
                        dr["Price"] = drProjecttemp["Price"];
                        dr["Cat"] = drProjecttemp["Cat"];
                        dr["Other"] = drProjecttemp["Other"];
                        dr["sortId"] = SortIdFont ;
                        dtProject.Rows.Add(dr);

                        DataRow[] row = dtModelSettingsTemp.Select(
                                           "ItemID = " + IdSource
                                                           );

                        foreach (DataRow item in row)
                        {
                            DataRow newRow = dtModelSettings.NewRow();
                            newRow["ID"] = item["ID"];
                            newRow["Model"] = item["Model"];
                            newRow["ItemID"] = IdChang + i;

                            newRow["Cat"] = item["Cat"];

                            newRow["ModelType"] = item["ModelType"];
                            newRow["Picture"] = item["Picture"];
                             
                            newRow["Label"] = item["Label"];
                            newRow["Comment"] = item["Comment"];

                            newRow["Count"] = item["Count"]; ;
                            newRow["UnitPrice"] = item["UnitPrice"];
                            newRow["TotalPrice"] = item["TotalPrice"];

                            newRow["Other"] = "1";

                            dtModelSettings.Rows.Add(newRow);
                        }
                       // IdChang++;
                    }
                    OtherChang = int.Parse(drProjecttemp["Other"].ToString())  ;
                }
            }
            if (ds.Tables.Count <= 0)
            {
                var resultGroupedByColumn = dtProject.Rows.Cast<DataRow>().GroupBy(r => r["sortId"].ToString());//对索引为0的一列进行分组，结果是集合
                if (resultGroupedByColumn != null && resultGroupedByColumn.Count() > 0)
                {
                    DataTable dt1 = dtProject.Clone();
                    foreach (IGrouping<string, DataRow> rows in resultGroupedByColumn)
                    {
                        DataTable dataTable = rows.ToArray().CopyToDataTable();
                        dt1.Merge(dataTable);
                    }
                    dtProject.Clear();
                    dtProject.Merge(dt1);
                }

                //dtProject.DefaultView.Sort = "sortId asc";

                ds.Tables.Add(dtProject);
                ds.Tables.Add(dtModelSettings);
                ds.Tables.Add(dtmodelDevices);
                ds.Relations.Add(dtProject.Columns["ID"], dtModelSettings.Columns["ItemID"]);             
            }
            else
            {
                //ds.Tables.Clear();
                //dtProject.DefaultView.Sort = "sortId asc";
                var resultGroupedByColumn = dtProject.Rows.Cast<DataRow>().GroupBy(r => r["sortId"].ToString());//对索引为0的一列进行分组，结果是集合
                if (resultGroupedByColumn != null && resultGroupedByColumn.Count() > 0)
                {
                    DataTable dt1 = dtProject.Clone();
                    foreach (IGrouping<string, DataRow> rows in resultGroupedByColumn)
                    {
                        DataTable dataTable = rows.ToArray().CopyToDataTable();
                        dt1.Merge(dataTable);
                    }
                    dtProject.Clear();
                    dtProject.Merge(dt1);
                }
                ds.Clear();
                ds.Tables[0].Merge(dtProject);
                ds.Tables[1].Merge(dtModelSettings);
                ds.Tables[2].Merge(dtmodelDevices);
                
            }
            //ds.Clear();
            //ds.Tables.Add(dtProject);
            //ds.Tables.Add(dtModelSettings);
            //ds.Tables.Add(dtmodelDevices);
            //ds.Relations.Add(dtProject.Columns["ID"], dtModelSettings.Columns["ItemID"]);

            CopyTotalPrice = 0;
            Dictionary<Int64, int> indexList = new Dictionary<Int64, int>();
            Dictionary<Int64, decimal> priceList = new Dictionary<Int64, decimal>();
            foreach (DataRow itemRow in dtModelSettings.Rows)
            {
                Int64 itemID = Convert.ToInt64(itemRow["ItemID"]);
                if (indexList.ContainsKey(itemID))
                {
                    indexList[itemID] = indexList[itemID] + 1;
                }
                else
                {
                    indexList.Add(itemID, 1);
                }
                itemRow["ID"] = indexList[itemID];

                decimal price = Convert.ToDecimal(itemRow["TotalPrice"]);
                CopyTotalPrice = CopyTotalPrice + price;
                if (priceList.ContainsKey(itemID))
                {
                    priceList[itemID] = priceList[itemID] + price;
                }
                else
                {
                    priceList.Add(itemID, price);
                }
            }

            //ProjectTableMemory Price
            foreach (DataRow itemRow in dtProject.Rows)
            {
                Int64 itemID = Convert.ToInt64(itemRow["ID"]);
                if (priceList.ContainsKey(itemID) == true)
                {
                    itemRow["Price"] = priceList[itemID];
                }
            }
 
            return ds;
        }

        private decimal FillDevicesDataSource()
        {
            DataTable dtModelSettings = ds.Tables[1];
            DBClass.GetInstance().ModelDeviceReportTable.Rows.Clear();
            decimal allPrice = 0;
            int index = 0;
            foreach (DataRow itemRow in dtModelSettings.Rows)
            {
                string model = itemRow["Model"].ToString();
                Int64 itemID = Convert.ToInt64(itemRow["ItemID"]);
                int count = Convert.ToInt32(itemRow["Count"]);
                decimal unitPrice = Convert.ToDecimal(itemRow["UnitPrice"]);
                decimal totalPrice = Convert.ToDecimal(itemRow["TotalPrice"]);
                allPrice = allPrice + totalPrice;

                DataRow[] findRow = DBClass.GetInstance().ModelDeviceReportTable.Select(string.Format("Model = '{0}'", model));
                if (findRow.Length == 0)
                {
                    DataRow newRow = DBClass.GetInstance().ModelDeviceReportTable.NewRow();
                    newRow["ID"] = ++index;
                    newRow["Model"] = model;
                    newRow["ItemID"] = itemRow["ItemID"];
                    newRow["Label"] = itemRow["Label"];
                    newRow["Comment"] = itemRow["Comment"];
                    newRow["Count"] = count;
                    newRow["UnitPrice"] = itemRow["UnitPrice"];
                    newRow["TotalPrice"] = itemRow["TotalPrice"];

                    DBClass.GetInstance().ModelDeviceReportTable.Rows.Add(newRow);
                }
                else
                {
                    int formerCount = Convert.ToInt32(findRow[0]["Count"]);
                    count = count + formerCount;
                    decimal newTotalPrice = count * unitPrice;
                    findRow[0]["Count"] = count;
                    findRow[0]["TotalPrice"] = newTotalPrice;
                }
            }
            return allPrice;

            //DataTable dtModelDevic = ds.Tables[2];
            //DataTable dtModelSettings = ds.Tables[1];

            //dtModelDevic.Rows.Clear();
            //decimal allPrice = 0;
            //int index = 0;
            //foreach (DataRow itemRow in dtModelSettings.Rows)
            //{
            //    string model = itemRow["Model"].ToString();
            //    Int64 itemID = Convert.ToInt64(itemRow["ItemID"]);
            //    int count = Convert.ToInt32(itemRow["Count"]);
            //    decimal unitPrice = Convert.ToDecimal(itemRow["UnitPrice"]);
            //    decimal totalPrice = Convert.ToDecimal(itemRow["TotalPrice"]);
            //    allPrice = allPrice + totalPrice;

            //    DataRow[] findRow = dtModelDevic.Select(string.Format("Model = '{0}'", model));
            //    if (findRow.Length == 0)
            //    {
            //        DataRow newRow = dtModelDevic.NewRow();
            //        newRow["ID"] = ++index;
            //        newRow["Model"] = model;
            //        newRow["ItemID"] = itemRow["ItemID"];
            //        newRow["Label"] = itemRow["Label"];
            //        newRow["Comment"] = itemRow["Comment"];
            //        newRow["Count"] = count;
            //        newRow["UnitPrice"] = itemRow["UnitPrice"];
            //        newRow["TotalPrice"] = itemRow["TotalPrice"];

            //        dtModelDevic.Rows.Add(newRow);
            //    }
            //    else
            //    {
            //        int formerCount = Convert.ToInt32(findRow[0]["Count"]);
            //        count = count + formerCount;
            //        decimal newTotalPrice = count * unitPrice;
            //        findRow[0]["Count"] = count;
            //        findRow[0]["TotalPrice"] = newTotalPrice;
            //    }
            //}
            //return allPrice;
        }
        public Int64 GetCurrentTableID(DataTable dt)
        {
             
            Int64 curMaxID = 0;
            object curMaxObj = dt.Compute("Max(ID)", string.Format("Cat = 'Panel'"));
            if (curMaxObj != DBNull.Value)
            {
                curMaxID = Convert.ToInt64(curMaxObj);
            }
            return curMaxID;
        }

        public Int64 GetCurrentTableIDColumn(DataTable dt)
        {

            Int64 curMaxID = 0;
            object curMaxObj = dt.Compute("Max(sortId)", string.Format("Cat = 'Panel'"));
            if (curMaxObj != DBNull.Value)
            {
                curMaxID = Convert.ToInt64(curMaxObj);
            }
            return curMaxID;
        }
    }
}
