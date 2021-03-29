using System;

namespace LCDDigits
{
    public static class LcdDigits
    {
        public static string GetLcdStringNumber(this int number)
        {
            switch(number){
                case 0:
                return "._.\n" +
                       "|.|\n" +
                       "|_|\n";
                default:
                throw new NotImplementedException();
            }
        }
    }
}