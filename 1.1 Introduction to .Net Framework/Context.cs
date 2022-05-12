using System;
using System.Collections.Generic;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// The class that is the data context.
    /// </summary>
    /// <typeparam name="T"> Data type parameter. </typeparam>
    public class Context<T>
    {
        /// <summary>
        /// Data collection
        /// </summary>
        public IList<T> Data { get; set; }

        /// <summary>
        /// Properties setting how data is read.
        /// </summary>
        public IDataReader<T> DataReader { get; set; }

        /// <summary>
        /// Properties setting how data is write.
        /// </summary>
        public IDataWriter<T> DataWriter { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataReader"> Setting how data is read. </param>
        /// <param name="dataWriter"> Setting how data is write. </param>
        public Context(IDataReader<T> dataReader, IDataWriter<T> dataWriter)
        {
            DataReader = dataReader
                ?? throw new ArgumentNullException(nameof(dataReader));
            DataWriter = dataWriter
                ?? throw new ArgumentNullException(nameof(dataWriter));
        }

        /// <summary>
        /// Setting the way to read and write data.
        /// </summary>
        public void ExecuteDataProcessing()
        {
            Data = DataReader.ReadData();
            if (Data.Count != 0)
            {
                DataWriter.WriteData(Data);
            }
            Data.Clear();
        }
    }
}
