using System;

namespace CoreParser
{
    class Program
    {
        //SIMPLE PRECEDENCE PARSER VAR 9
        static void Main(string[] args)
        {
            var path = @"C:\Users\Анна\source\repos\CoreParser\CoreParser\TextFile1.txt";
            var grammar = new Grammar(path, "S");

            Console.WriteLine("Initial grammar: ");
            Console.WriteLine(grammar);

            Console.WriteLine();

            var firstLastTable = new RelationsTable(grammar);
            Console.WriteLine("First Last table: ");

            Console.WriteLine(firstLastTable);

            var precedenceMatrix = new PrecedenceMatrix(firstLastTable, grammar);
            Console.WriteLine("Rules and Precedence matrix: ");

            Console.WriteLine(precedenceMatrix);

            Console.WriteLine("Parsing: ");
            var parser = new Parser(grammar, precedenceMatrix.M);
        }
    }
}
