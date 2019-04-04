// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AppBarMenuTextItem.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Form.ModernForm.Utils;
using System;
using System.Drawing;

namespace Zeroit.Framework.Form.ModernForm.Objects.MenuItems
{
    /// <summary>
    /// Class AppBarMenuTextItem.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Form.ModernForm.Objects.MenuItems.AppBarMenuItem" />
    public class AppBarMenuTextItem : AppBarMenuItem
    {
        /// <summary>
        /// The minimum width
        /// </summary>
        private const int minimumWidth = 150;
        /// <summary>
        /// The minimum height
        /// </summary>
        private const int minimumHeight = 40;
        /// <summary>
        /// The text offset left
        /// </summary>
        private const int textOffsetLeft = 10;
        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor { get; set; } = Color.Black;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBarMenuTextItem"/> class.
        /// </summary>
        public AppBarMenuTextItem() : this("")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBarMenuTextItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public AppBarMenuTextItem(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Handles the <see cref="E:RenderItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="RenderMenuItemEventArgs" /> instance containing the event data.</param>
        protected override void OnRenderItem(RenderMenuItemEventArgs e)
        {
            using (var brush = new SolidBrush(ForeColor)) {
                GraphicUtils.DrawCenteredText(
                    e.Graphics,
                    Text,
                    e.Font,
                    Rectangle.FromLTRB(e.Rectangle.Left + textOffsetLeft, e.Rectangle.Top, e.Rectangle.Right, e.Rectangle.Bottom),
                    ForeColor, horizontal: false);
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MeasureItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MeasureMenuItemEventArgs" /> instance containing the event data.</param>
        protected override void OnMeasureItem(MeasureMenuItemEventArgs e)
        {
            Size textSize = e.Graphics.MeasureString(Text, e.Font).ToSize();
            e.ItemSize = new Size(Math.Max(minimumWidth, textSize.Width), Math.Max(minimumHeight, textSize.Height));
        }

    }
}
