using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkControls
{
    public class DarkButton : Label
    {
        private bool hover;

        public DarkButton()
        {
            AutoSize = false;
            BorderStyle = BorderStyle.FixedSingle;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        [DefaultValue(BorderStyle.FixedSingle)]
        public new BorderStyle BorderStyle
        {
            get => base.BorderStyle;
            set => base.BorderStyle = value;
        }

        [DefaultValue(ContentAlignment.MiddleCenter)]
        public new ContentAlignment TextAlign
        {
            get => base.TextAlign;
            set => base.TextAlign = value;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (hover && Enabled)
            {
                int borderFudge = 0;
                if (BorderStyle == BorderStyle.FixedSingle)
                {
                    borderFudge = 2;
                }
                e.Graphics.DrawRectangle(SystemPens.Highlight, new Rectangle(0, 0, Width - borderFudge - 1, Height - borderFudge - 1));
            }
        }
    }
}
