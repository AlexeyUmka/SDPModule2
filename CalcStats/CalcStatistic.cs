using System.Collections.Generic;

namespace CalcStats
{
    public static class CalcStatistic
    {
        public static double GetStatistic(IEnumerable<int> numbers, StatisticBaseModel<double, IEnumerable<int>> statisticBaseModel)
        {
            return statisticBaseModel.Calculate(numbers);
        }
    }
}