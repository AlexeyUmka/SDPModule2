using System;
using System.Collections;
using System.Collections.Generic;

namespace CalcStats
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sequence = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Console.WriteLine(string.Join(", ", sequence));
            ShowResult(PredefinedStatisticModels.MinStatisticModel, sequence);
            ShowResult(PredefinedStatisticModels.MaxStatisticModel, sequence);
            ShowResult(PredefinedStatisticModels.AvgStatisticModel, sequence);
            ShowResult(PredefinedStatisticModels.LengthStatisticModel, sequence);
        }

        private static void ShowResult(StatisticBaseModel<double, IEnumerable<int>> model, IEnumerable<int> sequence)
        {
            Console.WriteLine($"{model.Title}: {CalcStatistic.GetStatistic(sequence, model)}");
        }
    }
}