using System;
using System.Drawing;

namespace Zeroit.Framework.Form.Thematic
{
    /// <summary>
    /// Class ControlButtons.
    /// </summary>
    [Serializable]
    public class CustomShadow
    {
        #region Old Shadow Code
        private int shadowBlur = 10;
        private int shadowSpread = -5;
        private int shadowV = 0;
        private int shadowH = 0;
        private Color shadowColor = Color.Black;
        private byte shadowOpacity = 150;
        #endregion

        #region Old Shadow Properties
        /// <summary>
        /// Gets or sets the shadow blur.
        /// </summary>
        /// <value>The shadow blur.</value>
        public int ShadowBlur
        {
            get { return shadowBlur; }
            set { shadowBlur = value;  }
        }

        /// <summary>
        /// Gets or sets the shadow spread.
        /// </summary>
        /// <value>The shadow spread.</value>
        public int ShadowSpread
        {
            get { return shadowSpread; }
            set { shadowSpread = value;  }
        }

        /// <summary>
        /// Gets or sets the shadow vertical location.
        /// </summary>
        /// <value>The shadow v.</value>
        public int ShadowV
        {
            get { return shadowV; }
            set { shadowV = value;  }
        }

        /// <summary>
        /// Gets or sets the shadow horizontal location.
        /// </summary>
        /// <value>The shadow h.</value>
        public int ShadowH
        {
            get { return shadowH; }
            set { shadowH = value;  }
        }

        public byte ShadowOpacity
        {
            get { return shadowOpacity; }
            set { shadowOpacity = value; }
        }

        public Color ShadowColor
        {
            get { return shadowColor; }
            set { shadowColor = value; }
        }

        #endregion

    }

}