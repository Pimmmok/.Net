using System;
using System.Collections.Generic;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Class for reading data from the console.
    /// </summary>
    public class ConsoleCoordinateReader : IDataReader<Coordinate>
    {
        /// <summary>
        /// Implementation of the data read interface. Reading data from the console.
        /// </summary>
        /// <returns> Collection of read coordinates. </returns>
        public List<Coordinate> ReadData()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            Console.WriteLine("Reading from console:");
            coordinates.Clear();
            Console.WriteLine("Please enter data in the format: {X},{Y}. Enter <C> (complete) to complete input");
            do
            {
                string[] coordinatesInput = Console.ReadLine().Split(',');
                if (coordinatesInput.Length == 2
                    && double.TryParse(coordinatesInput[0], out double coordinateX)
                    && double.TryParse(coordinatesInput[1], out double coordinateY))
                {
                    Coordinate coordinate = new Coordinate() {
                        CoordinateX = coordinateX,
                        CoordinateY = coordinateY
                    };
                    coordinates.Add(coordinate);
                }
                else
                {
                    Console.WriteLine("Invalid format, please input again!");
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.C);
            return coordinates;
        }
    }
}


