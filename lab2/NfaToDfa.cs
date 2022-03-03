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
            for (int i = 2; i < 8; i++) //fill in the transition list with objects 
            {
                string line = lines[i];
                var transition = ParseStringLine(line);
                transitionsList.Add(new Transition(transition.firstState, transition.weight, transition.lastState));
            }
            //добавить сортировку по первому стейту (?)
            return transitionsList;
        }

        public static List<Transition> GetTransitions(List<Transition> transitions)
        {
            //  transitions.OrderBy(x => x.FirstState);
            for (int i = 0; i < 4; i++)
            {

                if ((transitions[i].FirstState == transitions[i + 1].FirstState)
                    && transitions[i].Weight == transitions[i + 1].Weight)
                {

                    foreach (Transition t in transitions)
                    {
                        if (t.FirstState == transitions[i].FirstState)
                        {
                            string concat = transitions[i + 1].LastState + transitions[i].LastState;

                            t.FirstState = concat;
                            t.LastState = concat;
                        }

                        if (t.LastState == transitions[i].LastState)
                        {
                            string concat = transitions[i + 1].LastState + transitions[i].LastState;

                            t.LastState = concat;
                            t.LastState = concat;
                        }
                    }
                }

                else if ((transitions[i].LastState == transitions[i + 1].FirstState)
                    && (transitions[i].Weight == transitions[i + 1].Weight))
                {
                    string concat = transitions[i].LastState + transitions[i + 1].FirstState;

                    foreach (Transition t in transitions)
                    {
                        if (t.FirstState == transitions[i].FirstState)
                        {
                            t.FirstState = concat;
                            t.LastState = concat;
                        }
                    }
                }
            }

            return transitions;
        }


        public static void PrintDFA(List<Transition> transitions)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(transitions[i].FirstState, transitions[i].Weight, transitions[i].LastState);
            }
        }

        public static (string firstState, string weight, string lastState) ParseStringLine(string line)
        {
            // parse the line and pick first state, weight of transition and last state
            string firstState = line.Substring(2, 2);
            string weight = line.Substring(5, 1);
            string lastState = line.Substring(8, 2);

            return (firstState, weight, lastState); //return these objects
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
