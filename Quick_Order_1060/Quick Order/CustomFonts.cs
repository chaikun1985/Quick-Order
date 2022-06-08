using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Quick_Order
{
    class CustomFonts
    {
        private static CustomFonts CustomFontsInst;
        private string FontFiletPath = CommonUsages.CustomFontTTFFile;
        private PrivateFontCollection CustomFontCollection = new PrivateFontCollection();
        private static readonly string DefalutFontName = "Microsoft YaHei"; //"PingFang SC Regular";
        private string ExactFontName = DefalutFontName;
        private byte DefaultFontInstalled = 0;

        public static CustomFonts GetInstance()
        {
            if (CustomFontsInst == null)
            {
                CustomFontsInst = new Quick_Order.CustomFonts();
            }
            return CustomFontsInst;
        }

        CustomFonts()
        {
            if (CheckFontInstalled(DefalutFontName) == true)
            {
                DefaultFontInstalled = 1;
            }
            else
            {
                AddACustomFontFile();
            }

        }

        private void AddACustomFontFile()
        {
            try
            {
                CustomFontCollection.AddFontFile(CommonUsages.CustomFontTTFFile);
                DefaultFontInstalled = 2;
            }
            catch (Exception ee)
            {
                DefaultFontInstalled = 0;
            }
        }

        public FontFamily GetFontFamily0()
        {
            if (CustomFontCollection.Families.Length == 0)
            {
                return null;
            }

            return CustomFontCollection.Families[0];
        }

        public bool CheckFontInstalled(string fontName)
        {
            foreach (var font in new InstalledFontCollection().Families)
            {
                if (font.Name.Contains(fontName))
                {
                    ExactFontName = fontName;
                    return true;
                }
            }
            return false;
        }

        public Font GetFont0(float fontSize, bool isBold = false)
        {
            if (DefaultFontInstalled == 0)
            {
                return new Font("Tahoma", fontSize, (isBold == true ? FontStyle.Bold : FontStyle.Regular), GraphicsUnit.Pixel);
            }

            if (DefaultFontInstalled == 1)
            {
                return new Font(ExactFontName, fontSize, (isBold == true ? FontStyle.Bold : FontStyle.Regular), GraphicsUnit.Pixel);
            }

            if (CustomFontCollection.Families.Length == 0)
            {
                //return null;
                return new Font("Tahoma", fontSize, (isBold == true ? FontStyle.Bold : FontStyle.Regular), GraphicsUnit.Pixel);
            }

            Font font0 = null;
            if (isBold == true)
            {
                font0 = new Font(CustomFontCollection.Families[0], fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            else
            {
                font0 = new Font(CustomFontCollection.Families[0], fontSize, GraphicsUnit.Pixel);
            }

            return font0;
        }

        public void SetFontToCtrl(Control ctrl)
        {
            if (ctrl.HasChildren == true)
            {
                return;
            }
            ctrl.Font = GetFont0(ctrl.Font.Size, ctrl.Font.Bold);
        }

        public void SetFontToCtrlRecursion(Control ctrl)
        {
            foreach (Control item in ctrl.Controls)
            {
                if (item.Tag != null && item.Tag.ToString() == "NoFont")
                {
                }
                else
                {
                    SetFontToCtrl(item);
                    SetFontToCtrlRecursion(item);
                }
            }
        }

    }
}
