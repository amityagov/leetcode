using System.Collections.Generic;
using LeetCode.Problems;
using Xunit;

namespace LeetCode.Tests
{
    public class SolutionStrongPasswordCheckerTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Call(string value, int expected)
        {
            var @class = new SolutionStrongPasswordChecker();

            var actual = @class.StrongPasswordChecker(value);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] {"a", 5};
            yield return new object[] {"aaa", 3};
            yield return new object[] {"aaaB1", 1};
        }
    }
}