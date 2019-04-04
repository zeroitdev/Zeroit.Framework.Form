// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="RenderMenuItemEventArgs.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Form.ModernForm.Objects.MenuItems
{
    /// <summary>
    /// Class RenderMenuItemEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class RenderMenuItemEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderMenuItemEventArgs"/> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="font">The font.</param>
        public RenderMenuItemEventArgs(Graphics graphics, Rectangle rectangle, Font font)
        {
            Graphics = graphics;
            Rectangle = rectangle;
            Font = font;
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font { get; set; }
        /// <summary>
        /// Gets or sets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics { get; set; }
        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        /// <value>The rectangle.</value>
        public Rectangle Rectangle { get; set; }
    }
}
