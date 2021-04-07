using System;

namespace LeetCode.Problems
{
    public class SolutionIsNumber
    {
        public bool IsNumber(string s)
        {
            var span = s.AsSpan();
            Token state = Token.Start;
            for (int i = 0; i < span.Length; i++)
            {
                var value = span[i];
                var token = CharToToken(value);

                if (token == Token.Invalid)
                    return false;

                var newState = GetNextState(state, token);

                if (newState == Token.Invalid)
                    return false;

                state = newState;
            }

            state = GetNextState(state, Token.Eol);

            return state != Token.Invalid;
        }

        public static Token CharToToken(char value)
        {
            return value switch
            {
                'e' => Token.E,
                'E' => Token.E,
                '+' => Token.Sign,
                '-' => Token.Sign,
                '.' => Token.Dot,
                _ when char.IsDigit(value) => Token.Digit,
                _ => Token.Invalid
            };
        }

        public Token GetNextState(Token currentState, Token current)
        {
            return (currentState, current) switch
            {
                (Token.Start, Token.Digit) => Token.Integer,
                (Token.Start, Token.Dot) => Token.StartDecimal,
                (Token.Start, Token.Sign) => Token.StartInteger,
                (Token.StartInteger, Token.Dot) => Token.StartDecimal,
                (Token.StartInteger, Token.Digit) => Token.Integer,

                (Token.Integer, Token.Digit) => Token.Integer,
                (Token.Integer, Token.Dot) => Token.Decimal,
                (Token.Integer, Token.E) => Token.StartE,

                (Token.StartDecimal, Token.Digit) => Token.Decimal,
                (Token.StartDecimal, Token.Eol) => Token.Invalid,

                (Token.StartE, Token.Sign) => Token.EStateSign,
                (Token.StartE, Token.Eol) => Token.Invalid,
                (Token.StartE, Token.Digit) => Token.EState,

                (Token.EStateSign, Token.Digit) => Token.EState,
                (Token.EStateSign, Token.Eol) => Token.Invalid,

                (Token.EState, Token.Digit) => Token.EState,

                (Token.Sign, Token.Eol) => Token.Invalid,
                (Token.Dot, Token.Eol) => Token.Invalid,

                (Token.Decimal, Token.E) => Token.StartE,
                (Token.Decimal, Token.Digit) => Token.Decimal,
                (Token.Decimal, Token.Dot) => Token.Invalid,

                (_, Token.Eol) => currentState,

                _ => Token.Invalid
            };
        }

        public enum Token
        {
            // Tokens
            Start = -2,
            Eol = -1,
            Invalid = 0,
            Sign = 1,
            E = 2,
            Digit = 3,
            Dot = 4,

            // States
            StartInteger = 5,
            Integer = 6,
            StartDecimal = 7,
            Decimal = 8,
            StartE = 9,
            EState = 10,
            EStateSign = 11
        }
    }
}