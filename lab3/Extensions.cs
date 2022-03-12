using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerSharp
{
    public static class CharExtentions
    {
        public static bool IsDigit(this char c)
        {
            return KeywordsAndConst.Digits.Contains(c);
        }
        public static bool IsLetter(this char c)
        {
            return KeywordsAndConst.Letters.Contains(c);
        }
        public static bool IsIdentifierStart(this char c)
        {
            return c.IsLetter() || c == '_';
        }
        public static bool IsIdentifierSymbol(this char c)
        {
            return c.IsIdentifierStart() || c.IsDigit();
        }
        public static bool IsChar(this char c)
        {
            return !c.IsWhiteSpace() || c == ' ' || c == '\t';
        }
        public static bool IsWhiteSpace(this char c)
        {
            return c == '\n' || c == ' ' || c == '\t' || c == '\r';
        }
        public static bool IsArithmeticOperator(this char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        public static bool IsComparisonOperator(this char c)
        {
            return c == '>' || c == '<' || c == '!';
        }
        public static bool IsAssignment(this char c)
        {
            return c == '=';
        }
        public static bool IsOperator(this char c)
        {
            return c.IsArithmeticOperator() || c.IsAssignment() || c.IsComparisonOperator();
        }
        public static bool IsParantheses(this char c)
        {
            return c == '(' || c == ')';
        }
        public static bool IsBrace(this char c)
        {
            return c == '{' || c == '}';
        }
        public static bool IsBoolOperatorStart(this char c)
        {
            return c == '|' || c == '&';
        }
    }

    public static class StringExtensions
    {
        public static bool IsKeyword(this string s)
        {
            return KeywordsAndConst.Keywords.ContainsKey(s);
        }
    }
}
