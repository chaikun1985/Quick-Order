using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SQLite;
using System.Collections;
using System.Windows.Forms;

namespace Quick_Order
{
    class DBClass
    {
        public static DBClass DBClassInst;
        private SQLiteConnection conn;

        public DataSet DataSetAll = new DataSet("dataSetAll");

        public DataTable VersionTable = new DataTable();

        public DataTable ProjectMemoryTable = new DataTable("project");
        public DataTable ProjectTable = new DataTable();

        public DataTable ModelSettingsMemoryTable = new DataTable("modelSettings");
        public DataTable ModelSettingsTable = new DataTable();

        public DataTable ModelDeviceReportTable = new DataTable("modelDevices");

        private Dictionary<DataTable, string> DataTableMap = new Dictionary<DataTable, string>();

        private Int64 CurrentFitingsID = -1;

        DBClass()
        {
            TableNameMapping();

            CreateProjectMemoryTable();
            CreatePanelSettingsTable();

            DataSetAll.Tables.Add(ProjectMemoryTable);
            DataSetAll.Tables.Add(ModelSettingsMemoryTable);
            DataSetAll.Tables.Add(ModelDeviceReportTable);
            DataSetAll.Relations.Add(ProjectMemoryTable.Columns["ID"], ModelSettingsMemoryTable.Columns["ItemID"]);
        }

        public static DBClass GetInstance()
        {
            if (DBClassInst == null)
            {
                DBClassInst = new DBClass();
            }
            return DBClassInst;
        }


        private void TableNameMapping()
        {
            DataTableMap.Clear();
            DataTableMap.Add(VersionTable, "_version");
            DataTableMap.Add(ProjectTable, "project");
            DataTableMap.Add(ModelSettingsTable, "model");
        }

        public void InitTableData()
        {
            ProjectTable.Rows.Clear();           
            ModelSettingsTable.Rows.Clear();

            ModelSettingsMemoryTable.Rows.Clear();
            ModelDeviceReportTable.Rows.Clear();
            ProjectMemoryTable.Rows.Clear();            

            CurrentFitingsID = AddDefaultFittings("N-6000P系统");
        }

        public bool LoadAllDataToMemory(string DBFileString,ref string errMsg)
        {
            if (LoadSqliteTableDatas(DBFileString, ref errMsg) == false) return false;
            
            FillProjectMemeoryTable();
            FillModelMemeoryTable();

            return true;
        }

        public bool LoadSqliteTableDatas(string DBFileString, ref string errMsg)
        {
            try
            {
                OpenClose(true, DBFileString);
                if (ReadSQlite("select * from _version", ref VersionTable, ref errMsg) == false)
                {
                    OpenClose(false, DBFileString);
                    return false;
                }
                VersionTable.PrimaryKey = new DataColumn[] { VersionTable.Columns[0] };

                OpenClose(true, DBFileString);
                if (ReadSQlite("select * from project", ref ProjectTable, ref errMsg) == false)
                {
                    OpenClose(false, DBFileString);
                    return false;
                }
                ProjectTable.PrimaryKey = new DataColumn[] { ProjectTable.Columns[0] };

                if (ReadSQlite("select * from model", ref ModelSettingsTable, ref errMsg) == false)
                {
                    OpenClose(false, DBFileString);
                    return false;
                }
                
                OpenClose(false, DBFileString);
                return true;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                OpenClose(false, DBFileString);
                return false;
            }
        }

        public bool SaveAllDataToSqlite(string DBFileName, ref string errMsg)
        {
            try
            {
                SaveVersionTable(DBFileName);
                SaveProjectTable(DBFileName);
                SavePanelTable(DBFileName);

                SQLiteVACUUM(DBFileName);
                return true;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
        }

        #region "version表"
        private bool SaveVersionTable(string DBFileName)
        {
            try
            {
                VersionTable.Rows.Clear();
                DataRow tmpRow = VersionTable.NewRow();
                tmpRow[0] = CommonUsages.GetIntegerFromString(CommonUsages.CurrentDBVersion.Split('.')[0]);
                tmpRow[1] = CommonUsages.GetIntegerFromString(CommonUsages.CurrentDBVersion.Split('.')[1]);
                VersionTable.Rows.Add(tmpRow);

                SaveTableToSqlite(DBFileName, VersionTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving Version Table gets wrong.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public string ReadSQLiteDBVersion(string DBFileString, ref string errMsg)
        {
            string dbver = "";
            if (File.Exists(DBFileString.Trim()) == false)
            {
                errMsg = "DB not Found";
                return "";
            }
            try
            {
                OpenClose(true, DBFileString);
                if (ReadSQlite("select * from _version", ref VersionTable, ref errMsg) == false)
                {
                    OpenClose(false, DBFileString);
                    return "";
                }
                if (VersionTable.Rows.Count > 0)
                    dbver = VersionTable.Rows[0]["Major"] + "." + VersionTable.Rows[0]["Minor"];
                else
                    dbver = "1.0";
                OpenClose(false, DBFileString);
                return dbver;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return "";
            }
        }

        #endregion

        #region "Project Table"
        private void CreateProjectMemoryTable()
        {
            ProjectMemoryTable.Clear();
            ProjectMemoryTable.Columns.Add(new DataColumn("ID", typeof(Int64)));            
            ProjectMemoryTable.Columns.Add(new DataColumn("SystemType", typeof(string)));            
            ProjectMemoryTable.Columns.Add(new DataColumn("Cat", typeof(string)));
            ProjectMemoryTable.Columns.Add(new DataColumn("ItemType", typeof(string)));
            ProjectMemoryTable.Columns.Add(new DataColumn("Name", typeof(string)));
            ProjectMemoryTable.Columns.Add(new DataColumn("Picture", typeof(System.Drawing.Image)));
            ProjectMemoryTable.Columns.Add(new DataColumn("LeftPanel", typeof(System.Drawing.Image)));
            ProjectMemoryTable.Columns.Add(new DataColumn("MiddlePanel", typeof(System.Drawing.Image)));
            ProjectMemoryTable.Columns.Add(new DataColumn("RightPanel", typeof(System.Drawing.Image)));
            ProjectMemoryTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
            ProjectMemoryTable.Columns.Add(new DataColumn("Other", typeof(string)));
            ProjectMemoryTable.PrimaryKey = new DataColumn[] { ProjectMemoryTable.Columns["ID"] };           
        }

        private void FillProjectMemeoryTable()
        {
            ModelSettingsMemoryTable.Rows.Clear();
            ProjectMemoryTable.Rows.Clear();
            foreach (DataRow itemRow in ProjectTable.Rows)
            {
                DataRow newRow = ProjectMemoryTable.NewRow();
                newRow["ID"] = itemRow["ID"];
                newRow["SystemType"] = itemRow["SystemType"].ToString();
                newRow["ItemType"] = itemRow["ItemType"].ToString();
                newRow["Name"] = itemRow["Name"];           

                newRow["Picture"] = Properties.Resources.控制器;
                newRow["LeftPanel"] = null;
                newRow["MiddlePanel"] = null;
                newRow["RightPanel"] = null;

                newRow["Cat"] = itemRow["Cat"];
                newRow["Other"] = itemRow["Other"];

                ProjectMemoryTable.Rows.Add(newRow);
            }

            CurrentFitingsID = AddDefaultFittings("N-6000P系统");
        }

        private bool SaveProjectTable(string DBFileName)
        {
            ProjectTable.Rows.Clear();

            foreach (DataRow itemRow in ProjectMemoryTable.Rows)
            {
                DataRow newRow = ProjectTable.NewRow();
                newRow["ID"] = itemRow["ID"];
                newRow["SystemType"] = itemRow["SystemType"];
                newRow["ItemType"] = itemRow["ItemType"];
                newRow["Name"] = itemRow["Name"];
                newRow["Cat"] = itemRow["Cat"];
                newRow["Other"] = itemRow["Other"];

                ProjectTable.Rows.Add(newRow);
            }

            SaveTableToSqlite(DBFileName, ProjectTable);
            return true;
        }

        public Int64 GetCurrentMaxProjectID()
        {
            Int64 curMaxID = 0;
            object curMaxObj = ProjectMemoryTable.Compute("Max(ID)", string.Format("Cat = 'Panel'"));
            if (curMaxObj != DBNull.Value)
            {
                curMaxID = Convert.ToInt64(curMaxObj);
            }
            return curMaxID;
        }

        public Int64 AddANewPanel(BasicPanelSettings panel)
        {
            Int64 panelID = GetCurrentMaxProjectID() + 1;

            DataRow newProjectRow = ProjectMemoryTable.NewRow();
            newProjectRow["ID"] = panelID;
            newProjectRow["SystemType"] = panel.SystemType;
            newProjectRow["ItemType"] = panel.PanelType;
            newProjectRow["Name"] = panel.PanelLabel;
            newProjectRow["Picture"] = Properties.Resources.控制器;
            if (panel.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                newProjectRow["LeftPanel"] = Properties.Resources.主机正面_基础配置01;
                newProjectRow["MiddlePanel"] = Properties.Resources.主机开机正面_基础配置;
                newProjectRow["RightPanel"] = Properties.Resources.主机背面__基础配置;
            }
            if (panel.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                newProjectRow["LeftPanel"] = Properties.Resources._6000P_壁挂_主机正面_基础配置;
                newProjectRow["MiddlePanel"] = Properties.Resources._6000P_壁挂_主机开机正面__基础配置;
                newProjectRow["RightPanel"] = null;
            }

            newProjectRow["Cat"] = "Panel";
            newProjectRow["Other"] = "";
            newProjectRow["Price"] = 0;
            ProjectMemoryTable.Rows.Add(newProjectRow);

            if (panel.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
                AddAPanelSettingRow(new ModelProperty(BasicPanelSettings.PANELTYPE_N6000P_MODELNAME), panelID, 1);
            if (panel.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
                AddAPanelSettingRow(new ModelProperty(BasicPanelSettings.PANELTYPE_N6000PBIGUA_MODELNAME), panelID, 1);

            return panelID;
        }

        private Int64 DefaultFittingID = 99999;
        public Int64 AddDefaultFittings(string SystemType)
        {
            string filterString = string.Format("SystemType = '{0}' and Cat = 'Fittings'", SystemType);
            DataRow[] findRow = ProjectMemoryTable.Select(filterString);
            if (findRow.Length > 0)
            {
                return Convert.ToInt64(findRow[0]["ID"]);
            }
            
            Int64 fittinsID = DefaultFittingID;

            DataRow newProjectRow = ProjectMemoryTable.NewRow();
            newProjectRow["ID"] = fittinsID;
            newProjectRow["SystemType"] = SystemType;
            newProjectRow["Cat"] = "Fittings";
            newProjectRow["ItemType"] = "Fittings";
            newProjectRow["Name"] = "配件列表";
            newProjectRow["Picture"] = Properties.Resources.icon_产品配置;            
            newProjectRow["Other"] = "";
            ProjectMemoryTable.Rows.Add(newProjectRow);

            return fittinsID;
        }

        public void DeleteAPanel(Int64 panelID)
        {
            DataRow findRow = ProjectMemoryTable.Rows.Find(panelID);
            if (findRow != null)
            {
                ProjectMemoryTable.Rows.Remove(findRow);
            }

            string filterString = string.Format("ItemID = '{0}'", panelID);
            DataRow[] findRows = ModelSettingsMemoryTable.Select(filterString);
            if (findRows.Length > 0)
            {
                foreach (DataRow itemRow in findRows)
                {
                    ModelSettingsMemoryTable.Rows.Remove(itemRow);
                }
            }
        }

        public BasicPanelSettings ReadPanelSettingsFromTable(Int64 panelID)
        {
            BasicPanelSettings panel = null;
            if (panelID == DefaultFittingID)
                return null;
            DataRow findRow = ProjectMemoryTable.Rows.Find(panelID);
            if (findRow == null)
            {
                return panel;
            }

            string systemType = findRow["SystemType"].ToString();
            string panelType = findRow["ItemType"].ToString();
            string panelName = findRow["Name"].ToString();
            if (panelType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                panel = new N6000PPanelSettings(panelID, panelName);
            }
            if (panelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                panel = new N6000PBiGuaSettings(panelID, panelName);
            }
            panel.PanelLabel = panelName;
            panel.PanelType = panelType;

            panel.ACMCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.ACM, panelID);
            panel.POMCount = BasicPanelSettings.GetPlusKitCount(ModelTypeEnum.POM, GetSpecModelTypeCountFromTable(ModelTypeEnum.POM, panelID));
            panel.FecbusModuleCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.FECBUS, panelID);
            panel.LCMCardCount = BasicPanelSettings.GetPlusKitCount(ModelTypeEnum.LCM, GetSpecModelTypeCountFromTable(ModelTypeEnum.LCM, panelID));
            panel.LPIModbusCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.LPI, panelID);
            panel.NCMHighCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.NCM_High, panelID);
            panel.NCMMediumCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.NCM_Medium, panelID);
            panel.NCMLowCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.NCM_Low, panelID);
            panel.PrinterCount = BasicPanelSettings.GetPlusKitCount(ModelTypeEnum.Printer,GetSpecModelTypeCountFromTable(ModelTypeEnum.Printer, panelID));
            panel.BlackBoxCount = GetSpecModelTypeCountFromTable(ModelTypeEnum.BlackBox, panelID);

            return panel;
        }

        public void RefreshPanelNameByID(Int64 PanelID, string panelName)
        {
            DataRow findRow = ProjectMemoryTable.Rows.Find(PanelID);
            if (findRow != null)
            {
                findRow["Name"] = panelName;               
            }
        }
     
        #endregion

        #region "PanelSettingsTable"
        private void CreatePanelSettingsTable()
        {
            ModelSettingsMemoryTable.Clear();
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("ID", typeof(Int64)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Model", typeof(string)));   //板卡型号
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Cat", typeof(string)));     //Panel or Fittings
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("ItemID", typeof(Int64)));   //对应Project表的ID
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("ModelType", typeof(string)));  //对应的LCM、ACM等显示名
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Brand", typeof(string)));      //Fittings处的分类名
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Picture", typeof(System.Drawing.Image)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Comment", typeof(string)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Label", typeof(string)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Count", typeof(int)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("TotalPrice", typeof(decimal)));
            ModelSettingsMemoryTable.Columns.Add(new DataColumn("Other", typeof(string)));
            ModelSettingsMemoryTable.PrimaryKey = new DataColumn[] { ModelSettingsMemoryTable.Columns["Model"], ModelSettingsMemoryTable.Columns["ItemID"] };

            ModelDeviceReportTable = ModelSettingsMemoryTable.Clone();
            ModelDeviceReportTable.TableName = "modelDevices";
        }

        private void FillModelMemeoryTable()
        {
            
            foreach (DataRow itemRow in ModelSettingsTable.Rows)
            {
                DataRow newRow = ModelSettingsMemoryTable.NewRow();
                string model = itemRow["Model"].ToString();
                newRow["Model"] = model;
                newRow["ItemID"] = itemRow["ItemID"];

                ModelProperty modelPro = CommonUsages.PriceBookN6000P.GetModelPropertyByModelName(model);
                if (modelPro == null) continue;

                newRow["Cat"] = itemRow["Cat"];

                newRow["ModelType"] = (int)modelPro.modelType;

                newRow["Picture"] = modelPro.picture;

                newRow["Label"] = modelPro.label;
                newRow["Comment"] = modelPro.comment;
                int count = Convert.ToInt32(itemRow["Count"]);
                newRow["Count"] = count;

                newRow["UnitPrice"] = modelPro.unitPrice;

                newRow["TotalPrice"] = modelPro.unitPrice * count;
                newRow["Other"] = itemRow["Other"];

                ModelSettingsMemoryTable.Rows.Add(newRow);
            }
        }

        private bool SavePanelTable(string DBFileName)
        {
            ModelSettingsTable.Rows.Clear();

            foreach (DataRow itemRow in ModelSettingsMemoryTable.Rows)
            {
                DataRow newRow = ModelSettingsTable.NewRow();
                newRow["Model"] = itemRow["Model"];
                newRow["ItemID"] = itemRow["ItemID"];
                newRow["Count"] = itemRow["Count"];
                newRow["Other"] = itemRow["Other"];
                newRow["Cat"] = itemRow["Cat"];

                ModelSettingsTable.Rows.Add(newRow);
            }

            SaveTableToSqlite(DBFileName, ModelSettingsTable);
            return true;
        }
        
        private void AddAPanelSettingRow(ModelProperty modelPro, Int64 panelID, int count)
        {
            if (count == 0)
            {
                return;
            }
            DataRow newRow = ModelSettingsMemoryTable.NewRow();
            newRow["Model"] = modelPro.model;
            newRow["ItemID"] = panelID;

            newRow["Cat"] = "Panel";

            newRow["ModelType"] = (int)modelPro.modelType;
            newRow["Picture"] = modelPro.picture;

            newRow["Label"] = modelPro.label;
            newRow["Comment"] = modelPro.comment;

            newRow["Count"] = count;
            newRow["UnitPrice"] = modelPro.unitPrice;
            newRow["TotalPrice"] = modelPro.unitPrice * count;

            newRow["Other"] = modelPro.other;

            ModelSettingsMemoryTable.Rows.Add(newRow);
        }

        private DataRow FindModelSettingsRowByType(ModelTypeEnum modelType, Int64 PanelID)
        {
            string filterString = string.Format("ModelType = '{0}' and ItemID = '{1}'", (int)modelType, PanelID);
            DataRow[] findRow = ModelSettingsMemoryTable.Select(filterString);
            if (findRow.Length > 0)
            {
                return findRow[0];
            }
            return null;
        }

        private int GetSpecModelTypeCountFromTable(ModelTypeEnum modelType, Int64 PanelID)
        {
            int count = 0;
            DataRow findRow = FindModelSettingsRowByType(modelType, PanelID);
           
            if (findRow != null)
            {
                count = Convert.ToInt32(findRow["Count"]);
            }
            return count;
        }

        public void RefreshPanelSettingRowByModelType(ModelTypeEnum modelType, BasicPanelSettings curPanelSettings, int count, bool refreshBasic = true)
        {
            count = BasicPanelSettings.GetMinusKitCount(modelType, count);

            DataRow findRow = FindModelSettingsRowByType(modelType, curPanelSettings.ID);
            if (findRow != null)
            {
                if (count > 0)
                {
                    findRow["Count"] = count;
                    double unitPrice = Convert.ToDouble(findRow["UnitPrice"]);
                    findRow["TotalPrice"] = unitPrice * count;
                }
                else
                {
                    ModelSettingsMemoryTable.Rows.Remove(findRow);
                }
            }
            else
            {
                if (count > 0)
                {
                    AddAPanelSettingRow(new ModelProperty(modelType), curPanelSettings.ID, count);
                }
            }
            if (refreshBasic == true) RefreshBasicPanelSettings(curPanelSettings);
        }

        public void RefreshBasicPanelSettings(BasicPanelSettings curPanelSettings)
        {
            if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000P)
            {
                N6000PPanelSettings subSettings = curPanelSettings as N6000PPanelSettings;
                RefreshPanelSettingRowByModelType(ModelTypeEnum.LCM_Holder, curPanelSettings, subSettings.GetLCMHolderBoardCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.LCM_Board, curPanelSettings, subSettings.GetLCMHolderBoardCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.POM_Holder, curPanelSettings, subSettings.GetPOMHolderCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.POM_Board, curPanelSettings, subSettings.GetPOMBoardCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.POM_OperateBoard, curPanelSettings, subSettings.GetPOMOperateBoardCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.XianChao, curPanelSettings, subSettings.GetXianChaoCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.U2Board, curPanelSettings, subSettings.GetU2Count(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.U3Board, curPanelSettings, subSettings.GetU3Count(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.WuKaiKongBan, curPanelSettings, subSettings.GetWuKaiKongChenban(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.FuShanye, curPanelSettings, subSettings.GetFuShanyeCount(), false);
            }
            if (curPanelSettings.PanelType == BasicPanelSettings.PANELTYPE_N6000PBIGUA)
            {
                N6000PBiGuaSettings subSettings = curPanelSettings as N6000PBiGuaSettings;
                RefreshPanelSettingRowByModelType(ModelTypeEnum.LCM_Holder, curPanelSettings, subSettings.GetLCMHolderBoardCount(), false);
                RefreshPanelSettingRowByModelType(ModelTypeEnum.LCM_Board, curPanelSettings, subSettings.GetLCMHolderBoardCount(), false);
            }
        }

        #endregion

        #region "FittingsMemoryTable"
        
        public void RefreshAFittingSetitingRow(string model, int count)
        {
            DataRow findRow = ModelSettingsMemoryTable.Rows.Find(new object[] { model, CurrentFitingsID });
            if (count == 0)
            {                
                if (findRow != null)
                {
                    ModelSettingsMemoryTable.Rows.Remove(findRow);
                }
            }
            else
            {
                ModelProperty modelPro = CommonUsages.PriceBookN6000P.GetModelPropertyByModelName(model);
                if (findRow != null)
                {
                    findRow["Count"] = count;
                    findRow["UnitPrice"] = modelPro.unitPrice;
                    findRow["TotalPrice"] = modelPro.unitPrice * count;
                }
                else
                {
                    DataRow newRow = ModelSettingsMemoryTable.NewRow();
                    newRow["Model"] = model;

                    newRow["ItemID"] = CurrentFitingsID;
                    newRow["Cat"] = "Fittings";

                    newRow["Brand"] = modelPro.brand;
                    newRow["Picture"] = modelPro.picture;
                    newRow["Label"] = modelPro.label;
                    newRow["Comment"] = modelPro.comment;

                    newRow["Count"] = count;
                    newRow["UnitPrice"] = modelPro.unitPrice;
                    newRow["TotalPrice"] = modelPro.unitPrice * count;

                    newRow["Other"] = modelPro.other;

                    ModelSettingsMemoryTable.Rows.Add(newRow);
                }
            }
        }

        public void DeleteAFittingSetitingRow(string model)
        {
            DataRow findRow = ModelSettingsMemoryTable.Rows.Find(new object[] { model, CurrentFitingsID });
            if (findRow != null) ModelSettingsMemoryTable.Rows.Remove(findRow);
        }

        #endregion

        #region "Report Table"
        public decimal FillDevicesReportTable()
        {
            ModelDeviceReportTable.Rows.Clear();
            decimal allPrice = 0;
            int index = 0;
            foreach (DataRow itemRow in ModelSettingsMemoryTable.Rows)
            {
                string model = itemRow["Model"].ToString();
                Int64 itemID = Convert.ToInt64(itemRow["ItemID"]);
                int count = Convert.ToInt32(itemRow["Count"]);
                decimal unitPrice = Convert.ToDecimal(itemRow["UnitPrice"]);
                decimal totalPrice = Convert.ToDecimal(itemRow["TotalPrice"]);
                allPrice = allPrice + totalPrice;

                DataRow[] findRow = ModelDeviceReportTable.Select(string.Format("Model = '{0}'", model));
                if (findRow.Length == 0)
                {
                    DataRow newRow = ModelDeviceReportTable.NewRow();
                    newRow["ID"] = ++index;
                    newRow["Model"] = model;
                    newRow["ItemID"] = itemRow["ItemID"];
                    newRow["Label"] = itemRow["Label"];
                    newRow["Comment"] = itemRow["Comment"];
                    newRow["Count"] = count;
                    newRow["UnitPrice"] = itemRow["UnitPrice"];
                    newRow["TotalPrice"] = itemRow["TotalPrice"];

                    ModelDeviceReportTable.Rows.Add(newRow);
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
        }

        public decimal FillPanelReportTable()
        {
            decimal allTotalPrice = 0;
            Dictionary<Int64, int> indexList = new Dictionary<Int64, int>();
            Dictionary<Int64, decimal> priceList = new Dictionary<Int64, decimal>();
            foreach (DataRow itemRow in ModelSettingsMemoryTable.Rows)
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
                allTotalPrice = allTotalPrice + price;
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
            foreach (DataRow itemRow in ProjectMemoryTable.Rows)
            {
                Int64 itemID = Convert.ToInt64(itemRow["ID"]);
                if (priceList.ContainsKey(itemID) == true)
                {
                    itemRow["Price"] = priceList[itemID];
                }
            }

            return allTotalPrice;
        }
        #endregion

        #region "SQlite数据库相关"
        /// 数据库在执行了删除数据操作后，不会主动调整数据库文件的大小。只是在添加数据后会增大文件Size       
        public bool SQLiteVACUUM(string DBFileName)
        {
            try
            {
                OpenClose(true, DBFileName);
                ClearSQLite("VACUUM");
                OpenClose(false, DBFileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private string[] Element = new[] { "@ELement1", "@ELement2", "@ELement3", "@ELement4", "@ELement5", "@ELement6",
            "@ELement7", "@ELement8", "@ELement9", "@ELement10", "@ELement11", "@ELement12", "@ELement13", "@ELement14",
            "@ELement15", "@ELement16", "@ELement17", "@ELement18", "@ELement19", "@ELement20", "@ELement21", "@ELement22",
            "@ELement23", "@ELement24", "@ELement25", "@ELement26", "@ELement27", "@ELement28", "@ELement29", "@ELement30" };

        private DbType ReturnDbType(string Ctemp)
        {
            switch (Ctemp.ToLower())
            {
                case "system.string":
                    {
                        return System.Data.DbType.String;
                    }

                case "system.int64":
                    {
                        return System.Data.DbType.Int64;
                    }

                case "system.int32":
                    {
                        return System.Data.DbType.Int32;
                    }

                case "system.byte[]":
                    {
                        return System.Data.DbType.Binary;
                    }

                default:
                    {
                        return System.Data.DbType.Object;
                    }
            }
        }

        /// <summary>
        /// 写DB
        /// </summary>
        /// <param name="Tablename"></param>
        /// <param name="WriteItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool WriteSQlite(string Tablename, ArrayList WriteItem)
        {
            int i;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd = conn.CreateCommand();
                var Ctemp = "insert into " + Tablename + " values(";
                for (i = 1; i <= WriteItem.Count - 1; i++)
                {
                    Ctemp += Element[i - 1] + ",";
                    cmd.Parameters.Add(Element[i - 1], ReturnDbType(WriteItem[i - 1].GetType().ToString())).Value = WriteItem[i - 1];
                }
                Ctemp += Element[WriteItem.Count - 1] + ")";
                cmd.Parameters.Add(Element[WriteItem.Count - 1], ReturnDbType(WriteItem[WriteItem.Count - 1].GetType().ToString())).Value = WriteItem[WriteItem.Count - 1];
                cmd.CommandText = Ctemp;
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void SaveDataFromTable(string Tablename, DataTable MyTable)
        {
            int i;
            int i1;
            ArrayList MyArrayList = new ArrayList();
            try
            {
                // Using tran = conn.BeginTransaction
                for (i = 0; i <= MyTable.Rows.Count - 1; i++)
                {
                    for (i1 = 0; i1 <= MyTable.Columns.Count - 1; i1++)
                    {
                        // /2017-7-28 针对sqlite特殊的rowid处理
                        if (MyTable.Columns[i1].ColumnName == "rowid")
                            continue;
                        if (MyTable.Rows[i][i1].ToString() == "True")
                            MyArrayList.Add(1);
                        else if (MyTable.Rows[i][i1].ToString() == "False")
                            MyArrayList.Add(0);
                        else
                            MyArrayList.Add(MyTable.Rows[i][i1]);
                    }
                    WriteSQlite(Tablename, MyArrayList);
                    MyArrayList.Clear();
                }
            }
            // tran.Commit()
            // End Using
            catch (Exception ex)
            {
            }
        }


        public bool SaveTableToSqlite(string DBFileName, DataTable SavedTable)
        {
            try
            {
                OpenClose(true, DBFileName);
                string tmp = DataTableMap[SavedTable];
                // 可极大提升更新Sqlite数据库的速度。
                using (var tran = conn.BeginTransaction())
                {
                    ClearSQLite("delete  from " + tmp);
                    SaveDataFromTable(tmp, SavedTable);
                    tran.Commit();
                }
                OpenClose(false, DBFileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 读数据到内存中
        /// </summary>
        /// <param name="CommandString"></param>
        /// <param name="ReturnTable"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ReadSQlite(string CommandString, ref DataTable ReturnTable, ref string errMsg)
        {
            try
            {
                ReturnTable.Rows.Clear();
                SQLiteDataAdapter sa = new SQLiteDataAdapter(CommandString, conn);
                sa.Fill(ReturnTable);
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 执行SQLite表的SQL命令
        /// </summary>
        /// <param name="CommandString"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool ClearSQLite(string CommandString)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = CommandString; // "delete from Test WHERE TestName='动静1'"
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Open or Close SQLite DB
        /// </summary>
        /// <param name="B">打开还是关闭数据库连接。</param>
        /// <remarks></remarks>
        public void OpenClose(bool B, string DBFilename)
        {
            try
            {
                if (B)
                {
                    if (File.Exists(DBFilename) == false)
                    {
                        MessageBox.Show("Can't find DBFile :" + DBFilename);
                        return;
                    }
                    string ConnString = "Data Source=" + DBFilename + ";Pooling=true;FailIfMissing=false";
                    conn = new SQLiteConnection(ConnString);
                    if (conn.State != ConnectionState.Open)
                    {
                        //if (CheckDBEncrypt(DBFilename) == true)
                        //conn.SetPassword("sy23*#@$-SH89");
                        conn.Open();
                        //string newPasswd = "";
                        //if (true)
                        //    newPasswd = "sy23*#@$-SH89";
                        //conn.ChangePassword(newPasswd);
                    }
                }
                else
                {
                    if (conn == null)
                        return;
                    conn.Close();
                    SQLiteConnection.ClearAllPools();
                    GC.Collect();    // 2015-05-14 使用兼容64位的DLL后，不能及时释放资源，导致执行删除数据库文件操作时提示被其他进程占用
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(DBFilename) == false)
                {
                    MessageBox.Show("Open find DBFile :" + DBFilename + " Err");
                    return;
                }
                else
                    MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SQLite dll 新版本移除了对Password的支持。https://sqlite.org/forum/forumpost/a8c99c68e1
        /// </summary>
        /// <param name="dbFilename"></param>
        public void EncryptSqlitDB(string dbFilename)
        {
            SQLiteConnection enConn = new SQLiteConnection();
            try
            {
                if (File.Exists(dbFilename) == false)
                {
                    MessageBox.Show("Can't find DBFile :" + dbFilename);
                    return;
                }
                string ConnString = "Data Source=" + dbFilename + ";Pooling=true;FailIfMissing=false";
                enConn = new SQLiteConnection(ConnString);
                if (enConn.State != ConnectionState.Open)
                    //enConn.SetPassword("sy23*#@$-SH89");
                    enConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                enConn.Close();
                SQLiteConnection.ClearAllPools();
                GC.Collect();
            }
            return;
        }

        public void DecryptSqlitDB(string dbFilename, string passwd)
        {
            SQLiteConnection enConn = new SQLiteConnection();
            try
            {
                if (File.Exists(dbFilename) == false)
                {
                    MessageBox.Show("Can't find DBFile :" + dbFilename);
                    return;
                }
                string ConnString = "Data Source=" + dbFilename + ";Pooling=true;FailIfMissing=false";
                enConn = new SQLiteConnection(ConnString);
                if (enConn.State != ConnectionState.Open)
                {
                    //if (CheckDBEncrypt(dbFilename) == true)
                    //enConn.SetPassword(passwd);
                    enConn.Open();
                    //enConn.ChangePassword("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                enConn.Close();
                SQLiteConnection.ClearAllPools();
                GC.Collect();
            }
            return;
        }

        public bool CheckDBEncrypt(string dbFilename)
        {
            SQLiteConnection enConn = new SQLiteConnection();
            try
            {
                if (File.Exists(dbFilename) == false)
                {
                    MessageBox.Show("Can't find DBFile :" + dbFilename);
                    return false;
                }
                string ConnString = "Data Source=" + dbFilename + ";Pooling=true;FailIfMissing=false";
                enConn = new SQLiteConnection(ConnString);
                if (enConn.State != ConnectionState.Open)
                {
                    enConn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "select * from _version";
                    cmd.Connection = enConn;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                }

                return false;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("encrypted"))
                    return true;
                return false;
            }
            finally
            {
                enConn.Close();
                SQLiteConnection.ClearAllPools();
                GC.Collect();
            }
        }


        #endregion

        private void ExportRegisterToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {                       
            string exceloutFilePath = "ProjectName" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xls";

            DataTable curTable = ModelSettingsMemoryTable.Copy();
            curTable.DefaultView.Sort = string.Format("SlaveNum, Register ASC");
            curTable = curTable.DefaultView.ToTable();

            string sheetName = "Register";

            using (var fs = new FileStream(exceloutFilePath, FileMode.Append, FileAccess.Write))
            {
                IWorkbook workbook = new HSSFWorkbook();
                string xlsSheetName = curTable.TableName;
                if (!string.IsNullOrEmpty(sheetName))
                    xlsSheetName = sheetName;
                ISheet excelSheet = workbook.CreateSheet(xlsSheetName);


                ICellStyle headStyle = workbook.CreateCellStyle();
                headStyle.FillForegroundColor = IndexedColors.Blue.Index;
                headStyle.FillPattern = FillPattern.SolidForeground;


                List<string> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                foreach (System.Data.DataColumn column in curTable.Columns)
                {
                    columns.Add(column.ColumnName);
                    ICell cell = row.CreateCell(columnIndex);
                    cell.CellStyle = headStyle;
                    cell.SetCellValue(column.ColumnName);
                    columnIndex += 1;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in curTable.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;

                    foreach (string col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex += 1;
                    }

                    rowIndex += 1;
                }

                for (int ii = 0; ii <= curTable.Columns.Count - 1; ii++)
                    excelSheet.AutoSizeColumn(columnIndex);
                // excelSheet.SetAutoFilter(New CellRangeAddress(0, 0, 0, curTable.Columns.Count - 1))
                excelSheet.CreateFreezePane(curTable.Columns.Count, 1);

                workbook.Write(fs);
            }
        }

        public bool ImportExcel(string fileName)
        {
            // 加载到Register表，然后load到RegisterMemory中
            // 定义要返回的datatable对象
            DataTable data = new DataTable();
            NPOI.SS.UserModel.ISheet sheet = null/* TODO Change to default(_) if this is not a reference type */;
            string sheetName = "Register";
            int startRow = 0;

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = new HSSFWorkbook(fs);
            sheet = workbook.GetSheet(sheetName);
            if (sheet == null)
            {
                return false;
            }

            NPOI.SS.UserModel.IRow firstRow = sheet.GetRow(0);
            if (firstRow == null)
            {
                return false;
            }

            //一行最后一个cell的编号 即总的列数
            int cellCount = firstRow.LastCellNum;
            //第一行应是标题列名,必须与标准列名保持一致，且对应到数据库的列名
            List<string> colNameList = new List<string>();
            for (int i= firstRow.FirstCellNum;i<=cellCount-1;i++)
            {
                NPOI.SS.UserModel.ICell cell = firstRow.GetCell(i);
                if (cell != null)
                {
                    string cellValue = cell.StringCellValue;
                    if (cellValue != null)
                    {
                        colNameList.Add(cellValue);
                    }
                }
            }

            startRow = sheet.FirstRowNum + 1;
            int rowCount = sheet.LastRowNum;
            int blankStartMsgIndex = -1;

            for (int rowIndex= startRow;rowIndex<=rowCount;rowIndex++)
            {
                NPOI.SS.UserModel.IRow row = sheet.GetRow(rowIndex);
                if (row==null)
                {
                    continue;
                }

                Dictionary<string, string> cellStringMap = new Dictionary<string, string>();
                bool isBlankRow = true;
                for (int colIndex=0;colIndex<=cellCount-1;colIndex++)
                {
                    if (row.GetCell(colIndex) == null || row.GetCell(colIndex).ToString()=="")
                    {
                        
                    }
                    else
                    {
                        isBlankRow = false;
                        string ss = row.GetCell(colIndex).ToString();
                    }
                }
            }

            return true;
        }

    }
}
