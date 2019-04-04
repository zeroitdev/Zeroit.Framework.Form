// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-24-2018
// ***********************************************************************
// <copyright file="ModernShadowPanel.cs" company="Zeroit Dev Technologies">
//    This program is for creating a Form control.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Form.ModernForm.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.Form.ModernForm.Controls
{
    /// <summary>
    /// Class ZeroitShadowPanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxItem(false)]
    public class ZeroitShadowPanel : Panel
    {

        /// <summary>
        /// The shadow color
        /// </summary>
        private Color shadowColor = Color.Black;
        /// <summary>
        /// The shadow opacity
        /// </summary>
        private int shadowOpacity = 150;

        /// <summary>
        /// Gets or sets the shadow opacity.
        /// </summary>
        /// <value>The shadow opacity.</value>
        public int ShadowOpacity
        {
            get { return shadowOpacity; }
            set
            {
                shadowOpacity = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the frozen image.
        /// </summary>
        /// <value>The frozen image.</value>
        private Bitmap FrozenImage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitShadowPanel"/> class.
        /// </summary>
        public ZeroitShadowPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            DoubleBuffered = true;
        }

        /// <summary>
        /// Freezes this instance.
        /// </summary>
        public void Freeze()
        {
            FrozenImage = new Bitmap(Size.Width, Size.Height);
            using (var g = Graphics.FromImage(FrozenImage)) {
                DrawControlShadow(g);
            }
            Refresh();
        }

        /// <summary>
        /// Unfreezes this instance.
        /// </summary>
        public void Unfreeze()
        {
            FrozenImage = null;
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (FrozenImage != null)
                Freeze();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (FrozenImage != null)
                Freeze();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (FrozenImage != null)
                Freeze();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (FrozenImage != null) {
                e.Graphics.DrawImage(FrozenImage, Point.Empty);
                return;
            }
            DrawControlShadow(e.Graphics);
        }

        /// <summary>
        /// The shadow offset
        /// </summary>
        private const int SHADOW_OFFSET = 3;
        /// <summary>
        /// The half shadow offset
        /// </summary>
        private const int HALF_SHADOW_OFFSET = SHADOW_OFFSET / 2;
        /// <summary>
        /// The half half shadow offset
        /// </summary>
        private const int HALF_HALF_SHADOW_OFFSET = HALF_SHADOW_OFFSET / 2;
        /// <summary>
        /// Draws the control shadow.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawControlShadow(Graphics g)
        {
            using (var brush = new SolidBrush(Color.FromArgb(ShadowOpacity, ShadowColor))) {
                using (var img = new Bitmap(Width, Height)) {
                    using (var gp = Graphics.FromImage(img)) {
                        foreach (Control c in Controls) {
                            //gp.DrawRoundedRectangle(rInner, 5, Pens.Transparent, Color.Black);
                            gp.FillRectangle(brush, Rectangle.Inflate(c.Bounds, HALF_SHADOW_OFFSET, HALF_SHADOW_OFFSET));
                            //ShadowUtils.DrawOutsetShadow(gp, Color.Black, 0, 0, 20, 1, c);
                        }
                    }
                    var gaussian = new GaussianBlur(img);
                    using (var result = gaussian.Process(SHADOW_OFFSET)) {
                        g.DrawImageUnscaled(result, Point.Empty);
                    }
                }
            }
        }
    }
}