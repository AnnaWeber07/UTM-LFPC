using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerSharp
{
    public class Error
    {
        public string Value { get; set; }

        public Error(string value)
        {
            Value = value;
        }

        public static Error UnexpectedSymbol(int line, int column, char symbol)
        {
            return new Error($"Unexpected symbol: {symbol} at line {line}, column {column}");
        }

        public static Error ExpectedSymbol(int line, int column, char symbol)
        {
            return new Error($"Expected symbol: {symbol} at line {line}, column {column}");
        }
        public override string ToString()
        {
            return $"Error: {Value}";
        }
    }
}
