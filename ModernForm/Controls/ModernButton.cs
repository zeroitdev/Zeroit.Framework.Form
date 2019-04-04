// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ModernButton.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Form.ModernForm.Objects;
using Zeroit.Framework.Form.ModernForm.Utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Controls
{
    /// <summary>
    /// Class ZeroitFlatButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [ToolboxItem(false)]
    public class ZeroitFlatButton : Button
    {
        #region Fields

        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorScheme _colorScheme = DefaultColorSchemes.Blue;
        /// <summary>
        /// The custom color scheme
        /// </summary>
        private bool _customColorScheme;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [custom color scheme].
        /// </summary>
        /// <value><c>true</c> if [custom color scheme]; otherwise, <c>false</c>.</value>
        public bool CustomColorScheme
        {
            get => _customColorScheme;
            set
            {
                if (!_customColorScheme && value && _colorScheme == DefaultColorSchemes.Blue)
                    _colorScheme = ColorScheme;
                _customColorScheme = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        public ColorScheme ColorScheme
        {
            get
            {
                var form = FindForm();
                return form != null && form is Zeroit.Framework.Form.ModernForm.Forms.ModernForm mdF && !CustomColorScheme ? mdF.ColorScheme : _colorScheme;
            }
            set
            {
                _colorScheme = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets the control bounds.
        /// </summary>
        /// <value>The control bounds.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ControlBounds => new Rectangle(Point.Empty, Size);

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseDown(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnMouseUp(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnPaint(System.Windows.Forms.PaintEventArgs)" /> event.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            var cursorLoc = PointToClient(Cursor.Position);
            base.OnPaint(pevent);
            using (var primary = new SolidBrush(ColorScheme.PrimaryColor))
            {
                using (var mouseDown = new SolidBrush(ColorScheme.MouseDownColor))
                {
                    using (var mouseHover = new SolidBrush(ColorScheme.MouseHoverColor))
                    {
                        var isHover = DisplayRectangle.Contains(cursorLoc);
                        var isDown = MouseButtons == MouseButtons.Left;
                        pevent.Graphics.FillRectangle(
                            isDown && !DesignMode ? mouseDown : isHover && !DesignMode ? mouseHover : primary,
                            ControlBounds);
                        using (var sF = ControlPaintWrapper.StringFormatForAlignment(TextAlign))
                        {
                            using (var brush = new SolidBrush(ColorScheme.ForegroundColor))
                            {
                                pevent.Graphics.DrawString(Text, Font, brush, DisplayRectangle, sF);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}