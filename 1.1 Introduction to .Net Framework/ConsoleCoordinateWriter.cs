using System;
using System.Collections.Generic;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Console writing class.
    /// </summary>
    public class ConsoleCoordinateWriter : IDataWriter<Coordinate>
    {
        /// <summary>
        /// Recording interface implementation. Writing data to the console.
        /// </summary>
        /// <param name="coordinates"> Сollection of recorded coordinates. </param>
        public void WriteData(IList<Coordinate> coordinates)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Data after formatting:");
            if (coordinates.Count == 0)
            {
                Console.WriteLine("No data available!");
            }
            else
            {
                foreach (Coordinate coordinate in coordinates)
                {
                    Console.WriteLine(coordinate);
                }
            }
        }
    }
}
