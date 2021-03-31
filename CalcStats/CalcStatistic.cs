using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcStats
{
    public static class CalcStatistic
    {
        public enum StatisticType
        {
            Minimum,
            Maximum,
            Average,
            SequenceLength,
        }
        public static double GetStatistic(IEnumerable<int> numbers, StatisticType statisticType)
        {
            switch (statisticType)
            {
                case StatisticType.Minimum:
                    return numbers.Min();
                case StatisticType.Average:
                    return numbers.Average();
                case StatisticType.Maximum:
                    return numbers.Max();
                case StatisticType.SequenceLength:
                    return numbers.Count();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}