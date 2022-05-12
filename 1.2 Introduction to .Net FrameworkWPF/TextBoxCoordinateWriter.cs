using Introduction_to_.Net_Framework;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Introduction_to_.Net_FrameworkWPF
{
    /// <summary>
    /// Textbox writing class.
    /// </summary>
    public class TextBoxCoordinateWriter : IDataWriter<Coordinate>
    {
        /// <summary>
        /// A field for a link to a textbox.
        /// </summary>
        private readonly TextBox _textBox;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="textBox"> A link to a textbox. </param>
        public TextBoxCoordinateWriter(TextBox textBox)
        {
            this._textBox = textBox;
        }

        /// <summary>
        /// Implementation of the recorded data interface. Writing data to the textbox.
        /// </summary>
        /// <param name="coordinates"> Сollection of recorded coordinates. </param>
        public void WriteData(IList<Coordinate> coordinates)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Coordinate coordinate in coordinates)
            {
                stringBuilder = stringBuilder.AppendLine(coordinate.ToString());
            }
            _textBox.Text = stringBuilder.ToString();
        }
    }
}
