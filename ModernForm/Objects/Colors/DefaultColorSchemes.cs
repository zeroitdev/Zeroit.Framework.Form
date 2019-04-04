// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="DefaultColorSchemes.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
