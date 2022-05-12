namespace Introduction_to_.Net_Framework
{
    /// <summary>
    /// Сoordinate type.
    /// </summary>
    public struct Coordinate
    {
        /// <summary>
        /// Сoordinate X.
        /// </summary>
        public double CoordinateX { get; set; }

        /// <summary>
        /// Сoordinate Y.
        /// </summary>  
        public double CoordinateY { get; set; }

        /// <summary>
        /// Formatting coordinates to string.
        /// </summary>
        /// <returns> Text coordinates. </returns>
        public override string ToString()
        {
            return ("X: " + CoordinateX.ToString() + " Y: " + CoordinateY.ToString()).Replace('.', ',');
        }
    }

}
