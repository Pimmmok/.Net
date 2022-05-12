using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Introduction_to_.Net_Framework;
using Microsoft.Win32;

namespace Introduction_to_.Net_FrameworkWPF
{
    /// <summary>
    /// Class for reading data from the file.
    /// </summary>
    internal class FileCoordinateWPFReaderWpfProgram : IDataReader<Coordinate>
    {
        /// <summary>
        /// Implementation of the data reading interface. Reading data from the file.
        /// </summary>
        /// <returns> Collection of read coordinates. </returns>
        public List<Coordinate> ReadData()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] readCoordinates = line.Split(',');
                    if (readCoordinates.Length == 2
                        && double.TryParse(readCoordinates[0], out double coordinateX)
                        && double.TryParse(readCoordinates[1], out double coordinateY))
                    {
                        Coordinate coordinate = new Coordinate()
                        {
                            CoordinateX = coordinateX,
                            CoordinateY = coordinateY
                        };
                        coordinates.Add(coordinate);
                        Console.WriteLine(line);
                    }
                    else
                    {
                        _ = MessageBox.Show("Неверный формат введенных данных: " + line.ToString());
                    }
                }
            }
            return coordinates; ;
        }
    }
}
