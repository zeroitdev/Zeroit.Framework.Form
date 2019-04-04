// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="RenderMenuItemEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
