// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="FormUtils.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Zeroit.Framework.Form.ModernForm.Objects.Interaction;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Utils
{
    /// <summary>
    /// Class FormUtils.
    /// </summary>
    class FormUtils
    {
        /// <summary>
        /// Converts to resize result.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>ResizeResult.</returns>
        public static ResizeResult ConvertToResizeResult(WindowHitTestResult r)
        {
            switch (r) {
                case WindowHitTestResult.Up:
                    return ResizeResult.Top;
                case WindowHitTestResult.UpLeft:
                    return ResizeResult.TopLeft;
                case WindowHitTestResult.Left:
                    return ResizeResult.Left;
                case WindowHitTestResult.BottomLeft:
                    return ResizeResult.BottomLeft;
                case WindowHitTestResult.Bottom:
                    return ResizeResult.Bottom;
                case WindowHitTestResult.BottomRight:
                    return ResizeResult.BottomRight;
                case WindowHitTestResult.Right:
                    return ResizeResult.Right;
                case WindowHitTestResult.UpRight:
                    return ResizeResult.TopRight;
                default:
                    return ResizeResult.Client;
            }
        }

        /// <summary>
        /// Converts the range.
        /// </summary>
        /// <param name="originalStart">The original start.</param>
        /// <param name="originalEnd">The original end.</param>
        /// <param name="newStart">The new start.</param>
        /// <param name="newEnd">The new end.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        private static int ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, int value)
        {
            var scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }

        /// <summary>
        /// Enum ResizeResult
        /// </summary>
        public enum ResizeResult
        {
            /// <summary>
            /// The client
            /// </summary>
            Client = 1,
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 7,
            /// <summary>
            /// The top
            /// </summary>
            Top = 8,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight = 9,
            /// <summary>
            /// The left
            /// </summary>
            Left = 10,
            /// <summary>
            /// The right
            /// </summary>
            Right = 11,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom = 15,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 16,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 17,
        }


        /// <summary>
        /// Hits the test to cursor.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>Cursor.</returns>
        public static Cursor HitTestToCursor(ResizeResult result)
        {
            if ((result == ResizeResult.Left) || result == ResizeResult.Right)
                return Cursors.SizeWE;
            if (result == ResizeResult.Bottom || result == ResizeResult.Top)
                return Cursors.SizeNS;
            if (result == ResizeResult.BottomLeft || result == ResizeResult.TopRight)
                return Cursors.SizeNESW;
            if (result == ResizeResult.BottomRight || result == ResizeResult.TopLeft)
                return Cursors.SizeNWSE;
            return Cursors.Default;
        }

        /// <summary>
        /// Starts the form resize from edge.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <param name="result">The result.</param>
        /// <param name="c">The c.</param>
        public static void StartFormResizeFromEdge(System.Windows.Forms.Form f, ResizeResult result, Control c = null)
        {
            var minimum = f is Zeroit.Framework.Form.ModernForm.Forms.ModernForm modernForm ? modernForm.MinimumSize : f.MinimumSize;
            var maximum = f is Zeroit.Framework.Form.ModernForm.Forms.ModernForm form ? form.MaximumSize : f.MaximumSize;
            //Cursor.Clip = Screen.GetWorkingArea(f);
            var curLoc = f.PointToClient(Cursor.Position);
            var fLoc = new Point(f.Left, f.Top);
            var w = f.Width;
            var h = f.Height;
            var resultEnum = ((ResizeResult)result);

            Action<Object, MouseEventArgs> mouseMove = (s, e) => {


                if (f.WindowState != FormWindowState.Maximized) {
                    var changedSize = (new Size(curLoc) - new Size(e.Location)).Width;
                    var changedSizeH = (new Size(curLoc) - new Size(e.Location)).Height;
                    f.Cursor = HitTestToCursor(result);
                    switch (resultEnum) {
                        case ResizeResult.Left:
                            if (curLoc.X <= Zeroit.Framework.Form.ModernForm.Forms.ModernForm.SizingBorder && ((f.Width + changedSize) >= minimum.Width)) {
                                f.Left -= changedSize;
                                fLoc = new Point(f.Left, f.Top);
                                f.Width += changedSize;
                                f.Update();
                            }
                            break;
                        case ResizeResult.Right:
                            if (curLoc.X >= minimum.Width - Zeroit.Framework.Form.ModernForm.Forms.ModernForm.SizingBorder) {
                                f.Left = fLoc.X;
                                curLoc = f.PointToClient(Cursor.Position);
                                f.Width = w - changedSize;
                                f.Update();
                                w = f.Width;
                            }
                            break;
                        case ResizeResult.Bottom:
                            if (curLoc.Y >= minimum.Height - Zeroit.Framework.Form.ModernForm.Forms.ModernForm.SizingBorder) {
                                f.Top = fLoc.Y;
                                curLoc = f.PointToClient(Cursor.Position);
                                f.Height = h - changedSizeH;
                                f.Update();
                                h = f.Height;
                            }
                            break;
                        case ResizeResult.BottomLeft:
                            if (curLoc.X <= Zeroit.Framework.Form.ModernForm.Forms.ModernForm.SizingBorder && curLoc.Y >= minimum.Height - Zeroit.Framework.Form.ModernForm.Forms.ModernForm.SizingBorder && ((f.Width + changedSize) >= minimum.Width)) {
                                var ww = e.Location.X - f.Left;
                                var hh = e.Location.Y - f.Bottom;

                                f.Height = f.Bottom + hh;
                                f.Left -= changedSize;
                                fLoc = new Point(f.Left, f.Top);
                                f.Width += changedSize;

                                f.Update();

                            }
                            break;

                        case ResizeResult.BottomRight:
                            var ww2 = e.Location.X - f.Right;
                            var hh2 = e.Location.Y - f.Bottom;

                            f.Height = f.Bottom + hh2;

                            fLoc = new Point(f.Left, f.Top);
                            f.Width += f.Left + ww2;

                            f.Update();

                            break;
                    }
                }
            };
            MouseEventHandler invoke = mouseMove.Invoke;
            f.MouseMove += invoke;
            MouseEventHandler invokeCMove = (s, e) => {
                var pt = f.PointToClient(((Control)s).PointToScreen(e.Location));
                var x = pt.X;
                var y = pt.Y;


                invoke(f, new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta));
            };
            if (c != null) c.MouseMove += invokeCMove;



            MouseEventHandler invoke2 = null;

            invoke2 = (s, e) => {
                if (c != null) c.MouseMove -= invokeCMove;
                if (c != null) c.MouseUp -= invoke2;
                f.MouseUp -= invoke2;
                f.MouseMove -= invoke;
                f.Update();
                //Cursor.Clip = new Rectangle();
            };

            f.MouseUp += invoke2;
            if (c != null) c.MouseUp += invoke2;


        }

        /// <summary>
        /// Starts the form drag from titlebar.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <param name="c">The c.</param>
        public static void StartFormDragFromTitlebar(System.Windows.Forms.Form f, Control c = null)
        {
            //Cursor.Clip = Screen.GetWorkingArea(f);
            var startCursorPosition = (c ?? f).PointToClient(Cursor.Position);
            Action<Object, MouseEventArgs> mouseMove = (Object s, MouseEventArgs e) => {
                if (f.WindowState == FormWindowState.Maximized) {
                    var beforeW = (f is Zeroit.Framework.Form.ModernForm.Forms.ModernForm ? (((Zeroit.Framework.Form.ModernForm.Forms.ModernForm)f).TextBarRectangle.Width) : f.Width);
                    f.WindowState = FormWindowState.Normal;
                    var afterW = (f is Zeroit.Framework.Form.ModernForm.Forms.ModernForm ? (((Zeroit.Framework.Form.ModernForm.Forms.ModernForm)f).TextBarRectangle.Width) : f.Width);
                    startCursorPosition = new Point(ConvertRange(0, beforeW, 0, afterW, startCursorPosition.X), startCursorPosition.Y);
                }
                f.Location += (new Size(e.Location) - new Size(startCursorPosition));
            };
            MouseEventHandler invoke = mouseMove.Invoke;
            (c ?? f).MouseMove += invoke;
            (c ?? f).MouseUp += (s, e) => {
                (c ?? f).MouseMove -= invoke;

                //Cursor.Clip = new Rectangle();
            };
        }


    }
}
