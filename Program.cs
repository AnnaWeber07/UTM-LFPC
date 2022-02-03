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
            string grammar;
            string fileName = @"C:\Users\Анна\source\repos\LFPC_lab1\LFPC_lab1\var.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                grammar = sr.ReadToEnd();
            }

            ConvertToInput convertToInput = new ConvertToInput();

            int vertices = convertToInput.GetNumberOfVertices(grammar); //get the number of vertices
            int edges = convertToInput.GetNumberOfEdges(grammar);

            Console.WriteLine("LFPC LAB 1 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of data:");
            Console.WriteLine(grammar);

            Console.Write("Number of nonterminal symbols: ");
            Console.WriteLine(vertices);
            Console.Write("Number of terminal symbols: ");
            Console.WriteLine(edges);

            AdjacencyList adjacencyList = new AdjacencyList(vertices + 1);

            Console.WriteLine();

            for (int i = 0; i < edges; i++) //передача построчно инпут и дальнейшая его конвертация
            {

            }


            Console.WriteLine("Enter -> startVertex endVertex weight");



            //Console.WriteLine("Enter the edges with weights -");
            //int startVertex, endVertex, weight;

            //for (int i = 0; i < edges; ++i)
            //{
            //    startVertex = Int32.Parse(Console.ReadLine());
            //    endVertex = Int32.Parse(Console.ReadLine());
            //    weight = Int32.Parse(Console.ReadLine());

            //    adjacencyList.addEdgeAtEnd(startVertex, endVertex, weight);
            //}

            //adjacencyList.printAdjacencyList();



            // Spilt by space as delimeter
            //String[] input = Console.ReadLine().Split(' ');
            //var splitted = text
            //    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(part => part.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries));

            //int startVertex = Int32.Parse(input[0]);
            //int endVertex = Int32.Parse(input[1]);
            //int weight = Int32.Parse(input[2]);

            //for each \n line 0 + 2, 1 + 2, 2 + 2
            //Console.WriteLine(startVertex);
            //Console.WriteLine(endVertex);
            //Console.WriteLine(weight);

            Console.ReadKey();
        }
    }
}
