using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LexerSharp
{
    class Scanner
    {
        private string _source;
        private List<Token> tokens = new List<Token>();
        private int _start = 0;
        private int _current = 0;
        private int _line = 1;

        private static Dictionary<string, Token.TokenType> dictionary = new Dictionary<string, Token.TokenType>();

        static void FillDictionary()
        {
            dictionary = new Dictionary<string, Token.TokenType>();

            dictionary.Add("ET", Token.TokenType.ET);
            dictionary.Add("ALITER", Token.TokenType.ALITER);
            dictionary.Add("FALSUS", Token.TokenType.FALSUS);
            dictionary.Add("VERUM", Token.TokenType.VERUM);
            dictionary.Add("PARTES", Token.TokenType.PARTES);
            dictionary.Add("SI", Token.TokenType.SI);
            dictionary.Add("VARIABILIS", Token.TokenType.VARIABILIS);
            dictionary.Add("VEL", Token.TokenType.VEL);
            dictionary.Add("NOTA", Token.TokenType.NOTA);
            dictionary.Add("REDITIO", Token.TokenType.REDITIO);
            dictionary.Add("DUM", Token.TokenType.DUM);
            dictionary.Add("FINIS", Token.TokenType.FINIS);
        }


        public Scanner(string source)
        {
            _source = source;
        }

        private void addToken(Token.TokenType tokenType, object _literal)
        {
            string text = _source.Substring(_start, _current);
            tokens.Add(new Token(tokenType, text, _literal, _line));
        }

        private void addToken(Token.TokenType tokenType)
        {
            addToken(tokenType, null);
        }

        private void scanToken() //scanning string for tokens
        {
            char check = _source.ElementAt(_current++);

            if (Numeri(check))
                Numerus();
            else if (isCharacter(check))
                Identitatis();
            else if (check == '.')
                addToken(Token.TokenType.PUNCTUM);
            else if (check == ',')
                addToken(Token.TokenType.COMMA);
            else if (check == '(')
                addToken(Token.TokenType.SINISTRAM_PAREN);
            else if (check == ')')
                addToken(Token.TokenType.IUS_PAREN);
            else if (check == '{')
                addToken(Token.TokenType.SINISTRAM_CRISPUS);
            else if (check == '}')
                addToken(Token.TokenType.IUS_CRISPUS);
            else if (check == '-')
                addToken(Token.TokenType.MINUS);
            else if (check == '+')
                addToken(Token.TokenType.PLUS);
            else if (check == '*')
                addToken(Token.TokenType.MULTIPLICATIO);
            else if (check == ';')
                addToken(Token.TokenType.SIGNO);
            else if (check == '!')
                addToken(Matcher('=') ? Token.TokenType.EXCLAMATIO : Token.TokenType.EXCLAMATIO_AEQUALIS);
            else if (check == '=')
                addToken(Matcher('=') ? Token.TokenType.AEQUALIS : Token.TokenType.TRIBUO);
            else if (check == '<')
                addToken(Matcher('=') ? Token.TokenType.MINOR_AEQUALIS : Token.TokenType.MINOR);
            else if (check == '>')
                addToken(Matcher('=') ? Token.TokenType.MAIOR_AEQUALIS : Token.TokenType.MAIOR);
            else if (check == '\n')
                _line++;
            else if (check == '"')
            {
                bool v = (_current >= _source.Length);
                while (SlashN() != '"' && !v)
                {
                    if (SlashN() == '\n')
                        _line++;
                    _source.ElementAt(_current++);
                }
                if (v)
                    throw new Exception(_line.ToString() + " " + "inopinatum litterae");

                _source.ElementAt(_current++);
                string value = _source.Substring(_start + 1, _current - 1);
                addToken(Token.TokenType.FILUM, value);
            }
            else if (check == '/')
            {
                if (Matcher('/'))
                {
                    bool v = (_current >= _source.Length);
                    if (SlashN() != '\n' && !v)
                    {
                        _source.ElementAt(_current++);
                    }
                    else
                    {
                        addToken(Token.TokenType.DIVISIO);
                    }
                }
            }
            else throw new Exception(_line.ToString() + " " + "inopinatum litterae");

        }

        private bool Matcher(char v)
        {
            if (_current >= _source.Length) return false;
            if (_source.ElementAt(_current) != v) return false;

            _current++;
            return true;
        }

        private char SlashN()
        {
            if (_current >= _source.Length) return '\0';
            return _source.ElementAt(_current);
        }

        private bool Numeri(char c)
        {
            return c >= '0' && c <= 9;
        }

        private void Numerus()
        {
            while (Numeri(SlashN()))
                _source.ElementAt(_current++);

            if (SlashN() == '.' && Numeri(GetNext()))
            {
                _source.ElementAt(_current++);
                while (Numeri(SlashN()))
                    _source.ElementAt(_current++);
            }

            addToken(Token.TokenType.NUMERUS, Double.Parse(_source.Substring(_start, _current)));
        }

        private char GetNext()
        {
            if (_current + 1 >= _source.Length)
                return '\0';

            return _source.ElementAt(_current + 1);
        }

        private void Identitatis()
        {
            while (isNumeri(SlashN()))
                _source.ElementAt(_current++);

            addToken(Token.TokenType.IDENTITATIS);

            string text = _source.Substring(_start, _current);
            Token.TokenType type = 

        }

        private bool isCharacter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_';
        }

        private bool isNumeri(char c)
        {
            return isNumeri(c) || isCharacter(c);
        }

        public List<Token> scanTokens()
        {
            while (_current >= _source.Length)
            {
                _start = _current;
                scanToken();
            }

            tokens.Add(new Token(Token.TokenType.FINIS, "", null, _line));
            return tokens;
        }
    }
}
