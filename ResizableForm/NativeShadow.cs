using System;
using System.ComponentModel;
using System.Drawing;
using Zeroit.Framework.Form.ModernForm.Objects;

namespace Zeroit.Framework.Form.Thematic
{

    /// <summary>
    /// Class Shadow.
    /// </summary>
    [Serializable]
    public class NativeShadow
    {

        /// <summary>
        /// Gets or sets the type of the shadow.
        /// </summary>
        /// <value>The type of the shadow.</value>
        public ShadowType ShadowType { get; set; } = ShadowType.Default;

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        [Browsable(true)]
        [Category("Shadow")]
        public Color ShadowColor
        {
            get;
            set;
        } = Color.Black;

        /// <summary>
        /// The window opacity
        /// </summary>
        private float windowOpacity = 0.30F;
        /// <summary>
        /// Gets or sets the shadow opacity.
        /// </summary>
        /// <value>The shadow opacity.</value>
        public float WindowOpacity
        {
            get { return windowOpacity; }
            set
            {
                if (value > 1)
                {
                    value = 1;
                }

                if (value < 0)
                {
                    value = 0;
                }

                windowOpacity = value;


            }
        }

        /// <summary>
        /// Gets or sets the size of the border.
        /// </summary>
        /// <value>The size of the border.</value>
        public int BorderSize { get; set; } = 5;

    }

}