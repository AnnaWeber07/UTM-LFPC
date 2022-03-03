using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2final_final
{
    class Program
    {
        static void Main(string[] args)
        {
            //lab2 CHIRICIUC ANNA VAR 9

            string fileName = @"C:\Users\Анна\source\repos\lab2final_final\lab2final_final\TextFile1.txt";
            string[] lines = File.ReadAllLines(fileName);

            Console.WriteLine("LFPC LAB 2 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of NFA:");

            var i = NfaToDfa.GetList(lines);

            Console.WriteLine("NFA: ", i);
            

            NfaToDfa.GetTransitions(i);
            NfaToDfa.PrintDFA(i);
            

            Console.ReadKey();
        }
    }
}
