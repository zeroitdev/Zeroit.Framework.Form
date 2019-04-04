// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AppBarMenuItem.cs" company="Zeroit Dev Technologies">
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
    /// Class AppBarMenuItem.
    /// </summary>
    [Serializable]
    public abstract class AppBarMenuItem
    {
        /// <summary>
        /// Called to signal to subscribers that this action was clicked
        /// </summary>
        public event EventHandler Click;
        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler eh = Click;

            eh?.Invoke(this, e);
        }

        /// <summary>
        /// Called to signal to subscribers that the item needs to be measured
        /// </summary>
        public event EventHandler<MeasureMenuItemEventArgs> MeasureItem;
        /// <summary>
        /// Handles the <see cref="E:MeasureItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MeasureMenuItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMeasureItem(MeasureMenuItemEventArgs e)
        {
            EventHandler<MeasureMenuItemEventArgs> eh = MeasureItem;

            eh?.Invoke(this, e);
        }

        /// <summary>
        /// Called to signal to subscribers that the item needs to be rendered
        /// </summary>
        public event EventHandler<RenderMenuItemEventArgs> RenderItem;
        /// <summary>
        /// Handles the <see cref="E:RenderItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="RenderMenuItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnRenderItem(RenderMenuItemEventArgs e)
        {
            EventHandler<RenderMenuItemEventArgs> eh = RenderItem;

            eh?.Invoke(this, e);
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="g">The g.</param>
        /// <returns>Size.</returns>
        public Size GetSize(Font font, Graphics g)
        {
            MeasureMenuItemEventArgs args = new MeasureMenuItemEventArgs(font, g, Size.Empty);
            OnMeasureItem(args);
            return args.ItemSize;
        }


        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="font">The font.</param>
        public void DrawItem(Graphics g, Rectangle rect, Font font)
        {
            var args = new RenderMenuItemEventArgs(g, rect, font);
            OnRenderItem(args);
        }



        /// <summary>
        /// Performs the click.
        /// </summary>
        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }

    }
}
