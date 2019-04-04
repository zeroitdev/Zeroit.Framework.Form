// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="CustomForm.Designer.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Form
{
    //partial class CustomForm
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
        
    //    internal Panel nwsize;
    //    internal Panel swresize;
    //    internal Panel bottompnl;
    //    private ToolTip controlboxToolTip;
    //    private System.ComponentModel.IContainer components;
    //    private Point loc;
    //    private int pright;
    //    public panelmod cmdMaxRes;
    //    internal Panel toppnl;
    //    public Label titleCaption;
    //    internal Panel leftpnl;
    //    public panelmod bodypanel;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.components = new System.ComponentModel.Container();
    //        this.rightpnl = new System.Windows.Forms.Panel();
    //        this.bottompnl = new System.Windows.Forms.Panel();
    //        this.nwsize = new System.Windows.Forms.Panel();
    //        this.swresize = new System.Windows.Forms.Panel();
    //        this.controlboxToolTip = new System.Windows.Forms.ToolTip(this.components);
    //        this.cmdMaxRes = new Zeroit.Framework.Form.panelmod();
    //        this.cmdMin = new Zeroit.Framework.Form.panelmod();
    //        this.cmdClose = new Zeroit.Framework.Form.panelmod();
    //        this.leftpnl = new System.Windows.Forms.Panel();
    //        this.bodypanel = new Zeroit.Framework.Form.panelmod();
    //        this.bottompnl2 = new System.Windows.Forms.Panel();
    //        this.rightpnl2 = new System.Windows.Forms.Panel();
    //        this.leftpnl2 = new System.Windows.Forms.Panel();
    //        this.panelmod1 = new Zeroit.Framework.Form.panelmod();
    //        this.panel1 = new System.Windows.Forms.Panel();
    //        this.titleCaption = new System.Windows.Forms.Label();
    //        this.controlToolBoxItems = new System.Windows.Forms.Panel();
    //        this.toppnl = new System.Windows.Forms.Panel();
    //        this.bodypanel.SuspendLayout();
    //        this.panelmod1.SuspendLayout();
    //        this.panel1.SuspendLayout();
    //        this.controlToolBoxItems.SuspendLayout();
    //        this.SuspendLayout();
    //        // 
    //        // rightpnl
    //        // 
    //        this.rightpnl.Cursor = System.Windows.Forms.Cursors.SizeWE;
    //        this.rightpnl.Dock = System.Windows.Forms.DockStyle.Right;
    //        this.rightpnl.Location = new System.Drawing.Point(876, 35);
    //        this.rightpnl.Name = "rightpnl";
    //        this.rightpnl.Size = new System.Drawing.Size(1, 549);
    //        this.rightpnl.TabIndex = 1;
    //        this.rightpnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.rightpnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightpnl_MouseMove);
    //        this.rightpnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // bottompnl
    //        // 
    //        this.bottompnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
    //        this.bottompnl.Cursor = System.Windows.Forms.Cursors.SizeNS;
    //        this.bottompnl.Dock = System.Windows.Forms.DockStyle.Bottom;
    //        this.bottompnl.Location = new System.Drawing.Point(0, 584);
    //        this.bottompnl.Name = "bottompnl";
    //        this.bottompnl.Size = new System.Drawing.Size(877, 1);
    //        this.bottompnl.TabIndex = 2;
    //        this.bottompnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.bottompnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bottompnl_MouseMove);
    //        this.bottompnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // nwsize
    //        // 
    //        this.nwsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
    //        this.nwsize.Cursor = System.Windows.Forms.Cursors.SizeNESW;
    //        this.nwsize.Location = new System.Drawing.Point(1, 582);
    //        this.nwsize.Name = "nwsize";
    //        this.nwsize.Size = new System.Drawing.Size(2, 2);
    //        this.nwsize.TabIndex = 3;
    //        this.nwsize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.nwsize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nwsize_MouseMove);
    //        this.nwsize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // swresize
    //        // 
    //        this.swresize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
    //        this.swresize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
    //        this.swresize.Location = new System.Drawing.Point(874, 582);
    //        this.swresize.Name = "swresize";
    //        this.swresize.Size = new System.Drawing.Size(2, 2);
    //        this.swresize.TabIndex = 4;
    //        this.swresize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.swresize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.swresize_MouseMove);
    //        this.swresize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // cmdMaxRes
    //        // 
    //        this.cmdMaxRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
    //        this.cmdMaxRes.BackColor = System.Drawing.Color.Transparent;
    //        this.cmdMaxRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.cmdMaxRes.Location = new System.Drawing.Point(52, 3);
    //        this.cmdMaxRes.Name = "cmdMaxRes";
    //        this.cmdMaxRes.Size = new System.Drawing.Size(16, 16);
    //        this.cmdMaxRes.TabIndex = 10;
    //        this.controlboxToolTip.SetToolTip(this.cmdMaxRes, "Maximize/Restore");
    //        this.cmdMaxRes.Click += new System.EventHandler(this.cmdMaxRes_Click);
    //        this.cmdMaxRes.Paint += new System.Windows.Forms.PaintEventHandler(this.cmdMaxRes_Paint);
    //        this.cmdMaxRes.MouseLeave += new System.EventHandler(this.cmdMaxRes_MouseLeave);
    //        this.cmdMaxRes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdMaxRes_MouseMove);
    //        // 
    //        // cmdMin
    //        // 
    //        this.cmdMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
    //        this.cmdMin.BackColor = System.Drawing.Color.Transparent;
    //        this.cmdMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.cmdMin.Location = new System.Drawing.Point(29, 3);
    //        this.cmdMin.Name = "cmdMin";
    //        this.cmdMin.Size = new System.Drawing.Size(16, 16);
    //        this.cmdMin.TabIndex = 11;
    //        this.controlboxToolTip.SetToolTip(this.cmdMin, "Minimize");
    //        this.cmdMin.Click += new System.EventHandler(this.cmdMin_Click);
    //        this.cmdMin.Paint += new System.Windows.Forms.PaintEventHandler(this.cmdMaxRes_Paint);
    //        this.cmdMin.MouseLeave += new System.EventHandler(this.cmdMin_MouseLeave);
    //        this.cmdMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdMin_MouseMove);
    //        // 
    //        // cmdClose
    //        // 
    //        this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
    //        this.cmdClose.BackColor = System.Drawing.Color.Transparent;
    //        this.cmdClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.cmdClose.Location = new System.Drawing.Point(6, 3);
    //        this.cmdClose.Name = "cmdClose";
    //        this.cmdClose.Size = new System.Drawing.Size(16, 16);
    //        this.cmdClose.TabIndex = 12;
    //        this.controlboxToolTip.SetToolTip(this.cmdClose, "Close");
    //        this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
    //        this.cmdClose.Paint += new System.Windows.Forms.PaintEventHandler(this.cmdMaxRes_Paint);
    //        this.cmdClose.MouseLeave += new System.EventHandler(this.cmdClose_MouseLeave);
    //        this.cmdClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmdClose_MouseMove);
    //        // 
    //        // leftpnl
    //        // 
    //        this.leftpnl.Cursor = System.Windows.Forms.Cursors.SizeWE;
    //        this.leftpnl.Dock = System.Windows.Forms.DockStyle.Left;
    //        this.leftpnl.Location = new System.Drawing.Point(0, 35);
    //        this.leftpnl.Name = "leftpnl";
    //        this.leftpnl.Size = new System.Drawing.Size(1, 549);
    //        this.leftpnl.TabIndex = 0;
    //        this.leftpnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.leftpnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftpnl_MouseMove);
    //        this.leftpnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // bodypanel
    //        // 
    //        this.bodypanel.BackColor = System.Drawing.SystemColors.Control;
    //        this.bodypanel.Controls.Add(this.panel1);
    //        this.bodypanel.Controls.Add(this.bottompnl2);
    //        this.bodypanel.Controls.Add(this.rightpnl2);
    //        this.bodypanel.Controls.Add(this.leftpnl2);
    //        this.bodypanel.Dock = System.Windows.Forms.DockStyle.Fill;
    //        this.bodypanel.Location = new System.Drawing.Point(1, 35);
    //        this.bodypanel.Name = "bodypanel";
    //        this.bodypanel.Size = new System.Drawing.Size(875, 549);
    //        this.bodypanel.TabIndex = 6;
    //        // 
    //        // bottompnl2
    //        // 
    //        this.bottompnl2.BackColor = System.Drawing.Color.Transparent;
    //        this.bottompnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
    //        this.bottompnl2.Cursor = System.Windows.Forms.Cursors.SizeNS;
    //        this.bottompnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
    //        this.bottompnl2.Location = new System.Drawing.Point(2, 546);
    //        this.bottompnl2.Name = "bottompnl2";
    //        this.bottompnl2.Size = new System.Drawing.Size(870, 3);
    //        this.bottompnl2.TabIndex = 11;
    //        this.bottompnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.bottompnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bottompnl_MouseMove);
    //        this.bottompnl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // rightpnl2
    //        // 
    //        this.rightpnl2.BackColor = System.Drawing.Color.Transparent;
    //        this.rightpnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
    //        this.rightpnl2.Cursor = System.Windows.Forms.Cursors.SizeWE;
    //        this.rightpnl2.Dock = System.Windows.Forms.DockStyle.Right;
    //        this.rightpnl2.Location = new System.Drawing.Point(872, 0);
    //        this.rightpnl2.Name = "rightpnl2";
    //        this.rightpnl2.Size = new System.Drawing.Size(3, 549);
    //        this.rightpnl2.TabIndex = 10;
    //        this.rightpnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.rightpnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightpnl_MouseMove);
    //        this.rightpnl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // leftpnl2
    //        // 
    //        this.leftpnl2.BackColor = System.Drawing.Color.Transparent;
    //        this.leftpnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
    //        this.leftpnl2.Cursor = System.Windows.Forms.Cursors.SizeWE;
    //        this.leftpnl2.Dock = System.Windows.Forms.DockStyle.Left;
    //        this.leftpnl2.Location = new System.Drawing.Point(0, 0);
    //        this.leftpnl2.Name = "leftpnl2";
    //        this.leftpnl2.Size = new System.Drawing.Size(2, 549);
    //        this.leftpnl2.TabIndex = 9;
    //        this.leftpnl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.leftpnl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftpnl_MouseMove);
    //        this.leftpnl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // panelmod1
    //        // 
    //        this.panelmod1.BackColor = System.Drawing.SystemColors.Control;
    //        this.panelmod1.Controls.Add(this.controlToolBoxItems);
    //        this.panelmod1.Controls.Add(this.toppnl);
    //        this.panelmod1.Dock = System.Windows.Forms.DockStyle.Top;
    //        this.panelmod1.Location = new System.Drawing.Point(0, 0);
    //        this.panelmod1.Name = "panelmod1";
    //        this.panelmod1.Size = new System.Drawing.Size(877, 35);
    //        this.panelmod1.TabIndex = 5;
    //        this.panelmod1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelmod1_MouseDoubleClick);
    //        this.panelmod1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.panelmod1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
    //        this.panelmod1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // panel1
    //        // 
    //        this.panel1.Controls.Add(this.titleCaption);
    //        this.panel1.Location = new System.Drawing.Point(21, 65);
    //        this.panel1.Name = "panel1";
    //        this.panel1.Size = new System.Drawing.Size(806, 32);
    //        this.panel1.TabIndex = 14;
    //        this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelmod1_MouseDoubleClick);
    //        this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
    //        this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // titleCaption
    //        // 
    //        this.titleCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
    //        | System.Windows.Forms.AnchorStyles.Right)));
    //        this.titleCaption.AutoSize = true;
    //        this.titleCaption.BackColor = System.Drawing.Color.Transparent;
    //        this.titleCaption.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.titleCaption.Location = new System.Drawing.Point(373, 7);
    //        this.titleCaption.Name = "titleCaption";
    //        this.titleCaption.Size = new System.Drawing.Size(70, 14);
    //        this.titleCaption.TabIndex = 13;
    //        this.titleCaption.Text = "Custom Form";
    //        this.titleCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    //        this.titleCaption.Layout += new System.Windows.Forms.LayoutEventHandler(this.titleCaption_Layout);
    //        this.titleCaption.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelmod1_MouseDoubleClick);
    //        this.titleCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.titleCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
    //        this.titleCaption.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // controlToolBoxItems
    //        // 
    //        this.controlToolBoxItems.Controls.Add(this.cmdMaxRes);
    //        this.controlToolBoxItems.Controls.Add(this.cmdClose);
    //        this.controlToolBoxItems.Controls.Add(this.cmdMin);
    //        this.controlToolBoxItems.Dock = System.Windows.Forms.DockStyle.Right;
    //        this.controlToolBoxItems.Location = new System.Drawing.Point(806, 3);
    //        this.controlToolBoxItems.Name = "controlToolBoxItems";
    //        this.controlToolBoxItems.Size = new System.Drawing.Size(71, 32);
    //        this.controlToolBoxItems.TabIndex = 12;
    //        this.controlToolBoxItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelmod1_MouseDoubleClick);
    //        this.controlToolBoxItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.controlToolBoxItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nwsize_MouseMove);
    //        this.controlToolBoxItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // toppnl
    //        // 
    //        this.toppnl.BackColor = System.Drawing.Color.Transparent;
    //        this.toppnl.Cursor = System.Windows.Forms.Cursors.SizeNS;
    //        this.toppnl.Dock = System.Windows.Forms.DockStyle.Top;
    //        this.toppnl.Location = new System.Drawing.Point(0, 0);
    //        this.toppnl.Name = "toppnl";
    //        this.toppnl.Size = new System.Drawing.Size(877, 3);
    //        this.toppnl.TabIndex = 9;
    //        this.toppnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
    //        this.toppnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toppnl_MouseMove);
    //        this.toppnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferedPanel1_MouseUp);
    //        // 
    //        // CustomForm
    //        // 
    //        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
    //        this.ClientSize = new System.Drawing.Size(877, 585);
    //        this.Controls.Add(this.bodypanel);
    //        this.Controls.Add(this.leftpnl);
    //        this.Controls.Add(this.rightpnl);
    //        this.Controls.Add(this.panelmod1);
    //        this.Controls.Add(this.swresize);
    //        this.Controls.Add(this.nwsize);
    //        this.Controls.Add(this.bottompnl);
    //        this.DoubleBuffered = true;
    //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    //        this.MinimumSize = new System.Drawing.Size(250, 25);
    //        this.Name = "CustomForm";
    //        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    //        this.Text = "CustomForm";
    //        this.Activated += new System.EventHandler(this.mactheme_Activated);
    //        this.Deactivate += new System.EventHandler(this.mactheme_Deactivate);
    //        this.Load += new System.EventHandler(this.CustomForm_Load);
    //        this.Resize += new System.EventHandler(this.mactheme_Resize);
    //        this.bodypanel.ResumeLayout(false);
    //        this.panelmod1.ResumeLayout(false);
    //        this.panel1.ResumeLayout(false);
    //        this.panel1.PerformLayout();
    //        this.controlToolBoxItems.ResumeLayout(false);
    //        this.ResumeLayout(false);

    //    }

    //    #endregion
    //    public panelmod cmdMin;
    //    public panelmod cmdClose;
    //    public Panel panel1;
    //    public Panel controlToolBoxItems;
    //    public panelmod panelmod1;
    //    public Panel bottompnl2;
    //    public Panel rightpnl2;
    //    public Panel leftpnl2;
    //    public Panel rightpnl;
    //}
}