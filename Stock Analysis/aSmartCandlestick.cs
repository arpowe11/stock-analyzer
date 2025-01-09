using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analysis
{
    /// <summary>
    /// Represents a "smart" candlestick with additional properties and methods
    /// to identify and categorize various candlestick patterns and characteristics.
    /// </summary>
    public class aSmartCandlestick : aCandlestick
    {
        // Properties for SmartCandlestick class
        public decimal Range { get; private set; }  // The range of the whole candlestick (High - Low)
        public decimal BodyRange { get; private set; } // The range between Open and Close
        public decimal TopPrice { get; private set; } // The larger of Open or Close
        public decimal BottomPrice { get; private set; } // The lesser of Open or Close
        public decimal UpperTail { get; private set; } // The height of the upper tail (High - max(Open, Close))
        public decimal LowerTail { get; private set; } // The height of the lower tail (min(Open, Close) - Low)

        /// <summary>
        /// Constructor to initialize SmartCandlestick from aCandlestick.
        /// Calculates properties like Range, BodyRange, UpperTail, LowerTail, etc.
        /// </summary>
        /// <param name="date">The date of the candlestick.</param>
        /// <param name="open">The open price of the candlestick.</param>
        /// <param name="close">The close price of the candlestick.</param>
        /// <param name="high">The high price of the candlestick.</param>
        /// <param name="low">The low price of the candlestick.</param>
        /// <param name="volume">The volume of the candlestick.</param>
        public aSmartCandlestick(DateTime date, decimal open, decimal close, decimal high, decimal low, ulong volume)
            : base(date, open, close, high, low, volume)
        {
            // Calculate all the properties for SmartCandlestick
            Range = high - low;
            BodyRange = Math.Abs(open - close);
            TopPrice = Math.Max(open, close);
            BottomPrice = Math.Min(open, close);
            UpperTail = high - TopPrice;
            LowerTail = BottomPrice - low;
        }

        /// <summary>
        /// Determines if the candlestick is Bullish (Close > Open).
        /// </summary>
        /// <returns>True if the candlestick is bullish, otherwise false.</returns>
        public bool IsBullish()
        {
            return Close > Open;
        }

        /// <summary>
        /// Determines if the candlestick is Bearish (Close < Open).
        /// </summary>
        /// <returns>True if the candlestick is bearish, otherwise false.</returns>
        public bool IsBearish()
        {
            return Close < Open;
        }

        /// <summary>
        /// Determines if the candlestick is Neutral (Close == Open).
        /// </summary>
        /// <returns>True if the candlestick is neutral, otherwise false.</returns>
        public bool IsNeutral()
        {
            return Close == Open;
        }

        /// <summary>
        /// Determines if the candlestick is a Marubozu (no upper or lower tail).
        /// </summary>
        /// <returns>True if the candlestick is a Marubozu, otherwise false.</returns>
        public bool IsMarubozu()
        {
            return UpperTail == 0 && LowerTail == 0;
        }

        /// <summary>
        /// Determines if the candlestick is a Hammer (bullish or bearish, with a small body and long lower tail).
        /// </summary>
        /// <returns>True if the candlestick is a Hammer, otherwise false.</returns>
        public bool IsHammer()
        {
            return (BodyRange < (Range * 0.3m)) && LowerTail > (BodyRange * 2);
        }

        /// <summary>
        /// Determines if the candlestick is a Doji (open and close are very close to each other).
        /// </summary>
        /// <returns>True if the candlestick is a Doji, otherwise false.</returns>
        public bool IsDoji()
        {
            return BodyRange < (Range * 0.1m);
        }

        /// <summary>
        /// Determines if the candlestick is a Dragonfly Doji (Open and Close are equal, with long lower tail).
        /// </summary>
        /// <returns>True if the candlestick is a Dragonfly Doji, otherwise false.</returns>
        public bool IsDragonflyDoji()
        {
            return IsDoji() && Open == Close && LowerTail > (BodyRange * 2);
        }

        /// <summary>
        /// Determines if the candlestick is a Gravestone Doji (Open and Close are equal, with long upper tail).
        /// </summary>
        /// <returns>True if the candlestick is a Gravestone Doji, otherwise false.</returns>
        public bool IsGravestoneDoji()
        {
            return IsDoji() && Open == Close && UpperTail > (BodyRange * 2);
        }

        /// <summary>
        /// Returns a string representation of the SmartCandlestick pattern type.
        /// It checks if the candlestick matches any known pattern, such as Bullish, Bearish, Hammer, Doji, etc.
        /// </summary>
        /// <returns>A string representing the candlestick pattern.</returns>
        public string PatternType()
        {
            if (IsBullish()) return "Bullish";
            if (IsBearish()) return "Bearish";
            if (IsNeutral()) return "Neutral";

            if (IsMarubozu()) return "Marubozu";
            if (IsHammer()) return "Hammer";
            if (IsDoji()) return "Doji";
            if (IsDragonflyDoji()) return "Dragonfly Doji";
            if (IsGravestoneDoji()) return "Gravestone Doji";

            return "Unknown Pattern";
        }

        /// <summary>
        /// Returns a string representation of the SmartCandlestick data including its pattern type.
        /// This includes the basic candlestick data as well as calculated properties like Range, Body Range, etc.
        /// </summary>
        /// <returns>A string with a detailed description of the SmartCandlestick.</returns>
        public override string ToString()
        {
            return $"{base.ToString()}, Range: {Range}, Body Range: {BodyRange}, Top Price: {TopPrice}, Bottom Price: {BottomPrice}, " +
                   $"Upper Tail: {UpperTail}, Lower Tail: {LowerTail}, Pattern: {PatternType()}";
        }
    }
}

