// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="OSX.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
//using Zeroit.Framework.Widgets;

#endregion

namespace Zeroit.Framework.Form
{


    #region About This Mac Theme Core

    // WindowsFormApplication Form Theme : Macintosh OS X
    // Codes created and written by John J. Espiritu (Intel_VistaHacker)
    // Debugged by John J. Espiritu (Intel_VistaHacker)
    // Copyright (c) 2010 :: All Rights Reserved
    // Author's Email : john_granturismo04@yahoo.com
    // 
    // NOTICE : You are allowed to use this library/theme to you forms. Please just don't forget to credit me. :D
    // Thank you!!!
    #endregion

    /// <summary>
    /// A class collection for rendering a mac theme.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class OSXForm : System.Windows.Forms.Form
    {
        //This is the class where the mac theme base design is generated.

        //controls, variables, blah blah blah...

        #region Private Fields
        /// <summary>
        /// The rightpnl
        /// </summary>
        internal Panel rightpnl;
        /// <summary>
        /// The nwsize
        /// </summary>
        internal Panel nwsize;
        /// <summary>
        /// The swresize
        /// </summary>
        internal Panel swresize;
        /// <summary>
        /// The bottompnl
        /// </summary>
        internal Panel bottompnl;
        /// <summary>
        /// The controlbox tool tip
        /// </summary>
        private ToolTip controlboxToolTip;
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;
        /// <summary>
        /// The loc
        /// </summary>
        private Point loc;
        /// <summary>
        /// The pright
        /// </summary>
        private int pright;
        /// <summary>
        /// The panelmod1
        /// </summary>
        private panelmod panelmod1;
        /// <summary>
        /// The command maximum resource
        /// </summary>
        public panelmod cmdMaxRes;
        /// <summary>
        /// The command minimum
        /// </summary>
        internal panelmod cmdMin;
        /// <summary>
        /// The command close
        /// </summary>
        private panelmod cmdClose;
        /// <summary>
        /// The toppnl
        /// </summary>
        internal Panel toppnl;
        /// <summary>
        /// The title caption
        /// </summary>
        public Label titleCaption;
        /// <summary>
        /// The leftpnl
        /// </summary>
        internal Panel leftpnl;
        /// <summary>
        /// The bodypanel
        /// </summary>
        public panelmod bodypanel;
        /// <summary>
        /// The bottompnl2
        /// </summary>
        internal Panel bottompnl2;
        /// <summary>
        /// The rightpnl2
        /// </summary>
        internal Panel rightpnl2;
        /// <summary>
        /// The leftpnl2
        /// </summary>
        internal Panel leftpnl2;
        /// <summary>
        /// The originalleft
        /// </summary>
        private int originalleft;
        /// <summary>
        /// The originaltop
        /// </summary>
        private int originaltop;
        /// <summary>
        /// The pbottom
        /// </summary>
        private int pbottom;
        /// <summary>
        /// The win maxed
        /// </summary>
        internal bool winMaxed = false;
        /// <summary>
        /// The original size
        /// </summary>
        internal Size originalSize;
        /// <summary>
        /// The width
        /// </summary>
        private int theWidth;
        /// <summary>
        /// The r loc
        /// </summary>
        private ResizeLocation rLoc;
        //Windows API Constants (Form Resize)
        /// <summary>
        /// The wm nclbuttondown
        /// </summary>
        internal const int WM_NCLBUTTONDOWN = 161;
        /// <summary>
        /// The ht caption
        /// </summary>
        internal const int HT_CAPTION = 0x2;
        /// <summary>
        /// The htbottom
        /// </summary>
        internal const int HTBOTTOM = 15;
        /// <summary>
        /// The htbottomleft
        /// </summary>
        internal const int HTBOTTOMLEFT = 16;
        /// <summary>
        /// The htbottomright
        /// </summary>
        internal const int HTBOTTOMRIGHT = 17;
        /// <summary>
        /// The htright
        /// </summary>
        internal const int HTRIGHT = 11;
        /// <summary>
        /// The htleft
        /// </summary>
        internal const int HTLEFT = 10;
        /// <summary>
        /// The httop
        /// </summary>
        internal const int HTTOP = 12;
        /// <summary>
        /// The ws maximize
        /// </summary>
        internal const int WS_MAXIMIZE = 0x01000000;
        /// <summary>
        /// The wm command
        /// </summary>
        internal const int WM_COMMAND = 0x111;
        /// <summary>
        /// The size maximized
        /// </summary>
        internal const int SIZE_MAXIMIZED = 2;
        /// <summary>
        /// The wm size
        /// </summary>
        internal const int WM_SIZE = 0x0005;
        /// <summary>
        /// The sw maximize
        /// </summary>
        internal const int SW_MAXIMIZE = 3;
        /// <summary>
        /// The sw normal
        /// </summary>
        internal const int SW_NORMAL = 1;
        #endregion

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            //updates the titleCaption...
            get
            {
                return base.Text;
            }
            set
            {
                titleCaption.Text = value;
                base.Text = value;
            }
        }


        /// <summary>
        /// Creates an instance of a new themed form.
        /// </summary>
        public OSXForm()
        {
            //Initializes the components and maximum size of the form.
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSXForm));
            this.rightpnl = new System.Windows.Forms.Panel();
            this.bottompnl = new System.Windows.Forms.Panel();
            this.nwsize = new System.Windows.Forms.Panel();
            this.swresize = new System.Windows.Forms.Panel();
            this.controlboxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdMaxRes = new panelmod();
            this.cmdMin = new panelmod();
            this.cmdClose = new panelmod();
            this.leftpnl = new System.Windows.Forms.Panel();
            this.bodypanel = new panelmod();
            this.bottompnl2 = new System.Windows.Forms.Panel();
            this.rightpnl2 = new System.Windows.Forms.Panel();
            this.leftpnl2 = new System.Windows.Forms.Panel();
            this.panelmod1 = new panelmod();
            this.toppnl = new System.Windows.Forms.Panel();
            this.titleCaption = new System.Windows.Forms.Label();
            this.bodypanel.SuspendLayout();
            this.panelmod1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightpnl
            // 
            this.rightpnl.BackColor = System.Drawing.Color.Black;
            this.rightpnl.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.rightpnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightpnl.Location = new System.Drawing.Point(650, 22);
            this.rightpnl.Name = "rightpnl";
            this.rightpnl.Size = new System.Drawing.Size(1, 378);
            this.rightpnl.TabIndex = 1;
            this.rightpnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightpnl_MouseMove);
            this.rightpnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.rightpnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // bottompnl
            // 
            this.bottompnl.BackColor = System.Drawing.Color.Black;
            this.bottompnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottompnl.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.bottompnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottompnl.Location = new System.Drawing.Point(0, 400);
            this.bottompnl.Name = "bottompnl";
            this.bottompnl.Size = new System.Drawing.Size(651, 1);
            this.bottompnl.TabIndex = 2;
            this.bottompnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bottompnl_MouseMove);
            this.bottompnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.bottompnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // nwsize
            // 
            this.nwsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nwsize.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.nwsize.Location = new System.Drawing.Point(1, 398);
            this.nwsize.Name = "nwsize";
            this.nwsize.Size = new System.Drawing.Size(2, 2);
            this.nwsize.TabIndex = 3;
            this.nwsize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nwsize_MouseMove);
            this.nwsize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.nwsize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // swresize
            // 
            this.swresize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.swresize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.swresize.Location = new System.Drawing.Point(648, 398);
            this.swresize.Name = "swresize";
            this.swresize.Size = new System.Drawing.Size(2, 2);
            this.swresize.TabIndex = 4;
            this.swresize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.swresize_MouseMove);
            this.swresize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.swresize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // cmdMaxRes
            // 
            this.cmdMaxRes.BackColor = System.Drawing.Color.Transparent;
            this.cmdMaxRes.BackgroundImage = new Bitmap(Properties.Resources.cmdMaxRes_BackgroundImage); /*((System.Drawing.Image)(resources.GetObject("cmdMaxRes.BackgroundImage")));*/
            this.cmdMaxRes.Location = new System.Drawing.Point(47, 3);
            this.cmdMaxRes.Name = "cmdMaxRes";
            this.cmdMaxRes.Size = new System.Drawing.Size(16, 16);
            this.cmdMaxRes.TabIndex = 12;
            this.controlboxToolTip.SetToolTip(this.cmdMaxRes, "Maximize/Restore");
            this.cmdMaxRes.MouseLeave += new System.EventHandler(this.cmdMaxRes_MouseLeave);
            this.cmdMaxRes.Paint += new System.Windows.Forms.PaintEventHandler(this.cmdMaxRes_Paint);
            this.cmdMaxRes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdMaxRes_MouseMove);
            this.cmdMaxRes.Click += new System.EventHandler(this.cmdMaxRes_Click);
            // 
            // cmdMin
            // 
            this.cmdMin.BackColor = System.Drawing.Color.Transparent;
            this.cmdMin.BackgroundImage = new Bitmap(Properties.Resources.cmdMin_BackgroundImage);/* ((System.Drawing.Image)(resources.GetObject("cmdMin.BackgroundImage")));*/
            this.cmdMin.Location = new System.Drawing.Point(25, 3);
            this.cmdMin.Name = "cmdMin";
            this.cmdMin.Size = new System.Drawing.Size(16, 16);
            this.cmdMin.TabIndex = 11;
            this.controlboxToolTip.SetToolTip(this.cmdMin, "Minimize");
            this.cmdMin.MouseLeave += new System.EventHandler(this.cmdMin_MouseLeave);
            this.cmdMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdMin_MouseMove);
            this.cmdMin.Click += new System.EventHandler(this.cmdMin_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImage = new Bitmap(Properties.Resources.cmdClose_BackgroundImage); /*((System.Drawing.Image)(resources.GetObject("cmdClose.BackgroundImage")));*/
            this.cmdClose.Location = new System.Drawing.Point(3, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(16, 16);
            this.cmdClose.TabIndex = 10;
            this.controlboxToolTip.SetToolTip(this.cmdClose, "Close");
            this.cmdClose.MouseLeave += new System.EventHandler(this.cmdClose_MouseLeave);
            this.cmdClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // leftpnl
            // 
            this.leftpnl.BackColor = System.Drawing.Color.Black;
            this.leftpnl.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.leftpnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpnl.Location = new System.Drawing.Point(0, 22);
            this.leftpnl.Name = "leftpnl";
            this.leftpnl.Size = new System.Drawing.Size(1, 378);
            this.leftpnl.TabIndex = 0;
            this.leftpnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftpnl_MouseMove);
            this.leftpnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.leftpnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // bodypanel
            // 
            this.bodypanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.bodypanel.BackColor = Parent.BackColor; /*System.Drawing.Color.Transparent;*/
            this.bodypanel.Controls.Add(this.bottompnl2);
            this.bodypanel.Controls.Add(this.rightpnl2);
            this.bodypanel.Controls.Add(this.leftpnl2);
            this.bodypanel.Location = new System.Drawing.Point(1, 22);
            this.bodypanel.Name = "bodypanel";
            this.bodypanel.Size = new System.Drawing.Size(649, 376);
            this.bodypanel.TabIndex = 6;
            this.bodypanel.Dock = DockStyle.Fill;
            // 
            // bottompnl2
            // 
            this.bottompnl2.BackColor = System.Drawing.Color.Transparent;
            this.bottompnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottompnl2.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.bottompnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottompnl2.Location = new System.Drawing.Point(2, 373);
            this.bottompnl2.Name = "bottompnl2";
            this.bottompnl2.Size = new System.Drawing.Size(644, 3);
            this.bottompnl2.TabIndex = 11;
            this.bottompnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bottompnl_MouseMove);
            this.bottompnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.bottompnl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // rightpnl2
            // 
            this.rightpnl2.BackColor = System.Drawing.Color.Transparent;
            this.rightpnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightpnl2.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.rightpnl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightpnl2.Location = new System.Drawing.Point(646, 0);
            this.rightpnl2.Name = "rightpnl2";
            this.rightpnl2.Size = new System.Drawing.Size(3, 376);
            this.rightpnl2.TabIndex = 10;
            this.rightpnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightpnl_MouseMove);
            this.rightpnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.rightpnl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // leftpnl2
            // 
            this.leftpnl2.BackColor = System.Drawing.Color.Transparent;
            this.leftpnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftpnl2.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.leftpnl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpnl2.Location = new System.Drawing.Point(0, 0);
            this.leftpnl2.Name = "leftpnl2";
            this.leftpnl2.Size = new System.Drawing.Size(2, 376);
            this.leftpnl2.TabIndex = 9;
            this.leftpnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftpnl_MouseMove);
            this.leftpnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.leftpnl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // panelmod1
            // 
            this.panelmod1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelmod1.BackgroundImage = Properties.Resources.titlebar;
            this.panelmod1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelmod1.Controls.Add(this.cmdMaxRes);
            this.panelmod1.Controls.Add(this.cmdMin);
            this.panelmod1.Controls.Add(this.cmdClose);
            this.panelmod1.Controls.Add(this.toppnl);
            this.panelmod1.Controls.Add(this.titleCaption);
            this.panelmod1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelmod1.Location = new System.Drawing.Point(0, 0);
            this.panelmod1.Name = "panelmod1";
            this.panelmod1.Size = new System.Drawing.Size(651, 22);
            this.panelmod1.TabIndex = 5;
            this.panelmod1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
            this.panelmod1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelmod1_MouseDoubleClick);
            this.panelmod1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.panelmod1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // toppnl
            // 
            this.toppnl.BackColor = System.Drawing.Color.Transparent;
            this.toppnl.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.toppnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.toppnl.Location = new System.Drawing.Point(0, 0);
            this.toppnl.Name = "toppnl";
            this.toppnl.Size = new System.Drawing.Size(649, 3);
            this.toppnl.TabIndex = 9;
            this.toppnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toppnl_MouseMove);
            this.toppnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.toppnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // titleCaption
            // 
            this.titleCaption.AutoEllipsis = true;
            this.titleCaption.AutoSize = true;
            this.titleCaption.BackColor = System.Drawing.Color.Transparent;
            this.titleCaption.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleCaption.Location = new System.Drawing.Point(257, 3);
            this.titleCaption.Name = "titleCaption";
            this.titleCaption.Size = new System.Drawing.Size(130, 14);
            this.titleCaption.TabIndex = 13;
            this.titleCaption.Text = "WindowsFormApplication";
            this.titleCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleCaption.Layout += new System.Windows.Forms.LayoutEventHandler(this.titleCaption_Layout);
            this.titleCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
            this.titleCaption.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelmod1_MouseDoubleClick);
            this.titleCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.titleCaption.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
            // 
            // OSXForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(651, 401);
            this.Controls.Add(this.bodypanel);
            this.Controls.Add(this.leftpnl);
            this.Controls.Add(this.rightpnl);
            this.Controls.Add(this.panelmod1);
            this.Controls.Add(this.swresize);
            this.Controls.Add(this.nwsize);
            this.Controls.Add(this.bottompnl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(250, 25);
            this.Name = "OSXForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WindowsFormApplication";
            this.Deactivate += new System.EventHandler(this.mactheme_Deactivate);
            this.Activated += new System.EventHandler(this.mactheme_Activated);
            this.Resize += new System.EventHandler(this.mactheme_Resize);
            this.bodypanel.ResumeLayout(false);
            this.panelmod1.ResumeLayout(false);
            this.panelmod1.PerformLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Enum representing the resize location
        /// </summary>
        private enum ResizeLocation
        {
            //Determines the position of the cursor.
            /// <summary>
            /// The top
            /// </summary>
            Top = 0,
            /// <summary>
            /// The left
            /// </summary>
            Left = 1,
            /// <summary>
            /// The right
            /// </summary>
            Right = 2,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom = 3,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 4,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 5,
            /// <summary>
            /// The none
            /// </summary>
            None = 6,
        }

        /// <summary>
        /// Resizes the specified e.
        /// </summary>
        /// <param name="e">The e.</param>
        private void resize(ResizeLocation e)
        {
            //The resize function using the Windows API (SendMessage() and ReleaseCapture()).
            int dir = -1;
            switch (e)
            {
                case ResizeLocation.Top:
                    dir = HTTOP;
                    break;
                case ResizeLocation.Left:
                    dir = HTLEFT;
                    break;
                case ResizeLocation.Right:
                    dir = HTRIGHT;
                    break;
                case ResizeLocation.Bottom:
                    dir = HTBOTTOM;
                    break;
                case ResizeLocation.BottomLeft:
                    dir = HTBOTTOMLEFT;
                    break;
                case ResizeLocation.BottomRight:
                    dir = HTBOTTOMRIGHT;
                    break;
            }
            if (dir != -1)
            {
                API.ReleaseCapture();
                API.SendMessage(this.Handle, WM_NCLBUTTONDOWN, dir, 0);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the titlebar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            //a shared MouseDown function(titleCaption,title bar, sizing edges).
            //Retrieves the form's current location on the screen.
            loc = e.Location;
            theWidth = this.Width;
            pright = this.Right;
            pbottom = this.Bottom;
            Cursor.Clip = Screen.PrimaryScreen.WorkingArea;
            //For the resizing edges...
            try
            {
                Panel panel = (Panel)sender;
                switch (panel.Name)
                {
                    case "toppnl":
                        rLoc = ResizeLocation.Top;
                        break;
                    case "leftpnl":
                        rLoc = ResizeLocation.Left;
                        break;
                    case "leftpnl2":
                        rLoc = ResizeLocation.Left;
                        break;
                    case "rightpnl":
                        rLoc = ResizeLocation.Right;
                        break;
                    case "rightpnl2":
                        rLoc = ResizeLocation.Right;
                        break;
                    case "bottompnl":
                        rLoc = ResizeLocation.Bottom;
                        break;
                    case "bottompnl2":
                        rLoc = ResizeLocation.Bottom;
                        break;
                    case "nwsize":
                        rLoc = ResizeLocation.BottomLeft;
                        break;
                    case "swresize":
                        rLoc = ResizeLocation.BottomRight;
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// Handles the MouseMove event of the titlebar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void titlebar_MouseMove(object sender, MouseEventArgs e)
        {
            //Function for form dragging.
            if (this.WindowState != FormWindowState.Maximized)
            {
                if (MouseButtons.ToString() == "Left")
                {
                    API.ReleaseCapture();
                    API.SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the rightpnl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void rightpnl_MouseMove(object sender, MouseEventArgs e)
        {
            //Resize Function (Right):
            if (MouseButtons.ToString() == "Left")
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    resize(rLoc);
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the bottompnl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void bottompnl_MouseMove(object sender, MouseEventArgs e)
        {
            //Resize Function (Bottom);
            if (MouseButtons.ToString() == "Left")
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    resize(rLoc);
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the swresize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void swresize_MouseMove(object sender, MouseEventArgs e)
        {
            //The Bottom Right corner resize function.
            if (MouseButtons.ToString() == "Left")
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    resize(rLoc);
                }
            }
        }

        /// <summary>
        /// Handles the Resize event of the mactheme control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mactheme_Resize(object sender, EventArgs e)
        {
            //Function to center the caption position and update the form to avoid flickers.
            //Always determine the maximum workingArea of the screen.
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            int formWidth = this.Width;
            int captionWidth = titleCaption.Width;
            if (titleCaption.Left < cmdMaxRes.Right)
            {
                titleCaption.Left = cmdMaxRes.Right + 5;
            }
            else if (titleCaption.Left > cmdMaxRes.Right + 5)
            {
                titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
            }
            if ((formWidth / 2) - (captionWidth / 2) > cmdMaxRes.Right)
            {
                titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
            }
            this.Update();
        }

        /// <summary>
        /// Handles the MouseMove event of the leftpnl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void leftpnl_MouseMove(object sender, MouseEventArgs e)
        {
            //Resize function (Left side)
            if (MouseButtons.ToString() == "Left")
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    resize(rLoc);
                }
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the bufferedPanel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void bufferedPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            //releases the cursors limit when dragging the form around, to allow cursor to go to the taskbar.
            Cursor.Clip = Screen.PrimaryScreen.Bounds;
        }

        /// <summary>
        /// Handles the Activated event of the mactheme control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mactheme_Activated(object sender, EventArgs e)
        {
            //Sets the the titlebar's background to its normal color to determine that it's active.
            panelmod1.BackgroundImage = Properties.Resources.titlebar;
        }

        /// <summary>
        /// Handles the Deactivate event of the mactheme control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mactheme_Deactivate(object sender, EventArgs e)
        {
            //Sets the titlebar's background to a lighter color to determine that it's inactive and reset the cursor limits.
            panelmod1.BackgroundImage = Properties.Resources.titlebarunfocused1;
            Cursor.Clip = Screen.PrimaryScreen.Bounds;
        }

        /// <summary>
        /// Handles the MouseMove event of the cmdClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void cmdClose_MouseMove(object sender, MouseEventArgs e)
        {
            //change the backgroundimage...
            cmdClose.BackgroundImage = Properties.Resources.controlbutton_close;
        }

        /// <summary>
        /// Handles the MouseLeave event of the cmdClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdClose_MouseLeave(object sender, EventArgs e)
        {
            //restores the original button image...
            cmdClose.BackgroundImage = Properties.Resources.controlbutton_normal;
        }

        /// <summary>
        /// Handles the MouseMove event of the cmdMin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void cmdMin_MouseMove(object sender, MouseEventArgs e)
        {
            //sets the background image to minimize...
            cmdMin.BackgroundImage = Properties.Resources.controlbutton_min;
        }

        /// <summary>
        /// Handles the MouseLeave event of the cmdMin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdMin_MouseLeave(object sender, EventArgs e)
        {
            //restores the original image of cmdMin background image...
            cmdMin.BackgroundImage = Properties.Resources.controlbutton_normal;
        }

        /// <summary>
        /// Handles the MouseMove event of the cmdMaxRes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void cmdMaxRes_MouseMove(object sender, MouseEventArgs e)
        {
            //sets cmdMaxRes' background image '+'...
            cmdMaxRes.BackgroundImage = Properties.Resources.controlbutton_maxres;
        }

        /// <summary>
        /// Handles the MouseLeave event of the cmdMaxRes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdMaxRes_MouseLeave(object sender, EventArgs e)
        {
            //restores cmdMaxRes' background image to normal...
            cmdMaxRes.BackgroundImage = Properties.Resources.controlbutton_normal;
        }

        /// <summary>
        /// Handles the Click event of the cmdClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            //Closes the form.
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the cmdMin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdMin_Click(object sender, EventArgs e)
        {
            //minimizes the form.
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles the Click event of the cmdMaxRes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdMaxRes_Click(object sender, EventArgs e)
        {
            if (this.winMaxed == false)
            {
                //Maximizes the form and removes the resizing cursors of the edges.
                originalleft = this.Left;
                originaltop = this.Top;
                originalSize = this.Size;
                this.DesktopLocation = new Point(0, 0);
                this.Size = this.MaximumSize;
                leftpnl.Cursor = Cursors.Arrow;
                leftpnl2.Cursor = Cursors.Arrow;
                rightpnl.Cursor = Cursors.Arrow;
                rightpnl2.Cursor = Cursors.Arrow;
                bottompnl.Cursor = Cursors.Arrow;
                bottompnl2.Cursor = Cursors.Arrow;
                nwsize.Cursor = Cursors.Arrow;
                swresize.Cursor = Cursors.Arrow;
                toppnl.Cursor = Cursors.Arrow;

                leftpnl.MouseMove -= new MouseEventHandler(leftpnl_MouseMove);
                leftpnl2.MouseMove -= new MouseEventHandler(leftpnl_MouseMove);
                toppnl.MouseMove -= new MouseEventHandler(toppnl_MouseMove);
                bottompnl.MouseMove -= new MouseEventHandler(bottompnl_MouseMove);
                bottompnl2.MouseMove -= new MouseEventHandler(bottompnl_MouseMove);
                rightpnl.MouseMove -= new MouseEventHandler(rightpnl_MouseMove);
                rightpnl2.MouseMove -= new MouseEventHandler(rightpnl_MouseMove);
                swresize.MouseMove -= new MouseEventHandler(swresize_MouseMove);
                nwsize.MouseMove -= new MouseEventHandler(nwsize_MouseMove);
                titleCaption.MouseMove -= new MouseEventHandler(titlebar_MouseMove);
                panelmod1.MouseMove -= new MouseEventHandler(titlebar_MouseMove);

                winMaxed = true;
            }
            else
            {
                //Restores the form and returns the resizing cursors of the edges.
                API.ShowWindow(this.Handle, SW_NORMAL);
                this.Top = originaltop;
                this.Left = originalleft;
                this.Size = originalSize;
                leftpnl.Cursor = Cursors.SizeWE;
                leftpnl2.Cursor = Cursors.SizeWE;
                rightpnl.Cursor = Cursors.SizeWE;
                rightpnl2.Cursor = Cursors.SizeWE;
                bottompnl.Cursor = Cursors.SizeNS;
                bottompnl2.Cursor = Cursors.SizeNS;
                nwsize.Cursor = Cursors.SizeNESW;
                swresize.Cursor = Cursors.SizeNWSE;
                toppnl.Cursor = Cursors.SizeNS;

                leftpnl.MouseMove += new MouseEventHandler(leftpnl_MouseMove);
                leftpnl2.MouseMove += new MouseEventHandler(leftpnl_MouseMove);
                toppnl.MouseMove += new MouseEventHandler(toppnl_MouseMove);
                bottompnl.MouseMove += new MouseEventHandler(bottompnl_MouseMove);
                bottompnl2.MouseMove += new MouseEventHandler(bottompnl_MouseMove);
                rightpnl.MouseMove += new MouseEventHandler(rightpnl_MouseMove);
                rightpnl2.MouseMove += new MouseEventHandler(rightpnl_MouseMove);
                swresize.MouseMove += new MouseEventHandler(swresize_MouseMove);
                nwsize.MouseMove += new MouseEventHandler(nwsize_MouseMove);
                titleCaption.MouseMove += new MouseEventHandler(titlebar_MouseMove);
                panelmod1.MouseMove += new MouseEventHandler(titlebar_MouseMove);

                winMaxed = false;
            }
        }

        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            //Enables the form to be minimized through the taskbar.
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000;
                return cp;
            }
        }

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        /// <summary>
        /// Handles the Layout event of the titleCaption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LayoutEventArgs"/> instance containing the event data.</param>
        private void titleCaption_Layout(object sender, LayoutEventArgs e)
        {
            //recenter the caption
            int formWidth = this.Width;
            int captionWidth = titleCaption.Width;
            if (titleCaption.Left < cmdMaxRes.Right)
            {
                titleCaption.Left = cmdMaxRes.Right + 5;
            }
            else if (titleCaption.Left > cmdMaxRes.Right + 5)
            {
                titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
            }
            if ((formWidth / 2) - (captionWidth / 2) > cmdMaxRes.Right)
            {
                titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the toppnl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void toppnl_MouseMove(object sender, MouseEventArgs e)
        {
            //Resize function (Top)
            if (MouseButtons.ToString() == "Left")
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    resize(rLoc);
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the nwsize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        internal void nwsize_MouseMove(object sender, MouseEventArgs e)
        {
            //Resize function (Left and Bottom side)
            if (MouseButtons.ToString() == "Left")
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    resize(rLoc);
                }
            }
        }


        /// <summary>
        /// Handles the MouseDoubleClick event of the panelmod1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void panelmod1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Maximizes or Restores the window when you double-click the titlebar, similar to a regular window.
            if (this.WindowState == FormWindowState.Maximized)
            {
                cmdMaxRes_Click(cmdMaxRes, null);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                cmdMaxRes_Click(cmdMaxRes, null);
            }
        }

        /// <summary>
        /// Handles the Paint event of the cmdMaxRes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void cmdMaxRes_Paint(object sender, PaintEventArgs e)
        {

        }


    }

    /// <summary>
    /// Class API.
    /// </summary>
    public class API
    {
        //Windows API for resizing the window.
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, long lParam, long wParam);
        /// <summary>
        /// Releases the capture.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// Shows the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="cmdShow">The command show.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
    }

    /// <summary>
    /// Class panelmod.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxItem(false)]
    public class panelmod : Panel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="panelmod"/> class.
        /// </summary>
        public panelmod()
        {
            //sets the DoubleBuffered property of the panel to true.
            this.DoubleBuffered = true;
        }
    }

    /// <summary>
    /// Class ThemeManager.
    /// </summary>
    public class ThemeManager
    {
        //Functions for applying the  form theme.
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeManager"/> class.
        /// </summary>
        public ThemeManager()
        {
            //ThemeManager()
        }
        /// <summary>
        /// Applies the form theme sizable.
        /// </summary>
        /// <param name="clientForm">The client form.</param>
        public void ApplyFormThemeSizable(System.Windows.Forms.Form clientForm)
        {
            //This thread makes the specified form to be a control of the created Mac themed form (Resizable).
            OSXForm frm = new OSXForm();      //Creates a new Mac themed borderless form (generated by the OSXForm class).
            frm.TopMost = clientForm.TopMost;    //Determines if the themed form should be in the TopMost level.
            frm.ShowInTaskbar = clientForm.ShowInTaskbar;  //Determines if the themed form should appear in the taskbar.
            frm.ShowIcon = clientForm.ShowIcon;   //Determines if the themed form should show its icon in the taskbar.

            //Checks if the user wants to disable some sizing buttons...
            if (clientForm.MaximizeBox == false)
            {
                frm.ControlBox = false;
                frm.cmdMaxRes.Visible = false;
                frm.MaximizeBox = false;
            }
            if (clientForm.MinimizeBox == false)
            {
                frm.cmdMaxRes.Left = frm.cmdMin.Left;
                frm.cmdMin.Visible = false;
                frm.MinimizeBox = false;
            }
            //////////////////////////////////////////////////////////

            clientForm.TopLevel = false;               //Sets the TopLevel property of the clientForm to false so that we can add it as a client control on our mac themed form.
            clientForm.FormBorderStyle = FormBorderStyle.None;   //Makes the clientForm borderless.
            frm.Width = clientForm.Width + 8;      //Adjusts the width of the Mac themed form.
            frm.Top = 0;                                     //Sets the default Top location to 0.
            frm.Left = 0;                                     //Sets the default Left location to 0.

            frm.StartPosition = clientForm.StartPosition;  //Sets the themed form's StartPosition same as the clientForm's StartPositon. If {0,0} location is used and it is needed to be applied, just set the clientForm's StartPosition to manual.
            if (clientForm.Top != 0)
            {
                frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
                frm.Top = clientForm.Top;                 //Sets the themed form's Top the same as the clientForm's Top position.
            }
            if (clientForm.Left != 0)
            {
                frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
                frm.Left = clientForm.Left;                  //Sets the themed form's Left the same as the clientForm's Left position.
            }

            frm.Height = clientForm.Height + 28; //Adjusts the height of the Mac themed form.
            clientForm.Top = 0;                           //Sets the clientForm's Top location to 0.
            clientForm.Left = 3;                           //Sets the clientForms' Left location.
            frm.Text = clientForm.Text;                         //Sets the mac themed form's Text property to the specified title (param = formTitle).
            clientForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;    //Anchors the clientForm so it fits the themed form during resizing process.
            frm.titleCaption.Text = clientForm.Text;        //Sets the themed form's titleCaption Text property to the specified title (param = formTitle).
            frm.bodypanel.Controls.Add(clientForm); //Adds the clientForm to the bodypanel's Controls collection.
            frm.Icon = clientForm.Icon;                 //Sets the themed form's Icon property the same as the clientForm's Icon property.

            Size zeroSize = new Size(0, 0);            //The default minimum size of a form (0,0).
            if (clientForm.MinimumSize != zeroSize)   //If the minimum width and height of the clientForm is not on default (0,0)....
            {
                frm.MinimumSize = new Size(clientForm.MinimumSize.Width + 8, clientForm.MinimumSize.Height + 28);  //Sets the minimum size of the themed form.
            }
            if (clientForm.Width < frm.MinimumSize.Width)
            {
                clientForm.Width = frm.MinimumSize.Width;
            }
            if (clientForm.Height < frm.MinimumSize.Height)
            {
                clientForm.Height = frm.MinimumSize.Height;
            }
            clientForm.FormClosed += new FormClosedEventHandler(onThemedForm_Close);  //If the client form is closed, the themed form should also close as well.
            frm.Show();  //Show the generated themed form with the clientForm as it's child control.


        }
        /// <summary>
        /// Applies the form theme dialog.
        /// </summary>
        /// <param name="clientForm">The client form.</param>
        /// <param name="parentForm">The parent form.</param>
        public void ApplyFormThemeDialog(System.Windows.Forms.Form clientForm, System.Windows.Forms.Form parentForm)
        {
            //This thread makes the specified form to be a control of the created Mac themed form (Fixed Single).
            OSXForm frm = new OSXForm();      //Creates a new Mac themed borderless form (generated by this library).
            clientForm.FormBorderStyle = FormBorderStyle.None;   //Makes the clientForm borderless.
            frm.Width = clientForm.Width + 8;      //Adjusts the width of the Mac themed form.
            frm.Height = clientForm.Height + 28; //Adjusts the height of the Mac themed form.
            frm.Owner = parentForm;                   //Sets the owner of the themed form to the specified parentForm.
            frm.StartPosition = clientForm.StartPosition;  //Sets the themed form's StartPosition same as the clientForm's StartPositon. If {0,0} location is used and it is needed to be applied, just set the clientForm's StartPosition to manual.

            if (clientForm.Top != 0)
            {
                frm.StartPosition = FormStartPosition.Manual; //Sets the Form's Startup position to manual.
                frm.Top = clientForm.Top;                 //Sets the themed form's Top the same as the clientForm's Top position.
            }
            if (clientForm.Left != 0)
            {
                frm.StartPosition = FormStartPosition.Manual; //Sets the Form's Startup position to manual.
                frm.Left = clientForm.Left;                  //Sets the themed form's Left the same as the clientForm's Left position.
            }
            clientForm.TopLevel = false;               //Sets the TopLevel property of the clientForm to false so that we can add it as a client control on our mac themed form.

            //Sets the edges' cursor to normal and disable their resizing function;
            frm.leftpnl.Cursor = Cursors.Arrow;
            frm.leftpnl2.Cursor = Cursors.Arrow;
            frm.rightpnl.Cursor = Cursors.Arrow;
            frm.rightpnl2.Cursor = Cursors.Arrow;
            frm.bottompnl2.Cursor = Cursors.Arrow;
            frm.bottompnl.Cursor = Cursors.Arrow;
            frm.toppnl.Cursor = Cursors.Arrow;
            frm.leftpnl.MouseMove -= frm.leftpnl_MouseMove;
            frm.leftpnl2.MouseMove -= frm.leftpnl_MouseMove;
            frm.rightpnl.MouseMove -= frm.rightpnl_MouseMove;
            frm.rightpnl2.MouseMove -= frm.rightpnl_MouseMove;
            frm.bottompnl.MouseMove -= frm.bottompnl_MouseMove;
            frm.bottompnl2.MouseMove -= frm.bottompnl_MouseMove;
            frm.toppnl.MouseMove -= frm.toppnl_MouseMove;
            ///////////////////////////////////////////////////////////

            //Do not show in taskbar and removes the minimize and maximize/restore buttons...
            frm.cmdMaxRes.Visible = false;
            frm.cmdMin.Visible = false;
            frm.ShowInTaskbar = false;
            ///////////////////////////////////////////////////////////////////

            clientForm.Top = 0;                           //Sets the clientForm's Top location to 0.
            clientForm.Left = 3;                           //Sets the clientForms' Left location.
            frm.Text = clientForm.Text;                         //Sets the mac themed form's Text property to the specified title (param = formTitle).
            clientForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;    //Anchors the clientForm so it fits the themed form during resizing process.
            frm.titleCaption.Text = clientForm.Text;        //Sets the themed form's titleCaption Text property to the specified title (param = formTitle).
            frm.bodypanel.Controls.Add(clientForm); //Adds the clientForm to the bodypanel's Controls collection.
            frm.Icon = clientForm.Icon;                 //Sets the themed form's Icon property the same as the clientForm's Icon property.

            Size zeroSize = new Size(0, 0);            //The default minimum size of a form (0,0).
            if (clientForm.MinimumSize != zeroSize)   //If the minimum width and height of the clientForm is not on default (0,0)....
            {
                frm.MinimumSize = new Size(clientForm.MinimumSize.Width + 8, clientForm.MinimumSize.Height + 28); //Sets the minimum size of the themed form.
            }
            if (clientForm.Width < frm.MinimumSize.Width)
            {
                clientForm.Width = frm.MinimumSize.Width;
            }
            if (clientForm.Height < frm.MinimumSize.Height)
            {
                clientForm.Height = frm.MinimumSize.Height;
            }
            clientForm.FormClosed += new FormClosedEventHandler(onThemedForm_Close);  //If the clientForm closes, the themed dialog closes as well.
            frm.Show();  //Show the generated themed form with the clientForm as it's child control.
        }
        /// <summary>
        /// Handles the Close event of the onThemedForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void onThemedForm_Close(object sender, FormClosedEventArgs e)
        {
            //An event handler for closing the themed form to avoid leaving it running.
            try
            {
                //Gets the sender and checks if it is a mac themed form...
                System.Windows.Forms.Form frm = (System.Windows.Forms.Form)sender;
                OSXForm thm = (OSXForm)frm.ParentForm;
                thm.Close();  //closes the themed form.
            }
            catch
            {
                //Error message not displayed.
            }
        }
        /// <summary>
        /// Applies the form theme single sizable.
        /// </summary>
        /// <param name="clientForm">The client form.</param>
        public void ApplyFormThemeSingleSizable(System.Windows.Forms.Form clientForm)
        {
            //This thread makes the specified form to be a control of the created Mac themed form (Resizable, Thin Single Pixel borders, Corner resizing not available).
            OSXForm frm = new OSXForm();      //Creates a new Mac themed borderless form (generated by the OSXForm class).
            frm.TopMost = clientForm.TopMost;    //Determines if the themed form should be in the TopMost level.
            frm.ShowInTaskbar = clientForm.ShowInTaskbar;  //Determines if the themed form should appear in the taskbar.
            frm.ShowIcon = clientForm.ShowIcon;   //Determines if the themed form should show its icon in the taskbar.

            //Checks if the user wants to disable some sizing buttons...
            if (clientForm.MaximizeBox == false)
            {
                frm.ControlBox = false;
                frm.cmdMaxRes.Visible = false;
                frm.MaximizeBox = false;
            }
            if (clientForm.MinimizeBox == false)
            {
                frm.cmdMaxRes.Left = frm.cmdMin.Left;
                frm.cmdMin.Visible = false;
                frm.MinimizeBox = false;
            }
            //////////////////////////////////////////////////////////

            clientForm.TopLevel = false;               //Sets the TopLevel property of the clientForm to false so that we can add it as a client control on our mac themed form.
            clientForm.FormBorderStyle = FormBorderStyle.None;   //Makes the clientForm borderless.
            frm.Width = clientForm.Width + 8;      //Adjusts the width of the Mac themed form.
            frm.Height = clientForm.Height + 28; //Adjusts the height of the Mac themed form.
            frm.leftpnl2.Width = 0;                            //Makes the thick resizable edge disappear.
            frm.rightpnl2.Width = 0;                         //Makes the thick resizable edge disappear.
            frm.bottompnl2.Height = 0;                   //Makes the thick resizalbe edge disappear.
            frm.bodypanel.Left = 1;                     //Sets the themed form's form container (bodypanel) near the gray edge.
            frm.Top = 0;                                     //Sets the default Top location to 0.
            frm.Left = 0;                                     //Sets the default Left location to 0.

            frm.StartPosition = clientForm.StartPosition;  //Sets the themed form's StartPosition same as the clientForm's StartPositon. If {0,0} location is used and it is needed to be applied, just set the clientForm's StartPosition to manual.
            if (clientForm.Top != 0)
            {
                frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
                frm.Top = clientForm.Top;                 //Sets the themed form's Top the same as the clientForm's Top position.
            }
            if (clientForm.Left != 0)
            {
                frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
                frm.Left = clientForm.Left;                  //Sets the themed form's Left the same as the clientForm's Left position.
            }


            clientForm.Top = 0;                           //Sets the clientForm's Top location to 0.
            clientForm.Left = 0;                           //Sets the clientForms' Left location.
            clientForm.Width += 6;                     //Adds width to the clientForm to reach the Right edge.
            clientForm.Height += 5;                     //Adds height to the clientform to reach the Bottom edge.
            frm.bodypanel.Height += 2;              //Adds height to the clientForm container to reach the Bottom edge.
            frm.Text = clientForm.Text;                         //Sets the mac themed form's Text property to the specified title (param = formTitle).
            clientForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;    //Anchors the clientForm so it fits the themed form during resizing process.
            frm.titleCaption.Text = clientForm.Text;        //Sets the themed form's titleCaption Text property to the specified title (param = formTitle).
            frm.bodypanel.Controls.Add(clientForm); //Adds the clientForm to the bodypanel's Controls collection.
            frm.Icon = clientForm.Icon;                 //Sets the themed form's Icon property the same as the clientForm's Icon property.

            Size zeroSize = new Size(0, 0);            //The default minimum size of a form (0,0).
            if (clientForm.MinimumSize != zeroSize)   //If the minimum width and height of the clientForm is not on default (0,0)....
            {
                frm.MinimumSize = new Size(clientForm.MinimumSize.Width + 8, clientForm.MinimumSize.Height + 28);  //Sets the minimum size of the themed form.
            }
            if (clientForm.Width < frm.MinimumSize.Width)
            {
                clientForm.Width = frm.MinimumSize.Width;
            }
            if (clientForm.Height < frm.MinimumSize.Height)
            {
                clientForm.Height = frm.MinimumSize.Height;
            }
            clientForm.FormClosed += new FormClosedEventHandler(onThemedForm_Close);  //If the client form is closed, the themed form should also close as well.
            frm.Show();  //Show the generated themed form with the clientForm as it's child control.

        }
    }


}
