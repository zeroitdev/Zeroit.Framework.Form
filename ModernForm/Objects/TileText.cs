// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="TileText.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;

namespace Zeroit.Framework.Form.ModernForm.Objects
{
    /// <summary>
    /// Class TileText.
    /// </summary>
    public class TileText
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TileText"/> class.
        /// </summary>
        public TileText()
		{
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="TileText"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        public TileText(string text, Font font, Point location)
		{
			this.text = text;
			this.font = font;
			this.location = location;
		}
        /// <summary>
        /// The location
        /// </summary>
        Point location = Point.Empty;
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public virtual Point Location {
			get {
				return location;
			}
			set {
				location = value;
			}
		}

        /// <summary>
        /// The text
        /// </summary>
        String text = "TileText";
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public virtual String Text {
			get {
				return text;
			}
			set {
				text = value;
			}
		}

        /// <summary>
        /// The font
        /// </summary>
        Font font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public virtual Font Font {
			get {
				return font;
			}
			set {
				font = value;
			}
		}
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
		{
			return "TileText";
		}
	}
}
