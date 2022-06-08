using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data;
using System.Drawing;

namespace Quick_Order
{
    class PricesBook
    {
        public List<ModelProperty> DeviceTypeList = new List<ModelProperty>();

        public List<ModelProperty> FittingTypeList = new List<ModelProperty>();

        public DataTable FittingPriceTable = new DataTable();

        public string CurrentSheetName = "";

        public PricesBook(string sheetName)
        {
            CurrentSheetName = sheetName == "Sheet1" ? "N-6000P系统" : sheetName;    //2021-09-27  Only N6000P supported now. Distinct Sheet name if new brand added
            CreateFittingPriceTable();
            OpenPriceBook(sheetName);
        }

        public bool OpenPriceBook(string sheetName)
        {
            if (File.Exists(CommonUsages.PriceBookPath) == false) throw new Exception("缺少价格表文件。");

            NPOI.SS.UserModel.ISheet sheet = null/* TODO Change to default(_) if this is not a reference type */;

            int headerRowIndex = 1;
            int startRowIndex = headerRowIndex + 1;

            FileStream fs = new FileStream(CommonUsages.PriceBookPath, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = new XSSFWorkbook(fs);
            sheet = workbook.GetSheet(sheetName);
            if (sheet == null)
            {
                throw new Exception("价格表文件中缺少相应表格。" + sheetName);
            }

            NPOI.SS.UserModel.IRow headerRow = sheet.GetRow(headerRowIndex);
            if (headerRow == null)
            {
                throw new Exception("价格表文件格式不正确。" + sheetName);
            }

            //一行最后一个cell的编号 即总的列数
            int cellCount = headerRow.LastCellNum;
            if (cellCount < 9) return false;
            //第一行应是标题列名,必须与标准列名保持一致，且对应到数据库的列名
            List<string> colNameList = new List<string>();
            for (int i = headerRow.FirstCellNum; i <= cellCount - 1; i++)
            {
                NPOI.SS.UserModel.ICell cell = headerRow.GetCell(i);
                if (cell != null)
                {
                    string cellValue = cell.StringCellValue;
                    if (cellValue != null)
                    {
                        colNameList.Add(cellValue);
                    }
                }
            }

            int rowCount = sheet.LastRowNum;

            string currentBrand = "";

            for (int rowIndex = startRowIndex; rowIndex <= rowCount; rowIndex++)
            {
                NPOI.SS.UserModel.IRow row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                //获取型号

                if (GetCellString(row.GetCell(2)) == "")
                {
                    string brand = GetCellString(row.GetCell(1)).Trim();
                    if (!(brand == "" || brand == "N" || brand == "-"))
                    {
                        currentBrand = brand;
                    }
                    continue;
                }
                string model = row.GetCell(2).ToString();
                if (model == "") continue;
                ModelTypeEnum modelType = GetModelType(model);
                ModelProperty modelProp = new Quick_Order.ModelProperty(model, modelType);
                modelProp.brand = currentBrand;
                modelProp.comment = GetCellString(row.GetCell(3));
                modelProp.label = GetCellString(row.GetCell(4));
                modelProp.unitPrice = GetCellDouble(row.GetCell(8));
                modelProp.picture = GetImageByModelTypeEnum(modelType);

                AddAModelProprty (modelProp, ref DeviceTypeList);               
            }
            //ModelTypeEnum modelType1 = GetModelType("SCAB-6P-4U");
            //ModelProperty modelProp1 = new Quick_Order.ModelProperty("SCAB-6P-4U", modelType1);
            //modelProp1.brand = "备品备件专用";
            //modelProp1.comment ="";
            //modelProp1.label = "4U盲板";
            //modelProp1.unitPrice = 0;
            //modelProp1.picture = GetImageByModelTypeEnum(modelType1);
            //AddAModelProprty(modelProp1, ref DeviceTypeList);
            return true;
        }

        private string GetCellString(ICell icell)
        {
            if (icell == null) return "";
            return icell.ToString();
        }

        private double GetCellDouble(ICell icell)
        {
            if (icell == null) return 0;
            string cellString = icell.ToString().Trim();
            if (cellString == "") return 0;
            try
            {
                return Math.Round(Convert.ToDouble(icell.ToString()),2)  ;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private Image GetImageByModelTypeEnum(ModelTypeEnum modelType)
        {
            Image picture = Properties.Resources.控制器;

            switch(modelType)
            {
                case ModelTypeEnum.Panel:
                    return Properties.Resources._6000P_壁挂_主机正面_基础配置;
                case ModelTypeEnum.ACM:
                    return Properties.Resources.主机正面_ACM;
                case ModelTypeEnum.FECBUS:
                    return Properties.Resources.主机背面__Model;
                case ModelTypeEnum.LCM:
                    return Properties.Resources.主机开机正面_LCM;
                case ModelTypeEnum.LPI:
                    return Properties.Resources.LPI_modbus_3_0_1;
                case ModelTypeEnum.NCM_High:
                    return Properties.Resources.主机背面___光纤网卡;
                case ModelTypeEnum.NCM_Low:
                    return Properties.Resources.主机开机正面_低速网卡;
                case ModelTypeEnum.NCM_Medium:
                    return Properties.Resources.主机开机正面_中速网卡;
                case ModelTypeEnum.POM:
                    return Properties.Resources.DXKZ_16;
                case ModelTypeEnum.Printer:
                    return Properties.Resources.主机正面_打印机;
                case ModelTypeEnum.XianChao:
                    return Properties.Resources.主机开机正面__线槽_有设备;
                case ModelTypeEnum.LCM_Holder:
                    return Properties.Resources.LCM_2PG_ZJ; 
                case ModelTypeEnum.LCM_Board:
                    return Properties.Resources.主机开机正面_MB; 
                case ModelTypeEnum.BlackBox:
                    return Properties.Resources.主机开机正面_黑盒子;
                case ModelTypeEnum.NCA:
                    return Properties.Resources.NCA;
                case ModelTypeEnum.NCS:
                    return Properties.Resources.NCS;
                case ModelTypeEnum.PS:
                    return Properties.Resources.手动报警报警按钮;
                case ModelTypeEnum.Fireydrant:
                    return Properties.Resources.消火栓报警按钮;
                case ModelTypeEnum.BianMaQi:
                    return Properties.Resources.编码器_CP900;
                case ModelTypeEnum.PSHydrantBox:
                    return Properties.Resources.手动报警与按钮消火栓_安装盒;
                case ModelTypeEnum.LCD:
                    return Properties.Resources.楼层显示器含安装盒;
                case ModelTypeEnum.BuzzerBase:
                    return Properties.Resources.带蜂鸣器底座;
                case ModelTypeEnum.SoundLight:
                    return Properties.Resources.声光;
                case ModelTypeEnum.Module:
                    return Properties.Resources.模块;
                case ModelTypeEnum.Detector:
                    return Properties.Resources.探测器;
                case ModelTypeEnum.CommonBase:
                    return Properties.Resources.普通底座;
                case ModelTypeEnum.NetworkMonitor:
                    return Properties.Resources.网络显示器; 
                case ModelTypeEnum.KITV3:
                    return Properties.Resources.N_6000P_KIT_V3;
                case ModelTypeEnum.U2Board:
                    return Properties.Resources.SCAB6P2U;
                case ModelTypeEnum.FuShanye:
                    return Properties.Resources.SCAB_6P_DR;
                case ModelTypeEnum.U3Board:
                    return Properties.Resources.SCAB_6P_3U;
                case ModelTypeEnum.U4Board:
                    return Properties.Resources.SCAB_6P_4U;
                case ModelTypeEnum.POM_Holder:
                    return Properties.Resources.DXKZ_ZJ_6P;
                case ModelTypeEnum.POM_Board:
                    return Properties.Resources.DXKZ_JXB_6P;
                case ModelTypeEnum.POM_OperateBoard:
                    return Properties.Resources.DXKZ_MB_6P;
                case ModelTypeEnum.LRS_WM_350_24:
                    return Properties.Resources.LRS_WM_350_25;
                case ModelTypeEnum.BT12M28AC:
                    return Properties.Resources.BT_12M28AC;
                case ModelTypeEnum.BT12M20AC:
                    return Properties.Resources.BT_12M20AC;
                case ModelTypeEnum.CPU:
                    return Properties.Resources.N6000P_DSP;
                case ModelTypeEnum.LiGui:
                    return Properties.Resources.SCAB_6000P_V3;
                case ModelTypeEnum.WuKaiKongBan:
                    return Properties.Resources.BMP_6P;
                case ModelTypeEnum.LRS_350_24:
                    return Properties.Resources.LRS_350_24;

            }

            return picture;
        }

        private ModelTypeEnum GetModelType(string model)
        {
            ModelTypeEnum type = ModelTypeEnum.None;
            switch (model)
            {
                case "N-6000P-KIT-V3":
                    type = ModelTypeEnum.KITV3;
                    break;
                case "N-6000P-WM-KIT-V3":
                    type = ModelTypeEnum.KITV3;
                    break;
                case "LCM-2PG":
                    type = ModelTypeEnum.LCM;
                    break;
                case "DXKZ-16":
                    type = ModelTypeEnum.POM;
                    break;
                case "ZXMB-24":
                    type = ModelTypeEnum.ACM;
                    break;
                case "NCM-F-6P-V3":
                    type = ModelTypeEnum.NCM_High;
                    break;
                case "NCM-WF-6P":
                    type = ModelTypeEnum.NCM_Medium;
                    break;
                case "NCM-W-6P":
                    type = ModelTypeEnum.NCM_Low;
                    break;
                case "uPRT-6P-V3-KIT":
                case "uPRT-6P-V3":
                    type = ModelTypeEnum.Printer;
                    break;
                case "FECBUS":
                    type = ModelTypeEnum.FECBUS;
                    break;
                case "LPI-MODBUS-V3":
                case "LPI-MODBUS-V3-SW":
                    type = ModelTypeEnum.LPI;
                    break;
                case "LCM-2PG-ZJ":
                    type = ModelTypeEnum.LCM_Holder;
                    break;
                case "LCM-2PG-MB":
                    type = ModelTypeEnum.LCM_Board;
                    break;
                case "SCAB-6P-XC":
                    type = ModelTypeEnum.XianChao;
                    break;
                case "DXKZ-ZJ-6P":
                    type = ModelTypeEnum.POM_Holder;
                    break;
                case "DXKZ-JXB-6P":
                    type = ModelTypeEnum.POM_Board;
                    break;
                case "DXKZ-MB-6P":
                    type = ModelTypeEnum.POM_OperateBoard;
                    break;
                case "LRS-350-24":
                    type = ModelTypeEnum.LRS_350_24;
                    break;
                case "LRS-WM-350-24":
                    type = ModelTypeEnum.LRS_WM_350_24;
                    break;
                case "LRS-WM-350-25":
                    type = ModelTypeEnum.Power;
                    break;
                case "BT-12M28AC":
                    type = ModelTypeEnum.BT12M28AC;
                    break;
                case "BT-12M20AC":
                    type = ModelTypeEnum.BT12M20AC;
                    break;
                case "CPU-6000P-V3":
                    type = ModelTypeEnum.CPU;
                    break;
                case "BB-6000P":
                    type = ModelTypeEnum.BlackBox;
                    break;
                case "SCAB-6000P-V3":
                    type = ModelTypeEnum.LiGui;
                    break;
                case "BMP-6P":
                    type = ModelTypeEnum.WuKaiKongBan;
                    break;
                case "SCAB-6P-DR":
                    type = ModelTypeEnum.FuShanye;
                    break;
                case "SCAB-6P-2U":
                    type = ModelTypeEnum.U2Board;
                    break;
                case "SCAB-6P-3U":
                    type = ModelTypeEnum.U3Board;
                    break;
                case "SCAB-6P-4U":
                    type = ModelTypeEnum.U4Board;
                    break;
                case "NotList":
                    type = ModelTypeEnum.NCA;
                    break;
                case "N-NCS/V4":
                    type = ModelTypeEnum.NCS;
                    break;
                case "FCI-M800K":
                    type = ModelTypeEnum.PS;
                    break;
                case "FCI-M800H":
                    type = ModelTypeEnum.Fireydrant;
                    break;
                case "CP900M":
                    type = ModelTypeEnum.BianMaQi;
                    break;
                case "BBS-X":
                    type = ModelTypeEnum.PSHydrantBox;
                    break;
                case "LCD-800":
                    type = ModelTypeEnum.LCD;
                    break;
                case "B601BH":
                    type = ModelTypeEnum.BuzzerBase;
                    break;
                case "FCI-P800A":
                    type = ModelTypeEnum.SoundLight;
                    break;
                case "FCI-MM800":
                case "FCI-CM800":
                case "FCI-CMM800":
                case "FCI-ZM800":
                case "FCI-ISO800":
                    type = ModelTypeEnum.Module;
                    break;
                case "FCI-SD800":
                case "FCI-TD800":
                    type = ModelTypeEnum.Detector;
                    break;
                case "FCI-B800":
                    type = ModelTypeEnum.CommonBase;
                    break;
                case "NX-NCA-F":
                case "NX-NCA-W":
                    type = ModelTypeEnum.NetworkMonitor;
                    break;
                case "":
                    type = ModelTypeEnum.Other;
                    break;

                default:
                    type = ModelTypeEnum.Other;
                    break;
            }

            return type;
        }

        private void CreateFittingPriceTable()
        {
            FittingPriceTable.Clear();
            FittingPriceTable.Columns.Add(new DataColumn("Model", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("SystemName", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Brand", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Picture", typeof(Image)));
            FittingPriceTable.Columns.Add(new DataColumn("Comment", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Label", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
            FittingPriceTable.Columns.Add(new DataColumn("Count", typeof(int)));
        }       
        

        public Image GetImageByModel(ModelTypeEnum modelType)
        {
            ModelProperty mProp = GetModelPropertyByType(modelType);
            if (mProp != null)
                return mProp.picture;
            return null;
        }

        public ModelProperty GetModelPropertyByType(ModelTypeEnum modelType)
        {
            foreach (ModelProperty modelP in DeviceTypeList)
            {
                if (modelP.modelType == modelType)
                {
                    return modelP;
                }
            }            

            return null;
        }

        public ModelProperty GetModelPropertyByModelName(string modelName)
        {
            foreach (ModelProperty modelP in DeviceTypeList)
            {
                if (modelP.model == modelName)
                {
                    return modelP;
                }
            }            

            return null;
        }       

        private List<string> PanelModelList = new List<string>() { "N-6000P-KIT" };
        private List<string> LCMModelList = new List<string>() { "LCM-2PG" };
        private List<string> POMModelList = new List<string>() { "DXKZ-8" };
        private List<string> ACMModelList = new List<string>() { "ZXMB-32" };
        private List<string> NCMHighList = new List<string>() { "NCM-F-6P" };
        private List<string> NCMMediumList = new List<string>() { "NCM-WF-6P" };
        private List<string> NCMLowList = new List<string>() { "NCM-W-6P" };
        private List<string> PrinterList = new List<string>() { "NCM-W-6P" };

        private void AddAModelProprty(ModelProperty NewModelPro, ref List<ModelProperty> modelProList)
        {
            //新的取代旧的
            int formerIndex = -1;
            for (int index = 0; index < modelProList.Count; index++)
            {
                if (modelProList[index].model == NewModelPro.model)
                {
                    formerIndex = index;
                    break;
                }
            }
            if (formerIndex >= 0)
            {
                modelProList.RemoveAt(formerIndex);                
            }
            modelProList.Add(NewModelPro);
        }
    }

    public enum ModelTypeEnum
    {
        None,
        Panel,
        CPU,
        LCM,
        ACM,
        POM,
        NCM_High,
        NCM_Low,
        NCM_Medium,
        Printer,
        FECBUS,
        LPI,
        BlackBox,
        LCM_Holder,
        LCM_Board,
        XianChao,
        POM_Holder,
        POM_Board,
        POM_OperateBoard,
        Power,
        Dianci,
        LiGui,
        U2Board,
        U3Board,
        FuShanye,
        WuKaiKongBan,
        NCA,
        NCS,
        PS,
        Fireydrant,
        BianMaQi,
        PSHydrantBox,
        LCD,
        BuzzerBase,
        SoundLight,
        Module,
        Detector,
        CommonBase,
        NetworkMonitor,
        Other,
        KITV3,
        LRS_350_24,
        LRS_WM_350_24,
        BT12M28AC,
        BT12M20AC,
        U4Board
    }

    public class ModelProperty
    {
        //public string cat;
        public string brand;
        public string model;
        public ModelTypeEnum modelType;
        public string label;
        public string comment;
        public double unitPrice;
        public double agentPrice;
        public string other;
        public Image picture;


        public ModelProperty(ModelTypeEnum ModelType)
        {
            modelType = ModelType;

            ModelProperty modelPro = CommonUsages.PriceBookN6000P.GetModelPropertyByType(modelType);
            if (modelPro != null)
            {
                model = modelPro.model;
                label = modelPro.label;
                comment = modelPro.comment;
                unitPrice = modelPro.unitPrice;
                agentPrice = modelPro.agentPrice;
                other = modelPro.other;
                picture = modelPro.picture;
            }                      
        }

        public ModelProperty(string ModelName)
        {
            model = ModelName;

            ModelProperty modelPro = CommonUsages.PriceBookN6000P.GetModelPropertyByModelName(ModelName);
            if (modelPro != null)
            {
                model = modelPro.model;
                modelType = modelPro.modelType;
                label = modelPro.label;
                comment = modelPro.comment;
                unitPrice = modelPro.unitPrice;
                agentPrice = modelPro.agentPrice;
                other = modelPro.other;
                picture = modelPro.picture;
            }
        }

        public ModelProperty(string ModelName, ModelTypeEnum ModelType)
        {
            model = ModelName;
            modelType = ModelType;
        }
    }

    
}
