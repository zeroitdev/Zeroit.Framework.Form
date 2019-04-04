// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-24-2018
// ***********************************************************************
// <copyright file="ModernTileReborn.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Form.ModernForm.Objects;
using Zeroit.Framework.Form.ModernForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Controls
{
    /// <summary>
    /// TilePanel Reborn.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    public class ZeroitTilePanel : Control
    {
        #region Fields

        /// <summary>
        /// The branded tile
        /// </summary>
        private bool brandedTile;

        /// <summary>
        /// The can be hovered
        /// </summary>
        private bool canBeHovered;

        /// <summary>
        /// The checkable
        /// </summary>
        private bool checkable;

        /// <summary>
        /// The has drawn
        /// </summary>
        private bool hasDrawn;

        /// <summary>
        /// The image
        /// </summary>
        private Image image;

        /// <summary>
        /// The is hovered
        /// </summary>
        private bool isHovered;

        /// <summary>
        /// The light back color
        /// </summary>
        private Color lightBackColor;

        /// <summary>
        /// The lightlight back color
        /// </summary>
        private Color lightlightBackColor;

        /// <summary>
        /// The texts
        /// </summary>
        private List<TileText> texts = new List<TileText>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTilePanel"/> class.
        /// </summary>
        public ZeroitTilePanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor {
            get {
                return base.BackColor;
            }
            set {
                base.BackColor = value;
                lightBackColor = ControlPaint.Light(value);
                lightlightBackColor = ControlPaint.LightLight(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [branded tile].
        /// </summary>
        /// <value><c>true</c> if [branded tile]; otherwise, <c>false</c>.</value>
        public bool BrandedTile {
            get {
                return brandedTile;
            }
            set {
                brandedTile = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can be hovered.
        /// </summary>
        /// <value><c>true</c> if this instance can be hovered; otherwise, <c>false</c>.</value>
        public bool CanBeHovered {
            get {
                return canBeHovered;
            }
            set {
                canBeHovered = value;
                //UpdateParentHoverEvent(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitTilePanel"/> is checkable.
        /// </summary>
        /// <value><c>true</c> if checkable; otherwise, <c>false</c>.</value>
        public bool Checkable {
            get { return checkable; }
            set {
                checkable = value;
                UpdateSurface();
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitTilePanel"/> is flat.
        /// </summary>
        /// <value><c>true</c> if flat; otherwise, <c>false</c>.</value>
        public bool Flat { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image {
            get {
                return image;
            }
            set {
                image = value;
                UpdateSurface();
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(true)]
        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the texts.
        /// </summary>
        /// <value>The texts.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TileText> Texts {
            get {
                return texts;
            }
            set {
                texts = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the image rect.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public Rectangle GetImageRect()
        {
            if (brandedTile)
                return DisplayRectangle;

            return new Rectangle(0, 0, GetPercentage(Width, 50), GetPercentage(Height, 50));
        }

        /// <summary>
        /// Gets the outer rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public Rectangle GetOuterRectangle()
        {
            var rectangle = Bounds;
            rectangle.Inflate(3, 3);
            return rectangle;
        }

        /// <summary>
        /// Gets the percentage.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>System.Int32.</returns>
        public int GetPercentage(int size, int percent)
        {
            return size * percent / 100;
        }

        /// <summary>
        /// Gets the text rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public Rectangle GetTextRectangle()
        {
            var rectangle = Rectangle.FromLTRB(8, Height - 32, Width - 8, Height - 8);
            return rectangle;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            if (CanBeHovered) {
                Parent.Invalidate(GetOuterRectangle());
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            if (CanBeHovered) {
                Parent.Invalidate(GetOuterRectangle());
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!hasDrawn) {
                hasDrawn = true;
                OnLoad();
            }
            //Draw the outer Rectangle
            using (var solidBrush = new SolidBrush(lightlightBackColor)) {
                e.Graphics.FillRectangle(solidBrush, DisplayRectangle);
            }

            //Draw the inside color
            Rectangle displayRectangle = DisplayRectangle;
            displayRectangle.Inflate(-1, -1);
            using (var solidBrush = new SolidBrush(BackColor)) {
                e.Graphics.FillRectangle(solidBrush, DisplayRectangle);
            }
            if (!Flat) {
                //Draw gradient
                using (LinearGradientBrush brush = new LinearGradientBrush(displayRectangle, Color.FromArgb(75, 0, 0, 0), Color.FromArgb(7, 0, 0, 0), LinearGradientMode.Horizontal)) {
                    e.Graphics.FillRectangle(brush, displayRectangle);
                }
            }
            else {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(35, Color.Black))) {
                    e.Graphics.FillRectangle(sb, displayRectangle);
                }
            }

            if (Image != null) {
                Rectangle imgRect = GetImageRect();
                //Draw Image
                if (!brandedTile) {
                    ControlPaintWrapper.ZoomDrawImage(e.Graphics, Image, imgRect.Center(Rectangle.FromLTRB(displayRectangle.Left, displayRectangle.Top, displayRectangle.Right, ((string.Empty.Equals(Text.Trim()) ? displayRectangle.Bottom : GetTextRectangle().Top)))));
                }
                else {
                    e.Graphics.DrawImage(image, imgRect);
                }
            }
            if (!brandedTile) {
                using (var sb = new SolidBrush(ForeColor)) {
                    using (var tF = ControlPaintWrapper.CreateStringFormat(this, ContentAlignment.BottomLeft, false)) {
                        tF.FormatFlags = tF.FormatFlags | StringFormatFlags.NoWrap;
                        e.Graphics.DrawString(Text, Font, sb, GetTextRectangle(), tF);
                        foreach (var t in texts) {
                            if (t != null) {
                                e.Graphics.DrawString(t.Text, t.Font, sb, t.Location.X, t.Location.Y);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:PaintOuterRectParent" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="pevent">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected void OnPaintOuterRectParent(object sender, PaintEventArgs pevent)
        {
            if (isHovered && CanBeHovered) {
                using (var br = new SolidBrush(lightBackColor)) {
                    pevent.Graphics.FillRectangle(br, GetOuterRectangle());
                }
            }
        }

        /// <summary>
        /// Updates the surface.
        /// </summary>
        protected void UpdateSurface()
        {
            Refresh();
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        private void OnLoad()
        {
            if (Parent != null) {
                Parent.Paint += OnPaintOuterRectParent;
            }
        }

        #endregion
    }
}