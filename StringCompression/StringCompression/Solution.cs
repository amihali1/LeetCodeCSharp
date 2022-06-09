using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompression
{
    internal class Solution
    {
        //LeetCode complains if you make this parameter a ref, but it is ref here for the purpose of testing
        internal int Compress(ref char[] chars)
        {
            var stringBuilder = new StringBuilder();
            int counter = 1;
            char? prevChar = null;

            for (int i = 0; i < chars.Length; i++)
            {
                char currChar = chars[i];

                counter = AppendAndCount(counter, prevChar, currChar, stringBuilder);
                FinalCharCheck(counter, i, chars, prevChar, currChar, stringBuilder);

                prevChar = currChar;
            }

            for (int i = 0; i < stringBuilder.Length; i++)
                chars[i] = stringBuilder[i];

            return stringBuilder.Length;
        }

        internal int AppendAndCount(int counter, char? prevChar, char currChar, StringBuilder stringBuilder)
        {
            if (prevChar.HasValue && prevChar == currChar)
                counter++;
            else if ((prevChar.HasValue && prevChar != currChar))
            {
                stringBuilder.Append(prevChar);
                if (counter != 1)
                    stringBuilder.Append(counter.ToString());
                counter = 1;
            }
            return counter;
        }

        internal void FinalCharCheck(int counter, int i, char[] chars, char? prevChar, char currChar, StringBuilder stringBuilder)
        {
            if (i == chars.Length - 1 && prevChar.HasValue)
            {
                stringBuilder.Append(currChar);
                if (counter != 1)
                    stringBuilder.Append(counter.ToString());
            }
            else if (!prevChar.HasValue && i == chars.Length - 1)
                stringBuilder.Append(currChar);
        }
    }
}
