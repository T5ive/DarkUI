﻿using DarkUI.Config;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkStatusStrip : StatusStrip
    {
        #region Constructor Region

        public DarkStatusStrip()
        {
            AutoSize = false;
            BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            ForeColor = ThemeProvider.Theme.Colors.LightText;
            Size = new Size(Size.Width, 24);
            SizingGrip = false;
        }

        #endregion

        #region Paint Region

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var b = new SolidBrush(ThemeProvider.Theme.Colors.GreyBackground))
            {
                g.FillRectangle(b, ClientRectangle);
            }

            using (var p = new Pen(ThemeProvider.Theme.Colors.DarkBorder))
            {
                g.DrawLine(p, ClientRectangle.Left, 0, ClientRectangle.Right, 0);
            }

            using (var p = new Pen(ThemeProvider.Theme.Colors.LightBorder))
            {
                g.DrawLine(p, ClientRectangle.Left, 1, ClientRectangle.Right, 1);
            }
        }

        #endregion
    }
}
