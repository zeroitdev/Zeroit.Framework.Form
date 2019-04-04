// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="MetroFormGlow.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.Metro
{
    /// <summary>
    /// Class MetroFormGlow.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class MetroFormGlow : System.Windows.Forms.Form
    {
        /// <summary>
        /// The glowsize
        /// </summary>
        const int glowsize = 10;
        /// <summary>
        /// The parent form
        /// </summary>
        new MetroForm ParentForm;
        /// <summary>
        /// Initializes a new instance of the <see cref="MetroFormGlow"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public MetroFormGlow(MetroForm parent)
        {
            ParentForm = parent;
            this.FormBorderStyle = FormBorderStyle.None;

            //Click through gosh darn it
            //int initialStyle = WinAPI.GetWindowLong(this.Handle, WinAPI.GWL_EXSTYLE);
            //WinAPI.SetWindowLong(this.Handle, WinAPI.GWL_EXSTYLE, initialStyle | WinAPI.WS_EX_LAYERED | WinAPI.WS_EX_TRANSPARENT);
            ShowInTaskbar = false;

            Render();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            ParentForm.BringToFront();
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Updates the position.
        /// </summary>
        public void UpdatePosition() { this.Location = new Point(ParentForm.Location.X - glowsize, ParentForm.Location.Y - glowsize); }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        public void Render()
        {
            UpdatePosition();

            Bitmap bitmap = new Bitmap(ParentForm.Width + glowsize * 2, ParentForm.Height + glowsize * 2);
            using (Graphics g = Graphics.FromImage(bitmap))
            {//new Rectangle(glowsize, glowsize, ParentForm.Width - glowsize * 2, ParentForm.Height - glowsize * 2)
                g.FillRectangle(new SolidBrush(Color.FromArgb(0x55, ParentForm.ColorSchema.cPrimary)), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }

            IntPtr screenDc = WinAPI.GetDC(IntPtr.Zero);
            IntPtr memDc = WinAPI.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = WinAPI.SelectObject(memDc, hBitmap);

                Size size = new Size(bitmap.Width, bitmap.Height);
                Point pointSource = new Point(0, 0);
                Point topPos = new Point(Left, Top);
                WinAPI.BLENDFUNCTION blend = new WinAPI.BLENDFUNCTION();
                blend.BlendOp = WinAPI.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = 0xFF;
                blend.AlphaFormat = WinAPI.AC_SRC_ALPHA;

                WinAPI.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, WinAPI.ULW_ALPHA);
            }
            finally
            {
                WinAPI.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    WinAPI.SelectObject(memDc, oldBitmap);
                    WinAPI.DeleteObject(hBitmap);
                }
                WinAPI.DeleteDC(memDc);
            }
        }

        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WinAPI.WS_EX_LAYERED | WinAPI.WS_EX_TRANSPARENT;
                return cp;
            }
        }
    }
}
