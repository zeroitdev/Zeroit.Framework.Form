// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="SidebarControl.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.Form.ModernForm.Objects;
using static Zeroit.Framework.Form.ModernForm.Utils.Animation;
using static Zeroit.Framework.Form.ModernForm.Utils.ShadowUtils;

namespace Zeroit.Framework.Form.ModernForm.Controls
{
    /// <summary>
    /// The sidebar control (use with ZeroitAppBar)
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    /// <seealso cref="Zeroit.Framework.Form.ModernForm.Utils.ShadowUtils.IShadowController" />
    [ToolboxItem(false)]
    public class ZeroitSideBar : ContainerControl, IShadowController
    {
        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorScheme _colorScheme = DefaultColorSchemes.Blue;

        /// <summary>
        /// The is animating
        /// </summary>
        private bool _isAnimating;
        /// <summary>
        /// The was painted
        /// </summary>
        private bool _wasPainted;
        /// <summary>
        /// The top bar size
        /// </summary>
        private int topBarSize = 100;
        /// <summary>
        /// The top bar spacing
        /// </summary>
        private int topBarSpacing = 32;





        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSideBar"/> class.
        /// </summary>
        public ZeroitSideBar()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            Dock = DockStyle.Left;
            
        }

        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        public ColorScheme ColorScheme
        {
            get => Parent is Zeroit.Framework.Form.ModernForm.Forms.ModernForm ? ((Zeroit.Framework.Form.ModernForm.Forms.ModernForm) Parent).ColorScheme : _colorScheme;
            set => _colorScheme = value;
        }

        /// <summary>
        /// Gets or sets the width of the original.
        /// </summary>
        /// <value>The width of the original.</value>
        private int OriginalWidth { get; set; } = -1;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value><c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
        public bool IsClosed { get; set; }
        /// <summary>
        /// Gets or sets the size of the top bar.
        /// </summary>
        /// <value>The size of the top bar.</value>
        public int TopBarSize
        {
            get { return topBarSize; }
            set
            {
                topBarSize = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the color of the top bar.
        /// </summary>
        /// <value>The color of the top bar.</value>
        public Color TopBarColor { get; set; } = Color.FromArgb(189, 189, 189);
        /// <summary>
        /// Gets or sets the top bar spacing.
        /// </summary>
        /// <value>The top bar spacing.</value>
        public int TopBarSpacing
        {
            get { return topBarSpacing; }
            set
            {
                topBarSpacing = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<SideBarItem> Items { get; set; } = new List<SideBarItem>();

        /// <summary>
        /// Shoulds the show shadow.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldShowShadow()
        {
            return !(_isAnimating || IsClosed);
        }


        /// <summary>
        /// Called to signal to subscribers that
        /// </summary>
        public event EventHandler AnimationStart;
        /// <summary>
        /// Handles the <see cref="E:AnimationStart" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnAnimationStart(EventArgs e)
        {
            EventHandler eh = AnimationStart;

            eh?.Invoke(this, e);
        }

        /// <summary>
        /// Called to signal to subscribers that Description
        /// </summary>
        public event EventHandler AnimationStop;
        /// <summary>
        /// Handles the <see cref="E:AnimationStop" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnAnimationStop(EventArgs e)
        {
            EventHandler eh = AnimationStop;

            eh?.Invoke(this, e);
        }


        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            if (TopBarSize <= 0) return;
            using (var sB = new SolidBrush(TopBarColor))
            {
                pevent.Graphics.FillRectangle(sB, 0, 0, Width, TopBarSize);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!_wasPainted)
            {
                if (IsClosed && !DesignMode)
                {
                    OriginalWidth = Width;
                    Width = 0;
                }

                _wasPainted = true;
                this.CreateDropShadow();
            }

            if (IsClosed || _isAnimating) return;

            var yPos = TopBarSize + TopBarSpacing;
            SolidBrush altColor = new SolidBrush(ColorScheme.SecondaryColor);
            SolidBrush backColor = new SolidBrush(BackColor);

            foreach (var item in Items)
            {
                item.MeasureItem(this, e.Graphics, out var height);
                if (height < 1) continue;
                var itemRect = new Rectangle(0, yPos, Width, height);

                using (var bmp = new Bitmap(Width, height))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        var mouseHere = itemRect.Contains(PointToClient(Cursor.Position)) &&
                                        MouseButtons == MouseButtons.Left;
                        g.FillRectangle(mouseHere ? altColor : backColor, 0, 0, Width, height);
                        item.DrawItem(this, g, new Size(Width, height), mouseHere);
                    }

                    e.Graphics.DrawImageUnscaled(bmp, 0, yPos);
                    yPos += height;
                }
            }
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Refresh();
            var yPos = TopBarSize + TopBarSpacing;
            using (var bmpOrig = new Bitmap(Width, Height))
            {
                using (var g = Graphics.FromImage(bmpOrig))
                {
                    foreach (var item in Items)
                    {
                        item.MeasureItem(this, g, out var height);
                        if (height < 1) continue;
                        var itemRect = new Rectangle(0, yPos, Width, height);

                        var mouseHere = itemRect.Contains(e.Location) && e.Button == MouseButtons.Left;
                        if (mouseHere)
                        {
                            item.OnClick(e);
                            return;
                        }

                        yPos += height;
                    }
                }
            }
        }

        /// <summary>
        /// Shows the sidebar.
        /// </summary>
        public void ShowSidebar()
        {
            if (!IsClosed) return;
            var originalRect = Rectangle.FromLTRB(Bounds.Left, Bounds.Top, Bounds.Right + 8 * 2, Bounds.Bottom);
            if (OriginalWidth == -1)
                OriginalWidth = Width;
            Width = 0;
            IsClosed = false;
            var animIn = new AnimationBuilder()
                .WithAction(a => { Width++; })
                .WithCountLimit(OriginalWidth)
                .WithMultiplier(7)
                .WithInterval(8)
                .Build();
            Show();
            animIn.End(a =>
            {
                _isAnimating = false;
                Parent?.ResumeLayout();
                Parent?.Refresh();
                OnAnimationStop(EventArgs.Empty);
            });
            OnAnimationStart(EventArgs.Empty);
            _isAnimating = true;
            Parent?.Invalidate(originalRect);
            Parent?.SuspendLayout();
            animIn.Start();
        }

        /// <summary>
        /// Hides the sidebar.
        /// </summary>
        public void HideSidebar()
        {
            if (IsClosed) return;
            var originalRect = Rectangle.FromLTRB(Bounds.Left, Bounds.Top, Bounds.Right + 8 * 2, Bounds.Bottom);
            if (OriginalWidth == -1)
                OriginalWidth = Width;
            IsClosed = true;
            var animOut = new AnimationBuilder()
                .WithAction(a => Width--)
                .WithCountLimit(OriginalWidth)
                .WithMultiplier(7)
                .WithInterval(8)
                .Build();
            animOut.End(a =>
            {
                Hide();
                _isAnimating = false;
                Parent?.ResumeLayout();
                OnAnimationStop(EventArgs.Empty);
            });
            OnAnimationStart(EventArgs.Empty);
            _isAnimating = true;
            Parent?.Invalidate(originalRect);
            Parent?.SuspendLayout();
            animOut.Start();
        }

        
        
    }

    /// <summary>
    /// Class SideBarItem.
    /// </summary>
    public abstract class SideBarItem
    {
        /// <summary>
        /// Called to signal to subscribers that the item was clicked
        /// </summary>
        public event MouseEventHandler Click;

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="g">The g.</param>
        /// <param name="itemSize">Size of the item.</param>
        /// <param name="isSelected">if set to <c>true</c> [is selected].</param>
        public abstract void DrawItem(ZeroitSideBar c, Graphics g, Size itemSize, bool isSelected = false);
        /// <summary>
        /// Measures the item.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="g">The g.</param>
        /// <param name="itemHeight">Height of the item.</param>
        public abstract void MeasureItem(ZeroitSideBar c, Graphics g, out int itemHeight);

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public virtual void OnClick(MouseEventArgs e)
        {
            var eh = Click;
            eh?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Class SideBarItems.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Form.ModernForm.Controls.SideBarItem" />
    public class SideBarItems : SideBarItem
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="g">The g.</param>
        /// <param name="itemSize">Size of the item.</param>
        /// <param name="isSelected">if set to <c>true</c> [is selected].</param>
        public override void DrawItem(ZeroitSideBar c, Graphics g, Size itemSize, bool isSelected = false)
        {
            
        }

        /// <summary>
        /// Measures the item.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="g">The g.</param>
        /// <param name="itemHeight">Height of the item.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void MeasureItem(ZeroitSideBar c, Graphics g, out int itemHeight)
        {
            throw new NotImplementedException();
        }
    }
}