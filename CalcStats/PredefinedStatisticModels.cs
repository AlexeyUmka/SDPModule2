using System.Collections.Generic;
using System.Linq;

namespace CalcStats
{
    public static class PredefinedStatisticModels
    {
        private static double GetMinValue(IEnumerable<int> numbers) => numbers.Min();
        private static double GetMaxValue(IEnumerable<int> numbers) => numbers.Max();
        private static double GetAvgValue(IEnumerable<int> numbers) => numbers.Average();
        private static double GetLength(IEnumerable<int> numbers) => numbers.Count();

        public static StatisticBaseModel<double, IEnumerable<int>> MinStatisticModel =>
            new StatisticBaseModel<double, IEnumerable<int>>("Minimum value", GetMinValue);
        public static StatisticBaseModel<double, IEnumerable<int>> MaxStatisticModel =>
            new StatisticBaseModel<double, IEnumerable<int>>("Maximum value", GetMaxValue);
        public static StatisticBaseModel<double, IEnumerable<int>> AvgStatisticModel =>
            new StatisticBaseModel<double, IEnumerable<int>>("Average value", GetAvgValue);
        public static StatisticBaseModel<double, IEnumerable<int>> LengthStatisticModel =>
            new StatisticBaseModel<double, IEnumerable<int>>("Length of the sequence", GetLength);
    }
}