﻿using System;
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
            //lab2 CHIRICIUC ANNA var 9

            string fileName = @"C:\Users\Анна\source\repos\lab2final_final\lab2final_final\TextFile1.txt";
            string[] lines = File.ReadAllLines(fileName);

            Console.WriteLine("LFPC LAB 2 CHIRICIUC ANNA");
            Console.WriteLine("Analysis of NFA:");

            var array = Nfa.GetNfa(lines);
            Nfa nfa = new Nfa();
            nfa.ReadAllStates(lines);
            Console.WriteLine();

            




            Console.ReadKey();
        }
    }
}