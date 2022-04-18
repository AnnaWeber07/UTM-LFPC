using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrecedenceParser
{
    class Parser
    {
        private List<string> grammar = new List<string>();
        private List<char> _nonTerminal = new List<char>();
        private List<char> _terminal = new List<char>();
        private string[,] _matrix;

        public Parser(List<string> initialGrammar)
        {
            grammar = initialGrammar;
        }

        private List<char> GetNonTerminal()
        {
            char[] charsToTrim = { ',', '{', '}', ' ' };
            _nonTerminal = grammar[1].Substring(3)
                                     .Trim(charsToTrim)
                                     .ToCharArray()
                                     .ToList();

            return _nonTerminal;
        }

        private List<char> GetTerminal()
        {
            char[] charsToTrim = { ',', '{', '}', ' ' };
            _terminal = grammar[2].Substring(3)
                                     .Trim(charsToTrim)
                                     .ToCharArray()
                                     .ToList();

            return _terminal;
        }

        private string[,] GetMatrix()
        {

            return _matrix;
        }
    }
}
