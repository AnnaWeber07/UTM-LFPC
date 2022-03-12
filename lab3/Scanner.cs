using System;
using System.Collections.Generic;

namespace LexerSharp
{
    public class Scanner
    {
        private const string IDENT = "IDENTIFIER";
        private const string KEYWORD = "KEYWORD";
        private const string LPAREN = "LPAREN";
        private const string RPAREN = "RPAREN";
        private const string LBRACE = "LBRACE";
        private const string RBRACE = "RBRACE";
        private const string COMMA = "COMMA";
        private const string PLUS = "PLUS";
        private const string MINUS = "MINUS";
        private const string MULTIPLICATION = "MULTIPLICATION";
        private const string DIVISION = "DIVISION";
        private const string GREATER = "GREATER";
        private const string GREATER_OR_EQUAL = "GREATER_OR_EQUAL";
        private const string LESS = "LESS";
        private const string LESS_OR_EQUAL = "LESS_OR_EQUAL";
        private const string NOT = "NOT";
        private const string NOT_EQUALS = "NOT_EQUALS";
        private const string EQUALS = "EQUALS";
        private const string ASSIGN = "ASSIGN";
        private const string RETURN = "RETURN";
        private const string OR = "OR";
        private const string AND = "AND";
        private const string STRING_START = "STRING_START";
        private const string STRING = "STRING";
        private const string STRING_END = "STRING_END";
        private const string INT = "INT";
        private const string FLOAT = "FLOAT";

        public string Filum { get; set; }
        public List<Token> Tokens { get; set; }
        public List<Error> Errors { get; set; }

        private int _line = 1;
        private int _column = -1;
        private int _position;

        public Scanner(string filum)
        {
            Filum = filum;
            Errors = new List<Error>();
            Tokens = new List<Token>();
        }

        public void ScanTokens()
        {
            for (_position = 0; _position < Filum.Length; _position++, _column++)
            {
                int i = _position;

                if (Filum[i] == ' ' || Filum[i] == '\t' || Filum[i] == '\r')
                {
                    continue;
                }
                else if (Filum[i] == '\n')
                {
                    _line++;
                    _column = -1;
                }
                else if (Filum[i].IsIdentifierStart())
                {
                    var newToken = GetIdentifier();
                    if (newToken != null)
                    {
                        Tokens.Add(newToken);
                    }
                }
                else if (Filum[i].IsDigit())
                {
                    var newToken = Number();
                    if (newToken != null)
                    {
                        Tokens.Add(newToken);
                    }
                }
                else if (Filum[i] == '"')
                {
                    var newTokens = NewString();
                    if (newTokens != null)
                    {
                        Tokens.AddRange(newTokens);
                    }
                }
                else if (Filum[i] == ',')
                {
                    Tokens.Add(new Token(COMMA, ","));
                }
                else if (Filum[i] == '-')
                {
                    Tokens.Add(new Token(MINUS, "-"));
                }
                else if (Filum[i] == '+')
                {
                    Tokens.Add(new Token(PLUS, "+"));
                }
                else if (Filum[i] == '*')
                {
                    Tokens.Add(new Token(MULTIPLICATION, "*"));
                }
                else if (Filum[i] == '/')
                {
                    Tokens.Add(new Token(DIVISION, "/"));
                }
                else if (Filum[i] == '(')
                {
                    Tokens.Add(new Token(LPAREN, "("));
                }
                else if (Filum[i] == ')')
                {
                    Tokens.Add(new Token(RPAREN, ")"));
                }
                else if (Filum[i] == '{')
                {
                    Tokens.Add(new Token(LBRACE, "{"));
                }
                else if (Filum[i] == '}')
                {
                    Tokens.Add(new Token(RBRACE, "}"));
                }
                else if (Filum[i].IsComparisonOperator() || Filum[i] == '=')
                {
                    var withEquality = i < Filum.Length - 1 && Filum[i + 1] == '=';

                    Tokens.Add(Comparer(withEquality));
                }
                else if (Filum[i].IsBoolOperatorStart())
                {
                    if (i < Filum.Length - 1 && Filum[i + 1] == Filum[i])
                    {
                        Tokens.Add(TrueOrFalse(Filum));
                    }
                    else
                    {
                        Errors.Add(Error.UnexpectedSymbol(_line, _column, Filum[i]));
                    }
                }
                else
                {
                    Errors.Add(Error.UnexpectedSymbol(_line, _column, Filum[i]));
                }
            }
        }

        public void Output()
        {
            if (Errors.Count == 0)
            {
                foreach (var token in Tokens)
                {
                    Console.WriteLine(token);
                }
            }
            else
            {
                foreach (var error in Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private Token Number()
        {
            string tokenValue = "";
            bool isFloat = false;
            for (; _position < Filum.Length; _position++)
            {
                if (Filum[_position].IsWhiteSpace() || Filum[_position].IsOperator() || Filum[_position].IsParantheses() || Filum[_position].IsBrace())
                {
                    _position--;
                    break;
                }

                _column++;

                if (Filum[_position] == '.' && isFloat)
                {
                    Errors.Add(Error.UnexpectedSymbol(_line, _column, Filum[_position]));
                }
                else if (Filum[_position] == '.')
                {
                    tokenValue += Filum[_position];
                    isFloat = true;
                }
                else if (Filum[_position].IsDigit())
                {
                    tokenValue += Filum[_position];
                }
                else
                {
                    Errors.Add(Error.UnexpectedSymbol(_line, _column, Filum[_position]));
                }
            }

            if (Errors.Count > 0)
            {
                return null;
            }
            return isFloat ?
                new Token(FLOAT, tokenValue) :
                new Token(INT, tokenValue);
        }

        private Token GetIdentifier()
        {
            string tokenValue = "";

            for (; _position < Filum.Length; _position++)
            {
                if (Filum[_position].IsWhiteSpace() || Filum[_position].IsOperator() || 
                    Filum[_position].IsParantheses() || Filum[_position].IsBrace() || Filum[_position] == ',')
                {
                    _position--;
                    break;
                }

                _column++;

                if (Filum[_position].IsIdentifierSymbol())
                {
                    tokenValue += Filum[_position];
                }
                else
                {
                    Errors.Add(Error.UnexpectedSymbol(_line, _column, Filum[_position]));
                }
            }

            if (Errors.Count > 0)
            {
                return null;
            }
            if (tokenValue.IsKeyword())
            {
                return new Token($"{KEYWORD}[{KeywordsAndConst.Keywords[tokenValue]}]", tokenValue);
            }
          
            return new Token(IDENT, tokenValue);
        }

        private List<Token> NewString()
        {
            List<Token> tokens = new List<Token>
            {
                new Token(STRING_START, "\"")
            };

            _position++;
            _column++;

            string tokenValue = "";

            for (; _position < Filum.Length; _position++, _column++)
            {
                if (Filum[_position] == '"')
                {
                    _position++;
                    _column++;
                    break;
                }

                if (Filum[_position].IsChar())
                {
                    tokenValue += Filum[_position];
                }
                else
                {
                    Errors.Add(Error.ExpectedSymbol(_line, _column, '"'));
                }
            }

            if (Errors.Count > 0)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(tokenValue))
            {
                tokens.Add(new Token(STRING, tokenValue));
            }
            tokens.Add(new Token(STRING_END, "\""));

            return tokens;
        }

        private Token Comparer(bool withEquals)
        {
            string tokenValue = "";
            tokenValue += Filum[_position];

            if (withEquals)
            {
                _position++;
                _column++;
                tokenValue += Filum[_position];
                switch (tokenValue[0])
                {
                    case '>': return new Token(GREATER_OR_EQUAL, tokenValue);
                    case '<': return new Token(LESS_OR_EQUAL, tokenValue);
                    case '=': return new Token(EQUALS, tokenValue);
                    case '!': return new Token(NOT_EQUALS, tokenValue);
                }
            }
            else
            {
                switch (tokenValue[0])
                {
                    case '>': return new Token(GREATER, tokenValue);
                    case '<': return new Token(LESS, tokenValue);
                    case '=': return new Token(ASSIGN, tokenValue);
                    case '!': return new Token(NOT, tokenValue);
                }
            }
            return null;
        }

        private Token TrueOrFalse(string code)
        {
            string tokenValue = "";
            tokenValue += code[_position];

            _position++;
            _column++;
            tokenValue += code[_position];

            switch (tokenValue[0])
            {
                case '|': return new Token(OR, tokenValue);
                case '&': return new Token(AND, tokenValue);
            }

            return null;
        }
    }
}
