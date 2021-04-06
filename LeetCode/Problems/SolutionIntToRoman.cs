using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    public class SolutionIntToRoman
    {
        /// <summary>
        /// Symbol       Value
        /// I             1
        /// IV            4
        /// V             5
        /// IX            9
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// </summary>
        public string IntToRoman(int num)
        {
            var values = new (int, string)[]
            {
                (1, "I"),
                (4, "IV"),
                (5, "V"),
                (9, "IX"),
                (10, "X"),
                (40, "XL"),
                (50, "L"),
                (90, "XC"),
                (100, "C"),
                (400, "CD"),
                (500, "D"),
                (900, "CM"),
                (1000, "M")
            }.Reverse();

            var target = new StringBuilder();

            foreach (var (i, c) in values)
            {
                var remainder = num / i;

                num -= remainder * i;

                for (int j = 0; j < remainder; j++)
                {
                    target.Append(c);
                }
            }

            return target.ToString();
        }
    }
}