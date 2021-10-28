using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Quick_Order
{
    class MyButton : Button
    {
        public MyButton()
        {
            this.GotFocus += MyButton_GotFocus;
            this.LostFocus += MyButton_LostFocus;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(alpha, red, green, blue);

            this.EnabledChanged += MyButton_EnabledChanged;

            if (this.Enabled == false)
            {
                alpha = 70;
            }
            RefreshBackColor();
        }

        private int alpha = 255;
        private int red = 64;
        private int green = 64;
        private int blue = 64;

        private void MyButton_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                alpha = 70;
            }
            else
            {
                alpha = 255;
            }
            RefreshBackColor();
        }

        private void MyButton_LostFocus(object sender, EventArgs e)
        {
            red = 64;
            green = 64;
            blue = 64;
            RefreshBackColor();
        }

        private void MyButton_GotFocus(object sender, EventArgs e)
        {
            red = 23;
            green = 146;
            blue = 229;
            RefreshBackColor();
        }

        private void RefreshBackColor()
        {
            this.BackColor = Color.FromArgb(alpha, red, green, blue);
        }

        //避免Focus时的内边框
        protected override bool ShowFocusCues
        {
            get { return false; }
        }
    }
}
