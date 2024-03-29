﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace Quick_Order
{
    public partial class XtraReport_QD : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_QD()
        {
            InitializeComponent();
        }

        private bool ShowPanelPicture = false;
        private bool ForExcel = false;

        public void InitPage(bool showPanelPicture, bool forExcel = false)
        {
            ShowPanelPicture = showPanelPicture;
            ForExcel = forExcel;


            DetailReport_DeviceSettings.DataSource = DBClass.GetInstance().ModelDeviceReportTable;
            //DetailReport_DeviceSettings.DataSource = Form_Report.ds.Tables[2];
            if (ShowPanelPicture == true)
            {
                DetailReport_Picture.FilterString = string.Format("[Cat] = 'Panel'");
                //DetailReport_Picture.DataSource = DBClass.GetInstance().ProjectMemoryTable;
                DetailReport_Picture.DataSource = Form_Report.ds.Tables[0];
                DetailReport_Picture.Visible = true;
            }
            else
            {
                DetailReport_Picture.Visible = false;
            }

            if (ForExcel == true)
            {
                PageHeader.Visible = false;
                PageFooter.Visible = false;
                //GroupHeader_DeviceSettings.Visible = false;
            }
        }
        int index = 1;
        private void Detail_Picture_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (ShowPanelPicture == true)
            {
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
            }
            index++;

            //if (xrPictureBox3.Image == null)
            //    xrLabel6.Visible = false;   //主机背面
            //else
            //    xrLabel6.Visible = true;
        }

        int index2 = 1;
        private void xrTable_ProjectTop_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(ShowPanelPicture == true)
            {
                if (index2 != Form_Report.ds.Tables[0].Rows.Count)
                //    if (index2 != DBClass.GetInstance().ProjectMemoryTable.Rows.Count)
                {
                    XRTableRow curXrTableRow = ((XRTable)sender).Rows[0];
                    for (int ii = 0; ii <= 2; ii++)
                    {
                        curXrTableRow.Cells[ii].Borders = BorderSide.None;
                    }
                }
                else
                {
                    XRTableRow curXrTableRow = ((XRTable)sender).Rows[0];
                    for (int ii = 0; ii <= 2; ii++)
                    {
                        curXrTableRow.Cells[ii].Borders = BorderSide.Bottom;
                    }
                }
            }

            index2++;
        }

        private void XrTable_DetailSettings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            XRTableRow curXrTableRow = ((XRTable)sender).Rows[0];

            curXrTableRow.Cells[0].Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
            for (int ii = 1; ii <= 5; ii++)
            {
                curXrTableRow.Cells[ii].Borders = BorderSide.Right | BorderSide.Bottom;
            }
        }

        private void XtraReport_QD_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
