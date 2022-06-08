using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;

namespace Quick_Order
{
    class MyCombox : ComboBoxEdit
    {
        public MyCombox()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Properties.AppearanceFocused.BorderColor = Color.FromArgb(23, 146, 229);

            this.Properties.AppearanceDisabled.ForeColor = Color.FromArgb(120, 120, 120);
            this.Properties.AppearanceDisabled.BackColor = Color.FromArgb(56, 56, 56);

            this.Properties.AppearanceDropDown.Font = new Font("Tahoma", 13, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        protected override bool ShowFocusCues
        {
            get { return false; }
        }
    }
}
