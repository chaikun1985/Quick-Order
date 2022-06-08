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
    public partial class UserControl_GridView : UserControl
    {
        public UserControl_GridView()
        {
            InitializeComponent();
        }

        private void UserControl_Gridview_Load(object sender, EventArgs e)
        {
            ReAssignScrollBar();
        }

        private void ReAssignScrollBar()
        {
            CustomScrollbar1.Maximum = GridView1.RowHeight * GridView1.RowCount;
            CustomScrollbar1.LargeLength = GridControl1.Height;
            CustomScrollbar1.Value = 0;
            MaxScope = CustomScrollbar1.Maximum - CustomScrollbar1.LargeLength;
        }

        int MaxScope = 0;
        private void CustomScrollbar1_Scroll(object sender, EventArgs e)
        {
            int value = CustomScrollbar1.Value;

            float tmpIndex = GridView1.TopRowIndex;
            tmpIndex = (float)value / (float)MaxScope * (float)GridView1.RowCount;
            GridView1.TopRowIndex = (int)tmpIndex;
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
        }

        private void GridView1_RowCountChanged(object sender, EventArgs e)
        {
            ReAssignScrollBar();
        }

        private void GridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            (e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
        }

        private void UserControl_Gridview_SizeChanged(object sender, EventArgs e)
        {
            ReAssignScrollBar();
        }
    }
}
