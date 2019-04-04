// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ControlButtons.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Form.Thematic
{
    /// <summary>
    /// Class ControlButtons.
    /// </summary>
    public class ControlButtons
    {
        /// <summary>
        /// The image
        /// </summary>
        Image image = null;
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return image; }
            set
            {
                if (value == null)
                {
                    ImageSize = Size.Empty;
                }
                else
                {
                    ImageSize = value.Size;
                }

                image = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text symbol.
        /// </summary>
        /// <value>The text symbol.</value>
        public String TextSymbol
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get;
            set;
        } = new Font("Tahoma", 10);

        /// <summary>
        /// Gets or sets a value indicating whether [use image].
        /// </summary>
        /// <value><c>true</c> if [use image]; otherwise, <c>false</c>.</value>
        public bool UseImage
        {
            get;
            set;
        } = false;


        /// <summary>
        /// Gets or sets the color of the symbol.
        /// </summary>
        /// <value>The color of the symbol.</value>
        public Color SymbolColor
        {
            get;
            set;
        } = Color.Black;



        /// <summary>
        /// Initializes a new instance of the <see cref="ControlButtons"/> class.
        /// </summary>
        public ControlButtons()
        {

        }

    }

}