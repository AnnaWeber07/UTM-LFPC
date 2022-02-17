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

            var array2 = Logic.CopyArray(array, lines);

            for (var i = 0; i < array2.GetLength(0); i++)
            {
                for (var j = 0; j < array2.GetLength(1); j++)
                {
                    Console.Write(array2[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            
            

            string input = "acdbcdc";
            var hz = Validator.Validate(array, input);

            Console.WriteLine("Enter string: ");
            string hz2 = Console.ReadLine();

            var idk = Validator.Validate(array, hz2);
            Console.WriteLine(idk);

            Console.ReadKey();
        }
    }
}
