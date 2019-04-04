// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="DefaultColorSchemes.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Form.ModernForm.Objects
{

    /// <summary>
    /// Class DefaultColorSchemes.
    /// </summary>
    public static class DefaultColorSchemes
    {
        /// <summary>
        /// Gets the red.
        /// </summary>
        /// <value>The red.</value>
        public static ColorScheme Red => ColorScheme.CreateSimpleColorScheme(DefaultColors.Red);
        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public static ColorScheme Blue => ColorScheme.CreateSimpleColorScheme(DefaultColors.Blue);
        /// <summary>
        /// Gets the green.
        /// </summary>
        /// <value>The green.</value>
        public static ColorScheme Green => ColorScheme.CreateSimpleColorScheme(DefaultColors.Green);
    }
}
