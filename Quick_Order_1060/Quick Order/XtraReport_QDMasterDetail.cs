using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using System.Collections.Generic;

namespace Quick_Order
{
    public partial class XtraReport_QDMasterDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_QDMasterDetail()
        {
            InitializeComponent();
        }

        private bool ShowPanelPicture = false;
        private bool ForExcel = false;

        public void InitPage(bool showPanelPicture, bool forExcel = false)
        {
            ShowPanelPicture = showPanelPicture;
            ForExcel = forExcel;

            if (showPanelPicture == true)
            {
                if (Detail.Controls.Contains(XrPanel_PanelPicture) == false)
                    Detail.Controls.Add(XrPanel_PanelPicture);
                XrPanel_PanelPicture.Visible = true;
                Detail.HeightF = 350;
                GroupHeader_DeviceSettings.Visible = true;
            }
            else
            {
                if (Detail.Controls.Contains(XrPanel_PanelPicture) == true)
                    Detail.Controls.Remove(XrPanel_PanelPicture);
                XrPanel_PanelPicture.Visible = false;
                Detail.HeightF = 36;
                GroupHeader_DeviceSettings.Visible = false;
            }
            Detail.SortFields.Add(new GroupField("ID", XRColumnSortOrder.Ascending));

            if (ForExcel == true)
            {
                XrPanel_PageHeadLine.Visible = false;
                PageHeader.Visible = false;
                PageFooter.Visible = false;
                //GroupHeader_DeviceSettings.Visible = false;
            }
        }

        int index2 = 1;
        private void XrTable_Project_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (ShowPanelPicture == true)
            {
                if (index2 != Form_Report.ds.Tables[0].Rows.Count)                  
                //if (index2 != DBClass.GetInstance().ProjectMemoryTable.Rows.Count)
                {
                    XRTableRow curXrTableRow = ((XRTable)sender).Rows[0];
                    for (int ii = 0; ii <= 2; ii++)
                    {
                        curXrTableRow.Cells[ii].Borders = BorderSide.None;
                    }
                }
                else
                {
                    XRTableRow curXrTableRow = ((XRTable)sender).Rows[0];   //最后的配件,因为没有图，显示下边界
                    for (int ii = 0; ii <= 2; ii++)
                    {
                        curXrTableRow.Cells[ii].Borders = BorderSide.Bottom;
                    }
                }
            }

            index2++;
        }

        int index = 1;
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (ShowPanelPicture == true)
            {
                if (index == Form_Report.ds.Tables[0].Rows.Count)
                    //if (index == DBClass.GetInstance().ProjectMemoryTable.Rows.Count)    //最后的配件不要显示图
                {
                    if (Detail.Controls.Contains(XrPanel_PanelPicture) == true)
                        Detail.Controls.Remove(XrPanel_PanelPicture);
                    XrPanel_PanelPicture.Visible = false;
                    Detail.HeightF = 36;
                    GroupHeader_DeviceSettings.Visible = false;
                }
                if (index > Form_Report.ds.Tables[0].Rows.Count - 1)
                {
                    xrLabel6.Visible = false;   //主机背面
                }
                else
                {
                    if (string.IsNullOrEmpty(Form_Report.ds.Tables[0].Rows[index]["RightPanel"].ToString()))
                    {
                        xrLabel6.Visible = false;   //主机背面
                    }
                    else
                    {
                        xrLabel6.Visible = true;
                    }
                }
                
               
                //if (xrPictureBox3.Image == null)
                //    xrLabel6.Visible = false;   //主机背面
                //else
                //    xrLabel6.Visible = true;
            }

            index++;
        }

        private void XrTable_DetailSettings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int curPage = this.Pages.Count;

            XRTableRow curXrTableRow = ((XRTable)sender).Rows[0];
            curXrTableRow.Cells[0].Borders = BorderSide.Left | BorderSide.Bottom | BorderSide.Right;
            for (int ii = 1; ii <= 5; ii++)
            {
                curXrTableRow.Cells[ii].Borders = BorderSide.Bottom | BorderSide.Right;
            }
        }

        private void XrTable_DetailSettings_AfterPrint(object sender, EventArgs e)
        {
            
        }     
       
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void PageFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void XtraReport_QDMasterDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
