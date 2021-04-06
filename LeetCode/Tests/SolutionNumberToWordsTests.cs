using System.Collections.Generic;
using LeetCode.Problems;
using Xunit;

namespace LeetCode.Tests
{
    public class SolutionNumberToWordsTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Call(int value, string expected)
        {
            var @class = new SolutionNumberToWords();

            var actual = @class.NumberToWords(value);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] {0, "Zero"};
            yield return new object[] {1, "One"};
            yield return new object[] {100, "One Hundred"};
            yield return new object[] {123, "One Hundred Twenty Three"};
            yield return new object[] {100000, "One Hundred Thousand"};
            yield return new object[] {1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"};
            yield return new object[] {1234567891, "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"};
        }
    }
}