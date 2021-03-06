﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Model.Indicators
{
    public class TrueRange
    {
        /// <summary>
        /// Returns TR array of length [days.Length]
        /// </summary>
        public static IEnumerable<Point<decimal>> Calculate(ShareDay[] days, int startIndex, bool includeFirstTrueRange)
        {
            if (startIndex >= days.Length)
                yield break;

            var previous = days[startIndex];

            if (includeFirstTrueRange)
                yield return Point.With(previous.Date, previous.High - previous.Low);

            for (int i = startIndex + 1; i < days.Length; i++)
            {
                var current = days[i];

                var trueRange = new[]
                {
                    current.High - current.Low, 
                    Math.Abs(current.High - previous.Close), 
                    Math.Abs(current.Low - previous.Close)
                }.Max();

                yield return Point.With(current.Date, trueRange);

                previous = current;
            }
        }
    }
}