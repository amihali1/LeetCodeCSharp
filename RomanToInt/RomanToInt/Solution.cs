using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToInt
{
    internal class Solution
    {
        public int RomanToInt(string s)
        {
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var curChar = new RomanNumeral(s[i]);
                var nextChar = i < s.Length - 1 ? new RomanNumeral(s[i + 1]) : null;

                if (nextChar != null && nextChar.intValue > curChar.intValue)
                {
                    result += (nextChar.intValue - curChar.intValue);
                    i++;
                }
                else
                    result += curChar.intValue;
            }

            return result;
        }
    }

    internal class RomanNumeral
    {
        internal char stringValue;
        internal int intValue;

        public RomanNumeral(char character)
        {
            stringValue = character;
            intValue = character == 'M' ? 1000 :
                       character == 'D' ? 500 :
                       character == 'C' ? 100 :
                       character == 'L' ? 50 :
                       character == 'X' ? 10 :
                       character == 'V' ? 5 :
                       1;                       
        }
    }
}
