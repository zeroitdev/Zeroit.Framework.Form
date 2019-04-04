// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="SidebarTextItem.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using Zeroit.Framework.Form.ModernForm.Controls;
using Zeroit.Framework.Form.ModernForm.Utils;

namespace Zeroit.Framework.Form.ModernForm
{
    /// <summary>
    /// Class SidebarTextItem.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Form.ModernForm.Controls.SideBarItem" />
    public class SidebarTextItem : SideBarItem
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public String Text { get; set; } = "";
        /// <summary>
        /// The default text height
        /// </summary>
        private const int DEFAULT_TEXT_HEIGHT = 32;
        /// <summary>
        /// The side offset
        /// </summary>
        private const int SIDE_OFFSET = 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="SidebarTextItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public SidebarTextItem(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="g">The g.</param>
        /// <param name="itemSize">Size of the item.</param>
        /// <param name="isSelected">if set to <c>true</c> [is selected].</param>
        public override void DrawItem(ZeroitSideBar c, Graphics g, Size itemSize, bool isSelected)
        {
            using (var sb = new SolidBrush(isSelected ? GraphicUtils.ForegroundColorForBackground(c.ColorScheme.SecondaryColor) : ForeColor)) {
                using (var format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                }) {
                    g.DrawString(Text, c.Font, sb, new Rectangle(SIDE_OFFSET, 0, itemSize.Width, itemSize.Height), format);
                }
            }
        }

        /// <summary>
        /// Measures the item.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="g">The g.</param>
        /// <param name="itemHeight">Height of the item.</param>
        public override void MeasureItem(ZeroitSideBar c, Graphics g, out int itemHeight)
        {
            itemHeight = Math.Max(DEFAULT_TEXT_HEIGHT, (int)g.MeasureString(Text, c.Font).Height + SIDE_OFFSET * 2);
        }
    }
}
