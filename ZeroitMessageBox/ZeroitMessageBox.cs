// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-14-2018
// ***********************************************************************
// <copyright file="ZeroitMessageBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace Zeroit.Framework.Form
{
    #region Custom MessageBox

    #region Control

    /// <summary>
    /// A class collection for rendering a custom message box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ZeroitMessageBox : System.Windows.Forms.Form
    {

        /// <summary>
        /// The new message box
        /// </summary>
        static ZeroitMessageBox newMessageBox;
        /// <summary>
        /// The MSG timer
        /// </summary>
        public System.Windows.Forms.Timer msgTimer;
        /// <summary>
        /// The button identifier
        /// </summary>
        static string Button_id;
        /// <summary>
        /// The dispose form timer
        /// </summary>
        int disposeFormTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMessageBox" /> class.
        /// </summary>
        public ZeroitMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the box.
        /// </summary>
        /// <param name="txtMessage">The text message.</param>
        /// <returns>System.String.</returns>
        public string ShowBox(string txtMessage)
        {
            newMessageBox = new ZeroitMessageBox();
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        /// <summary>
        /// Shows the box.
        /// </summary>
        /// <param name="txtMessage">The text message.</param>
        /// <param name="txtTitle">The text title.</param>
        /// <returns>System.String.</returns>
        public string ShowBox(string txtMessage, string txtTitle)
        {
            newMessageBox = new ZeroitMessageBox();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        /// <summary>
        /// Handles the Load event of the MyMessageBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            disposeFormTimer = 30;
            newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            msgTimer = new System.Windows.Forms.Timer();
            msgTimer.Interval = 1000;
            msgTimer.Enabled = true;
            msgTimer.Start();
            msgTimer.Tick += new System.EventHandler(this.timer_tick);
        }

        /// <summary>
        /// Handles the Paint event of the MyMessageBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "1";
            newMessageBox.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();
            Button_id = "2";
            newMessageBox.Dispose();
        }

        /// <summary>
        /// Handles the tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            }
            else
            {
                newMessageBox.msgTimer.Stop();
                newMessageBox.msgTimer.Dispose();
                newMessageBox.Dispose();
            }
        }
    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(314, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(9, 120);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 16);
            this.lblTimer.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(234, 105);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 58);
            this.panel1.TabIndex = 6;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(376, 58);
            this.lblMessage.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Properties.Resources.title_bar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 25);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 8;
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(400, 142);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyMessageBox";
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMessageBox";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyMessageBox_Paint);
            this.Load += new System.EventHandler(this.MyMessageBox_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The label timer
        /// </summary>
        private System.Windows.Forms.Label lblTimer;
        /// <summary>
        /// The BTN ok
        /// </summary>
        private System.Windows.Forms.Button btnOK;
        /// <summary>
        /// The panel1
        /// </summary>
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// The label message
        /// </summary>
        private System.Windows.Forms.Label lblMessage;
        /// <summary>
        /// The picture box1
        /// </summary>
        private System.Windows.Forms.PictureBox pictureBox1;
        /// <summary>
        /// The label title
        /// </summary>
        private System.Windows.Forms.Label lblTitle;
    }

    #endregion

    #endregion
}
