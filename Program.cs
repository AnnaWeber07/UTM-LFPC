using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab1
{
    //LFPC LAB 1 CHIRICIUC ANNA
    //REGULAR GRAMMAR TO FINITE AUTOMATA
    //VARIANT 9

    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Анна\source\repos\LFPC_lab1\LFPC_lab1\var.txt";

            string[] lines = File.ReadAllLines(fileName);

            int vertices = ConvertToInput.GetNumberOfVertices(lines); //get the number of vertices
            int edges = ConvertToInput.GetNumberOfEdges(lines);

            Console.WriteLine("LFPC LAB 1 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of data:");
            Console.WriteLine();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
            Console.Write("Number of nonterminal symbols: ");
            Console.WriteLine(vertices);
            Console.Write("Number of terminal symbols: ");
            Console.WriteLine(edges);

            char[,] AdjacencyMatrix = new char[vertices + 1, edges + 1];


            //String[] input = Console.ReadLine().Split(' ');
            //var splitted = text
            //    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(part => part.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries));

            Console.ReadKey();
        }
    }
}
