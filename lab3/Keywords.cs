using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerSharp
{
    public static class KeywordsAndConst
    {
        public const string Digits = "0123456789";
        public const string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static readonly Dictionary<string, string> Keywords = new Dictionary<string, string>()
            {
                { "partes", "FUNCTION" },
                { "si", "IF" },
                { "aliter", "ELSE" },
                { "variabilis", "VARIABLE" },
                { "primor",  "MAIN"},
                { "vel", "OR" },
                { "falsus", "FALSE"},
                { "verum", "TRUE" },
                { "nota", "PRINT" },
                { "reditio", "RETURN" },
                { "et", "AND" }
            };

    }
}
