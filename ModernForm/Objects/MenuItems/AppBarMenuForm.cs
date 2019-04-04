// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AppBarMenuForm.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.Form.ModernForm.Objects.MenuItems
{
    /// <summary>
    /// Class AppBarMenuForm.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Form.ModernForm.Forms.ModernForm" />
    class AppBarMenuForm : Zeroit.Framework.Form.ModernForm.Forms.ModernForm
    {
        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation => true;
    }
}
