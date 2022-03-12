using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerSharp
{
    class Token
    {
        public enum TokenType
        {
            //single character tokens
            SINISTRAM_PAREN, IUS_PAREN, SINISTRAM_CRISPUS, IUS_CRISPUS,
            COMMA, PUNCTUM, MINUS, PLUS, SIGNO, DIVISIO, MULTIPLICATIO,

            // One or two character tokens
            EXCLAMATIO, EXCLAMATIO_AEQUALIS,
            TRIBUO, AEQUALIS,
            MAIOR, MAIOR_AEQUALIS,
            MINOR, MINOR_AEQUALIS,

            // Literals
            IDENTITATIS, FILUM, NUMERUS,

            // Keywords
            NOTA, VARIABILIS, DUM, ET, ALITER, FALSUS,
            VERUM, PARTES, SI, VEL, REDITIO,

            //End of file
            FINIS
        };

        public TokenType type;
        public String lexeme;
        public Object literal;
        public int line;
        public static bool error = false;

        public Token(TokenType type, String lexeme, Object literal, int line)
        {
            this.type = type;
            this.lexeme = lexeme;
            this.literal = literal;
            this.line = line;
        }

        public String ConvertToString()
        {
            return type + " " + lexeme + " " + literal;
        }

        public static void Error(int _line, String message)
        {
            GetMess(_line, "", message);

        }

        private static void GetMess(int _line, String where, String message)
        {
            Console.WriteLine("[line " + _line + "]Error " + where + ": " + message);
            error = true;
        }
    }
}
