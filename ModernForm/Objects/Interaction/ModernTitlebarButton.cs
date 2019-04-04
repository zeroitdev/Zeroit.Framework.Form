// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ModernTitlebarButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Objects.Interaction
{
    /// <summary>
    /// Class ModernTitlebarButton.
    /// </summary>
    public class ModernTitlebarButton
    {
        #region Events
        /// <summary>
        /// Called to signal to subscribers that this button was clicked
        /// </summary>
        public event EventHandler<MouseEventArgs> Click;
        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void OnClick(MouseEventArgs e)
        {
            var eh = Click;
            eh?.Invoke(this, e);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public virtual Font Font { get; set; } = SystemFonts.CaptionFont;
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public virtual String Text { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public virtual int Width { get; set; } = Zeroit.Framework.Form.ModernForm.Forms.ModernForm.DefaultTitlebarHeight;
        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        /// <value>The visible.</value>
        public virtual Boolean Visible { get; set; } = true;

        #endregion

    }
}
