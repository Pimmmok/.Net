using System;
using System.Collections.Generic;
using System.IO;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Class for reading data from the file.
    /// </summary>
    public class FileCoordinateReader : IDataReader<Coordinate>
    {
        /// <summary>
        /// Implementation of the data reading interface. Reading data from the file.
        /// </summary>
        /// <returns> Collection of read coordinates. </returns>
        public List<Coordinate> ReadData()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            Console.WriteLine("Reading from file <data.txt>");
            using (StreamReader streamReader = new StreamReader("data.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] coordinatesOutput = line.Split(',');

                    if (coordinatesOutput.Length == 2
                        && double.TryParse(coordinatesOutput[0], out double coordinateX)
                        && double.TryParse(coordinatesOutput[1], out double coordinateY))

                    {
                        Coordinate coordinate = new Coordinate() {
                            CoordinateX = coordinateX,
                            CoordinateY = coordinateY
                        };
                        coordinates.Add(coordinate);
                        Console.WriteLine(line);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid format in the text of the file:<{line}>");
                    }
                }
            }
            return coordinates; ;
        }
    }
}
