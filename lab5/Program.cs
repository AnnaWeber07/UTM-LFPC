using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrecedenceParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //CHIRICIUC ANNA VAR 9
            //SIMPLE PRECEDENCE PARSER
            //STIRNG TO ANALYZE: abacdae

            string toAnalyze = "abacdae";

            string path = @"C:\Users\Анна\source\repos\SimplePrecedenceParser\SimplePrecedenceParser\TextFile1.txt";

            string[] text = File.ReadAllLines(path);
            List<string> initialGrammar = text.ToList();

            Parser parser = new Parser(initialGrammar);


        }
    }
}
