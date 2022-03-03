using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2final_final
{
    public class NfaToDfa
    {

        public static List<Transition> GetList(string[] lines)
        {
            List<Transition> transitionsList = new List<Transition>();
            for (int i = 2; i < 8; i++)
            {
                string line = lines[i];
                var transition = ParseStringLine(line);
                transitionsList.Add(new Transition(transition.firstState, transition.weight, transition.lastState));
            }

            return transitionsList;
        }


        public static (string firstState, string weight, string lastState) ParseStringLine(string line)
        {
            string firstState = line.Substring(2, 2);
            string weight = line.Substring(5, 1);
            string lastState = line.Substring(8, 2);

            return (firstState, weight, lastState);
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
            var dataFromFile2 = dataFromFile.Substring(dataFromFile.IndexOf(a) + 1, dataFromFile.IndexOf(b) - 3);
            var elements = dataFromFile2.Split(stringSeparators, 5, StringSplitOptions.RemoveEmptyEntries);

            return elements;
        }

    }
}
