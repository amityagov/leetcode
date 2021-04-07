using System;

namespace LeetCode.Problems
{
    public class SolutionStrongPasswordChecker
    {
        public int StrongPasswordChecker(string password)
        {
            bool tooShort = password.Length < 6;
            bool tooBig = password.Length > 20;

            var span = password.AsSpan();

            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool hasSequence = false;

            int seq = 0;

            for (int i = 0; i < span.Length; i++)
            {
                var c = span[i];

                hasDigit |= char.IsDigit(c);
                hasLower |= char.IsLower(c);
                hasUpper |= char.IsUpper(c);

                if (i + 3 <= span.Length)
                {
                    if (Test(c, span.Slice(i, 3)))
                    {
                        hasSequence = true;
                        seq += 1;
                    }
                }
            }

            if (tooShort == false && tooBig == false && hasDigit && hasLower && hasUpper && hasSequence == false)
            {
                return 0;
            }

            int counter = 0;

            int inserts = 0;

            if (tooShort)
            {
                inserts = 6 - password.Length;
                counter += inserts;
            }

            if (tooBig)
            {
                counter += password.Length - 20;
            }

            if (hasSequence)
            {
                counter += Math.Max(0, seq - inserts);
            }

            return counter;
        }

        private static bool Test(char c, ReadOnlySpan<char> span)
        {
            return span.Length == 3
                   && span[0] == c
                   && span[1] == c
                   && span[2] == c;
        }
    }
}