// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="NativeTitlebarButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Objects.Interaction
{
    /// <summary>
    /// Class NativeTitlebarButton.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Form.ModernForm.Objects.Interaction.ModernTitlebarButton" />
    public class NativeTitlebarButton : ModernTitlebarButton
    {
        /// <summary>
        /// The parent
        /// </summary>
        System.Windows.Forms.Form parent;
        /// <summary>
        /// The action
        /// </summary>
        readonly TitlebarAction action;
        //Make use of the Marlett font.
        //This font provides characters that can be used to display a caption button
        /// <summary>
        /// The f marlett
        /// </summary>
        static Font fMarlett = new Font("Marlett", 10f);

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeTitlebarButton"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="width">The width.</param>
        /// <param name="action">The action.</param>
        public NativeTitlebarButton(System.Windows.Forms.Form parent, int width, TitlebarAction action)
        {
            this.action = action;
            this.parent = parent;
            this.Width = width;
            this.Font = fMarlett;
            Click += TitlebarButton_Click;
        }

        /// <summary>
        /// Handles the Click event of the TitlebarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void TitlebarButton_Click(object sender, MouseEventArgs e)
        {
            switch (action) {
                case TitlebarAction.Minimize:
                    parent.WindowState = FormWindowState.Minimized;
                    break;
                case TitlebarAction.Maximize:
                    FormWindowState finalWindowState = FormWindowState.Normal;
                    if (parent.WindowState == FormWindowState.Normal)
                        finalWindowState = FormWindowState.Maximized;
                    parent.WindowState = finalWindowState;
                    break;
                case TitlebarAction.Close:
                    parent.Close();
                    break;
            }
        }

        /// <summary>
        /// Gets the button text.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetButtonText()
        {
            switch (action) {
                case TitlebarAction.Minimize:
                    return "0"; //In Marlett, "0" represents minimize button
                case TitlebarAction.Maximize:
                    return parent.WindowState == FormWindowState.Maximized ? "2" : "1"; //In Marlett, "1" represents maximize and "2" represents restore button
                case TitlebarAction.Close:
                    return "r"; //In Marlett, "r" represents close button
            }
            return "";
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public override string Text {
            get {
                return GetButtonText();
            }
            set => base.Text = value;
        }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        /// <value>The visible.</value>
        public override bool Visible {
            get {
                switch (action) {
                    case TitlebarAction.Minimize:
                        return parent.MinimizeBox;
                    case TitlebarAction.Maximize:
                        return parent.MaximizeBox;
                }
                return true;
            }
            set => base.Visible = value;
        }

        /// <summary>
        /// Enum TitlebarAction
        /// </summary>
        public enum TitlebarAction
        {
            /// <summary>
            /// The minimize
            /// </summary>
            Minimize, //Minimize
            /// <summary>
            /// The maximize
            /// </summary>
            Maximize, //Maximize/Restore
            /// <summary>
            /// The close
            /// </summary>
            Close //Close
        }
    }
}
