// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Action.cs" company="Zeroit Dev Technologies">
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
