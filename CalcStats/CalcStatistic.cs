using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcStats
{
    public static class CalcStatistic
    {
        public static double GetStatistic(IEnumerable<int> numbers)
        {
            return numbers.Min();
        }
    }
}