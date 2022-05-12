using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using Introduction_to_.Net_Framework;

namespace Introduction_to_.Net_FrameworkWPF
{
    /// <summary>
    /// File writing class.
    /// </summary>
    public class FileCoordinateWriterWpfProgram : IDataWriter<Coordinate>
    {
        /// <summary>
        /// Implementation of the recorded data interface. Writing data to the file.
        /// </summary>
        /// <param name="coordinates"> Сollection of recorded coordinates. </param>
        public void WriteData(IList<Coordinate> coordinates)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "(*.txt)|*.txt",
                DefaultExt = "txt"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                using StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true,
                                                                   System.Text.Encoding.Default);
                streamWriter.WriteLine("\nДанные после форматирования");
                if (coordinates.Count == 0)
                {
                    streamWriter.WriteLine("Данные не загружены");
                }
                else
                {
                    foreach (Coordinate coordinate in coordinates)
                    {
                        streamWriter.WriteLine(coordinate);
                    }
                }
                _ = MessageBox.Show("Данные отформатированы и сохранены в файл: " + saveFileDialog.FileName);
            }
        }
    }
}
