using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerSharp
{
    

    class Program
    {
        //LFPC LAB 3 CHIRICIUC ANNA
        //LEXER
        //LATIN DSL

        static void Main(string[] args)
        {
            string libellus = @"C:\Users\Анна\source\repos\LexerSharp\LexerSharp\Libellus.txt";
            string[] lineae = File.ReadAllLines(libellus);

            Console.WriteLine("LFPC LAB 3 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of latin program:");
            Console.WriteLine("");

            foreach (string linea in lineae)
            {
                Console.WriteLine(linea);
            }

            foreach (String linea in lineae)
            {
                Scanner scanner = new Scanner(linea);
                List<Token> tokens = scanner.scanTokens();

                foreach (Token token in tokens)
                {
                    Console.WriteLine(token);
                }
            }


            Console.WriteLine();

        }
    }
}
