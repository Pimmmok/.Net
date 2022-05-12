using System.Collections.Generic;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Data reading interface.
    /// </summary>
    /// <typeparam name="T"> Data type parameter. </typeparam>
    public interface IDataReader<T>
    {
        /// <summary>
        /// Data reading method.
        /// </summary>
        /// <returns> Data collection. </returns>
        public List<T> ReadData();
    }
}
