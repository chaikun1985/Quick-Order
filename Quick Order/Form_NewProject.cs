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
    public partial class Form_NewProject : Form
    {
        public static string SelectedProjectPath = "";

        public Form_NewProject()
        {
            InitializeComponent();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            string projectName = TextBox_ProjectName.Text.Trim();
            string projectFolder = TextBox_ProjectFolder.Text.Trim();

            if (projectName == "")
            {
                CommonUsages.MyMsgBox("项目名不能为空！", CommonUsages.MsgBoxTypeEnum.Warning);
                return;
            }

            if (projectFolder == "")
            {
                CommonUsages.MyMsgBox("项目路径不能为空！", CommonUsages.MsgBoxTypeEnum.Warning);
                return;
            }

            string tmpPath = CommonUsages.PathCombine(projectFolder, projectName) + CommonUsages.ProjectSuffix;
            //if (System.IO.File.Exists(tmpPath) == true)
            //{
            //    CommonUsages.MyMsgBox("该文件已存在，请修改！", CommonUsages.MsgBoxTypeEnum.Warning);
            //    return;
            //}

            SelectedProjectPath = tmpPath;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextBox_ProjectFolder.Text = FolderBrowserDialog1.SelectedPath;
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

        private void Button_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Form_NewProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form_Main"].Close();
        }
    }
}
