// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-24-2018
// ***********************************************************************
// <copyright file="ZeroitThemeContainer.cs" company="Zeroit Dev Technologies">
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
    #region  ZeroitMarginForm

    /// <summary>
    /// A class collection for rendering a theme container.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    public class ZeroitMarginForm : ContainerControl
    {


        #region  Variables

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
        private int BorderCurve = 7;
        /// <summary>
        /// The state
        /// </summary>
        protected MouseState State;
        /// <summary>
        /// The has shown
        /// </summary>
        private bool HasShown;
        /// <summary>
        /// The header rect
        /// </summary>
        private Rectangle HeaderRect;


        #endregion

        #region  Enums

        /// <summary>
        /// Enum representing the MouseState
        /// </summary>
        public enum MouseState
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

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the borders.
        /// </summary>
        /// <value>The borders.</value>
        public int Borders
        {
            get { return BorderCurve; }
            set
            {
                if (value > 7)
                {
                    BorderCurve = 7;
                    this.Invalidate();
                }

                BorderCurve = value;
                this.Invalidate();
            }
        }


        /// <summary>
        /// The sizable
        /// </summary>
        private bool _Sizable = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMarginForm" /> is sizable.
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
        private FormStartPosition _StartPosition;

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
                InitializeMessages();

                if (_IsParentForm)
                {
                    this.ParentForm.FormBorderStyle = FormBorderStyle.None;
                    this.ParentForm.TransparencyKey = Color.Fuchsia;

                    if (!DesignMode)
                    {
                        ParentForm.Shown += FormShown;
                    }
                }
                Parent.BackColor = BackColor;
                Parent.MinimumSize = new Size(126, 39);
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

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                SetState(MouseState.Down);
            }
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
            {
                if (HeaderRect.Contains(e.Location))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[0]);
                }
                else if (_Sizable && !(Previous == 0))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[Previous]);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

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

        #endregion

        #region  Mouse & Size

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="current">The current.</param>
        private void SetState(MouseState current)
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

                SetState(MouseState.Over);
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
        /// Creates a handle for the control.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMarginForm" /> class.
        /// </summary>
        public ZeroitMarginForm()
        {
            SetStyle((ControlStyles)(139270), true);
            Dock = DockStyle.Fill;
            MoveHeight = 25;
            Padding = new Padding(3, 28, 3, 28);
            Font = new Font("Segoe UI", 8, FontStyle.Regular);
            ForeColor = Color.FromArgb(142, 142, 142);
            //BackColor = Color.FromArgb(246, 246, 246);
            DoubleBuffered = true;
        }

        /// <summary>
        /// The bottom and upper color
        /// </summary>
        private Color bottomAndUpperColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the bottom and upper.
        /// </summary>
        /// <value>The color of the bottom and upper.</value>
        public Color BottomAndUpperColor
        {
            get { return bottomAndUpperColor; }
            set
            {
                bottomAndUpperColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Color TransparencyKey = this.ParentForm.TransparencyKey;

            G.SmoothingMode = SmoothingMode.Default;
            G.Clear(TransparencyKey);

            // Draw the container borders
            G.FillPath(new SolidBrush(bottomAndUpperColor), RoundRectangle.RoundRect(ClientRectangle, BorderCurve));
            // Draw a rectangle in which the controls should be added on
            G.FillPath(new SolidBrush(BackColor), RoundRectangle.RoundRect(new Rectangle(2, 20, Width - 5, Height - 42), BorderCurve));

            // Patch the header with a rectangle that has a curve so its border will remain within container bounds
            G.FillPath(new SolidBrush(bottomAndUpperColor), RoundRectangle.RoundRect(new Rectangle(2, 2, (int)(Width / 2 + 2), 16), BorderCurve));
            G.FillPath(new SolidBrush(bottomAndUpperColor), RoundRectangle.RoundRect(new Rectangle((int)(Width / 2 - 3), 2, (int)(Width / 2), 16), BorderCurve));
            // Fill the header rectangle below the patch
            G.FillRectangle(new SolidBrush(bottomAndUpperColor), new Rectangle(2, 15, Width - 5, 10));

            // Increase the thickness of the container borders
            G.DrawPath(new Pen(bottomAndUpperColor), RoundRectangle.RoundRect(new Rectangle(2, 2, Width - 5, Height - 5), BorderCurve));
            G.DrawPath(new Pen(bottomAndUpperColor), RoundRectangle.RoundRect(ClientRectangle, BorderCurve));

            // Draw the string from the specified 'Text' property on the header rectangle
            G.DrawString(Text, new Font("Trebuchet MS", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), new Rectangle(BorderCurve, BorderCurve - 4, Width - 1, 22), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });


            // Draws a rectangle at the bottom of the container
            G.FillRectangle(new SolidBrush(bottomAndUpperColor), 0, Height - 25, Width - 3, 22 - 2);
            G.DrawLine(new Pen(bottomAndUpperColor), 5, Height - 5, Width - 6, Height - 5);
            G.DrawLine(new Pen(bottomAndUpperColor), 7, Height - 4, Width - 7, Height - 4);

            G.DrawString(_TextBottom, new Font("Trebuchet MS", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), 5, Height - 23);

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}
