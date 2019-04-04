using System;
using System.Drawing;

namespace Zeroit.Framework.Form.Thematic
{
    /// <summary>
    /// Class ControlButtons.
    /// </summary>
    public class ControlButtons
    {
        /// <summary>
        /// The image
        /// </summary>
        Image image = null;
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return image; }
            set
            {
                if (value == null)
                {
                    ImageSize = Size.Empty;
                }
                else
                {
                    ImageSize = value.Size;
                }

                image = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text symbol.
        /// </summary>
        /// <value>The text symbol.</value>
        public String TextSymbol
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get;
            set;
        } = new Font("Tahoma", 10);

        /// <summary>
        /// Gets or sets a value indicating whether [use image].
        /// </summary>
        /// <value><c>true</c> if [use image]; otherwise, <c>false</c>.</value>
        public bool UseImage
        {
            get;
            set;
        } = false;


        /// <summary>
        /// Gets or sets the color of the symbol.
        /// </summary>
        /// <value>The color of the symbol.</value>
        public Color SymbolColor
        {
            get;
            set;
        } = Color.Black;



        /// <summary>
        /// Initializes a new instance of the <see cref="ControlButtons"/> class.
        /// </summary>
        public ControlButtons()
        {

        }

    }

}