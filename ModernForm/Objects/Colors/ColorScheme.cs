// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="ColorScheme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Form.ModernForm.Utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.Form.ModernForm.Utils.GraphicUtils;

namespace Zeroit.Framework.Form.ModernForm.Objects
{
    /// <summary>
    /// Class ColorScheme.
    /// </summary>
    [TypeConverter(typeof(ColorSchemeConverter))]
    public class ColorScheme
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorScheme"/> class.
        /// </summary>
        /// <param name="primaryColor">Color of the primary.</param>
        /// <param name="secondaryColor">Color of the secondary.</param>
        public ColorScheme(Color primaryColor, Color secondaryColor)
        {
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            MouseDownColor = DarkenColor(primaryColor, 0.2f);
            MouseHoverColor = LightenColor(secondaryColor, 0.2F);
            if (primaryColor.IsDarker())
            {
                MouseDownColor = LightenColor(MouseDownColor, 0.2f);
                MouseHoverColor = LightenColor(MouseDownColor, 0.25f);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the color of the primary.
        /// </summary>
        /// <value>The color of the primary.</value>
        public Color PrimaryColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the secondary.
        /// </summary>
        /// <value>The color of the secondary.</value>
        public Color SecondaryColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the mouse down.
        /// </summary>
        /// <value>The color of the mouse down.</value>
        public Color MouseDownColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the mouse hover.
        /// </summary>
        /// <value>The color of the mouse hover.</value>
        public Color MouseHoverColor { get; set; }
        /// <summary>
        /// Gets the color of the foreground.
        /// </summary>
        /// <value>The color of the foreground.</value>
        public Color ForegroundColor => ForegroundColorForBackground(PrimaryColor);
        #endregion

        #region Static Methods
        /// <summary>
        /// Darkens the color.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="value">The value.</param>
        /// <returns>Color.</returns>
        public static Color DarkenColor(Color original, float value = 0.05f)
        {
            return ControlPaint.Dark(original, value);
        }

        /// <summary>
        /// Lightens the color.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="value">The value.</param>
        /// <returns>Color.</returns>
        public static Color LightenColor(Color original, float value = 0.05f)
        {
            return ControlPaint.Light(original, value);
        }

        /// <summary>
        /// Creates the simple color scheme.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>ColorScheme.</returns>
        public static ColorScheme CreateSimpleColorScheme(Color original)
        {
            return new ColorScheme(original, DarkenColor(original));
        }
        #endregion
    }
}
