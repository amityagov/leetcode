using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    public class SolutionNumberToWords
    {
        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            var map = new Dictionary<int, string>
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
                {20, "Twenty"},
                {30, "Thirty"},
                {40, "Forty"},
                {50, "Fifty"},
                {60, "Sixty"},
                {70, "Seventy"},
                {80, "Eighty"},
                {90, "Ninety"},

                {100, "Hundred"},
                {1000, "Thousand"},
                {1_000_000, "Million"},
                {1_000_000_000, "Billion"},
            };

            var keyList = new List<int>(map.Keys);
            keyList.Sort();
            keyList.Reverse();

            var target = new StringBuilder();

            Worker(target, num, map, keyList);

            return target.ToString().TrimEnd();
        }

        private void Worker(StringBuilder target, int value, IDictionary<int, string> map, IList<int> sortedKeys)
        {
            foreach (var i in sortedKeys)
            {
                var remainder = value / i;

                if (remainder > 0)
                {
                    if (i >= 100)
                    {
                        Worker(target, remainder, map, sortedKeys);
                    }

                    target.Append(map[i]);
                    target.Append(" ");

                    value -= i * remainder;
                }
            }
        }
    }
}