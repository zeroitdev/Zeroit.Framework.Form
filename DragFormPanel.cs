// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="DragFormPanel.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.Form.Thematic;


namespace Zeroit.Framework.Form
{
    /// <summary>
    /// Class DragFormPanel.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxItem(false)]
    partial class DragFormPanel : Component
    {

        /// <summary>
        /// The control
        /// </summary>
        public Control control = new Control();

        /// <summary>
        /// The drag form
        /// </summary>
        ResizableForm dragForm = new ResizableForm();
        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control
        {
            get { return control; }
            set
            {
                control = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DragFormPanel"/> class.
        /// </summary>
        public DragFormPanel()
        {
            InitializeComponent();

            control.MouseDown += dragForm.DragForm_MouseDown;
            control.MouseMove += dragForm.DragForm_MouseMove;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DragFormPanel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public DragFormPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Handles the Paint event of the DragForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void DragForm_Paint(object sender, PaintEventArgs e)
        {
            ////Draws a border to make the Form stand out
            ////Just done for appearance, not necessary


            //Pen p = new Pen(Color.Black, 1);
            //e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            //p.Dispose();
        }



        /// <summary>
        /// Handles the MouseDown event of the DragForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void DragForm_MouseDown(object sender, MouseEventArgs e)
        {

            dragForm.lastClick = new Point(e.X, e.Y); //We'll need this for when the Form starts to move
        }

        /// <summary>
        /// Handles the MouseMove event of the DragForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void DragForm_MouseMove(object sender, MouseEventArgs e)
        {

            //Point newLocation = new Point(e.X - lastE.X, e.Y - lastE.Y);
            if (e.Button == MouseButtons.Left) //Only when mouse is clicked
            {
                //Move the Form the same difference the mouse cursor moved;
                
                dragForm.Left += e.X - dragForm.lastClick.X;
                dragForm.Left += e.Y - dragForm.lastClick.Y;
            }
        }
    }
}
