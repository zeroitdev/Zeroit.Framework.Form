// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="ShadowUtils.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static System.Math;

namespace Zeroit.Framework.Form.ModernForm.Utils
{
    /// <summary>
    /// Class ShadowUtils.
    /// </summary>
    public static class ShadowUtils
    {
        /// <summary>
        /// Interface IShadowController
        /// </summary>
        public interface IShadowController
        {
            /// <summary>
            /// Shoulds the show shadow.
            /// </summary>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            bool ShouldShowShadow();
        }
        /// <summary>
        /// Enum RenderSide
        /// </summary>
        enum RenderSide
        {
            /// <summary>
            /// The top
            /// </summary>
            Top,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom,
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        /// <summary>
        /// The visible top
        /// </summary>
        static RenderSide[] VisibleTop = { RenderSide.Bottom/*, RenderSide.Top*/ };
        /// <summary>
        /// The visible bottom
        /// </summary>
        static RenderSide[] VisibleBottom = { RenderSide.Top/*, RenderSide.Bottom*/ };
        /// <summary>
        /// The visible left
        /// </summary>
        static RenderSide[] VisibleLeft = { RenderSide.Right };
        /// <summary>
        /// The visible right
        /// </summary>
        static RenderSide[] VisibleRight = { RenderSide.Left };

        /// <summary>
        /// Determines whether the specified side is visible.
        /// </summary>
        /// <param name="side">The side.</param>
        /// <param name="st">The st.</param>
        /// <returns><c>true</c> if the specified side is visible; otherwise, <c>false</c>.</returns>
        static bool IsVisible(RenderSide side, DockStyle st)
        {
            switch (st) {
                case DockStyle.Top:
                    return VisibleTop.Contains(side);
                case DockStyle.Bottom:
                    return VisibleBottom.Contains(side);
                case DockStyle.Left:
                    return VisibleLeft.Contains(side);
                case DockStyle.Right:
                    return VisibleRight.Contains(side);
                case DockStyle.Fill:
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Draws the shadow.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c">The c.</param>
        /// <param name="r">The r.</param>
        /// <param name="d">The d.</param>
        /// <param name="st">The st.</param>
        public static void DrawShadow(Graphics G, Color c, Rectangle r, int d, DockStyle st = DockStyle.None)
        {
            Color[] colors = GetColorVector(c, d).ToArray();

            if (IsVisible(RenderSide.Top, st))
                for (int i = 1; i < d; i++) {
                    //TOP
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Left - Max(i - 1, 0), r.Top - i), new Point(r.Right + Max(i - 1, 0), r.Top - i));
                }

            if (IsVisible(RenderSide.Bottom, st))
                for (int i = 0; i < d; i++) {
                    //BOTTOM
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Left - Max(i - 1, 0), r.Bottom + i), new Point(r.Right + i, r.Bottom + i));
                }
            if (IsVisible(RenderSide.Left, st))
                for (int i = 1; i < d; i++) {
                    //LEFT
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Left - i, r.Top - i), new Point(r.Left - i, r.Bottom + i));
                }
            if (IsVisible(RenderSide.Right, st))
                for (int i = 0; i < d; i++) {
                    //RIGHT
                    using (Pen pen = new Pen(colors[i], 1f))
                        G.DrawLine(pen, new Point(r.Right + i, r.Top - i), new Point(r.Right + i, r.Bottom + Max(i - 1, 0)));
                }
        }

        //Code taken and adapted from StackOverflow (https://stackoverflow.com/a/13653167).
        //All credits go to Marino Šimić (https://stackoverflow.com/users/610204/marino-%c5%a0imi%c4%87).
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="gfx">The GFX.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawPen">The draw pen.</param>
        /// <param name="fillColor">Color of the fill.</param>
        public static void DrawRoundedRectangle(this Graphics gfx, Rectangle bounds, int cornerRadius, Pen drawPen, Color fillColor)
        {
            int strokeOffset = Convert.ToInt32(Ceiling(drawPen.Width));
            bounds = Rectangle.Inflate(bounds, -strokeOffset, -strokeOffset);

            var gfxPath = new GraphicsPath();
            if (cornerRadius > 0) {
                gfxPath.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
                gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
                gfxPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius,
                               cornerRadius, 0, 90);
                gfxPath.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            } else {
                gfxPath.AddRectangle(bounds);
            }
            gfxPath.CloseAllFigures();
            using (SolidBrush brush = new SolidBrush(fillColor)) {
                gfx.FillPath(brush, gfxPath);
                if (drawPen != Pens.Transparent) {
                    var pen = new Pen(drawPen.Color);
                    pen.EndCap = pen.StartCap = LineCap.Round;
                    gfx.DrawPath(pen, gfxPath);
                    pen.Dispose();
                }
            }
            gfxPath.Dispose();
        }

        //Code taken and adapted from StackOverflow (https://stackoverflow.com/a/13653167).
        //All credits go to Marino Šimić (https://stackoverflow.com/users/610204/marino-%c5%a0imi%c4%87).
        /// <summary>
        /// Draws the outset shadow.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="shadowColor">Color of the shadow.</param>
        /// <param name="hShadow">The h shadow.</param>
        /// <param name="vShadow">The v shadow.</param>
        /// <param name="blur">The blur.</param>
        /// <param name="spread">The spread.</param>
        /// <param name="control">The control.</param>
        public static void DrawOutsetShadow(Graphics g, Color shadowColor, int hShadow, int vShadow, int blur, int spread, Control control)
        {
            var rOuter = Rectangle.Inflate(control.Bounds, blur / 2, blur / 2);
            var rInner = Rectangle.Inflate(control.Bounds, blur / 2, blur / 2);
            //rInner.Offset(hShadow, vShadow);
            rInner.Inflate(-blur, -blur);
            rOuter.Inflate(spread, spread);
            //rOuter.Offset(hShadow, vShadow);
            var originalOuter = rOuter;

            var img = new Bitmap(originalOuter.Width, originalOuter.Height, g);
            var g2 = Graphics.FromImage(img);

            var currentBlur = 0;

            do {
                var transparency = (rOuter.Height - rInner.Height) / (double)(blur * 2 + spread * 2);
                var color = Color.FromArgb(((int)(200 * (transparency * transparency))), shadowColor);
                var rOutput = rInner;
                rOutput.Offset(-originalOuter.Left, -originalOuter.Top);
                g2.DrawRoundedRectangle(rOutput, 5, Pens.Transparent, color);
                rInner.Inflate(1, 1);
                currentBlur = (int)((double)blur * (1 - (transparency * transparency)));
            } while (rOuter.Contains(rInner));

            g2.Flush();
            g2.Dispose();

            g.DrawImage(img, originalOuter);

            img.Dispose();
        }

        //Code taken and adapted from https://stackoverflow.com/a/25741405
        //All credits go to TaW (https://stackoverflow.com/users/3152130/taw)
        /// <summary>
        /// Gets the color vector.
        /// </summary>
        /// <param name="fc">The fc.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>List&lt;Color&gt;.</returns>
        static List<Color> GetColorVector(Color fc, int depth)
        {
            List<Color> cv = new List<Color>();
            int baseC = 65;
            float div = baseC / depth;
            for (int d = 1; d <= depth; d++) {
                cv.Add(Color.FromArgb(Max(0, baseC), fc));
                baseC -= (int)div;
            }
            return cv;
        }


        //Code taken and adapted from https://stackoverflow.com/a/25741405
        //All credits go to TaW (https://stackoverflow.com/users/3152130/taw)
        /// <summary>
        /// Gets the rect path.
        /// </summary>
        /// <param name="R">The r.</param>
        /// <returns>GraphicsPath.</returns>
        static GraphicsPath GetRectPath(Rectangle R)
        {
            byte[] fm = new byte[3];
            for (int b = 0; b < 3; b++) fm[b] = 1;
            List<Point> points = new List<Point>
            {
                new Point(R.Left, R.Bottom),
                new Point(R.Right, R.Bottom),
                new Point(R.Right, R.Top)
            };
            return new GraphicsPath(points.ToArray(), fm);
        }

        /// <summary>
        /// Creates the drop shadow.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        public static void CreateDropShadow(this Control ctrl)
        {
            if (ctrl.Parent != null) {
                ctrl.Parent.Paint += (s, e) => {
                    if (ctrl.Parent != null && ctrl.Visible && (!(ctrl is IShadowController) || ((IShadowController)ctrl).ShouldShowShadow()))
                        DrawShadow(e.Graphics, Color.Black, ctrl.Bounds, 7, ctrl.Dock);
                };
            }
        }
    }
}
