// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AppBar.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Form.ModernForm.Objects;
using Zeroit.Framework.Form.ModernForm.Objects.MenuItems;
using Zeroit.Framework.Form.ModernForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Controls
{
    /// <summary>
    /// Class ZeroitAppBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    public class ZeroitAppBar : Control
    {
        #region Fields

        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorScheme _colorScheme = DefaultColorSchemes.Blue;

        /// <summary>
        /// The has started yet
        /// </summary>
        private bool _hasStartedYet;
        /// <summary>
        /// The text
        /// </summary>
        private string _text = "";
        /// <summary>
        /// The icon visible
        /// </summary>
        private bool _iconVisible;
        /// <summary>
        /// The override parent text
        /// </summary>
        private bool _overrideParentText;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAppBar"/> class.
        /// </summary>
        public ZeroitAppBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(10, RoundUp((int) (Zeroit.Framework.Form.ModernForm.Forms.ModernForm.DefaultTitlebarHeight * 1.5d)));
            Dock = DockStyle.Top;
            Load += AppBar_Load;
            
        }

        #endregion

        #region Events

        /// <summary>
        /// Called to signal to subscribers that this control loaded
        /// </summary>
        public event EventHandler Load;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [override parent text].
        /// </summary>
        /// <value><c>true</c> if [override parent text]; otherwise, <c>false</c>.</value>
        public bool OverrideParentText
        {
            get => _overrideParentText;
            set
            {
                _overrideParentText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is side bar available.
        /// </summary>
        /// <value><c>true</c> if this instance is side bar available; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSideBarAvailable => Parent != null && Parent.Controls.OfType<ZeroitSideBar>().Any();

        /// <summary>
        /// Gets or sets a value indicating whether [cast shadow].
        /// </summary>
        /// <value><c>true</c> if [cast shadow]; otherwise, <c>false</c>.</value>
        public bool CastShadow { get; set; } = true;

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<AppAction> Actions { get; set; } = new List<AppAction>();

        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        public ColorScheme ColorScheme
        {
            get => Parent != null && Parent is Zeroit.Framework.Form.ModernForm.Forms.ModernForm ? ((Zeroit.Framework.Form.ModernForm.Forms.ModernForm) Parent).ColorScheme : _colorScheme;
            set => _colorScheme = value;
        }

        /// <summary>
        /// Gets or sets the size of the hamburger button.
        /// </summary>
        /// <value>The size of the hamburger button.</value>
        public int HamburgerButtonSize { get; set; } = 32;

        /// <summary>
        /// Gets the control bounds.
        /// </summary>
        /// <value>The control bounds.</value>
        public Rectangle ControlBounds => new Rectangle(Point.Empty, Size);

        /// <summary>
        /// Gets or sets a value indicating whether [icon visible].
        /// </summary>
        /// <value><c>true</c> if [icon visible]; otherwise, <c>false</c>.</value>
        public bool IconVisible
        {
            get => _iconVisible;
            set
            {
                _iconVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the menu items.
        /// </summary>
        /// <value>The menu items.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<AppBarMenuItem> MenuItems { get; set; } = new List<AppBarMenuItem>();



        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(true)]
        public override string Text
        {
            get => !OverrideParentText ? FindForm()?.Text : _text;
            set
            {
                if (OverrideParentText)
                    _text = value;
                else
                {
                    var findForm = FindForm();
                    if (findForm == null) return;
                    findForm.Text = value;
                    findForm.Invalidate();
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text font.
        /// </summary>
        /// <value>The text font.</value>
        public Font TextFont { get; set; } = new Font(SystemFonts.CaptionFont.FontFamily, 14f);

        /// <summary>
        /// Gets the text rectangle.
        /// </summary>
        /// <value>The text rectangle.</value>
        public Rectangle TextRectangle =>
            Rectangle.FromLTRB((IsSideBarAvailable ? HamburgerButtonSize : 0) + XTextOffset * (IconVisible ? 2 : 1), 0,
                ControlBounds.Right - XTextOffset, ControlBounds.Bottom);

        /// <summary>
        /// Gets the hamburger rectangle.
        /// </summary>
        /// <value>The hamburger rectangle.</value>
        public Rectangle HamburgerRectangle => IsSideBarAvailable
            ? Rectangle.FromLTRB(TextRectangle.Left - 8 - HamburgerButtonSize, TextRectangle.Top + 8,
                TextRectangle.Left - 8, TextRectangle.Bottom - 8)
            : Rectangle.Empty;

        /// <summary>
        /// Gets the x text offset.
        /// </summary>
        /// <value>The x text offset.</value>
        public int XTextOffset => 20;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the menu rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public Rectangle GetMenuRectangle()
        {
            int index = 0;
            int xTextOffset = XTextOffset;
            int size = Height - xTextOffset;
            int xTextOffsetHalf = XTextOffset / 2;
            int right = Width - xTextOffsetHalf - (index * size + xTextOffsetHalf * index);
            return Rectangle.FromLTRB(right - size, xTextOffsetHalf, right, Height - xTextOffsetHalf);
        }

        /// <summary>
        /// Handles the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnLoad(EventArgs e)
        {
            EventHandler eh = Load;

            eh?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (IsSideBarAvailable) Invalidate(HamburgerRectangle);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (IsSideBarAvailable) Invalidate(HamburgerRectangle);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (IsSideBarAvailable && HamburgerRectangle.Contains(e.Location))
            {
                Parent.Controls.OfType<ZeroitSideBar>().All(c =>
                {
                    if (c.IsClosed)
                    {
                        c.ShowSidebar();
                    }
                    else
                        c.HideSidebar();

                    return true;
                });
            }

            Rectangle menuRect = GetMenuRectangle();
            if (MenuItems != null && MenuItems.Count > 0 && menuRect.Contains(e.Location))
            {
                //Open new "window" to act as menu
                Color splitterColor = Color.Gray;
                const float splitterPercentage = 0.75f;
                var form = new AppBarMenuForm
                {
                    TitlebarVisible = false,
                    Tag = MenuItems,
                    Text = "ModernMenu",
                    ShowInTaskbar = false,
                    TopMost = true,
                    Sizable = false,
                };

                bool mouseDown = false;
                form.MouseDown += (s, ee) =>
                {
                    mouseDown = true;
                    form.Invalidate();
                };
                form.MouseUp += (s, ee) =>
                {
                    mouseDown = false;
                    form.Invalidate();
                };
                form.MouseMove += (s, ee) => { form.Refresh(); };

                form.Click += (s, ee) =>
                {
                    //Check the click
                    if (form.Tag != null)
                    {
                        if (form.Tag is List<AppBarMenuItem> items)
                        {
                            using (var g = form.CreateGraphics())
                            {
                                int yOffset = 0;
                                foreach (var item in items)
                                {
                                    Size itemSize = item.GetSize(Font, g);
                                    Rectangle rect =
                                        new Rectangle(
                                            new Point(form.DisplayRectangle.Left, yOffset + form.DisplayRectangle.Top),
                                            new Size(itemSize.Width, itemSize.Height - 1));

                                    if (rect.Contains(form.PointToClient(Cursor.Position)))
                                    {
                                        item.PerformClick();
                                        return;
                                    }

                                    yOffset += itemSize.Height;
                                }
                            }
                        }
                    }
                };

                form.Deactivate += (s, ee) =>
                {
                    if (Parent is System.Windows.Forms.Form frm)
                    {
                        frm.Activate();
                    }

                    form.Dispose();
                };
                form.Paint += (s, ee) =>
                {
                    //Draw the menu
                    int yOffset = 0;
                    using (var splitterPen = new Pen(splitterColor))
                    {
                        for (int i = 0, menuItemsCount = MenuItems.Count; i < menuItemsCount; i++)
                        {
                            var item = MenuItems[i];
                            Size itemSize = item.GetSize(Font, ee.Graphics);
                            Rectangle rect =
                                new Rectangle(
                                    new Point(form.DisplayRectangle.Left, yOffset + form.DisplayRectangle.Top),
                                    new Size(itemSize.Width, itemSize.Height - 1));

                            if (mouseDown && rect.Contains(form.PointToClient(Cursor.Position)))
                            {
                                ee.Graphics.FillRectangle(Brushes.LightGray, rect);
                            }

                            item.DrawItem(ee.Graphics, rect, Font);
                            if (i < menuItemsCount - 1)
                            {
                                int lineWidth = (int) (form.Width * splitterPercentage);
                                int side = (form.Width - lineWidth) / 2;
                                ee.Graphics.DrawLine(splitterPen, side, (yOffset + (itemSize.Height)),
                                    form.Width - side, (yOffset + (itemSize.Height)));
                            }

                            yOffset += itemSize.Height;
                        }
                    }
                };

                int maxWidth = -1;
                int maxHeight = -1;
                using (Graphics g = CreateGraphics())
                {
                    foreach (var item in MenuItems)
                    {
                        var size = item.GetSize(Font, g);

                        maxWidth = Math.Max(maxWidth, size.Width);
                        maxHeight += size.Height;
                    }
                }

                form.Size = new Size(maxWidth + 2, maxHeight + 2);
                Point screenLoc = PointToScreen(new Point(menuRect.Right, menuRect.Top));
                form.Location = new Point(screenLoc.X - maxWidth, screenLoc.Y);
                form.Show(this.Parent);
            }

            if (Actions != null)
            {
                Actions.ForEach(a =>
                {
                    Rectangle rect = a.GetRectangle(this, Actions);
                    if (rect != Rectangle.Empty && rect.Contains(e.Location))
                    {
                        a.OnClick(EventArgs.Empty);
                    }
                });
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_hasStartedYet)
            {
                _hasStartedYet = true;
                OnLoad(EventArgs.Empty);
            }

            if (Actions != null)
            {
                Actions.ForEach(a =>
                {
                    Rectangle rect = a.GetRectangle(this, Actions);
                    if (rect != Rectangle.Empty && a.Image != null)
                    {
                        ControlPaintWrapper.ZoomDrawImage(e.Graphics, a.Image, rect);
                    }
                });
            }

            using (var primary = new SolidBrush(ColorScheme.PrimaryColor))
            {
                using (var secondary = new SolidBrush(ColorScheme.SecondaryColor))
                {
                    using (var foreColor = new SolidBrush(ColorScheme.ForegroundColor))
                    {
                        e.Graphics.FillRectangle(primary, ControlBounds);
                        if (IconVisible)
                        {
                            e.Graphics.DrawIcon(((System.Windows.Forms.Form)Parent).Icon,
                                Rectangle.FromLTRB(XTextOffset / 2, XTextOffset / 2, XTextOffset * 2,
                                    Height - (XTextOffset / 2)));
                        }

                        GraphicUtils.DrawCenteredText(e.Graphics, Text, TextFont, TextRectangle,
                            ColorScheme.ForegroundColor, false, true);

                        if (MenuItems != null && MenuItems.Count > 0)
                        {
                            //Draw menu icon
                            Rectangle rect = GetMenuRectangle();
                            const int circleRadius = 2;
                            const int interval = 3;
                            int centerX = rect.Right - (rect.Width / 2);
                            int centerY = rect.Bottom - (rect.Height / 2);
                            int topCircle = centerY - (circleRadius * 2) - interval;
                            int bottomCircle = centerY + (circleRadius * 2) + interval;

                            var oldMode = e.Graphics.SmoothingMode;
                            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                            //Top
                            e.Graphics.FillEllipse(foreColor, centerX - circleRadius, topCircle - circleRadius,
                                circleRadius * 2, circleRadius * 2);

                            //Middle
                            e.Graphics.FillEllipse(foreColor, centerX - circleRadius, centerY - circleRadius,
                                circleRadius * 2, circleRadius * 2);

                            //Bottom
                            e.Graphics.FillEllipse(foreColor, centerX - circleRadius, bottomCircle - circleRadius,
                                circleRadius * 2, circleRadius * 2);

                            e.Graphics.SmoothingMode = oldMode;
                        }

                        if (IsSideBarAvailable)
                            GraphicUtils.DrawHamburgerButton(e.Graphics, secondary, HamburgerRectangle,
                                ColorScheme.ForegroundColor, this);
                    }
                }
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            #region Implemented in OnPaint method
            //using (var primary = new SolidBrush(ColorScheme.PrimaryColor))
            //{
            //    using (var secondary = new SolidBrush(ColorScheme.SecondaryColor))
            //    {
            //        using (var foreColor = new SolidBrush(ColorScheme.ForegroundColor))
            //        {
            //            pevent.Graphics.FillRectangle(primary, ControlBounds);
            //            if (IconVisible)
            //            {
            //                pevent.Graphics.DrawIcon(((System.Windows.Forms.Form) Parent).Icon,
            //                    Rectangle.FromLTRB(XTextOffset / 2, XTextOffset / 2, XTextOffset * 2,
            //                        Height - (XTextOffset / 2)));
            //            }

            //            GraphicUtils.DrawCenteredText(pevent.Graphics, Text, TextFont, TextRectangle,
            //                ColorScheme.ForegroundColor, false, true);

            //            if (MenuItems != null && MenuItems.Count > 0)
            //            {
            //                //Draw menu icon
            //                Rectangle rect = GetMenuRectangle();
            //                const int circleRadius = 2;
            //                const int interval = 3;
            //                int centerX = rect.Right - (rect.Width / 2);
            //                int centerY = rect.Bottom - (rect.Height / 2);
            //                int topCircle = centerY - (circleRadius * 2) - interval;
            //                int bottomCircle = centerY + (circleRadius * 2) + interval;

            //                var oldMode = pevent.Graphics.SmoothingMode;
            //                pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //                //Top
            //                pevent.Graphics.FillEllipse(foreColor, centerX - circleRadius, topCircle - circleRadius,
            //                    circleRadius * 2, circleRadius * 2);

            //                //Middle
            //                pevent.Graphics.FillEllipse(foreColor, centerX - circleRadius, centerY - circleRadius,
            //                    circleRadius * 2, circleRadius * 2);

            //                //Bottom
            //                pevent.Graphics.FillEllipse(foreColor, centerX - circleRadius, bottomCircle - circleRadius,
            //                    circleRadius * 2, circleRadius * 2);

            //                pevent.Graphics.SmoothingMode = oldMode;
            //            }

            //            if (IsSideBarAvailable)
            //                GraphicUtils.DrawHamburgerButton(pevent.Graphics, secondary, HamburgerRectangle,
            //                    ColorScheme.ForegroundColor, this);
            //        }
            //    }
            //} 
            #endregion
        }

        /// <summary>
        /// Handles the Load event of the AppBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AppBar_Load(object sender, EventArgs e)
        {
            if (!CastShadow) return;
            //The control was drawn.
            //This means we can add the drop shadow
            this.CreateDropShadow();
            if (Parent != null)
            {
                Parent.Invalidate();
            }
        }

        /// <summary>
        /// Rounds down.
        /// </summary>
        /// <param name="toRound">To round.</param>
        /// <returns>System.Int32.</returns>
        private int RoundDown(int toRound) => toRound - toRound % 10;

        /// <summary>
        /// Rounds up.
        /// </summary>
        /// <param name="toRound">To round.</param>
        /// <returns>System.Int32.</returns>
        private int RoundUp(int toRound) => (10 - toRound % 10) + toRound;

        #endregion
    }
}