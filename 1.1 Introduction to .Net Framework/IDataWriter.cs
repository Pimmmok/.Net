using System.Collections.Generic;

namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Data writing interface.
    /// </summary>
    /// <typeparam name="T"> Data type parameter. </typeparam>
    public interface IDataWriter<T>
    {
        /// <summary>
        /// Data recording method.
        /// </summary>
        /// <param name="data"> Data collection. </param>
        public void WriteData(IList<T> data);
    }
}
