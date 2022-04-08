using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_Chomsky
{
    class Program
    {
        static void Main(string[] args)
        {
            //CHIRICIUC ANNA VAR 9 CHOMSKY NORMAL FORM

            string path = @"C:\Users\Анна\source\repos\LFPC_Chomsky\LFPC_Chomsky\TextFile.txt";
            string[] text = File.ReadAllLines(path);
            List<string> initialGrammar = text.ToList();

            Grammar grammar = new Grammar(initialGrammar);
            grammar.GetChomskyForm();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
