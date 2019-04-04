// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="EllipticalForm.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
using System.Drawing;
using Zeroit.Framework.Form.Helper;

namespace Zeroit.Framework.Form
{
    /// <summary>
    /// A class collection for rendering an Elliptical form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class EllipticalForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        /// <summary>
        /// Gets or sets the border radius.
        /// </summary>
        /// <value>The border radius.</value>
        public int BorderRadius
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                Ellipse.Apply(this, this.int_0);
            }
        }

        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ClassStyle = createParams.ClassStyle | 131072;
                createParams.ExStyle = createParams.ExStyle | 33554432;
                return createParams;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipticalForm" /> class.
        /// </summary>
        public EllipticalForm()
        {
            this.InitializeComponent();
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form" />.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(284, 261);
            base.Name = "EllipticalForm";
            this.Text = "EllipticalForm";
            base.ResumeLayout(false);
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            Ellipse.Apply(this, this.int_0);
            base.OnResize(e);
        }
    }

}
