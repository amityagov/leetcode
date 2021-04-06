using System;

namespace LeetCode.Problems
{
    public class SolutionRomanToInt
    {
        public int RomanToInt(string value)
        {
            int counter = 0;

            for (int i = 0; i < value.Length;)
            {
                char c = value[i];
                char? next = null;
                if (i < value.Length - 1)
                {
                    next = value[i + 1];
                }

                counter += Convert(c, next, out var advance);
                i += advance;
            }

            return counter;
        }

        /// <summary>
        /// I             1
        /// V             5
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// </summary>
        private int Convert(char c, char? nextChar, out int advance)
        {
            advance = 1;

            int value;

            switch (c)
            {
                case 'I':
                {
                    value = 1;
                    if (nextChar == 'V')
                    {
                        advance = 2;
                        value = 4;
                    }
                    if (nextChar == 'X')
                    {
                        advance = 2;
                        value = 9;
                    }
                    break;
                }

                case 'V':
                    value = 5;
                    break;

                case 'X':
                {
                    value = 10;
                    if (nextChar == 'L')
                    {
                        value = 40;
                        advance = 2;
                    }

                    if (nextChar == 'C')
                    {
                        value = 90;
                        advance = 2;
                    }

                    break;
                }

                case 'L':
                    value = 50;
                    break;

                case 'C':
                {
                    value = 100;
                    if (nextChar == 'D')
                    {
                        value = 400;
                        advance = 2;
                    }

                    if (nextChar == 'M')
                    {
                        value = 900;
                        advance = 2;
                    }

                    break;
                }

                case 'D':
                    value = 500;
                    break;

                case 'M':
                    value = 1000;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(c), c, null);
            }

            return value;
        }
    }
}