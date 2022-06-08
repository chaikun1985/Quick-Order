using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quick_Order
{
    public abstract class BasicPanelSettings
    {
        public Int64 ID = -1;
        public string PanelLabel = "控制器";
        public string SystemType = "";
        public string PanelType = "";

        public const string SYSTEMTYPE_N6000P = "N-6000P";
        public const string PANELTYPE_N6000P = "N-6000P立柜";
        public const string PANELTYPE_N6000PBIGUA = "N-6000P壁挂";
        public const string PANELTYPE_N6000P_MODELNAME = "N-6000P-KIT-V3";
        public const string PANELTYPE_N6000PBIGUA_MODELNAME = "N-6000P-WM-KIT-V3";

        public static int DefaultPOMCount = 1;
        public static int DefaultLCMCardCount = 1;
        public static int DefaultBlackBoxCount = 0;
        public static int DefaultPrinterCount = 0;
        public static int DefautDianchiCount = 2;
        public static int DefautPowerCount = 1;
        public static int DefautLiGuiCount = 1;       

        public int LCMCardCount = 0;
        public int POMCount = 0;
        public int ACMCount = 0;
        public int LPIModbusCount = 0;
        public int FecbusModuleCount = 0;
        public int NCMHighCount = 0;
        public int NCMLowCount = 0;
        public int NCMMediumCount = 0;
        public int BlackBoxCount = 0;  
        public int PrinterCount = 0;

        public BasicPanelSettings(Int64 panelID)
        {
            ID = panelID;

            LCMCardCount = DefaultLCMCardCount;
            POMCount = DefaultPOMCount;
            BlackBoxCount = DefaultBlackBoxCount;  
            PrinterCount = DefaultPrinterCount;
        }

        public BasicPanelSettings(Int64 panelID, string panelName)
        {
            ID = panelID;
            PanelLabel = panelName;

            LCMCardCount = DefaultLCMCardCount;
            POMCount = DefaultPOMCount;
            BlackBoxCount = DefaultBlackBoxCount;  
            PrinterCount = DefaultPrinterCount;
        }

        /// <summary>
        /// 考虑到套件的存在。在“控制器”页面计算单品数量时，要增加/删除套件内的数量。
        /// 该操作随着左面操作栏选择单品数量而变。对于套件内默认数量为0的数据，其实不用增减操作。
        /// “配件”页面为独立于控制器的单独购买页面。可以在控制器的购买页面外继续购买除了“套件”以外的单品
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// 
        //打印机和黑盒子现在都自选
        public static int GetMinusKitCount(ModelTypeEnum modelType, int count)
        {
            switch (modelType)
            {
                case ModelTypeEnum.ACM:
                    return count;
                case ModelTypeEnum.BlackBox:
                    // return count - DefaultBlackBoxCount;
                    return count ;
                case ModelTypeEnum.Dianci:
                    return count - DefautDianchiCount;
                case ModelTypeEnum.FECBUS:
                    return count;
                case ModelTypeEnum.FuShanye:
                    return count;
                case ModelTypeEnum.LCM:
                    return count - DefaultLCMCardCount;
                case ModelTypeEnum.LCM_Board:
                    return count - 1;
                case ModelTypeEnum.LCM_Holder:
                    return count - 1;
                case ModelTypeEnum.LiGui:
                    return count - 1;
                case ModelTypeEnum.LPI:
                    return count;
                case ModelTypeEnum.NCM_High:
                    return count;
                case ModelTypeEnum.NCM_Low:
                    return count;
                case ModelTypeEnum.NCM_Medium:
                    return count;
                case ModelTypeEnum.Panel:
                    return count;
                case ModelTypeEnum.POM:
                    return count - DefaultPOMCount;
                case ModelTypeEnum.POM_Board:
                    return count - 1;
                case ModelTypeEnum.POM_Holder:
                    return count ;
                case ModelTypeEnum.POM_OperateBoard:
                    return count - 1;
                case ModelTypeEnum.Power:
                    return count - 1;
                case ModelTypeEnum.Printer:
                    //return count - 1;
                    return count;
                case ModelTypeEnum.U2Board:
                    //return (count - 3) >= 0 ? (count - 3) : 0;
                    return count;
                case ModelTypeEnum.U3Board:
                    return count;
                // (count - 2) >= 0 ? (count - 2) : 0;
                case ModelTypeEnum.U4Board:
                    return count;              
                case ModelTypeEnum.WuKaiKongBan:
                    return count;
                   // return (count - 4) >= 0 ? (count - 4) : 0;
                case ModelTypeEnum.XianChao:
                    return (count - 3) >= 0 ? (count - 3) : 0;

                default:
                    return count;
            }
        }

        public static int GetPlusKitCount(ModelTypeEnum modelType, int count)
        {
            switch (modelType)
            {
                case ModelTypeEnum.ACM:
                    return count;
                case ModelTypeEnum.BlackBox:
                    return count + DefaultBlackBoxCount;
                case ModelTypeEnum.Dianci:
                    return count + DefautDianchiCount;
                case ModelTypeEnum.FECBUS:
                    return count;
                case ModelTypeEnum.FuShanye:
                    return count;
                case ModelTypeEnum.LCM:
                    return count + DefaultLCMCardCount;
                case ModelTypeEnum.LCM_Board:
                    return count + 1;
                case ModelTypeEnum.LCM_Holder:
                    return count + 1;
                case ModelTypeEnum.LiGui:
                    return count + 1;
                case ModelTypeEnum.LPI:
                    return count;
                case ModelTypeEnum.NCM_High:
                    return count;
                case ModelTypeEnum.NCM_Low:
                    return count;
                case ModelTypeEnum.NCM_Medium:
                    return count;
                case ModelTypeEnum.Panel:
                    return count;
                case ModelTypeEnum.POM:
                    return count + DefaultPOMCount;
                case ModelTypeEnum.POM_Board:
                    return count + 1;
                case ModelTypeEnum.POM_Holder:
                    return count + 1;
                case ModelTypeEnum.POM_OperateBoard:
                    return count + 1;
                case ModelTypeEnum.Power:
                    return count + 1;
                case ModelTypeEnum.Printer:
                    return count ;
                case ModelTypeEnum.U2Board:
                    return (count - 3) <= 3 ? (count - 3) : 0;
                case ModelTypeEnum.U3Board:
                    return (count - 2) <= 2 ? (count - 2) : 0;
                case ModelTypeEnum.WuKaiKongBan:
                    return (count + 4) <= 9 ? (count + 4) : 9;
                case ModelTypeEnum.XianChao:
                    return (count + 3) <= 10 ? (count + 3) : 10;

                default:
                    return count;
            }
        }

        public abstract bool CheckError();

    }

    public class N6000PBiGuaSettings : BasicPanelSettings
    {
        public static int POMMaxCount = 1;
        public static int ACMMaxCount = 1;

        public N6000PBiGuaSettings(long panelID,string label) : base(panelID,label)
        {
            SystemType = SYSTEMTYPE_N6000P;
            PanelType = PANELTYPE_N6000PBIGUA;          
        }

        public bool HaveNCMLowMedium()
        {
            if ((NCMLowCount + NCMMediumCount) >= 1)
                return true;
            else
                return false;
        }

        public int GetFrontOpenBeibanCount()
        {
            //因为必有POM，且一个板子。所以至少两个板卡。
            //高速网卡、FECBus、LPI可以放在没有主板的卡的左右位置。所以最多三个（此时LCM的数量必定小于5）。
            //LCM的数量大于4时，高速网卡、FECBus、LPI最多只有一个
            int beibanCount = 2;

            int lcmHolderBoardCount = GetLCMHolderBoardCount();            
            if (lcmHolderBoardCount == 2)
            {
                return 3;  //第三个背板必须放POM
            }
            if (lcmHolderBoardCount == 1)
            {                
                if (HaveNCMLowMedium() == true)
                {
                    return 3; //POM
                }
                else
                {
                    int H_F_LCount = NCMHighCount + FecbusModuleCount + LPIModbusCount;
                    if (H_F_LCount > 1) return 3; else return 2;
                }
            }            

            return beibanCount;
        }

        public int GetLCMHolderBoardCount()
        {
            int count = 1;
            if (LCMCardCount > 4) return 2;
            return count;
        }

        public int GetWuKaiKongChenban()
        {
            int count = 0;
            if (PrinterCount > 1)
            {
                PrinterCount = 1;
            }
            int usedCount = ACMCount + POMCount + PrinterCount;//因为打印机这里数量是2，不知道为啥是2
            if (usedCount <=3)
            {
                count = 3 - usedCount;
            }

            return count;          
        }

        /// <summary>
        /// POM的背板在第二板上还是第三个
        /// 如果LCM>4或者存在中低速网卡，POM一定在3的位置上。POM在的位置同样可以给高速网卡/LPI/FecBus。
        /// 如果LCM<=4且没有中低速网卡。则第二第三板都可以给POM/高速网卡/LPI/FecBus用。默认把POM放在最靠前的位置
        /// </summary>
        /// <returns></returns>
        public int GetPOMPositionBoard()
        {
            int pos = 2;
            if (HaveNCMLowMedium() == true)
            {
                return 3;
            }
            if (GetLCMHolderBoardCount() == 2)
            {
                return 3;
            }
            return pos;
        }

        public override bool CheckError()
        {
            int H_F_LCount = NCMHighCount + FecbusModuleCount + LPIModbusCount;
            int pomPos = GetPOMPositionBoard();
            if (pomPos == 2)
            {               
                if (H_F_LCount > 3)
                    throw new Exception("位置已被其他板卡占据，无法更改。");
            }
            if (pomPos == 3)
            {
                if (H_F_LCount > 1)
                    throw new Exception("位置已被其他板卡占据，无法更改。");
            }
            return true;
        }
    }  

    public class N6000PPanelSettings : BasicPanelSettings 
    {
        public static int POMMaxCount = 4;
        public static int ACMMaxCount = 4;

        public N6000PPanelSettings(Int64 panelID, string panelName) : base(panelID, panelName)
        {
            SystemType = SYSTEMTYPE_N6000P;
            PanelType = PANELTYPE_N6000P;           
        }

        public bool HaveNCMLowMedium()
        {
            if ((NCMLowCount + NCMMediumCount) >= 1)
                return true;
            else
                return false;
        }

        public int GetFrontOpenBeibanCount()
        {
            int beibanCount = GetLCMHolderBoardCount();
            if (beibanCount == 1)
            {
                if (HaveNCMLowMedium() && BlackBoxCount > 0)
                {
                    beibanCount = 2;
                }
            }

            return beibanCount;
        }

        public int GetBackBeiBanCount()
        {
            int beibanCount = POMCount;
            int noPOMCount = LPIModbusCount + FecbusModuleCount + NCMHighCount;

            switch(POMCount)
            {
                case 4:
                    return 4;
                case 3:
                    if (noPOMCount >= 4) return 4;
                    else return 3;
                case 2:
                    if (noPOMCount == 3 || noPOMCount == 4)
                    {
                        return 3;
                    }
                    else if(noPOMCount == 5)
                    {
                        return 4;
                    }
                    else return 2;
                case 1:
                    if (noPOMCount >= 4) return 3;
                    else if(noPOMCount >= 2) return 2;
                    else return 1;
            }
            return beibanCount;
        }

        public int GetBackXianCaoCount()
        {
            int count = GetBackBeiBanCount();
            if (count >= 3) count++;    //第三个背板和第二个背板错开了，平面上显示两个槽
            return count;
        }

        public int GetLCMHolderBoardCount()
        {
            int count = 1;
            if (LCMCardCount > 4) return 2;
            return count;
        }

        /// <summary>
        /// POM的背板支架也可以放LPI、NCM、Fecbus等板卡
        /// </summary>
        /// <returns></returns>
        public int GetPOMHolderCount()
        {
            int count = GetBackBeiBanCount();
            count = count - POMCount;
            return count;
        }

        public int GetPOMBoardCount()
        {
            int count = POMCount;

            return count;
        }

        public int GetPOMOperateBoardCount()
        {
            int count = POMCount;

            return count;
        }

        public int GetXianChaoCount()
        {
            int count = GetFrontOpenBeibanCount() + 1 + GetBackXianCaoCount();  //1 为后面板电源位置

            return count;
        }

        public bool HaveSecondDoor()
        {
            if ((ACMCount + POMCount + PrinterCount) > 5)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 没有第二门的时候，3个2U、2个3U   或者 1个2U、2个3U、1个4U（价格表中没有4U）
        /// </summary>
        /// <returns></returns>
        public int GetU2Count()
        {
            int count = 0;
            //if (HaveSecondDoor() == true)
            //{
            //    count = 9 - (ACMCount + POMCount + PrinterCount);
            //    return count;
            //}
            if (HaveSecondDoor() == false)
            {
                return 1;
            }
            return count;
        }

        public int GetU3Count()
        {
            int count = 0;
            if (HaveSecondDoor() == false)
            {
                return 2;
            }
            return count;
        }
        public int GetU4Count()
        {
            int count = 0;
            if (HaveSecondDoor() == false)
            {
                return 1;
            }
            return count;
        }
        public int GetBMP_6PCount()
        {
            int count = 0;
            if (HaveSecondDoor() == false)
            {
                return 5 - (ACMCount + POMCount + PrinterCount);
            }
            return count;
        }

        /// <summary>
        /// 有第二个门，对应一个副扇叶
        /// </summary>
        /// <returns></returns>
        public int GetFuShanyeCount()
        {
            int count = 0;
            if (HaveSecondDoor() == true)
            {
                return 1;
            }
            return count;
        }

        /// <summary>
        /// 正面除了ACM/POM/Printer外的空板
        /// </summary>
        /// <returns></returns>
        public int GetWuKaiKongChenban()
        {
            int count = 4;
            if (PrinterCount > 1)
            {
                PrinterCount = 1;
            }
            int usedCount = ACMCount + POMCount + PrinterCount ;//因为打印机这里数量是2，不知道为啥是2
            if (usedCount <= 5)
            {
                count = 5 - usedCount;
            }
            else
            {
                count = 9 - usedCount;
            }

            return count;
        }

        public override bool CheckError()
        {
            bool result = true;
            if (FecbusModuleCount + LPIModbusCount + NCMHighCount > 4 && POMCount == 4) //当多线控制卡满配时候，其他卡的数量只能是4个
            {
                result = false;
               // throw new Exception("LPI-MODBUS、FECBUS MODULE、光纤网卡的数量加起来最多不能超过4个。");
                throw new Exception("已没有空余位置放置板卡！。");
            }

            return result;
        }
    }
}
