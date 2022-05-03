using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToRoman
{
    internal class Solution
    {
        public string IntToRoman(int num)
        {
            StringBuilder result = new StringBuilder();
            while (num > 0)
            {
                if (num >= 1000)
                {
                    result.Append("M");
                    num -= 1000;
                }
                else if (num >= 900)
                {
                    result.Append("CM");
                    num -= 900;
                }
                else if (num >= 500)
                {
                    result.Append("D");
                    num -= 500;
                }
                else if (num >= 400)
                {
                    result.Append("CD");
                    num -= 400;
                }
                else if (num >= 100)
                {
                    result.Append("C");
                    num -= 100;
                }
                else if (num >= 90)
                {
                    result.Append("XC");
                    num -= 90;
                }
                else if (num >= 50)
                {
                    result.Append("L");
                    num -= 50;
                }
                else if (num >= 40)
                {
                    result.Append("XL");
                    num -= 40;
                }
                else if (num >= 10)
                {
                    result.Append("X");
                    num -= 10;
                }
                else if (num >= 9)
                {
                    result.Append("IX");
                    num -= 9;
                }
                else if (num >= 5)
                {
                    result.Append("V");
                    num -= 5;
                }
                else if (num >= 4)
                {
                    result.Append("IV");
                    num -= 4;
                }
                else if (num >= 1)
                {
                    result.Append("I");
                    num -= 1;
                }
            }

            return result.ToString();
        }
    }
}
