// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="NativeShadow.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using Zeroit.Framework.Form.ModernForm.Objects;

namespace Zeroit.Framework.Form.Thematic
{

    /// <summary>
    /// Class Shadow.
    /// </summary>
    [Serializable]
    public class NativeShadow
    {

        /// <summary>
        /// Gets or sets the type of the shadow.
        /// </summary>
        /// <value>The type of the shadow.</value>
        public ShadowType ShadowType { get; set; } = ShadowType.Default;

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        [Browsable(true)]
        [Category("Shadow")]
        public Color ShadowColor
        {
            get;
            set;
        } = Color.Black;

        /// <summary>
        /// The window opacity
        /// </summary>
        private float windowOpacity = 0.30F;
        /// <summary>
        /// Gets or sets the shadow opacity.
        /// </summary>
        /// <value>The shadow opacity.</value>
        public float WindowOpacity
        {
            get { return windowOpacity; }
            set
            {
                if (value > 1)
                {
                    value = 1;
                }

                if (value < 0)
                {
                    value = 0;
                }

                windowOpacity = value;


            }
        }

        /// <summary>
        /// Gets or sets the size of the border.
        /// </summary>
        /// <value>The size of the border.</value>
        public int BorderSize { get; set; } = 5;

    }

}