// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ResizableForm.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Zeroit.Framework.Form.ModernForm.Forms;
using Zeroit.Framework.Form.ModernForm.Native;
using Zeroit.Framework.Form.ModernForm.Objects;

namespace Zeroit.Framework.Form.Thematic
{
    /// <summary>
    /// A class colletion for rendering styled form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ResizableForm : System.Windows.Forms.Form
    {
        #region ENUMS

        /// <summary>
        /// Enum ShadowNature
        /// </summary>
        public enum ShadowNature
        {
            /// <summary>
            /// The custom
            /// </summary>
            Custom,
            /// <summary>
            /// The native
            /// </summary>
            Native,
            /// <summary>
            /// The none
            /// </summary>
            None
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// The shadow type
        /// </summary>
        private ShadowNature typeOfShadow = ShadowNature.Native;

        /// <summary>
        /// The c grip
        /// </summary>
        private int cGrip = 10;      // Grip size
        /// <summary>
        /// The c caption
        /// </summary>
        private int cCaption = 32;   // Caption bar height;
        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;

        /// <summary>
        /// The header
        /// </summary>
        private Color header = Color.Transparent;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.RoyalBlue;

        /// <summary>
        /// The background color1
        /// </summary>
        private Color backgroundColor1 = Color.DarkSeaGreen;
        /// <summary>
        /// The background color
        /// </summary>
        private Color backgroundColor = Color.Orange;

        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = false;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 100;

        /// <summary>
        /// The custom shadow
        /// </summary>
        private CustomShadow customShadow = new CustomShadow();

        /// <summary>
        /// The shadow
        /// </summary>
        private NativeShadow nativeShadow = new NativeShadow();

        /// <summary>
        /// The iconsize
        /// </summary>
        private Size iconsize = new Size(22, 22);

        /// <summary>
        /// The themes
        /// </summary>
        private Themes themes = Themes.Spicylips;

        #region Include in Private Field (Color Blend)
        /// <summary>
        /// The blend positions
        /// </summary>
        private float[] blendPositions = new float[11];

        /// <summary>
        /// The color blends
        /// </summary>
        private Color[] colorBlends = new Color[11];

        /// <summary>
        /// The gamma correction
        /// </summary>
        private bool gammaCorrection = false;

        /// <summary>
        /// The show grip
        /// </summary>
        private bool showGrip = false;

        /// <summary>
        /// The wrap mode
        /// </summary>
        private WrapMode wrapMode = WrapMode.Clamp;

        /// <summary>
        /// The enable color blend
        /// </summary>
        private bool enableColorBlend = false;

        /// <summary>
        /// The angle
        /// </summary>
        private float angle = 90f;

        /// <summary>
        /// The blend rotate
        /// </summary>
        private float blendRotate = 0f;

        /// <summary>
        /// The handle draw dash style
        /// </summary>
        private DashStyle handleDrawDashStyle = DashStyle.Dot;

        /// <summary>
        /// The handle border width
        /// </summary>
        private int handleBorderWidth = 1;

        /// <summary>
        /// The handle color border
        /// </summary>
        private Color handleColorBorder = Color.Black;

        /// <summary>
        /// The grip color
        /// </summary>
        private Color gripColor = Color.White;

        /// <summary>
        /// Enum representing the rendering type
        /// </summary>
        public enum RenderMode
        {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The gradient
            /// </summary>
            Gradient,
            /// <summary>
            /// The hatch
            /// </summary>
            Hatch

        }

        /// <summary>
        /// Enum representing the alignment
        /// </summary>
        public enum Align
        {
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The center
            /// </summary>
            Center,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        /// <summary>
        /// The draw mode
        /// </summary>
        private RenderMode _drawMode = RenderMode.Solid;

        /// <summary>
        /// The text align
        /// </summary>
        private Align _textAlign = Align.Left;

        /// <summary>
        /// The icon alignment
        /// </summary>
        private Align _iconAlignment = Align.Left;

        /// <summary>
        /// The drawheader region
        /// </summary>
        private bool drawheaderRegion = false;


        #endregion

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the type of the shadow.
        /// </summary>
        /// <value>The type of the shadow.</value>
        public ShadowNature ShadowKind
        {
            get { return typeOfShadow; }
            set
            {
                typeOfShadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the control box spacing.
        /// </summary>
        /// <value>The control box spacing.</value>
        public int ControlBoxSpacing
        {
            get;
            set;
        } = 15;

        #region Include in Public Properties (Color Blend)        
        /// <summary>
        /// Gets or sets the angle for color blending.
        /// </summary>
        /// <value>The angle.</value>
        [Browsable(true)]
        [Category("Color Blend")]
        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable color blend.
        /// </summary>
        /// <value><c>true</c> if enable color blend; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Color Blend")]
        public bool EnableColorBlend
        {
            get { return enableColorBlend; }
            set
            {
                enableColorBlend = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the wrap mode.
        /// </summary>
        /// <value>The wrap mode.</value>
        [Browsable(true)]
        [Category("Color Blend")]
        public WrapMode WrapMode
        {
            get { return wrapMode; }
            set
            {
                wrapMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to  use gamma correction for color blending.
        /// </summary>
        /// <value><c>true</c> if gamma correction; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Color Blend")]
        public bool GammaCorrection
        {
            get { return gammaCorrection; }
            set
            {
                gammaCorrection = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color blends.
        /// </summary>
        /// <value>The color blends.</value>
        [Browsable(true)]
        [Category("Color Blend")]
        public Color[] ColorBlends
        {
            get { return colorBlends; }
            set
            {
                colorBlends = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the blend positions.
        /// </summary>
        /// <value>The blend positions.</value>
        [Browsable(true)]
        [Category("Color Blend")]
        public float[] BlendPositions
        {
            get { return blendPositions; }
            set
            {
                for (int x = 1; x <= 10; x++)
                {
                    if (blendPositions[x] > 1.0f)
                    {
                        blendPositions[x] = 1.0f;
                    }
                }

                #region Old Code
                //if (blendPositions[0] > 1.0f)
                //{
                //    blendPositions[0] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[1] > 1.0f)
                //{
                //    blendPositions[1] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[2] > 1.0f)
                //{
                //    blendPositions[2] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[3] > 1.0f)
                //{
                //    blendPositions[3] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[4] > 1.0f)
                //{
                //    blendPositions[4] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[5] > 1.0f)
                //{
                //    blendPositions[5] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[6] > 1.0f)
                //{
                //    blendPositions[6] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[7] > 1.0f)
                //{
                //    blendPositions[7] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[8] > 1.0f)
                //{
                //    blendPositions[8] = 1.0f;
                //    Invalidate();
                //}

                //if (blendPositions[9] > 1.0f)
                //{
                //    blendPositions[9] = 1.0f;
                //    Invalidate();
                //} 
                #endregion

                blendPositions = value;

                Invalidate();
            }
        }

        #endregion

        #region HatchBrush

        /// <summary>
        /// The hatch brushgradient1
        /// </summary>
        private Color hatchBrushgradient1 = Color.Black;
        /// <summary>
        /// The hatch brushgradient2
        /// </summary>
        private Color hatchBrushgradient2 = Color.Transparent;

        /// <summary>
        /// The hatch brush type
        /// </summary>
        private HatchStyle hatchBrushType = HatchStyle.ForwardDiagonal;

        #endregion


        #region HatchBrush Property        
        /// <summary>
        /// Gets or sets the color gradient hatch brush.
        /// </summary>
        /// <value>The color hatch brushgradient1.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color ColorHatchBrushgradient1
        {
            get { return hatchBrushgradient1; }
            set
            {
                hatchBrushgradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color gradient hatch brush.
        /// </summary>
        /// <value>The color hatch brushgradient2.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color ColorHatchBrushgradient2
        {
            get { return hatchBrushgradient2; }
            set
            {
                hatchBrushgradient2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hatch brush.
        /// </summary>
        /// <value>The hatch brush.</value>
        [Browsable(true)]
        [Category("Design")]
        public HatchStyle HatchStyle
        {
            get
            {
                return hatchBrushType;
            }

            set
            {
                hatchBrushType = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether to enable automatic animation.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        public Themes Theme
        {
            get { return themes; }
            set
            {
                themes = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the style of the size grip to display in the lower-right corner of the form.
        /// </summary>
        /// <value>The size grip style.</value>
        public new SizeGripStyle SizeGripStyle
        {
            get { return base.SizeGripStyle; }
            set
            {
                base.SizeGripStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the icon alignment.
        /// </summary>
        /// <value>The icon Align.</value>
        [Browsable(true)]
        [Category("Window Style")]
        public Align IconAlign
        {
            get { return _iconAlignment; }
            set
            {
                _iconAlignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>The size of the icon.</value>
        [Browsable(true)]
        [Category("Window Style")]
        public Size IconSize
        {
            get { return iconsize; }
            set
            {
                iconsize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text Align.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Align TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rendering type.
        /// </summary>
        /// <value>The draw mode.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public RenderMode DrawMode
        {
            get { return _drawMode; }
            set
            {
                _drawMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the handle draw style.
        /// </summary>
        /// <value>The handle draw style.</value>
        [Browsable(true)]
        [Category("Window Style")]
        public DashStyle HandleDrawStyle
        {
            get { return handleDrawDashStyle; }
            set
            {
                handleDrawDashStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color1.
        /// </summary>
        /// <value>The background color1.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color BackgroundColor1
        {
            get { return backgroundColor1; }
            set
            {
                backgroundColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the header.
        /// </summary>
        /// <value>The color of the header.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color HeaderColor
        {
            get { return header; }
            set
            {
                header = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the handle's border.
        /// </summary>
        /// <value>The handle border color.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color HandleColorBorder
        {
            get
            {
                return handleColorBorder;
            }

            set
            {
                handleColorBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the grip.
        /// </summary>
        /// <value>The color of the grip.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public Color GripColor
        {
            get { return gripColor; }
            set { gripColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        [Browsable(true)]
        [Category("Behavior")]
        public int TimerInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the grip.
        /// </summary>
        /// <value>The size of the grip.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public int GripSize
        {
            get { return cGrip; }
            set
            {
                cGrip = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the caption.
        /// </summary>
        /// <value>The height of the caption.</value>
        [Browsable(true)]
        [Category("Window Style")]
        public int CaptionHeight
        {
            get { return cCaption; }
            set
            {
                cCaption = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the handle's border.
        /// </summary>
        /// <value>The width of the handle's border.</value>
        [Browsable(true)]
        [Category("Appearance")]
        public int HandleBorderWidth
        {
            get { return handleBorderWidth; }
            set
            {
                handleBorderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable custom shadow.
        /// </summary>
        /// <value><c>true</c> if custom shadow; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Shadow")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NativeShadow NativeShadow
        {
            get { return nativeShadow; }
            set
            {
                nativeShadow = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether to enable custom shadow.
        /// </summary>
        /// <value><c>true</c> if custom shadow; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Shadow")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomShadow CustomShadow
        {
            get { return customShadow; }
            set
            {
                customShadow = value;
                Invalidate();
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether to draw head region.
        /// </summary>
        /// <value><c>true</c> if draw head region; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Window Style")]
        public bool DrawHeadRegion
        {
            get { return drawheaderRegion; }
            set { drawheaderRegion = value; Invalidate(); }
        }



        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ResizableForm" /> class.
        /// </summary>
        public ResizableForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Font = new Font("Segoe UI", 10);

            blendPositions[0] = 0.000f;
            blendPositions[1] = blendRotate + 0.100f;
            blendPositions[2] = blendRotate + 0.200f;
            blendPositions[3] = blendRotate + 0.300f;
            blendPositions[4] = blendRotate + 0.400f;
            blendPositions[5] = blendRotate + 0.500f;
            blendPositions[6] = blendRotate + 0.600f;
            blendPositions[7] = blendRotate + 0.700f;
            blendPositions[8] = blendRotate + 0.800f;
            blendPositions[9] = blendRotate + 0.900f;
            blendPositions[10] = blendRotate + 1.00f;

            colorBlends[0] = Color.Red;
            colorBlends[1] = Color.Yellow;
            colorBlends[2] = Color.Lime;
            colorBlends[3] = Color.Cyan;
            colorBlends[4] = Color.Blue;
            colorBlends[5] = Color.Violet;
            colorBlends[6] = Color.LightGray;
            colorBlends[7] = Color.Indigo;
            colorBlends[8] = Color.IndianRed;
            colorBlends[9] = Color.DarkOrange;
            colorBlends[10] = Color.Turquoise;

            //---------------Memory Management----------------//

            #region Timer Utility


            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion

            //---------------Memory Management----------------//
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.angle + 1 > 360f)
                this.angle = 0;
            else
            {
                this.angle++;
                Invalidate();
            }

            if(this.blendRotate + 0.01f > 1)
            {
                blendRotate = 0f;
            }

            else
            {
                blendRotate += 0.01f;
                Invalidate();
            }
                
        }

        /// <summary>
        /// Handles the Load event of the ResizableForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ResizableForm_Load(object sender, EventArgs e)
        {

            switch (ShadowKind)
            {
                case ShadowNature.Custom:

                    #region Old Show Code ( Has Performance Issues )

                    if (!DesignMode)
                    {
                        ZeroitDropshadow AddShadow = new ZeroitDropshadow(this);

                        #region New Idea

                        AddShadow.DrawShadow = true;
                        AddShadow.ShadowBlur = CustomShadow.ShadowBlur;
                        AddShadow.ShadowSpread = CustomShadow.ShadowSpread;
                        AddShadow.ShadowV = CustomShadow.ShadowV;
                        AddShadow.ShadowH = CustomShadow.ShadowH;
                        AddShadow.ShadowColor = Color.FromArgb(CustomShadow.ShadowOpacity, CustomShadow.ShadowColor);
                        AddShadow.ShadowOpacity = CustomShadow.ShadowOpacity;
                        AddShadow.ActivateShadow();

                        #endregion
                        
                    }
                    #endregion

                    break;
                case ShadowNature.Native:

                    #region New Shadow Code ( Improved Performance )

                    if (!DesignMode)
                    {
                        if (Location.IsEmpty) CenterToScreen();

                        //Check if we can use the aero shadow
                        if ((NativeShadow.ShadowType.Equals(ShadowType.AeroShadow) || NativeShadow.ShadowType.Equals(ShadowType.Default)) &&
                            DwmNative.ExtendFrameIntoClientArea(this, 0, 0, 0, 1))
                        {
                            //We can! Tell windows to allow the rendering to happen on our borderless form
                            DwmNative.AllowRenderInBorderless(this);
                        }
                        else if (NativeShadow.ShadowType.Equals(ShadowType.Default) || NativeShadow.ShadowType.Equals(ShadowType.FlatShadow))
                        {
                            //No aero for us! We must create the typical flat shadow.
                            new ShadowForm()
                            {
                                ShadowColor = NativeShadow.ShadowColor,
                                WindowOpacity = NativeShadow.WindowOpacity,
                                BorderSize = NativeShadow.BorderSize
                            }.Show(this);
                        }

                    }

                    #endregion

                    break;
                case ShadowNature.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            

            
        }

        #region Custom Drag Form Code

        #region Allow any control to drag  

        /// <summary>
        /// The last click
        /// </summary>
        public Point lastClick;


        /// <summary>
        /// Handles the Paint event of the DragForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void DragForm_Paint(object sender, PaintEventArgs e)
        {
            //Draws a border to make the Form stand out
            //Just done for appearance, not necessary


            Pen p = new Pen(Color.Black, 1);
            e.Graphics.DrawRectangle(p, 0, 0, Width - 1, this.Height - 1);
            p.Dispose();
        }


        /// <summary>
        /// Add a MouseDown Event and set it to this eventhandler in the Form's constructor
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void DragForm_MouseDown(object sender, MouseEventArgs e)
        {

            lastClick = new Point(e.X, e.Y); //We'll need this for when the Form starts to move

        }


        /// <summary>
        /// Add a MouseMove Event and set it to this eventhandler in the Form's constructor
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void DragForm_MouseMove(object sender, MouseEventArgs e)
        {

            //Point newLocation = new Point(e.X - lastE.X, e.Y - lastE.Y);
            if (e.Button == MouseButtons.Left) //Only when mouse is clicked
            {
                //Move the Form the same difference the mouse cursor moved;
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }



        #endregion

        #endregion

        #endregion

        #region Overrides


        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// </exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            timer.Interval = interval;
            

            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(ThemeManager.GetColor(Theme,BackColor));
            
            Rectangle gripRect = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            Rectangle border = new Rectangle(0, 0, Width - 1, Height - 1);
            
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);

            #region Adding Color Blend
            // Create a new LinearGradientBrush using the rectangle, 
            // DarkSeaGreen and Orange. and 90-degree angle.


            Rectangle linearRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            LinearGradientBrush brush = new LinearGradientBrush(linearRectangle, backgroundColor, backgroundColor1, angle, true);

            if (enableColorBlend)
            {

                ColorBlend colorBlend = new ColorBlend();

                Single[] blendPoints = new Single[]
                {
                blendPositions[0],
                blendPositions[1],
                blendPositions[2],
                blendPositions[3],
                blendPositions[4],
                blendPositions[5],
                blendPositions[6],
                blendPositions[7],
                blendPositions[8],
                blendPositions[9],
                blendPositions[10]

                };


                Color[] blendcolors = new System.Drawing.Color[]
                    {
                colorBlends[0],
                colorBlends[1],
                colorBlends[2],
                colorBlends[3],
                colorBlends[4],
                colorBlends[5],
                colorBlends[6],
                colorBlends[7],
                colorBlends[8],
                colorBlends[9],
                colorBlends[10]
                    };

                colorBlend.Positions = blendPoints;

                colorBlend.Colors = blendcolors;

                brush.InterpolationColors = colorBlend;
                brush.GammaCorrection = gammaCorrection;


            }
            
            #endregion


            Pen drawHandleRegion = new Pen(handleColorBorder, handleBorderWidth);
            drawHandleRegion.DashStyle = handleDrawDashStyle;
            
            switch (_drawMode)
            {
                case RenderMode.Solid:
                    g.FillRectangle(new SolidBrush(ThemeManager.GetColor(Theme, BackColor)), linearRectangle);
                    g.DrawRectangle(new Pen(borderColor, borderWidth), border);
                    break;
                case RenderMode.Gradient:
                    g.FillRectangle(brush, linearRectangle);
                    g.DrawRectangle(new Pen(borderColor, borderWidth), border);

                    break;
                case RenderMode.Hatch:

                    #region HatchBrush Paint
                    HatchBrush HB = new HatchBrush(HatchStyle, hatchBrushgradient1, hatchBrushgradient2);
                    g.FillRectangle(HB, linearRectangle);
                    #endregion

                    //g.FillRectangle(brush, linearRectangle);

                    g.DrawRectangle(new Pen(borderColor, borderWidth), border);

                    break;
                default:
                    break;
            }

            g.FillRectangle(new SolidBrush(header), rc);

            if (drawheaderRegion)
            {
                g.DrawRectangle(drawHandleRegion, rc);
            }

            StringFormat stf = new StringFormat();
            stf.Alignment = StringAlignment.Near;

            //g.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(5,5,Width, cCaption),stf);

            switch (TextAlign)
            {
                case Align.Left:
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(35 + ((iconsize.Width + iconsize.Height)/20), 7));

                    break;
                case Align.Center:
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(Width / 2, 7));

                    break;
                case Align.Right:
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(Width - 45, 7));

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (IconAlign)
            {
                case Align.Left:
                    if(ShowIcon)
                    g.DrawIcon(Icon, new Rectangle(10, 4, iconsize.Width,iconsize.Height));

                    break;
                case Align.Center:
                    if (ShowIcon)
                        g.DrawIcon(Icon, new Rectangle((Width/2) - 20, 4, iconsize.Width, iconsize.Height));

                    break;
                case Align.Right:
                    if (ShowIcon)
                        g.DrawIcon(Icon, new Rectangle(Width - 65, 4, iconsize.Width, iconsize.Height));

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (SizeGripStyle)
            {
                case SizeGripStyle.Auto:
                    ControlPaint.DrawSizeGrip(g, gripColor, gripRect);

                    break;
                case SizeGripStyle.Show:
                    ControlPaint.DrawSizeGrip(g, gripColor, gripRect);

                    break;
                case SizeGripStyle.Hide:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
            if(ControlBox)
            {
                int spacing = ControlBoxSpacing;

                for (int i = 0; i < ControlBoxButtons.Count; i++)
                {


                    if (ControlBoxButtons[i].UseImage)
                    {
                        g.DrawImage(ControlBoxButtons[i].Image, Width - spacing - (ControlBoxButtons[i].ImageSize.Width), 4);
                        spacing += ControlBoxButtons[i].ImageSize.Width + ControlBoxSpacing;
                        

                    }
                    else
                    {
                        SizeF TS = g.MeasureString(ControlBoxButtons[i].TextSymbol, ControlBoxButtons[i].Font);
                        g.DrawString(ControlBoxButtons[i].TextSymbol, ControlBoxButtons[i].Font, new SolidBrush(ControlBoxButtons[i].SymbolColor), new PointF(this.Width - spacing - TS.Width, 7));

                        spacing += (int)TS.Width + ControlBoxSpacing;

                    }



                }
                
            }
            

            brush.Dispose();
            drawHandleRegion.Dispose();
            
        }


        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }


        #region Size Grip Code (Slows program)

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }


        #endregion

        #region Not relevant to the forms drag ability but however performs a different task

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterParent;
            base.OnLoad(e);


        }

        #endregion

        #endregion
        
        #region New Concept


        /// <summary>
        /// Gets or sets the control box buttons.
        /// </summary>
        /// <value>The control box buttons.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ControlButtons> ControlBoxButtons
        {
            get;set;
        } = new List<ControlButtons>();

        #endregion

    }


    
}

