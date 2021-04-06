using System.Collections.Generic;
using LeetCode.Problems;
using Xunit;

namespace LeetCode.Tests
{
    public class SolutionIntToRomanTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Call(string expected, int value)
        {
            var @class = new SolutionIntToRoman();

            var actual = @class.IntToRoman(value);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] {"I", 1};
            yield return new object[] {"III", 3};
            yield return new object[] {"IV", 4};
            yield return new object[] {"MCMXCIV", 1994};
        }
    }
}