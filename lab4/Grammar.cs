using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LFPC_Chomsky
{
    class Grammar
    {
        private List<string> grammar = new List<string>();
        private List<string> NonTerminal = new List<string>();
        private List<string> Terminal = new List<string>();

        public Grammar(List<string> grammar)
        {
            this.grammar = grammar;
        }

        public List<string> GetChomskyForm()
        {
            List<string> production = new List<string>();

            NonTerminal = GetNonterminalSymbols(grammar);
            Terminal = GetTerminalSymbols(grammar);

            production = GetProduction(grammar);

            EpsilonElimination(production);
            RenamingElimination(production);
            InaccessibleSymbolElimination(production);
            NonProductiveSymbolElimination(production);
            GetChomskyNormalForm(production);
            //finalStep
            //call print function?


            return production;
        }


        public List<string> GetProduction(List<string> grammar)
        {
            List<string> production = new List<string>();

            for (int i = 0; i < grammar.Count; i++)
            {
                string line = grammar[i];
                char[] charsToTrim = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ' ', '{', '}' };

                if (line.Any(char.IsDigit))
                {
                    var edited = line.Trim(charsToTrim);
                    production.Add(edited);
                }
            }

            return production;
        }

        public List<string> GetNonterminalSymbols(List<string> grammar)
        {
            var elements = grammar[1].Substring(3)
                                     .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => x.Trim('{', '}', ' '));

            return elements
                .Select(x => x)
                .ToList();
        }

        private List<string> GetTerminalSymbols(List<string> grammar)
        {
            var elements = grammar[2].Substring(3)
                                     .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => x.Trim('{', '}', ' '));

            return elements
                .Select(x => x)
                .ToList();
        }


        public List<string> EpsilonElimination(List<string> prod)
        //Eliminate epsilon productions
        {
            //get P transitions copied to a new list for easier use

            return prod;
        }

        public List<string> RenamingElimination(List<string> prod)
        //Eliminate any renaming
        {
            //The production that has the form XY, X and Y are nonterminal, is called renaming
            return prod;
        }

        public List<string> InaccessibleSymbolElimination(List<string> prod)
        //Eliminate inaccessible symbols
        {
            //blahblahblah
            return prod;
        }

        public List<string> NonProductiveSymbolElimination(List<string> prod)
        // Eliminate the nonproductive symbols
        {
            //blah
            return prod;
        }

        public List<string> GetChomskyNormalForm(List<string> prod)
        // Obtain the Chomsky Normal Form S=>AB or S=>a
        {
            //fuck this
            return prod;
        }

        public void PrintForm()
        {
            foreach (string line in grammar)
            {
                Console.WriteLine(line);
            }
        }
    }
}
