using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock_Analysis
{
    public class aCandlestick
    {
        // Property to store the date of the candlestick data point
        public DateTime Date { get; set; }

        // Property to store the opening price of the candlestick
        public decimal Open { get; set; }

        // Property to store the closing price of the candlestick
        public decimal Close { get; set; }

        // Property to store the highest price of the candlestick
        public decimal High { get; set; }

        // Property to store the lowest price of the candlestick
        public decimal Low { get; set; }

        // Property to store the trading volume of the candlestick
        public ulong Volume { get; set; }


        /// <summary>
        /// Initializes a new instance of the aCandlestick class with specified data.
        /// </summary>
        /// <param name="date">The date of the candlestick data point.</param>
        /// <param name="open">The opening price of the candlestick.</param>
        /// <param name="close">The closing price of the candlestick.</param>
        /// <param name="high">The highest price of the candlestick.</param>
        /// <param name="low">The lowest price of the candlestick.</param>
        /// <param name="volume">The trading volume of the candlestick.</param>
        public aCandlestick(DateTime date, decimal open, decimal close, decimal high, decimal low, ulong volume)
        {
            // Assign the date parameter to the Date property
            Date = date;

            // Assign the open price to the Open property
            Open = open;

            // Assign the close price to the Close property
            Close = close;

            // Assign the highest price to the High property
            High = high;

            // Assign the lowest price to the Low property
            Low = low;

            // Assign the volume to the Volume property
            Volume = volume;
        }

        /// <summary>
        /// Returns a string representation of the candlestick data.
        /// </summary>
        /// <returns>A string that represents the candlestick data point.</returns>
        public override string ToString()
        {
            // Return a formatted string with details of the candlestick data
            return $"Date: {Date}, Open: {Open}, High: {High}, Low: {Low}, Close: {Close} Volume: {Volume}";
        }
    }
}
