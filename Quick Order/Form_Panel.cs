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
    public partial class Form_Panel : Form
    {
        public static string SelectedProjectPath = "";
        public Point _parentLocation;
        public Size _parentSize;

        public Form_Panel()
        {
            InitializeComponent();
        }

        public Form_Panel(Point ParentLocation, Size ParentSize)
        {
            InitializeComponent();
            _parentLocation = ParentLocation;
            _parentSize = ParentSize;

        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form_NewProject_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form_NewProject_Load(object sender, EventArgs e)
        {
            Form_StartPage Form1 = Owner as Form_StartPage;
            this.Location = _parentLocation;
            this.Size = _parentSize;
            //Form_NewProject newForm = new Form_NewProject();
            //newForm.label9.Text = "新建项目名";
            //newForm.TopMost = true;
            //newForm.Show();
            //if (newForm.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
        }
    }
}
