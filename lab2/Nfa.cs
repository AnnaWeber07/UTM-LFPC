using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2final_final
{
    class Nfa
    {
        
        public List<string> GetTransitionList(string[] lines)
        {
           
        }

        public void ReadAllStates(string[] lines)
        {
            List<string> trans = new List<string>();

            for (int i = 2; i < 8; i++)
            {
                string s = lines[i];
                trans.Add(s);
            }
        }

        public static string[] GetNfa(string[] dataFromFile)
        {
            var states = GetStates(dataFromFile[0]);

            return states;
        }

        private static string[] GetStates(string dataFromFile)
        {
            string[] stringSeparators = new string[] { ", " };
            char a = '{';
            char b = '}';
            var dataFromFile2 = dataFromFile.Substring(dataFromFile.IndexOf(a)+1, dataFromFile.IndexOf(b)-3);
            var elements = dataFromFile2.Split(stringSeparators, 5, StringSplitOptions.RemoveEmptyEntries);

            return elements;
        }

    }
}
