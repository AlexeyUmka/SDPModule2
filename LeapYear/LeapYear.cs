using System;

namespace LeapYear
{
    public static class LeapYear
    {
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0;
        }
    }
}