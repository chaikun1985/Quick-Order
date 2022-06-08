using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;
using DevExpress.XtraSplashScreen;

namespace Quick_Order
{
    class CommonUsages
    {
        public static string SoftwareName = "Quick Order";
        public static string ConfigFolder = Application.StartupPath + @"\Config\";
        public static string SoftwareConfigFileName = "QuickConfig";
        public static string TempFolder = PathCombine(ConfigFolder, "Temp");
        public static string ProjectSuffix = ".qder";

        public static string CustomFontFolder = PathCombine(ConfigFolder, "Fonts");
        public static string CustomFontTTFFile = PathCombine(CustomFontFolder, "PingFang SC Regular.ttf");

        public static string PriceBookFolder = PathCombine(ConfigFolder, "PriceBook");
        public static string PriceBookPath = PathCombine(ConfigFolder, "");

        public static string PanelImageFolder = PathCombine(ConfigFolder, "PanelImage");

        public static string CurrentDBVersion = "1.0";

        public static DataSet SystemDataSet = new DataSet();
        public static DataTable SystemTable = new DataTable();
        public static DataTable BrandTable = new DataTable();
        public static DataTable FittingPriceTable = new DataTable();
        public static PricesBook PriceBookN6000P;
        public static RecentProjectClass RecentProjectClassInst;

        public static string CurrentProjectPath = "";
        public static bool IsInDebug = false;

        public static void Init()
        {
            try
            {
                GetPriceBookFile();
                CommonUsages.PriceBookN6000P = new PricesBook("Sheet1");  //N-6000P系统   
            }
            catch (Exception ee)
            {
                SplashScreenManager.CloseForm(false);
                CommonUsages.MyMsgBox("无法打开价格表文件。\n\r" + ee.Message, CommonUsages.MsgBoxTypeEnum.Error);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }


            SystemTable.Clear();
            SystemTable.Columns.Add(new DataColumn("SystemName", typeof(string)));

            BrandTable.Clear();
            BrandTable.Columns.Add(new DataColumn("SystemName", typeof(string)));
            BrandTable.Columns.Add(new DataColumn("Brand", typeof(string)));
            BrandTable.PrimaryKey = new DataColumn[] { BrandTable.Columns["Brand"] };

            CreateFittingPriceTable();

            FillBrandTable();

            SystemDataSet.Tables.Add(SystemTable);
            SystemDataSet.Tables.Add(BrandTable);
            SystemDataSet.Relations.Add(SystemTable.Columns["SystemName"], BrandTable.Columns["SystemName"]);
        }

        private static string GetPriceBookFile()
        {
            DateTime recentTime = new DateTime(1980, 1, 1);
            string fileName = "";
            DirectoryInfo folder = new DirectoryInfo(PriceBookFolder);
            foreach(FileInfo file in folder.GetFiles())
            {
                if (file.Name.Contains("Price Book") || file.Name.Contains("PriceBook") || file.Name.Contains("Price+Book"))
                {
                    if (file.LastWriteTime > recentTime)
                    {
                        recentTime = file.LastWriteTime;
                        fileName = file.Name;
                    }
                }
            }

            if (fileName != "")
            {
                PriceBookPath = PathCombine(PriceBookFolder, fileName);
            }
            return fileName;
        }

        private static void FillBrandTable()
        {
            SystemTable.Rows.Clear();
            DataRow newSystemRow = SystemTable.NewRow();
            newSystemRow["SystemName"] = PriceBookN6000P.CurrentSheetName;
            SystemTable.Rows.Add(newSystemRow);

            BrandTable.Rows.Clear();
            foreach (ModelProperty item in PriceBookN6000P.DeviceTypeList)
            {
                if (BrandTable.Rows.Find(item.brand) == null)
                {
                    DataRow newRow = BrandTable.NewRow();
                    newRow["SystemName"] = PriceBookN6000P.CurrentSheetName;
                    newRow["Brand"] = item.brand;
                    BrandTable.Rows.Add(newRow);
                }

                if (/*item.modelType != ModelTypeEnum.Panel ||*/ item.modelType != ModelTypeEnum.KITV3)  //21-08-17 除了控制器本身外，其它都可以作为配件额外购买
                {
                    DataRow newFittingPriceRow = FittingPriceTable.NewRow();
                    newFittingPriceRow["Model"] = item.model;
                    newFittingPriceRow["SystemName"] = PriceBookN6000P.CurrentSheetName;
                    newFittingPriceRow["Brand"] = item.brand;
                    newFittingPriceRow["Picture"] = PriceBookN6000P.GetImageByModel(item.modelType);
                    newFittingPriceRow["Label"] = item.label;
                    newFittingPriceRow["Comment"] = item.comment;
                    newFittingPriceRow["UnitPrice"] = item.unitPrice;
                    newFittingPriceRow["Count"] = 1;
                    FittingPriceTable.Rows.Add(newFittingPriceRow);
                }                
            }
        }

        private static void CreateFittingPriceTable()
        {
            FittingPriceTable.Clear();
            FittingPriceTable.Columns.Add(new DataColumn("Model", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("SystemName", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Brand", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Picture", typeof(Image)));
            FittingPriceTable.Columns.Add(new DataColumn("Label", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Comment", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Count", typeof(int)));
        }
               
        public static string PathCombine(string path1, string path2)
        {
            string result = path1.TrimEnd('\\');

            result = result + @"\" + path2.TrimStart('\\');

            result = result.TrimEnd('\\');
            return result;
        }

        public static int GetIntegerFromString(string NumString)
        {
            string pattern = @"\d+";
            System.Text.RegularExpressions.Match iMatch = System.Text.RegularExpressions.Regex.Match(NumString, pattern);
            if (iMatch.Success == true)
                return Convert.ToInt32(iMatch.ToString());

            return -1;
        }

        public enum MsgBoxTypeEnum
        {
            Info,
            Error,
            Warning
        }

        public static void MyMsgBox(string MessageText, MsgBoxTypeEnum MessageType)
        {
            switch (MessageType)
            {
                case MsgBoxTypeEnum.Info:
                    MessageBox.Show(MessageText, "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MsgBoxTypeEnum.Warning:
                    MessageBox.Show(MessageText, "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MsgBoxTypeEnum.Error:
                    MessageBox.Show(MessageText, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show(MessageText, "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        public static bool IsInteger(string s)
        {
            string pattern = @"^\d*$";
            return System.Text.RegularExpressions.Regex.IsMatch(s, pattern);
        }
        /// <summary>
        /// 判断一个字符串是否为合法数字(0-32整数)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string s)
        {
            return IsNumber(s, 32, 0);
        }

        /// <summary>
        /// 判断一个字符串是否为合法数字(指定整数位数和小数位数)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="precision">整数位数</param>
        /// <param name="scale">小数位数</param>
        /// <returns></returns>
        public static bool IsNumber(string s, int precision, int scale)
        {
            if ((precision == 0) && (scale == 0))
            {
                return false;
            }
            string pattern = @"(^\d{1," + precision + "}";
            if (scale > 0)
            {
                pattern += @"\.\d{0," + scale + "}$)|" + pattern;
            }
            pattern += "$)";
            return System.Text.RegularExpressions.Regex.IsMatch(s, pattern);
        }

        public static string TrimEndString(string basicString, string endString)
        {
            string result = basicString;
            while (result.EndsWith(endString) == true)
                result = result.Substring(0, result.Length - endString.Length);

            return result;
        }

        public static string TrimStartString(string basicString, string startString)
        {
            string result = basicString;
            while (result.StartsWith(startString) == true)
                result = result.Substring(startString.Length);

            return result;
        }

        public delegate void PopupFunctionDelegate();

        public static void GrayMainFormWhenPopup(Form mainForm, PopupFunctionDelegate popupFunction)
        {
            // take a screenshot of the form and darken it:
            Bitmap bmp = new Bitmap(mainForm.ClientRectangle.Width, mainForm.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(mainForm.PointToScreen(new Point(0, 0)), new Point(0, 0), mainForm.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, mainForm.ClientRectangle);
                }
            }

            // put the darkened screenshot into a Panel and bring it to the front:
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = mainForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                mainForm.Controls.Add(p);
                p.BringToFront();

                // display your dialog somehow:
                //Form frm = new Form();
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.ShowDialog(mainForm);
                popupFunction();

            } // panel will 
        }
    }
}
