// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-24-2018
// ***********************************************************************
// <copyright file="ZeroitFormChrome.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Form
{
    #region ZeroitChromeForm

    /// <summary>
    /// A class collection for rendering a chrome form.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Form.ThemeContainer154" />
    public class ZeroitChromeForm : ThemeContainer154
    {
        #region Variables
        /// <summary>
        /// The title color
        /// </summary>
        Color TitleColor;
        /// <summary>
        /// The xcolor
        /// </summary>
        Color Xcolor;
        /// <summary>
        /// The xellipse
        /// </summary>
        Color Xellipse;
        /// <summary>
        /// The color background1
        /// </summary>
        Color _ColorBackground1 = Color.WhiteSmoke;
        /// <summary>
        /// The color background2
        /// </summary>
        Color _ColorBackground2 = Color.LightGray;
        /// <summary>
        /// The color angle
        /// </summary>
        float _ColorAngle = 90f;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the color background.
        /// </summary>
        /// <value>The color background1.</value>
        public Color ColorBackground1
        {
            get { return this._ColorBackground1; }
            set
            {
                this._ColorBackground1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color background.
        /// </summary>
        /// <value>The color background2.</value>
        public Color ColorBackground2
        {
            get { return this._ColorBackground2; }
            set
            {
                this._ColorBackground2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color angle.
        /// </summary>
        /// <value>The color angle.</value>
        private float ColorAngle
        {
            get { return this._ColorAngle; }
            set
            {
                this._ColorAngle = value;
                this.Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitChromeForm" /> class.
        /// </summary>
        public ZeroitChromeForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            TransparencyKey = Color.Fuchsia;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9);
            SetColor("Title color", Color.Black);
            SetColor("X-color", BackColor);
            SetColor("X-ellipse", Color.Red);
        }

        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            TitleColor = GetColor("Title color");
            Xcolor = GetColor("X-color");
            Xellipse = GetColor("X-ellipse");
        }

        /// <summary>
        /// The x
        /// </summary>
        int X;

        /// <summary>
        /// The y
        /// </summary>
        int Y;
        /// <summary>
        /// Handles the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            X = e.Location.X;
            Y = e.Location.Y;
            base.OnMouseMove(e);
            Invalidate();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnClick(e);
            Rectangle r = new Rectangle(Width - 22, 5, 15, 15);
            if (r.Contains(new Point(e.X, e.Y)) || r.Contains(new Point(X, Y)) && e.Button == MouseButtons.Left)
                FindForm().Close();
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            G.Clear(BackColor);
            DrawCorners(Color.Fuchsia);
            DrawCorners(Color.Fuchsia, 1, 0, Width - 2, Height);
            DrawCorners(Color.Fuchsia, 0, 1, Width, Height - 2);
            DrawCorners(Color.Fuchsia, 2, 0, Width - 4, Height);
            DrawCorners(Color.Fuchsia, 0, 2, Width, Height - 4);

            Rectangle EllipseRectangle = new Rectangle(Width - 24, 6, 16, 16);

            LinearGradientBrush BodyBrush = new LinearGradientBrush(EllipseRectangle, _ColorBackground1, _ColorBackground2, _ColorAngle);

            G.SmoothingMode = SmoothingMode.HighQuality;
            if (new Rectangle(Width - 22, 5, 15, 15).Contains(new Point(X, Y)))
            {
                G.FillEllipse(BodyBrush, EllipseRectangle);
                G.DrawString("r", new Font("Webdings", 8), new SolidBrush(BackColor), new Point(Width - 23, 5));
            }
            else
            {
                G.DrawString("r", new Font("Webdings", 8), new SolidBrush(Xcolor), new Point(Width - 23, 5));
            }

            DrawText(new SolidBrush(TitleColor), new Point(8, 7));
        }
    }

    #endregion
}
