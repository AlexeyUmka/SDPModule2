using System;

namespace LCDDigits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input your number to its LCD representation");
            var inputNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine(inputNumber.GetLcdStringNumber());
        }
    }
}