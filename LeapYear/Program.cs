using System;

namespace LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the year: ");
            var year = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine($"Is year leap: {LeapYear.IsLeapYear(year)}");
        }
    }
}