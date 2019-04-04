// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ColorSchema.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Form.Metro
{
    /// <summary>
    /// Class ColorSchema.
    /// </summary>
    public class ColorSchema
    {
        /// <summary>
        /// The schemata
        /// </summary>
        public static ColorSchema[] Schemata =
        {
            new ColorSchema(), //Light blue (Default)
            new ColorSchema()  //Blue
            {
                cPrimaryLightLightLight = Color.FromArgb(0xDC, 0xE7, 0xFF),
                cPrimaryLightLight = Color.FromArgb(0x94, 0xAD, 0xE5),
                cPrimaryLight = Color.FromArgb(0x5A, 0x7E, 0xD0),
                cPrimary = Color.FromArgb(0x31, 0x5D, 0xC1),
                cPrimaryDark = Color.FromArgb(0x0F, 0x3D, 0xA8),
                cPrimaryDarkDark = Color.FromArgb(0x0A, 0x2B, 0x76)
            },
            new ColorSchema() //Red
            {
                cPrimaryLightLightLight = Color.FromArgb(0xFD, 0xEA, 0xEA),
                cPrimaryLightLight = Color.FromArgb(0xFF, 0x84, 0x84),
                cPrimaryLight = Color.FromArgb(0xFE, 0x5B, 0x5B),
                cPrimary = Color.FromArgb(0xEA, 0x33, 0x33),
                cPrimaryDark = Color.FromArgb(0x9E, 0x02, 0x02),
                cPrimaryDarkDark = Color.FromArgb(0x9E, 0x02, 0x02)
            },
            new ColorSchema()  //Purple
            {
                cPrimaryLightLightLight = Color.FromArgb(0xEB, 0xDC, 0xFF),
                cPrimaryLightLight = Color.FromArgb(0xB6, 0x8E, 0xEA),
                cPrimaryLight = Color.FromArgb(0x8D, 0x53, 0xD9),
                cPrimary = Color.FromArgb(0x6F, 0x28, 0xCD),
                cPrimaryDark = Color.FromArgb(0x50, 0x0B, 0xAC),
                cPrimaryDarkDark = Color.FromArgb(0x37, 0x07, 0x75)
            }
        };

        /// <summary>
        /// The c primary light light light
        /// </summary>
        public Color
        cPrimaryLightLightLight = Color.FromArgb(0xEC, 0xF7, 0xFC),
        /// <summary>
        /// The c primary light light
        /// </summary>
        cPrimaryLightLight = Color.FromArgb(0x80, 0xCB, 0xEB),
        /// <summary>
        /// The c primary light
        /// </summary>
        cPrimaryLight = Color.FromArgb(0x4F, 0xC8, 0xFC),
        /// <summary>
        /// The c primary
        /// </summary>
        cPrimary = Color.FromArgb(0x41, 0xB1, 0xE1),
        /// <summary>
        /// The c primary dark
        /// </summary>
        cPrimaryDark = Color.FromArgb(0x27, 0x6B, 0x87),
        /// <summary>
        /// The c primary dark dark
        /// </summary>
        cPrimaryDarkDark = Color.FromArgb(0x08, 0x6F, 0x9E),

        /// <summary>
        /// The c secondary
        /// </summary>
        cSecondary = Color.FromArgb(0xFF, 0xFF, 0xFF),
        /// <summary>
        /// The c secondary dark
        /// </summary>
        cSecondaryDark = Color.FromArgb(0xF7, 0xF7, 0xF7),
        /// <summary>
        /// The c secondary dark mid
        /// </summary>
        cSecondaryDarkMid = Color.FromArgb(0xE0, 0xE0, 0xE0), //Blame MahApps for this, I usually follow the LL L M D DD format
        /// <summary>
        /// The c secondary dark dark
        /// </summary>
        cSecondaryDarkDark = Color.FromArgb(0xCC, 0xCC, 0xCC),
        /// <summary>
        /// The c secondary text dark
        /// </summary>
        cSecondaryTextDark = Color.FromArgb(0x00, 0x00, 0x00);

        /// <summary>
        /// The b caption
        /// </summary>
        public SolidBrush
        bCaption,
        /// <summary>
        /// The b window
        /// </summary>
        bWindow,
        /// <summary>
        /// The b caption title
        /// </summary>
        bCaptionTitle,
        /// <summary>
        /// The b caption controls
        /// </summary>
        bCaptionControls,
        /// <summary>
        /// The b caption controls hover
        /// </summary>
        bCaptionControlsHover,
        /// <summary>
        /// The b caption controls active
        /// </summary>
        bCaptionControlsActive,
        /// <summary>
        /// The b caption controls shadow
        /// </summary>
        bCaptionControlsShadow,

        /// <summary>
        /// The b control background
        /// </summary>
        bControlBackground,
        /// <summary>
        /// The b control background hover
        /// </summary>
        bControlBackgroundHover,
        /// <summary>
        /// The b control background active
        /// </summary>
        bControlBackgroundActive;

        /// <summary>
        /// The p border
        /// </summary>
        public Pen
        pBorder,
        /// <summary>
        /// The p caption controls
        /// </summary>
        pCaptionControls,
        /// <summary>
        /// The p caption controls active
        /// </summary>
        pCaptionControlsActive,
        /// <summary>
        /// The p caption controls shadow
        /// </summary>
        pCaptionControlsShadow,

        /// <summary>
        /// The p control border
        /// </summary>
        pControlBorder,
        /// <summary>
        /// The p control border focused
        /// </summary>
        pControlBorderFocused;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSchema"/> class.
        /// </summary>
        public ColorSchema()
        {
            Update();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
        {
            bCaption = new SolidBrush(cPrimary);
            bWindow = new SolidBrush(cSecondary);
            bCaptionTitle = new SolidBrush(cSecondary);
            bCaptionControls = new SolidBrush(cPrimaryDark);
            bCaptionControlsHover = new SolidBrush(cPrimaryLightLight);
            bCaptionControlsActive = new SolidBrush(cPrimaryDarkDark);
            bCaptionControlsShadow = new SolidBrush(cPrimaryLight);

            bControlBackground = new SolidBrush(cSecondaryDark);
            bControlBackgroundHover = new SolidBrush(cSecondaryDarkMid);
            bControlBackgroundActive = new SolidBrush(cPrimaryLightLightLight);

            pBorder = new Pen(cPrimary);
            pCaptionControls = new Pen(cPrimaryDark, 2f);
            pCaptionControlsActive = new Pen(cSecondary, 2f);
            pCaptionControlsShadow = new Pen(cPrimaryLight, 2f);

            pControlBorder = new Pen(cSecondaryDarkDark);
            pControlBorderFocused = new Pen(cPrimaryLight);
        }
    }
}
