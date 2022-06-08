using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quick_Order
{
    public partial class UserControl_MenuItem : UserControl
    {
        public UserControl_MenuItem()
        {
            InitializeComponent();
        }


        public bool ShowArrow
        {
            get
            {
                return Label_Arrow.Visible;
            }

            set
            {
                Label_Arrow.Visible = value;
            }
        }

        public string TitleText
        {
            get
            {
                return Label_Title.Text;
            }
            set
            {
                Label_Title.Text = value;
                if (Label_Title.Text.Length > 25)
                {
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(this.Label_Title, this.Label_Title.Text);
                }
            }
        }

        public string ShortCutText
        {
            get
            {
                return Label_ShortKey.Text;
            }
            set
            {
                Label_ShortKey.Text = value;
            }
        }

        private void UserControl_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UserControl_MenuItem_Load(object sender, EventArgs e)
        {

        }

        private void Label_Title_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void Label_Arrow_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void UserControl_MenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
        }

        private void UserControl_MenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void Label_Title_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
        }

        private void Label_Title_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void Label_ShortKey_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(146)))), ((int)(((byte)(229)))));
        }

        private void Label_ShortKey_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
