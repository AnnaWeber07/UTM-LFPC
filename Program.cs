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
            
            Console.WriteLine("LFPC LAB 1 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of data:");
            Console.WriteLine();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

           
            Console.WriteLine();
            
            var inputList = lines.ToList();

            var array = Logic.GetArray(inputList.ToArray());

                

            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Enter string: ");
            string input = Console.ReadLine();

            Console.WriteLine(Logic.CheckForString(array, input));

            Console.ReadKey();
        }
    }
}
