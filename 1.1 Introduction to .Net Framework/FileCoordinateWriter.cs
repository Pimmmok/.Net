using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Class for recording data to the file.
    /// </summary>
    public class FileCoordinateWriter : IDataWriter<Coordinate>
    {
        /// <summary>
        /// Recording interface implementation. Writing data to the file.
        /// </summary>
        /// <param name="coordinates"> Сollection of recorded coordinates. </param>
        public void WriteData(IList<Coordinate> coordinates)
        {
            using StreamWriter streamWriter = new StreamWriter("data.txt", true, Encoding.Default);
            streamWriter.WriteLine("\nData after formatting:");
            if (coordinates.Count == 0)
            {
                streamWriter.WriteLine("No data available!");
            }
            else
            {
                foreach (Coordinate coordinate in coordinates)
                {
                    streamWriter.WriteLine(coordinate);
                }
                Console.WriteLine("Written to file <data.txt>");
            }
        }
    }
}
