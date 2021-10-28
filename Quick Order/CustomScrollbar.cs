using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;

namespace Quick_Order
{
    [Designer(typeof(ScrollbarControlDesigner))]
    /// Modified basic on https://www.codeproject.com/Articles/14801/How-to-skin-scrollbars-for-Panels-in-C
    /// Remove uparrow、downarrow、thumb pictures.
    /// must set Maximum(the Panel's maxisum child control's location)\LargeLength(the Panel's visible height, diffrent from the VScrolBar)
    /// Must Set the Panel's AutoScroll property and set another panel to override the default ScrollBar.
    /// If used for GridControl, for easy usage, diable mouse scrol and mouse up and down. Use RowCount*RowHeight to get the maximum.
    public partial class CustomScrollbar : UserControl
    {
        protected Color moThumbColor = Color.FromArgb(112, 112, 112);
        protected bool moVisibleWhenFull = false;

        protected int moLargeLength = 0;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        private int nClickPoint;

        protected int moThumbTop = 0;

        protected bool moAutoSize = false;

        private bool moThumbDown = false;
        private bool moThumbDragging = false;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;

        private int GetThumbHeight()
        {
            int nTrackHeight = (this.Height);
            float fThumbHeight = ((float)LargeLength / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            return nThumbHeight;
        }

        public CustomScrollbar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            this.Width = 5;
            base.MinimumSize = new Size(5, GetThumbHeight());
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("When there is no outside control, set scroll bar's visibility.")]
        public bool VisibleWhenFull
        {
            get { return moVisibleWhenFull; }
            set
            {
                moVisibleWhenFull = value;
                SetScrollVisible();
            }
        }

        private void SetScrollVisible()
        {
            if (moVisibleWhenFull == true)
            {
                this.Visible = true;
            }
            else
            {
                if (this.Maximum > this.LargeLength)
                {
                    this.Visible = true;
                }
                else
                {
                    this.Visible = false;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeLength
        {
            get { return moLargeLength; }
            set
            {
                moLargeLength = value;
                RefreshScrollBar();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange
        {
            get { return moSmallChange; }
            set
            {
                moSmallChange = value;
                RefreshScrollBar();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum
        {
            get { return moMinimum; }
            set
            {
                moMinimum = value;
                RefreshScrollBar();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum
        {
            get { return moMaximum; }
            set
            {
                moMaximum = value;
                RefreshScrollBar();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;

                int nTrackHeight = this.Height;
                float fThumbHeight = ((float)LargeLength / (float)Maximum) * nTrackHeight;
                int nThumbHeight = (int)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < 56)
                {
                    nThumbHeight = 56;
                    fThumbHeight = 56;
                }

                //figure out value
                int nPixelRange = nTrackHeight - nThumbHeight;
                int nRealRange = (Maximum - Minimum) - LargeLength;
                float fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = (float)moValue / (float)nRealRange;
                }

                float fTop = fPerc * nPixelRange;
                moThumbTop = (int)fTop;

                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ThumbColor
        {
            get { return moThumbColor; }
            set { moThumbColor = value; }
        }

        protected void RefreshScrollBar()
        {
            SetScrollVisible();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            Brush oBrush = new SolidBrush(BackColor);

            //draw channel
            e.Graphics.FillRectangle(oBrush, new Rectangle(1, 0, this.Width - 2, (this.Height)));

            //draw thumb
            int nTrackHeight = (this.Height);
            float fThumbHeight = ((float)LargeLength / (float)Maximum) * nTrackHeight;

            if (fThumbHeight > nTrackHeight)
            {
                fThumbHeight = nTrackHeight;
            }
            if (fThumbHeight < 56)
            {
                fThumbHeight = 56;
            }

            int nTop = moThumbTop;

            e.Graphics.FillRectangle(new SolidBrush(ThumbColor), new Rectangle(1, nTop, this.Width - 2, (int)fThumbHeight));
        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackHeight = (this.Height);
            float fThumbHeight = ((float)LargeLength / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nTop = moThumbTop;

            Rectangle thumbrect = new Rectangle(new Point(1, nTop), new Size(this.Width, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {

                //hit the thumb
                nClickPoint = (ptPoint.Y - nTop);
                this.moThumbDown = true;
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        private void MoveThumb(int y)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = (this.Height);
            float fThumbHeight = ((float)LargeLength / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    int nNewThumbTop = y - (nSpot);

                    if (nNewThumbTop < 0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                    }
                    else if (nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                    }
                    else
                    {
                        moThumbTop = y - (nSpot);
                    }

                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum - LargeLength);
                    moValue = (int)fValue;
                    Debug.WriteLine(moValue.ToString());

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moThumbDown == true)
            {
                this.moThumbDragging = true;
            }

            if (this.moThumbDragging)
            {

                MoveThumb(e.Y);
            }

            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if (Scroll != null)
                Scroll(this, new EventArgs());
        }

    }

    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null)
                {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize)
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        }
    }
}
