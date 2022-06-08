using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quick_Order
{
    public partial class Form_EditControlCount : Form
    {
        public static string SelectedProjectPath = "";

        public  string ControlCount = string.Empty;
        public Form_EditControlCount()
        {
            InitializeComponent();
        }
        public Form_EditControlCount(string controlCount)
        {
            InitializeComponent();
            ControlCount = controlCount;
            TextBox_ProjectName.Text = ControlCount;
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            string controlCount = TextBox_ProjectName.Text.Trim();
            //string projectFolder = TextBox_ProjectFolder.Text.Trim();

            if (controlCount == "")
            {
                CommonUsages.MyMsgBox("控制器数量不能为空！", CommonUsages.MsgBoxTypeEnum.Warning);
                return;
            }
            ControlCount = controlCount;
            //if (projectFolder == "")
            //{
            //    CommonUsages.MyMsgBox("项目路径不能为空！", CommonUsages.MsgBoxTypeEnum.Warning);
            //    return;
            //}

            //string tmpPath = CommonUsages.PathCombine(projectFolder, projectName) + CommonUsages.ProjectSuffix;
            //if (System.IO.File.Exists(tmpPath)==true)
            //{
            //    CommonUsages.MyMsgBox("该文件已存在，请修改！", CommonUsages.MsgBoxTypeEnum.Warning);
            //    return;
            //}

            //SelectedProjectPath = tmpPath;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
             //   TextBox_ProjectFolder.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void Form_NewProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form_NewProject_Load(object sender, EventArgs e)
        {
        }

        private void TextBox_ProjectName_EditValueChanged(object sender, EventArgs e)
        {
            if ( !string.IsNullOrEmpty(this.TextBox_ProjectName.EditValue.ToString())   && int.Parse(this.TextBox_ProjectName.EditValue.ToString()) > 256)
            {
                CommonUsages.MyMsgBox("数量不能超过256！", CommonUsages.MsgBoxTypeEnum.Warning);
                //this.TextBox_ProjectName.EditValue = 
                this.TextBox_ProjectName.EditValue = 1;
                //this.TextBox_ProjectName.ResetText();
                //this.TextBox_ProjectName.Reset();
                this.TextBox_ProjectName.Refresh();
                return;
            }
        }
    }
}
