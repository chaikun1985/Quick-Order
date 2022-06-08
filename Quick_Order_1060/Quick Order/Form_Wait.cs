using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace Quick_Order
{
    public partial class Form_Wait : WaitForm
    {
        public Form_Wait()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = Panel_ProgressSlider.Location.X;
            x += 5;
            if ((x + Panel_ProgressSlider.Width) >= Panel_ProgressBar.Width)
            {
                x = 0;
            }
            Panel_ProgressSlider.Location = new Point(x, 0);
        }

        private void Form_Wait_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
