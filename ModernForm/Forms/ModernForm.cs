// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ModernForm.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Form.ModernForm.Controls;
using Zeroit.Framework.Form.ModernForm.Native;
using Zeroit.Framework.Form.ModernForm.Objects;
using Zeroit.Framework.Form.ModernForm.Objects.Interaction;
using Zeroit.Framework.Form.ModernForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Forms
{
    /// <summary>
    /// Class ModernForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class ModernForm : System.Windows.Forms.Form
    {
        #region Fields

        /// <summary>
        /// The default height of the titlebar
        /// </summary>
        public const int DefaultTitlebarHeight = 32;

        /// <summary>
        /// The size of the border
        /// </summary>
        public const int SizingBorder = 7;

        /// <summary>
        /// The native titlebar buttons
        /// </summary>
        private readonly List<ModernTitlebarButton>  _nativeTitlebarButtons;
        /// <summary>
        /// The titlebar buttons
        /// </summary>
        private List<ModernTitlebarButton> _titlebarButtons = new List<ModernTitlebarButton>();
        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorScheme _colorScheme;
        /// <summary>
        /// The minimum size
        /// </summary>
        private Size _minimumSize = Size.Empty;
        /// <summary>
        /// The mouse changed
        /// </summary>
        private bool _mouseChanged;
        /// <summary>
        /// The window hit
        /// </summary>
        private WindowHitTestResult _windowHit = WindowHitTestResult.None;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernForm"/> class.
        /// </summary>
        public ModernForm()
        {
            Font = SystemFonts.MessageBoxFont;
            ColorScheme = DefaultColorSchemes.Blue;

            DoubleBuffered = true;
            AutoScaleMode = AutoScaleMode.None;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            _titlebarButtons = new List<ModernTitlebarButton>();
            _nativeTitlebarButtons = GenerateNativeButtons(DefaultTitlebarHeight, this);

            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the size of the hamburger button.
        /// </summary>
        /// <value>The size of the hamburger button.</value>
        public int HamburgerButtonSize { get; set; } = 32;

        /// <summary>
        /// Gets a value indicating whether this instance is side bar available.
        /// </summary>
        /// <value><c>true</c> if this instance is side bar available; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSideBarAvailable => !IsAppBarAvailable && Controls.OfType<ZeroitSideBar>().Any();


        /// <summary>
        /// Gets the hamburger rectangle.
        /// </summary>
        /// <value>The hamburger rectangle.</value>
        public Rectangle HamburgerRectangle => IsSideBarAvailable
            ? Rectangle.FromLTRB(TextBarRectangle.Left - HamburgerButtonSize - 1, 0, TextBarRectangle.Left,
                TextBarRectangle.Bottom)
            : Rectangle.Empty;

        /// <summary>
        /// Gets the bottom side.
        /// </summary>
        /// <value>The bottom side.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BottomSide => Rectangle.FromLTRB(SizingBorder, FormBounds.Bottom - SizingBorder,
            FormBounds.Right - SizingBorder, FormBounds.Bottom);

        /// <summary>
        /// The color scheme on this window
        /// </summary>
        /// <value>The color scheme.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorScheme ColorScheme
        {
            get => _colorScheme;
            set
            {
                _colorScheme = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets the rectangle that represents the virtual display area of the control.
        /// </summary>
        /// <value>The display rectangle.</value>
        public override Rectangle DisplayRectangle => Rectangle.FromLTRB(TitlebarRectangle.Left,
            TitlebarRectangle.Bottom, TitlebarRectangle.Right, FormBounds.Bottom - 1);

        /// <summary>
        /// The form bounds rectangle relative to 0,0
        /// </summary>
        /// <value>The form bounds.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle FormBounds => new Rectangle(Point.Empty, Size);

        /// <summary>
        /// Gets a value indicating whether this instance is application bar available.
        /// </summary>
        /// <value><c>true</c> if this instance is application bar available; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsAppBarAvailable => Controls.OfType<ZeroitAppBar>().Any();

        /// <summary>
        /// Gets the left bottom.
        /// </summary>
        /// <value>The left bottom.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle LeftBottom =>
            Rectangle.FromLTRB(0, FormBounds.Bottom - SizingBorder, SizingBorder, FormBounds.Bottom);

        /// <summary>
        /// Gets the left side.
        /// </summary>
        /// <value>The left side.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle LeftSide =>
            Rectangle.FromLTRB(0, TitlebarRectangle.Bottom, SizingBorder, FormBounds.Bottom - SizingBorder);

        /// <summary>
        /// Gets the maximum size the form can be resized to.
        /// </summary>
        /// <value>The maximum size.</value>
        public override Size MaximumSize
        {
            get => Screen.GetWorkingArea(this).Size;
            set
            {
                value = Screen.GetWorkingArea(this).Size;
                base.MaximumSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum size the form can be resized to.
        /// </summary>
        /// <value>The minimum size.</value>
        public override Size MinimumSize
        {
            get
            {
                if (_minimumSize.IsEmpty)
                {
                    var v = GetTitleBarButtonsWidth();
                    return new Size(v, TitlebarHeight + SizingBorder);
                }

                return _minimumSize;
            }
            set => _minimumSize = value;
        }

        /// <summary>
        /// Gets the right bottom.
        /// </summary>
        /// <value>The right bottom.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle RightBottom => Rectangle.FromLTRB(FormBounds.Right - SizingBorder,
            FormBounds.Bottom - SizingBorder, FormBounds.Right, FormBounds.Bottom);

        /// <summary>
        /// Gets the right side.
        /// </summary>
        /// <value>The right side.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle RightSide => Rectangle.FromLTRB(FormBounds.Right - SizingBorder, TitlebarRectangle.Bottom,
            FormBounds.Right, FormBounds.Bottom - SizingBorder);

        /// <summary>
        /// Gets or sets the type of the shadow.
        /// </summary>
        /// <value>The type of the shadow.</value>
        public ShadowType ShadowType { get; set; } = ShadowType.Default;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ModernForm"/> is sizable.
        /// </summary>
        /// <value><c>true</c> if sizable; otherwise, <c>false</c>.</value>
        public bool Sizable { get; set; } = true;

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Rectangle that represents the titlebar text
        /// </summary>
        /// <value>The text bar rectangle.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle TextBarRectangle => Rectangle.FromLTRB(
            (IsSideBarAvailable ? HamburgerButtonSize : 0) + TitlebarRectangle.Left, TitlebarRectangle.Top,
            TitlebarRectangle.Right - GetTitleBarButtonsWidth(), TitlebarRectangle.Bottom);

        /// <summary>
        /// Gets or sets the titlebar buttons.
        /// </summary>
        /// <value>The titlebar buttons.</value>
        public List<ModernTitlebarButton> TitlebarButtons
        {
            get { return _titlebarButtons; }
            set
            {
                _titlebarButtons = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Rectangle that represents all caption/titlebar buttons
        /// </summary>
        /// <value>The titlebar buttons rectangle.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Rectangle TitlebarButtonsRectangle
        {
            get
            {
                var btnWidth = GetTitleBarButtonsWidth();
                var titlebarRect = TitlebarRectangle;
                return Rectangle.FromLTRB(titlebarRect.Right - btnWidth, titlebarRect.Top, titlebarRect.Right,
                    titlebarRect.Bottom);
            }
        }

        /// <summary>
        /// The font used in the titlebar
        /// </summary>
        /// <value>The title bar font.</value>
        public Font TitleBarFont { get; set; } = SystemFonts.CaptionFont;

        /// <summary>
        /// The actual height of the titlebar
        /// </summary>
        /// <value>The height of the titlebar.</value>
        public int TitlebarHeight { get; set; } = DefaultTitlebarHeight;

        /// <summary>
        /// Gets the border offset.
        /// </summary>
        /// <value>The border offset.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual int BorderOffset => WindowState == FormWindowState.Maximized ? 0 : 1;

        /// <summary>
        /// Rectangle that represents the complete titlebar
        /// </summary>
        /// <value>The titlebar rectangle.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Rectangle TitlebarRectangle => Rectangle.FromLTRB(BorderOffset, BorderOffset,
            FormBounds.Right - BorderOffset, TitlebarVisible ? TitlebarHeight + BorderOffset : BorderOffset);

        /// <summary>
        /// Gets or sets a value indicating whether [titlebar visible].
        /// </summary>
        /// <value><c>true</c> if [titlebar visible]; otherwise, <c>false</c>.</value>
        public bool TitlebarVisible { get; set; } = true;

        /// <summary>
        /// Gets the native titlebar buttons.
        /// </summary>
        /// <value>The native titlebar buttons.</value>
        private List<ModernTitlebarButton> NativeTitlebarButtons => _nativeTitlebarButtons;

        #endregion

        #region Methods

        /// <summary>
        /// Handles the mouse move and child.
        /// </summary>
        /// <param name="c">The c.</param>
        public void HandleMouseMoveAndChild(Control c)
        {
            //Listen to mouse events
            c.MouseDown += HandleMouseEventHandler;
            c.MouseMove += MouseMoveEvent;
            foreach (Control c2 in c.Controls)
            {
                //Do the same for child controls
                //(Recursive method call)
                HandleMouseMoveAndChild(c2);
            }
        }

        /// <summary>
        /// Hits the test.
        /// </summary>
        /// <param name="loc">The loc.</param>
        /// <returns>WindowHitTestResult.</returns>
        public WindowHitTestResult HitTest(Point loc)
        {
            return HitTest(loc, Point.Empty);
        }

        /// <summary>
        /// Hits the test.
        /// </summary>
        /// <param name="loc">The loc.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>WindowHitTestResult.</returns>
        public WindowHitTestResult HitTest(Point loc, Point offset)
        {
            var negativeOffset = new Point(-offset.X, -offset.Y);
            if (TitlebarButtonsRectangle.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.TitleBarButtons;

            if (TextBarRectangle.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.TitleBar;

            if (!Sizable)
                return WindowHitTestResult.None;

            if (LeftBottom.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.BottomLeft;

            if (LeftSide.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.Left;

            if (BottomSide.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.Bottom;

            if (RightBottom.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.BottomRight;

            if (RightSide.OffsetAndReturn(negativeOffset).Contains(loc))
                return WindowHitTestResult.Right;

            return WindowHitTestResult.None;
        }

        /// <summary>
        /// Unhandles the mouse move and child.
        /// </summary>
        /// <param name="c">The c.</param>
        public void UnhandleMouseMoveAndChild(Control c)
        {
            //Remove mouse events listeners
            c.MouseDown -= HandleMouseEventHandler;
            c.MouseMove -= MouseMoveEvent;
            foreach (Control c2 in c.Controls)
            {
                //Do the same for child controls
                //(Recursive method call)
                UnhandleMouseMoveAndChild(c2);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            //Detect when control is added and handle form resizing
            HandleMouseMoveAndChild(e.Control);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            //Detect when control is removed and remove all mouse listeners
            UnhandleMouseMoveAndChild(e.Control);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                if (Location.IsEmpty) CenterToScreen();

                //Check if we can use the aero shadow
                if ((ShadowType.Equals(ShadowType.AeroShadow) || ShadowType.Equals(ShadowType.Default)) &&
                    DwmNative.ExtendFrameIntoClientArea(this, 0, 0, 0, 1))
                {
                    //We can! Tell windows to allow the rendering to happen on our borderless form
                    DwmNative.AllowRenderInBorderless(this);
                }
                else if (ShadowType.Equals(ShadowType.Default) || ShadowType.Equals(ShadowType.FlatShadow))
                {
                    //No aero for us! We must create the typical flat shadow.
                    new ShadowForm().Show(this);
                }
                //else if (ShadowType.Equals(ShadowType.GlowShadow))
                //{
                //    var glowShadowForm = new PerPixelAlphaForm()
                //    {/*
                //        ShadowBlur = 5,
                //        ShadowSpread = 5,
                //        ShadowColor = ColorScheme.PrimaryColor*/
                //    };
                //    using (var bmp = new Bitmap(Width + 10, Height + 10))
                //    {
                //        using (var g = Graphics.FromImage(bmp))
                //        {
                //            g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);
                //        }
                //        glowShadowForm.SetBitmap(bmp);
                //    }

                //    glowShadowForm.Location = new Point(Location.X - 5, Location.Y - 5);
                //    glowShadowForm.Show();
                //    //SizeChanged += (s, ee) => glowShadowForm.RefreshShadow();
                //    //glowShadowForm.RefreshShadow();
                //}
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (_windowHit != WindowHitTestResult.None && _windowHit != WindowHitTestResult.TitleBar &&
                _windowHit != WindowHitTestResult.TitleBarButtons && Sizable)
            {
                _windowHit = WindowHitTestResult.None;
                return;
            }

            var titlebarButtonOffset = 0;
            switch (HitTest(e.Location))
            {
                case WindowHitTestResult.TitleBarButtons:
                    titlebarButtonOffset = 0;
                    HandleTitlebarButtonClick(e, ref titlebarButtonOffset, NativeTitlebarButtons);
                    HandleTitlebarButtonClick(e, ref titlebarButtonOffset, TitlebarButtons);
                    break;
            }

            if (IsSideBarAvailable && HamburgerRectangle.Contains(e.Location))
                Controls.OfType<ZeroitSideBar>().All(ToggleSidebar);
        }

        /// <summary>
        /// Toggles the sidebar.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ToggleSidebar(ZeroitSideBar c)
        {
            if (c.IsClosed)
            {
                c.ShowSidebar();
            }
            else
                c.HideSidebar();

            return true;
        }

        /// <summary>
        /// The is mouse down
        /// </summary>
        private bool _isMouseDown;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isMouseDown = true;
            var hitResult = HitTest(e.Location);

            _windowHit = hitResult;

            if (hitResult == WindowHitTestResult.TitleBar)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2 && MaximizeBox)
                {
                    WindowState = (WindowState == FormWindowState.Normal
                        ? FormWindowState.Maximized
                        : FormWindowState.Normal);
                    return;
                }

                FormUtils.StartFormDragFromTitlebar(this);
            }
            else if (hitResult != WindowHitTestResult.TitleBarButtons && hitResult != WindowHitTestResult.None &&
                     Sizable)
            {
                if (!Sizable) return;
                FormUtils.StartFormResizeFromEdge(this, FormUtils.ConvertToResizeResult(hitResult));
            }

            Invalidate(TitlebarButtonsRectangle);
            if (IsSideBarAvailable)
                Invalidate(HamburgerRectangle);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (DesignMode) return;
            if (_mouseChanged)
            {
                Cursor = Cursors.Default;
                _mouseChanged = false;
            }

            Invalidate(TitlebarButtonsRectangle);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (DesignMode) return;
            if (_mouseChanged)
            {
                Cursor = Cursors.Default;
                _mouseChanged = false;
            }

            Invalidate(TitlebarButtonsRectangle);
            if (IsSideBarAvailable)
                Invalidate(HamburgerRectangle);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (DesignMode) return;
            var hitResult = HitTest(e.Location);
            var resizeResult = FormUtils.ConvertToResizeResult(hitResult);
            var cursor = FormUtils.HitTestToCursor(resizeResult);
            if (WindowState != FormWindowState.Maximized)
            {
                if (_mouseChanged)
                {
                    base.Cursor = cursor;
                }

                _mouseChanged = true /*!cursor.Equals(Cursors.Default)*/;
            }

            Invalidate(TitlebarButtonsRectangle);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isMouseDown = false;
            if (_mouseChanged)
            {
                Cursor = Cursors.Default;
                _mouseChanged = false;
            }

            Invalidate(TitlebarButtonsRectangle);
            if (IsSideBarAvailable)
                Invalidate(HamburgerRectangle);
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            var curLoc = PointToClient(Cursor.Position);

            using (var primary = new SolidBrush(ColorScheme.PrimaryColor))
            {
                using (var secondary = new SolidBrush(ColorScheme.SecondaryColor))
                {
                    using (var mouseDownColor = new SolidBrush(ColorScheme.MouseDownColor))
                    {
                        using (var mouseHoverColor = new SolidBrush(ColorScheme.MouseHoverColor))
                        {
                            //Draw titlebar
                            if (TitlebarVisible)
                                e.Graphics.FillRectangle(IsAppBarAvailable ? secondary : primary, TitlebarRectangle);
                            //Draw form border
                            if (BorderOffset != 0)
                                GraphicUtils.DrawRectangleBorder(FormBounds, e.Graphics, ColorScheme.SecondaryColor);

                            if (!TitlebarVisible)
                                return;
                            //Start rendering the titlebar buttons
                            var titlebarButtonOffset = 0;
                            titlebarButtonOffset = RenderTitlebarButtons(e, curLoc, mouseDownColor, mouseHoverColor,
                                NativeTitlebarButtons, ref titlebarButtonOffset);
                            titlebarButtonOffset = RenderTitlebarButtons(e, curLoc, mouseDownColor, mouseHoverColor,
                                TitlebarButtons,
                                ref titlebarButtonOffset);
                            //Dectect if an app bar is available.
                            //If it is, draw the window title.
                            if (!IsAppBarAvailable ||
                                (Controls.OfType<ZeroitAppBar>().FirstOrDefault()?.OverrideParentText ?? false))
                            {
                                GraphicUtils.DrawCenteredText(e.Graphics, Text, TitleBarFont,
                                    Rectangle.FromLTRB(TextBarRectangle.Left + SizingBorder, TextBarRectangle.Top,
                                        TextBarRectangle.Right - SizingBorder, TextBarRectangle.Bottom),
                                    ColorScheme.ForegroundColor, false, true);
                            }

                            if (IsSideBarAvailable)
                                GraphicUtils.DrawHamburgerButton(e.Graphics, secondary, HamburgerRectangle,
                                    ColorScheme.ForegroundColor, this, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var oldClip = e.Graphics.Clip;
            e.Graphics.SetClip(DisplayRectangle);
            base.OnPaint(e);
            e.Graphics.SetClip(oldClip.GetBounds(e.Graphics));
            oldClip.Dispose();
        }

        /// <summary>
        /// This method adds the default titlebar buttons.
        /// </summary>
        /// <param name="width">Button width</param>
        /// <param name="parent">Form containing the buttons</param>
        /// <returns>List&lt;ModernTitlebarButton&gt;.</returns>
        private static List<ModernTitlebarButton> GenerateNativeButtons(int width, System.Windows.Forms.Form parent)
        {
            //Create a temporary list
            var list = new List<ModernTitlebarButton>
            {
                new NativeTitlebarButton(parent, width, NativeTitlebarButton.TitlebarAction.Close),
                new NativeTitlebarButton(parent, width, NativeTitlebarButton.TitlebarAction.Maximize),
                new NativeTitlebarButton(parent, width, NativeTitlebarButton.TitlebarAction.Minimize)
            };

            return list;
        }

        /// <summary>
        /// Get rectangle of a button
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="btn">The button</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetTitlebarButtonRectangle(int offset, ModernTitlebarButton btn)
        {
            return Rectangle.FromLTRB(TitlebarRectangle.Right - btn.Width - offset, 0, TitlebarRectangle.Right - offset,
                TitlebarRectangle.Bottom);
        }

        /// <summary>
        /// Get total width of all the caption buttons
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetTitleBarButtonsWidth()
        {
            var titlebarButtonOffset = 0;
            for (var i = 0; i < NativeTitlebarButtons.Count; i++)
            {
                var btn = NativeTitlebarButtons[i];
                if (!btn.Visible) continue;
                var rect = GetTitlebarButtonRectangle(titlebarButtonOffset, btn);
                titlebarButtonOffset += btn.Width;
            }

            for (var i = 0; i < TitlebarButtons.Count; i++)
            {
                var btn = TitlebarButtons[i];
                if (!btn.Visible) continue;
                var rect = GetTitlebarButtonRectangle(titlebarButtonOffset, btn);
                titlebarButtonOffset += btn.Width;
            }

            return titlebarButtonOffset;
        }

        /// <summary>
        /// Handles the mouse event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void HandleMouseEventHandler(object sender, MouseEventArgs e)
        {
            //Get the control
            var c = (Control) sender;
            //Check if the window isn't and there isn't more than one click
            if ((WindowState != FormWindowState.Maximized) && e.Clicks != 1) return;
            //Check where clicked
            var result = HitTest(e.Location, c.Location);
            //Invoke method that will start firm resizing
            if (Sizable)
                FormUtils.StartFormResizeFromEdge(this, FormUtils.ConvertToResizeResult(result), c);
        }

        /// <summary>
        /// Handles the titlebar button click.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <param name="titlebarButtonOffset">The titlebar button offset.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns>System.Int32.</returns>
        private int HandleTitlebarButtonClick(MouseEventArgs e, ref int titlebarButtonOffset,
            List<ModernTitlebarButton> buttons)
        {
            for (var i = 0; i < buttons.Count; i++)
            {
                var btn = buttons[i];
                if (!btn.Visible) continue;
                var rect = GetTitlebarButtonRectangle(titlebarButtonOffset, btn);
                titlebarButtonOffset += btn.Width;
                if (rect.Contains(e.Location))
                {
                    btn.OnClick(e);
                }
            }

            return titlebarButtonOffset;
        }

        /// <summary>
        /// Mouses the move event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            //Get the control
            var c = ((Control) sender);

            //Check if window is maximized, if it is, stop!
            if (WindowState == FormWindowState.Maximized) return;
            //Try to see where the mouse was
            var result = HitTest(e.Location, c.Location);
            var cur = FormUtils.HitTestToCursor(FormUtils.ConvertToResizeResult(result));
            //Change the mouse accordingly
            if (!c.Cursor.Equals(cur) && _mouseChanged)
            {
                c.Cursor = cur;
                _mouseChanged = !cur.Equals(Cursors.Default);
            }
        }

        /// <summary>
        /// Renders the titlebar buttons.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="curLoc">The current loc.</param>
        /// <param name="secondaryDown">The secondary down.</param>
        /// <param name="secondaryHover">The secondary hover.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="titlebarButtonOffset">The titlebar button offset.</param>
        /// <returns>System.Int32.</returns>
        private int RenderTitlebarButtons(PaintEventArgs e, Point curLoc, SolidBrush secondaryDown,
            SolidBrush secondaryHover, IEnumerable<ModernTitlebarButton> buttons, ref int titlebarButtonOffset)
        {
            foreach (var btn in buttons)
            {
                if (!btn.Visible) continue;
                var rect = GetTitlebarButtonRectangle(titlebarButtonOffset, btn);
                if (rect.Contains(curLoc) && !DesignMode)
                    e.Graphics.FillRectangle(_isMouseDown ? secondaryDown : secondaryHover, rect);
                GraphicUtils.DrawCenteredText(e.Graphics, btn.Text, btn.Font, rect, ColorScheme.ForegroundColor);
                titlebarButtonOffset += btn.Width;
            }

            return titlebarButtonOffset;
        }

        /// <summary>
        /// Resets the <see cref="P:System.Windows.Forms.Control.BackColor" /> property to its default value.
        /// </summary>
        private new void ResetBackColor()
        {
            BackColor = Color.White;
        }

        /// <summary>
        /// Resets the color scheme.
        /// </summary>
        private void ResetColorScheme()
        {
            ColorScheme = DefaultColorSchemes.Blue;
        }

        #endregion
    }
}