// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ModernTitlebarButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
