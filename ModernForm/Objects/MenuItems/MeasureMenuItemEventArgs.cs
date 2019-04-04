// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="MeasureMenuItemEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Form.ModernForm.Objects.MenuItems
{
    /// <summary>
    /// Class MeasureMenuItemEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MeasureMenuItemEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasureMenuItemEventArgs"/> class.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="itemSize">Size of the item.</param>
        public MeasureMenuItemEventArgs(Font font, Graphics graphics, Size itemSize)
        {
            Font = font;
            Graphics = graphics;
            ItemSize = itemSize;
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
        /// Gets or sets the size of the item.
        /// </summary>
        /// <value>The size of the item.</value>
        public Size ItemSize { get; set; } = Size.Empty;
    }
}
