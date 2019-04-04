// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AddShadow.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.Form
{
    /// <summary>
    /// Class AddShadow.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
    public partial class AddShadow : Component
    {
        /// <summary>
        /// The shadow blur
        /// </summary>
        private int shadowBlur = 10;
        /// <summary>
        /// The shadow spread
        /// </summary>
        private int shadowSpread = -5;
        /// <summary>
        /// The shadow v
        /// </summary>
        private int shadowV = 0;
        /// <summary>
        /// The shadow h
        /// </summary>
        private int shadowH = 0;
        /// <summary>
        /// The shadow color
        /// </summary>
        private Color shadowColor = Color.Black;
        /// <summary>
        /// The enable shadow
        /// </summary>
        private bool enableShadow = false;

        /// <summary>
        /// The control
        /// </summary>
        ContainerControl control;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AddShadow"/> is shadow.
        /// </summary>
        /// <value><c>true</c> if shadow; otherwise, <c>false</c>.</value>
        [Category("Shadow"),
         Browsable(true),
         Description("This Enables the form to have shadow effect")]
        public bool Shadow
        {
            get { return enableShadow; }
            set
            {
                enableShadow = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the blur.
        /// </summary>
        /// <value>The blur.</value>
        [Category("Shadow"),
         Browsable(true),
         Description("Sets the blured level of the shadow.")]
        public int Blur
        {
            get { return shadowBlur; }
            set
            {
                shadowBlur = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the dispersion.
        /// </summary>
        /// <value>The dispersion.</value>
        [Category("Shadow"),
         Browsable(true),
         Description("Set to change how the shadow spreads.")]
        public int Dispersion
        {
            get { return shadowSpread; }
            set
            {
                shadowSpread = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the vertical direction.
        /// </summary>
        /// <value>The vertical direction.</value>
        [Category("Shadow"),
         Browsable(true),
         Description("Set to change the vertical direction of the shadow.")]
        public int VerticalDirection
        {
            get { return shadowV; }
            set
            {
                shadowV = value;
                
            }

        }

        /// <summary>
        /// Gets or sets the horizontal direction.
        /// </summary>
        /// <value>The horizontal direction.</value>
        [Category("Shadow"),
         Browsable(true),
         Description("Set to change the horizontal direction of the shadow.")]
        public int HorizontalDirection
        {
            get { return shadowH; }
            set
            {
                shadowH = value;
                
            }

        }

        /// <summary>
        /// Gets or sets the color of shadow.
        /// </summary>
        /// <value>The color of shadow.</value>
        [Category("Shadow"),
         Browsable(true),
         Description("Set to change the shadow color.")]
        public Color ColorOfShadow
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        public ContainerControl Control
        {
            get { return control; }
            set
            {
                control = value;
                
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddShadow"/> class.
        /// </summary>
        public AddShadow()
        {
            InitializeComponent();


            //if(control.ParentForm.Enabled)
            //{
            //    control.ParentForm.Load += AddShadow_Load;
            //}

           if(Shadow)
            {
                control.ParentForm.Select();
             

                control.ParentForm.Load += AddShadow_Load;
            }
            
        }

        /// <summary>
        /// Handles the Load event of the AddShadow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddShadow_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            ZeroitDropshadow AddShadow = new ZeroitDropshadow(control.ParentForm);
            AddShadow.ShadowBlur = shadowBlur;
            AddShadow.ShadowSpread = shadowSpread;
            AddShadow.ShadowV = shadowV;
            AddShadow.ShadowH = shadowH;
            AddShadow.ShadowColor = shadowColor;
            AddShadow.ActivateShadow();


        }

        /// <summary>
        /// Handles the Paint event of the AddShadow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void AddShadow_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddShadow"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AddShadow(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
