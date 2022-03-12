using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexerSharp;

namespace LexerSharp
{
    class Program
    {
        //LFPC LAB 3 CHIRICIUC ANNA
        //LEXER
        //LATIN DSL

        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"C:\Users\Анна\source\repos\ConsoleApp1\ConsoleApp1\Libellus.txt");

            Scanner scanner = new Scanner(text);
            scanner.ScanTokens();

            Console.WriteLine("LFPC LAB 3 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of latin DSL");
            Console.WriteLine();

            scanner.Output();

            Console.ReadKey();
        }
    }
}
