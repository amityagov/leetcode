using System.Collections.Generic;
using LeetCode.Problems;
using Xunit;

namespace LeetCode.Tests
{
    public class SolutionIsNumberTests
    {
        [Theory]
        [MemberData(nameof(GetValidTestData))]
        public void Valid(string value)
        {
            var @class = new SolutionIsNumber();
            var actual = @class.IsNumber(value);

            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(GetInvalidTestData))]
        public void Invalid(string value)
        {
            var @class = new SolutionIsNumber();
            var actual = @class.IsNumber(value);

            Assert.False(actual);
        }

        public static IEnumerable<object[]> GetValidTestData()
        {
            yield return new[] {"2"};
            yield return new[] {"0089"};
            yield return new[] {"-0.1"};
            yield return new[] {"+3.14"};
            yield return new[] {"4."};
            yield return new[] {"-.9"};
            yield return new[] {"2e10"};
            yield return new[] {"-90E3"};
            yield return new[] {"3e+7"};
            yield return new[] {"+6e-1"};
            yield return new[] {"53.5e93"};
            yield return new[] {"-123.456e789"};
            yield return new[] {"26."};
        }

        public static IEnumerable<object[]> GetInvalidTestData()
        {
            yield return new[] {"abc"};
            yield return new[] {"1a"};
            yield return new[] {"1e"};
            yield return new[] {"e3"};
            yield return new[] {"99e2.5"};
            yield return new[] {"99e42.5"};
            yield return new[] {"--6"};
            yield return new[] {"-+3"};
            yield return new[] {"95a54e53"};
            yield return new[] {"."};
            yield return new[] {".e1"};
            yield return new[] {"1e."};
            yield return new[] {".1."};
            yield return new[] {".11."};
            yield return new[] {"6+1"};
            yield return new[] {".8+"};
            yield return new[] {"3.5e+3.5e+3.5"};
            yield return new[] {".+."};
            yield return new[] {"+."};
            yield return new[] {"+E3"};
            yield return new[] {"6.3.0"};
            yield return new[] {"6.34.0"};
            yield return new[] {"7.e-."};
            yield return new[] {"20..8"};
            yield return new[] {"92e1740e91"};
            yield return new[] {"56+.84473"};
            yield return new[] {"87e276-.9"};
            yield return new[] {".62e.e.9"};
            yield return new[] {".0e"};
            yield return new[] {"092e359-2"};
            yield return new[] {"4e+"};
        }
    }
}