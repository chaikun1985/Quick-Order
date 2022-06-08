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
    public partial class Form_NewPanelType : Form
    {
        public static string SelectedProjectType = "";
        public static string SelectedProjectLabel = "";

        public Form_NewPanelType()
        {
            InitializeComponent();
            ComboBox_NewPanel_PanelType.Properties.Items.RemoveAt(1);
        }       

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (TextBox_PanelLabel.Text.Trim()=="")
            {
                CommonUsages.MyMsgBox("控制器系统名不能为空！", CommonUsages.MsgBoxTypeEnum.Warning);
                return;
            }

            SelectedProjectType = ComboBox_NewPanel_PanelType.Text;
            SelectedProjectLabel = TextBox_PanelLabel.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_NewProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ComboBox_NewPanel_PanelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_PanelLabel.Text = ComboBox_NewPanel_PanelType.Text;
        }

        private void Form_NewPanelType_Load(object sender, EventArgs e)
        {
        }

        private void Form_NewPanelType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
