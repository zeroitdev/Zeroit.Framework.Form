// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="CustomShadow.cs" company="Zeroit Dev Technologies">
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
    [Serializable]
    public class CustomShadow
    {
        #region Old Shadow Code
        private int shadowBlur = 10;
        private int shadowSpread = -5;
        private int shadowV = 0;
        private int shadowH = 0;
        private Color shadowColor = Color.Black;
        private byte shadowOpacity = 150;
        #endregion

        #region Old Shadow Properties
        /// <summary>
        /// Gets or sets the shadow blur.
        /// </summary>
        /// <value>The shadow blur.</value>
        public int ShadowBlur
        {
            get { return shadowBlur; }
            set { shadowBlur = value;  }
        }

        /// <summary>
        /// Gets or sets the shadow spread.
        /// </summary>
        /// <value>The shadow spread.</value>
        public int ShadowSpread
        {
            get { return shadowSpread; }
            set { shadowSpread = value;  }
        }

        /// <summary>
        /// Gets or sets the shadow vertical location.
        /// </summary>
        /// <value>The shadow v.</value>
        public int ShadowV
        {
            get { return shadowV; }
            set { shadowV = value;  }
        }

        /// <summary>
        /// Gets or sets the shadow horizontal location.
        /// </summary>
        /// <value>The shadow h.</value>
        public int ShadowH
        {
            get { return shadowH; }
            set { shadowH = value;  }
        }

        public byte ShadowOpacity
        {
            get { return shadowOpacity; }
            set { shadowOpacity = value; }
        }

        public Color ShadowColor
        {
            get { return shadowColor; }
            set { shadowColor = value; }
        }

        #endregion

    }

}