using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace Stock_Analysis
{
    /// <summary>
    /// Class that loads the data from the user and creates the list of candle sticks to be
    /// displayed in a chart for easy visualization
    /// </summary>
    public static class aCandlestickLoader
    {

        /// <summary>
        /// Loads candlestick data from a CSV file and converts it to a list of aCandlestick objects.
        /// Each line in the CSV file should contain data in the format:
        /// Date (yyyy-MM-dd), Open, High, Low, Close, Volume.
        /// The method parses and rounds decimal values to two decimal places.
        /// </summary>
        /// <param name="filePath">The path to the CSV file containing candlestick data.</param>
        /// <returns>A list of aCandlestick objects populated from the CSV data.</returns>
        public static List<aCandlestick> LoadFromCsv(string filePath)
        {
            // Initialize an empty list to store candlestick data
            var candlesticks = new List<aCandlestick>();

            // Open the CSV file for reading
            using (var reader = new StreamReader(filePath))
            {
                // Define delimiters for splitting CSV data
                char[] delim = { '\\', ',', '"' };

                // Read the header of the CSV file to skip it
                string line = reader.ReadLine();

                // Read each line of the CSV file until reaching the end
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into individual values based on delimiters
                    var values = line.Split(delim, StringSplitOptions.RemoveEmptyEntries);

                    // Parse and format each value from the CSV line
                    var date = DateTime.ParseExact(values[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var open = Math.Round(100 * decimal.Parse(values[1], CultureInfo.InvariantCulture)) / 100;
                    var high = Math.Round(100 * decimal.Parse(values[2], CultureInfo.InvariantCulture)) / 100;
                    var low = Math.Round(100 * decimal.Parse(values[3], CultureInfo.InvariantCulture)) / 100;
                    var close = Math.Round(100 * decimal.Parse(values[4], CultureInfo.InvariantCulture)) / 100;
                    var volume = ulong.Parse(values[5], CultureInfo.InvariantCulture);

                    // Create a new aCandlestick object with the parsed values
                    var candlestick = new aCandlestick(date, open, close, high, low, volume);

                    // Add the candlestick object to the list
                    candlesticks.Add(candlestick);
                }
            }

            // Return the list of candlesticks populated from the CSV file
            return candlesticks;
        }
    }
}
