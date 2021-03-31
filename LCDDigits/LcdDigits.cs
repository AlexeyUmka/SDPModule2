using System;
using System.Linq;
using System.Text;

namespace LCDDigits
{
    public static class LcdDigits
    {
        private static readonly string[,] DigitStringMap = {
                {"._.",
                 "|.|",
                 "|_|" },
                {"...",
                 "..|",
                 "..|" },
                {"._.",
                 "._|",
                 "|_." },
                {"._.",
                 "._|",
                 "._|" },
                {"...",
                 "|_|",
                 "..|" },
                {"._.",
                 "|_.",
                 "._|" },
                {"._.",
                 "|_.",
                 "|_|" },
                {"._.",
                 "..|",
                 "..|" },
                {"._.",
                 "|_|",
                 "|_|" },
                {"._.",
                 "|_|",
                 "..|" }
            };
        private const int MaxLineHeight = 3;
        public static string GetLcdStringNumber(this int number)
        {
            var output = new StringBuilder();
            var digits = number.ToString().Select(c => int.Parse($"{c}")).ToArray();

            for (var lineHeight = 0; lineHeight < MaxLineHeight; lineHeight++)
            {
                foreach (var digit in digits)
                {
                    output.Append(DigitStringMap[digit, lineHeight]);
                }
                output.Append("\n");
            }

            return output.ToString();
        }
    }
}