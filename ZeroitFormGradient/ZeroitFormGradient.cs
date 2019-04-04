// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-24-2018
// ***********************************************************************
// <copyright file="ZeroitFormGradient.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Form
{
    #region ZeroitGradientForm

    /// <summary>
    /// Delegate OnDragFormEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    public delegate void OnDragFormEventHandler(object sender, MouseEventArgs e);
    /// <summary>
    /// Delegate OnDragFormPaintEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
    public delegate void OnDragFormPaintEventHandler(object sender, PaintEventArgs e);

    /// <summary>
    /// A class collection for rendering a gradient form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    public class ZeroitGradientForm : ContainerControl
    {
        #region Variables

        /// <summary>
        /// The mouse p
        /// </summary>
        private Point MouseP = new Point(0, 0);
        /// <summary>
        /// The cap
        /// </summary>
        private bool Cap = false;
        /// <summary>
        /// The move height
        /// </summary>
        private int MoveHeight;
        /// <summary>
        /// The text bottom
        /// </summary>
        private string _TextBottom = null;
        /// <summary>
        /// The border curve
        /// </summary>
        private int BorderCurve = 1;
        /// <summary>
        /// The state
        /// </summary>
        protected MouseStates State;
        /// <summary>
        /// The header rect
        /// </summary>
        private Rectangle HeaderRect;
        /// <summary>
        /// The color1
        /// </summary>
        private Color _Color1 = Color.DarkSlateGray;
        /// <summary>
        /// The color2
        /// </summary>
        private Color _Color2 = Color.SaddleBrown;
        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;
        /// <summary>
        /// The color angle
        /// </summary>
        private float _ColorAngle = 100f;
        /// <summary>
        /// The animate
        /// </summary>
        private bool animate = false;

        /// <summary>
        /// The color drag paint
        /// </summary>
        private Color colorDragPaint = Color.Gray;
        /// <summary>
        /// The mouse state
        /// </summary>
        private int MouseState;
        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        /// <summary>
        /// The inactive gb
        /// </summary>
        private LinearGradientBrush InactiveGB;
        /// <summary>
        /// The pressed gb
        /// </summary>
        private LinearGradientBrush PressedGB;
        /// <summary>
        /// The pressed contour gb
        /// </summary>
        private LinearGradientBrush PressedContourGB;
        /// <summary>
        /// The r1
        /// </summary>
        private Rectangle R1;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The p3
        /// </summary>
        private Pen P3;
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The background color1
        /// </summary>
        private Color _BackgroundColor1;
        /// <summary>
        /// The background color2
        /// </summary>
        private Color _BackgroundColor2;
        /// <summary>
        /// The background color pressed1
        /// </summary>
        private Color _BackgroundColorPressed1;
        /// <summary>
        /// The background color pressed2
        /// </summary>
        private Color _BackgroundColorPressed2;
        /// <summary>
        /// The background color pressed contour1
        /// </summary>
        private Color _BackgroundColorPressedContour1;
        /// <summary>
        /// The background color pressed contour2
        /// </summary>
        private Color _BackgroundColorPressedContour2;
        /// <summary>
        /// The radius upper left
        /// </summary>
        private int _RadiusUpperLeft = 10;
        /// <summary>
        /// The radius upper right
        /// </summary>
        private int _RadiusUpperRight = 10;
        /// <summary>
        /// The radius bottom left
        /// </summary>
        private int _RadiusBottomLeft = 10;
        /// <summary>
        /// The radius bottom right
        /// </summary>
        private int _RadiusBottomRight = 10;
        /// <summary>
        /// The angle
        /// </summary>
        private Double _Angle = 90f;
        /// <summary>
        /// The inner height
        /// </summary>
        private int innerHeight = 25;
        /// <summary>
        /// The gripstyle
        /// </summary>
        private SizeGripStyle gripstyle = SizeGripStyle.Show;

        /// <summary>
        /// The correct angle
        /// </summary>
        private float CorrectAngle;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        /// <summary>
        /// The last click
        /// </summary>
        public Point lastClick; //Holds where the Form was clicked

        #endregion

        #region  Mouse & Size

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="current">The current.</param>
        private void SetState(MouseStates current)
        {
            State = current;
            Invalidate();
        }

        /// <summary>
        /// The get index point
        /// </summary>
        private Point GetIndexPoint;
        /// <summary>
        /// The B1X
        /// </summary>
        private bool B1x;
        /// <summary>
        /// The B2X
        /// </summary>
        private bool B2x;
        /// <summary>
        /// The b3
        /// </summary>
        private bool B3;
        /// <summary>
        /// The b4
        /// </summary>
        private bool B4;
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetIndex()
        {
            GetIndexPoint = PointToClient(MousePosition);
            B1x = GetIndexPoint.X < 7;
            B2x = GetIndexPoint.X > Width - 7;
            B3 = GetIndexPoint.Y < 7;
            B4 = GetIndexPoint.Y > Height - 7;

            if (B1x && B3)
            {
                return 4;
            }
            if (B1x && B4)
            {
                return 7;
            }
            if (B2x && B3)
            {
                return 5;
            }
            if (B2x && B4)
            {
                return 8;
            }
            if (B1x)
            {
                return 1;
            }
            if (B2x)
            {
                return 2;
            }
            if (B3)
            {
                return 3;
            }
            if (B4)
            {
                return 6;
            }
            return 0;
        }

        /// <summary>
        /// The current
        /// </summary>
        private int Current;
        /// <summary>
        /// The previous
        /// </summary>
        private int Previous;
        /// <summary>
        /// Invalidates the mouse.
        /// </summary>
        private void InvalidateMouse()
        {
            Current = GetIndex();
            if (Current == Previous)
            {
                return;
            }

            Previous = Current;
            switch (Previous)
            {
                case 0:
                    Cursor = Cursors.Default;
                    break;
                case 6:
                    Cursor = Cursors.SizeNS;
                    break;
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 7:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        /// <summary>
        /// The messages
        /// </summary>
        private Message[] Messages = new Message[9];
        /// <summary>
        /// Initializes the messages.
        /// </summary>
        private void InitializeMessages()
        {
            Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (int I = 1; I <= 8; I++)
            {
                Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        /// <summary>
        /// Corrects the bounds.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        private void CorrectBounds(Rectangle bounds)
        {
            if (Parent.Width > bounds.Width)
            {
                Parent.Width = bounds.Width;
            }
            if (Parent.Height > bounds.Height)
            {
                Parent.Height = bounds.Height;
            }

            int X = Parent.Location.X;
            int Y = Parent.Location.Y;

            if (X < bounds.X)
            {
                X = bounds.X;
            }
            if (Y < bounds.Y)
            {
                Y = bounds.Y;
            }

            int Width = bounds.X + bounds.Width;
            int Height = bounds.Y + bounds.Height;

            if (X + Parent.Width > Width)
            {
                X = Width - Parent.Width;
            }
            if (Y + Parent.Height > Height)
            {
                Y = Height - Parent.Height;
            }

            Parent.Location = new Point(X, Y);
        }

        /// <summary>
        /// The wm lmbuttondown
        /// </summary>
        private bool WM_LMBUTTONDOWN;
        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (WM_LMBUTTONDOWN && m.Msg == 513)
            {
                WM_LMBUTTONDOWN = false;

                SetState(MouseStates.Over);
                if (!_SmartBounds)
                {
                    return;
                }

                if (IsParentMdi)
                {
                    CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
                }
                else
                {
                    CorrectBounds(Screen.FromControl(Parent).WorkingArea);
                }
            }
        }

        #endregion

        #region Image Designer

        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <param name="_ContentAlignment">The content alignment.</param>
        /// <returns>StringFormat.</returns>
        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color to paint the border the form is dragged.
        /// </summary>
        /// <value>The color border drag paint.</value>
        public Color ColorBorderDragPaint
        {
            get { return colorDragPaint; }
            set
            {
                colorDragPaint = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitGradientForm" /> should be animated.
        /// </summary>
        /// <value><c>true</c> if animate; otherwise, <c>false</c>.</value>
        public bool Animate
        {
            get { return animate; }
            set
            {
                animate = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size grip style.
        /// </summary>
        /// <value>The size grip style.</value>
        public SizeGripStyle SizeGripStyle
        {
            get { return gripstyle; }
            set
            {
                gripstyle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Enum representing the mouse states
        /// </summary>
        public enum MouseStates
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The over
            /// </summary>
            Over = 1,
            /// <summary>
            /// Down
            /// </summary>
            Down = 2
        }

        /// <summary>
        /// The sizable
        /// </summary>
        private bool _Sizable = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitGradientForm" /> is sizable.
        /// </summary>
        /// <value><c>true</c> if sizable; otherwise, <c>false</c>.</value>
        public bool Sizable
        {
            get
            {
                return _Sizable;
            }
            set
            {
                _Sizable = value;
            }
        }

        /// <summary>
        /// The smart bounds
        /// </summary>
        private bool _SmartBounds = false;

        /// <summary>
        /// Gets or sets a value indicating whether to enable/disable smart bounds.
        /// </summary>
        /// <value><c>true</c> if smart bounds; otherwise, <c>false</c>.</value>
        public bool SmartBounds
        {
            get
            {
                return _SmartBounds;
            }
            set
            {
                _SmartBounds = value;
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get { return this._TextAlignment; }
            set
            {
                this._TextAlignment = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get { return this._Color1; }
            set
            {
                this._Color1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get { return this._Color2; }
            set
            {
                this._Color2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed1.</value>
        public Color BackgroundColorPressed1
        {
            get { return this._BackgroundColorPressed1; }
            set
            {
                this._BackgroundColorPressed1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed2.</value>
        public Color BackgroundColorPressed2
        {
            get { return this._BackgroundColorPressed2; }
            set
            {
                this._BackgroundColorPressed2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color when the control is pressed.
        /// </summary>
        /// <value>The background border color pressed1.</value>
        public Color BackgroundColorPressedContour1
        {
            get { return this._BackgroundColorPressedContour1; }
            set
            {
                this._BackgroundColorPressedContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color when the control is pressed.
        /// </summary>
        /// <value>The background border color pressed2.</value>
        public Color BackgroundColorPressedContour2
        {
            get { return this._BackgroundColorPressedContour2; }
            set
            {
                this._BackgroundColorPressedContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The radius upper left.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - Value cannot go below 0.</exception>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusUpperLeft
        {
            get { return this._RadiusUpperLeft; }
            set
            {
                if (_RadiusUpperLeft == null)
                {
                    this._RadiusUpperLeft = 10;

                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 0.");
                    this._RadiusUpperLeft = 1;
                }


                this._RadiusUpperLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius upper right.</value>
        [Description("This changes the upper right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusUpperRight
        {
            get { return this._RadiusUpperRight; }
            set
            {
                if (_RadiusUpperRight == null)
                {
                    this._RadiusUpperRight = 10;

                }

                this._RadiusUpperRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom left.</value>
        [Description("This changes the bottom left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusBottomLeft
        {
            get { return this._RadiusBottomLeft; }
            set
            {
                if (_RadiusBottomLeft == null)
                {
                    this._RadiusBottomLeft = 10;

                }

                this._RadiusBottomLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom right.</value>
        [Description("This changes the bottom right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusBottomRight
        {
            get { return this._RadiusBottomRight; }
            set
            {
                if (_RadiusBottomRight == null)
                {
                    this._RadiusBottomRight = 10;

                }

                this._RadiusBottomRight = value;
                this.Invalidate();


            }
        }


        /// <summary>
        /// This changes the angle of gradient button
        /// </summary>
        /// <value>The angle.</value>
        [Description("This changes the angle of gradient button"),
        Category("Appearance"),
        Browsable(true)]
        public float Angle
        {
            get { return this._ColorAngle; }
            set
            {
                if (_ColorAngle == null)
                {
                    this._ColorAngle = 30f;
                }

                this._ColorAngle = value;
                //CorrectAngle = DoubleToFloat(_Angle);

                this.Invalidate();


            }
        }

        /// <summary>
        /// Gets or sets the height of the inner.
        /// </summary>
        /// <value>The height of the inner.</value>
        public int InnerHeight
        {
            get { return innerHeight; }
            set
            {
                innerHeight = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Doubles to float.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <returns>System.Single.</returns>
        private static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }

        #endregion


        #region EventArgs

        /// <summary>
        /// Called when [create control].
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
        }


        /// <summary>
        /// The is parent form
        /// </summary>
        private bool _IsParentForm;
        /// <summary>
        /// Gets a value indicating whether this instance is parent form.
        /// </summary>
        /// <value><c>true</c> if this instance is parent form; otherwise, <c>false</c>.</value>
        protected bool IsParentForm
        {
            get
            {
                return _IsParentForm;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is parent MDI.
        /// </summary>
        /// <value><c>true</c> if this instance is parent MDI; otherwise, <c>false</c>.</value>
        protected bool IsParentMdi
        {
            get
            {
                if (Parent == null)
                {
                    return false;
                }
                return Parent.Parent != null;
            }
        }

        /// <summary>
        /// The control mode
        /// </summary>
        private bool _ControlMode;
        /// <summary>
        /// Gets or sets a value indicating whether [control mode].
        /// </summary>
        /// <value><c>true</c> if [control mode]; otherwise, <c>false</c>.</value>
        protected bool ControlMode
        {
            get
            {
                return _ControlMode;
            }
            set
            {
                _ControlMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The start position
        /// </summary>
        private FormStartPosition _StartPosition = FormStartPosition.CenterScreen;

        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>The start position.</value>
        public FormStartPosition StartPosition
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                {
                    return ParentForm.StartPosition;
                }
                else
                {
                    return _StartPosition;
                }
            }
            set
            {
                _StartPosition = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.StartPosition = value;
                }
            }
        }

        #endregion


        #region  EventArgs

        /// <summary>
        /// Handles the <see cref="E:ParentChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected sealed override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent == null)
            {
                return;
            }
            _IsParentForm = Parent is System.Windows.Forms.Form;

            if (!_ControlMode)
            {

                if (_IsParentForm)
                {
                    this.ParentForm.FormBorderStyle = FormBorderStyle.None;
                    this.ParentForm.TransparencyKey = Color.Fuchsia;



                    if (!DesignMode)
                    {
                        ParentForm.Shown += FormShown;


                    }
                }
                //Parent.BackColor = BackColor;
                Parent.MinimumSize = new Size(126, 39);

            }
        }


        /// <summary>
        /// The has shown
        /// </summary>
        private bool HasShown;
        /// <summary>
        /// Forms the shown.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormShown(object sender, EventArgs e)
        {
            if (_ControlMode || HasShown)
            {
                return;
            }

            if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
            {
                Rectangle SB = Screen.PrimaryScreen.Bounds;
                Rectangle CB = ParentForm.Bounds;
                ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
            }
            HasShown = true;

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            Cap = false;
            Invalidate();
            base.OnMouseUp(e);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {

            MouseState = 1;
            Invalidate();
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            // [Inactive]
            Invalidate();
            // Update control
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        #endregion

        #region Additional Code
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Invalidated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.InvalidateEventArgs" /> that contains the event data.</param>
        protected override void OnInvalidated(System.Windows.Forms.InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            ParentForm.Text = Text;
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Creates a handle for the control.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
            {
                if (_Sizable && !_ControlMode)
                {
                    InvalidateMouse();
                }
            }
            if (Cap)
            {
                Parent.Location = (System.Drawing.Point)((object)(System.Convert.ToDouble(MousePosition) - System.Convert.ToDouble(MouseP)));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected sealed override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!_ControlMode)
            {
                HeaderRect = new Rectangle(0, 0, Width - 14, MoveHeight - 7);
            }
            Invalidate();
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGradientForm" /> class.
        /// </summary>
        public ZeroitGradientForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14);
            ForeColor = Color.White;
            Size = new Size(166, 40);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(_BackgroundColor1);
            this.Dock = DockStyle.Fill;
            SetStyle((ControlStyles)(139270), true);
            MoveHeight = 25;
            Font = new Font("Segoe UI", 8, FontStyle.Regular);


            //this.StartPosition = FormStartPosition.CenterScreen;


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                // Button Background Colors

                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);

                P3 = new Pen(PressedContourGB);
            }

            // Button Radius iTalk
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures();


            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(P1, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }


            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width, Height);

            #region Zeroit Removed
            //Color TransparencyKey = this.ParentForm.TransparencyKey;
            #endregion

            LinearGradientBrush bBackground = new LinearGradientBrush(ClientRectangle, _Color1, _Color2, _ColorAngle);
            //G.SmoothingMode = SmoothingMode.HighSpeed;

            #region Zeroit Removed
            //G.Clear(TransparencyKey);
            #endregion

            G.Clear(BackColor);

            // Draw the container borders
            G.FillPath(bBackground, RoundRectangle.RoundRect(ClientRectangle, BorderCurve));
            // Draw a rectangle in which the controls should be added on
            G.FillPath(bBackground, RoundRectangle.RoundRect(new Rectangle(2, 20, Width - 5, Height - 42), BorderCurve));

            // Patch the header with a rectangle that has a curve so its border will remain within container bounds
            G.FillPath(bBackground, RoundRectangle.RoundRect(new Rectangle(2, 2, (int)(Width / 2 + 2), 16), BorderCurve));
            G.FillPath(bBackground, RoundRectangle.RoundRect(new Rectangle((int)(Width / 2 - 3), 2, (int)(Width / 2), 16), BorderCurve));
            // Fill the header rectangle below the patch
            G.FillRectangle(bBackground, new Rectangle(2, 15, Width - 5, 10));

            // Increase the thickness of the container borders
            G.DrawPath(new Pen(_BorderColor), RoundRectangle.RoundRect(new Rectangle(2, 2, Width - 5, Height - 5), BorderCurve));
            G.DrawPath(new Pen(_BorderColor), RoundRectangle.RoundRect(ClientRectangle, BorderCurve));

            // Draw the string from the specified 'Text' property on the header rectangle
            G.DrawString(Text, new Font("Trebuchet MS", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), new Rectangle(BorderCurve, BorderCurve - 4, Width - 1, 22), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });


            // Draws a rectangle at the bottom of the container
            G.FillRectangle(bBackground, 0, Height - 25, Width - 3, 22 - 2);
            G.DrawLine(new Pen(_BorderColor), 5, Height - 5, Width - 6, Height - 5);
            G.DrawLine(new Pen(_BorderColor), 7, Height - 4, Width - 7, Height - 4);

            G.DrawString(_TextBottom, new Font("Trebuchet MS", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), 5, Height - 23);

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();


            base.OnPaint(e);
        }

        #region Drag 

        //-----------------------------------Allow Form To Be Dragged ---------------------------------//

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
        //    {
        //        m.Result = (IntPtr)2;   // HTCLIENT
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        //-----------------------------------Allow Form To Be Dragged ---------------------------------//









        #endregion


    }
    #endregion
}
