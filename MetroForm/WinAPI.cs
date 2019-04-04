// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="WinAPI.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.Form.Metro
{
    /// <summary>
    /// Class WinAPI.
    /// </summary>
    public class WinAPI
    {
        /// <summary>
        /// The wm activate
        /// </summary>
        public const int
        /* WM (Windows Messages) */
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_NCCALCSIZE = 0x83,
        WM_NCHITTEST = 0x84,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_SYSCOMMAND = 0x0112,
        WM_NCMOUSELEAVE = 0x02A2,
        WM_MOUSELEAVE = 0x02A3,
        /* HT (Hit Test) */
        HTTRANSPARENT = -1,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTCLOSE = 20,
        /* SC (?) */
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_RESTORE = 0xF120,
        /* Misc */
        GWL_EXSTYLE = -20,
        WS_EX_LAYERED = 0x80000,
        WS_EX_TRANSPARENT = 0x20;

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// Struct BLENDFUNCTION
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            /// <summary>
            /// The blend op
            /// </summary>
            public byte BlendOp;
            /// <summary>
            /// The blend flags
            /// </summary>
            public byte BlendFlags;
            /// <summary>
            /// The source constant alpha
            /// </summary>
            public byte SourceConstantAlpha;
            /// <summary>
            /// The alpha format
            /// </summary>
            public byte AlphaFormat;
        }

        /// <summary>
        /// The ulw colorkey
        /// </summary>
        public const Int32 ULW_COLORKEY = 0x00000001;
        /// <summary>
        /// The ulw alpha
        /// </summary>
        public const Int32 ULW_ALPHA = 0x00000002;
        /// <summary>
        /// The ulw opaque
        /// </summary>
        public const Int32 ULW_OPAQUE = 0x00000004;

        /// <summary>
        /// The ac source over
        /// </summary>
        public const byte AC_SRC_OVER = 0x00;
        /// <summary>
        /// The ac source alpha
        /// </summary>
        public const byte AC_SRC_ALPHA = 0x01;

        /// <summary>
        /// Updates the layered window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="hdcDst">The HDC DST.</param>
        /// <param name="pptDst">The PPT DST.</param>
        /// <param name="psize">The psize.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="pprSrc">The PPR source.</param>
        /// <param name="crKey">The cr key.</param>
        /// <param name="pblend">The pblend.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hDC">The h dc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="hObject">The h object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);
    }
}
