using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab2_final
{
    class Program
    {
        //9 var

        public static void BuildAndShow(String fileName)
        {
            Console.WriteLine(nfa);
            Console.WriteLine("---");
           
            Console.WriteLine(dfa);
            Console.WriteLine("Writing DFA graph to file " + fileName);
            dfa.WriteDot(fileName);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            Nfa nfa = new Nfa(0, 4);
            Dfa dfa = nfa.ToDfa();

        }
    }
}
