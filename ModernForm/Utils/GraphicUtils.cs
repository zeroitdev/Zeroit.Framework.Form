// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-24-2018
// ***********************************************************************
// <copyright file="GraphicUtils.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Utils
{
    /// <summary>
    /// Class GraphicUtils.
    /// </summary>
    public static class GraphicUtils
    {

        /// <summary>
        /// Draws the hamburger button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="secondary">The secondary.</param>
        /// <param name="hamburgerRectangle">The hamburger rectangle.</param>
        /// <param name="foreColor">Color of the fore.</param>
        /// <param name="c">The c.</param>
        /// <param name="smallButton">if set to <c>true</c> [small button].</param>
        public static void DrawHamburgerButton(Graphics g, SolidBrush secondary, Rectangle hamburgerRectangle, Color foreColor, Control c, bool smallButton = false)
        {
            if (Control.MouseButtons != MouseButtons.None && hamburgerRectangle.Contains(c.PointToClient(Cursor.Position)))
            {
                g.FillRectangle(secondary, hamburgerRectangle);
            }

            using (var forePen = new Pen(foreColor, 3))
            {
                //Draw hamburger icon
                var rect = hamburgerRectangle;
                const int barSize = 2;
                var spacingSides = smallButton ? 6 : 4;
                const int interval = 3;
                var centerX = rect.Right - (rect.Width / 2);
                var centerY = rect.Bottom - (rect.Height / 2);
                var topLine = centerY - (barSize * 2) - interval;
                var bottomLine = centerY + (barSize * 2) + interval;

                var oldMode = g.SmoothingMode;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //Top
                g.DrawLine(forePen, rect.Left + spacingSides, topLine, rect.Right - spacingSides,
                    topLine);

                //Middle
                g.DrawLine(forePen, rect.Left + spacingSides, centerY, rect.Right - spacingSides,
                    centerY);

                //Bottom
                g.DrawLine(forePen, rect.Left + spacingSides, bottomLine, rect.Right - spacingSides,
                    bottomLine);

                g.SmoothingMode = oldMode;
            }
        }

        /// <summary>
        /// Offsets the and return.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle OffsetAndReturn(this Rectangle rect, Point offset)
        {
            if (offset.Equals(Point.Empty))
                return rect;
            var newR = new Rectangle(rect.Location, rect.Size);
            newR.Offset(offset);
            return newR;
        }

        /// <summary>
        /// Offsets the and return.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle OffsetAndReturn(this Rectangle rect, int x, int y)
        {
            if (x.Equals(Point.Empty.X) && y.Equals(Point.Empty.Y))
                return rect;
            var newR = new Rectangle(rect.Location, rect.Size);
            newR.Offset(x, y);
            return newR;
        }

        //Method taken from https://stackoverflow.com/a/2241471
        //All credits go to the author: JYelton(https://stackoverflow.com/users/161052/jyelton)
        /// <summary>
        /// Perceiveds the brightness.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>System.Int32.</returns>
        public static int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .299 +
            c.G * c.G * .587 +
            c.B * c.B * .114);
        }

        /// <summary>
        /// Foregrounds the color for background.
        /// </summary>
        /// <param name="back">The back.</param>
        /// <returns>Color.</returns>
        public static Color ForegroundColorForBackground(Color back)
        {
            return !IsDark(back) ? Color.Black : Color.White;
        }

        /// <summary>
        /// Determines whether the specified c is dark.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if the specified c is dark; otherwise, <c>false</c>.</returns>
        public static bool IsDark(this Color c)
        {
            return PerceivedBrightness(c) < 130;
        }
        /// <summary>
        /// Determines whether the specified c is darker.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if the specified c is darker; otherwise, <c>false</c>.</returns>
        public static bool IsDarker(this Color c)
        {
            return PerceivedBrightness(c) < 100;
        }


        /// <summary>
        /// Draws the rectangle border.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="g">The g.</param>
        /// <param name="borderColor">Color of the border.</param>
        public static void DrawRectangleBorder(Rectangle rect, Graphics g, Color borderColor)
        {
            using (var p = new Pen(borderColor))
            {
                //Top
                g.DrawLine(p, rect.Left + 1, rect.Top, rect.Right - 1, rect.Top);
                //Bottom
                g.DrawLine(p, rect.Left + 1, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                //Left
                g.DrawLine(p, rect.Left, rect.Top, rect.Left, rect.Bottom);
                //Right
                g.DrawLine(p, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
            }
        }

        /// <summary>
        /// Draws the centered text.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="text">The text.</param>
        /// <param name="f">The f.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="textColor">Color of the text.</param>
        /// <param name="horizontal">if set to <c>true</c> [horizontal].</param>
        /// <param name="vertical">if set to <c>true</c> [vertical].</param>
        public static void DrawCenteredText(Graphics g, string text, Font f, Rectangle rect, Color textColor, bool horizontal = true, bool vertical = true)
        {
            var sb = new SolidBrush(textColor);
            var stringFormat = new StringFormat();
            if (horizontal) stringFormat.Alignment = StringAlignment.Center;      // -- Horizontal Alignment
            if (vertical) stringFormat.LineAlignment = StringAlignment.Center;      // || Vertical Alignment

            g.DrawString(text, f, sb, rect, stringFormat);
            stringFormat.Dispose();
            sb.Dispose();
        }


    }
}
