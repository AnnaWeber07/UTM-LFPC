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

        public void GetChomskyForm()
        {
            List<string> production = new List<string>();
            List<string> production2 = new List<string>();
            List<string> production3 = new List<string>();
            List<string> production4 = new List<string>();
            List<string> production5 = new List<string>();
            List<string> production6 = new List<string>();

            NonTerminal = GetNonterminalSymbols(grammar);
            Terminal = GetTerminalSymbols(grammar);

            production = GetProduction(grammar);

            production2 = EpsilonElimination(production);
            //PrintForm(production2);

            production3 = RenamingElimination(production2);
            //            PrintForm(production3);

            production4 = InaccessibleSymbolElimination(production3);
            //          PrintForm(production4);

            production5 = NonProductiveSymbolElimination(production4);
            //        PrintForm(production5);

            production6 = GetChomskyNormalForm(production5);
            //      PrintForm(production6);
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

        private List<string> GetNonterminalSymbols(List<string> grammar)
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

        private List<string> EpsilonElimination(List<string> prod)
        //Eliminate epsilon productions
        {
            //get P transitions copied to a new list for easier use
            List<string> production = new List<string>();
            List<string> result = new List<string>();
            List<string> final = new List<string>();
            List<char> nonterminal = new List<char>();

            result.AddRange(prod);

            foreach (string line in prod) //find character(s) leading to e & remove those lines
            {
                if (line.Contains("epsilon"))
                {
                    char symbol = line.ElementAt(0);
                    nonterminal.Add(symbol);
                    result.Remove(line);
                }
            }

            foreach (string line in prod) //find rules to eliminate e productions
            {
                foreach (char symbol in nonterminal)
                {
                    if (line.Contains(symbol) && line.IndexOf(symbol) != 0)
                    {
                        production.Add(line);
                    }
                }
            }

            foreach (string line in production) //append additional strings to list
            {
                foreach (char symbol in nonterminal)
                {
                    if (line.Contains(symbol) && line.IndexOf(symbol) != 0)
                    {
                        char[] removeOneChar = line.ToArray();
                        var iterationForAppend = removeOneChar.Count(p => p == symbol);

                        for (int i = 0; i <= iterationForAppend; i++)
                        {
                            int position = line.IndexOf(symbol);
                            string formatted = line.Remove(position, i);
                            result.Add(formatted);
                        }
                    }
                }
            }

            final = result.Distinct().ToList(); //remove duplicates

            return final;
        }

        private List<string> RenamingElimination(List<string> prod)
        //Eliminate any renaming
        {
            //The production that has the form X->Y, X and Y are nonterminal, is called renaming

            List<string> production = new List<string>();
            List<string> result = new List<string>();
            List<string> additional = new List<string>();

            result.AddRange(prod);

            foreach (string line in prod) //find unit productions
            {
                string check = line.Substring(3);

                if (check.All(x => Char.IsUpper(x)) && check.Length == 1)
                {
                    production.Add(line);
                    result.Remove(line); //remove X -> Y productions. they ae still available for iterations
                }
            }

            //for each X -> Y, substitute with Y values:

            foreach (string line in production)
            {
                string symbol = line.Substring(0, 1); //get needed symbol
                string startOfReplacement = line.Substring(3, 1);

                foreach (string checker in result)
                {
                    if (checker.StartsWith(startOfReplacement))
                    {

                        string format = symbol + "=>" + checker.Substring(3);
                        additional.Add(format);
                    }
                }
            }

            result.AddRange(additional);

            return result;
        }

        private List<string> InaccessibleSymbolElimination(List<string> prod)
        //Eliminate inaccessible symbols
        {
            List<string> result = new List<string>();

            result.AddRange(prod);




            return result;
        }



        private List<string> NonProductiveSymbolElimination(List<string> prod)
        // Eliminate the nonproductive symbols
        {
            //blah
            return prod;
        }

        private List<string> GetChomskyNormalForm(List<string> prod)
        // Obtain the Chomsky Normal Form S=>AB or S=>a
        {
            //fuck this
            return prod;
        }

        private void PrintForm(List<string> grammar)
        {
            foreach (string line in grammar)
            {
                Console.WriteLine(line);
            }
        }


    }
}
