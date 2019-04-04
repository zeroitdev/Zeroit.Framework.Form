// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Action.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Form.ModernForm.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.Form.ModernForm.Objects
{
    /// <summary>
    /// Class AppAction.
    /// </summary>
    [Serializable]
    public class AppAction
    {
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image { get; set; }

        /// <summary>
        /// Called to signal to subscribers that it was clicked.
        /// </summary>
        public event EventHandler Click;
        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public virtual void OnClick(EventArgs e)
        {
            EventHandler eh = Click;

            eh?.Invoke(this, e);
        }


        /// <summary>
        /// Gets the rectangle.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="containerList">The container list.</param>
        /// <returns>Rectangle.</returns>
        public Rectangle GetRectangle(ZeroitAppBar bar, List<AppAction> containerList)
        {
            if (bar != null && containerList != null && containerList.Contains(this)) {
                int index = containerList.IndexOf(this) + (bar.MenuItems != null && bar.MenuItems.Count > 0 ? 1 : 0);
                int xTextOffset = bar.XTextOffset;
                int size = bar.Height - xTextOffset;
                int xTextOffsetHalf = bar.XTextOffset / 2;
                int right = bar.Width - xTextOffsetHalf - (index * size + xTextOffsetHalf * index);
                return Rectangle.FromLTRB(right - size, xTextOffsetHalf, right, bar.Height - xTextOffsetHalf);
            }
            return Rectangle.Empty;
        }
    }
}
