using System;

namespace CalcStats
{
    public class StatisticBaseModel<TValue, TSequence>
    {
        public string Title { get; }
        public Func<TSequence, TValue> Calculate { get; }

        public StatisticBaseModel(string title, Func<TSequence, TValue> calculateFunc)
        {
            Title = title;
            Calculate = calculateFunc;
        }
    }
}