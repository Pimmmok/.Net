using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using Introduction_to_.Net_Framework;

namespace Introduction_to_.Net_FrameworkWPF
{
    /// <summary>
    /// Class for reading data from the textbox.
    /// </summary>
    public class TextBoxCoordinateReader : IDataReader<Coordinate>
    {
        /// <summary>
        /// A field for a link to a textbox.
        /// </summary>
        private readonly TextBox _textBox;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="textBox"> A link to a textbox. </param>
        public TextBoxCoordinateReader(TextBox textBox)
        {
            _textBox = textBox;
        }

        /// <summary>
        /// Implementation of the data reading interface. Reading data from the textbox.
        /// </summary>
        /// <returns> Collection of read coordinates. </returns>
        public List<Coordinate> ReadData()
        {
            List<Coordinate> _coordinates = new List<Coordinate>();
              using StringReader reader = new StringReader(_textBox.Text);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] coordinatesOutput = line.Split(',');
                if (coordinatesOutput.Length == 2
                    && double.TryParse(coordinatesOutput[0], out double coordinateX)
                    && double.TryParse(coordinatesOutput[1], out double coordinateY))
                {
                    Coordinate coordinate = new Coordinate()
                    {
                        CoordinateX = coordinateX,
                        CoordinateY = coordinateY
                    };
                    _coordinates.Add(coordinate);
                    Console.WriteLine(line);
                }
                else
                {
                    _ = MessageBox.Show("Неверный формат введенных данных: " + line.ToString());
                }
            }
            return _coordinates;
        }
    }
}