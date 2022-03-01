using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab2_final
{
    public class Dfa
    {
        private readonly int startState;
        private readonly Set<int> acceptStates;
        private readonly IDictionary<int, IDictionary<String, int>> trans;

        public Dfa(int startState, Set<int> acceptStates, IDictionary<int, IDictionary<String, int>> trans)
        {
            this.startState = startState;
            this.acceptStates = acceptStates;
            this.trans = trans;
        }

        public int Start { get { return startState; } }

        public Set<int> Accept { get { return acceptStates; } }

        public IDictionary<int, IDictionary<String, int>> Trans
        {
            get { return trans; }
        }

        public override String ToString()
        {
            return "DFA start=" + startState + "\naccept=" + acceptStates;
        }

        public void WriteDot(String filename)
        {
            TextWriter wr =
              new StreamWriter(new FileStream(filename, FileMode.Create,
                                              FileAccess.Write));
            wr.WriteLine("// Format this file as a Postscript file with ");
            wr.WriteLine("//    dot " + filename + " -Tps -o out.ps\n");
            wr.WriteLine("digraph dfa {");
            wr.WriteLine("size=\"11,8.25\";");
            wr.WriteLine("rotate=90;");
            wr.WriteLine("rankdir=LR;");
            wr.WriteLine("n999999 [style=invis];");    // Invisible start node
            wr.WriteLine("n999999 -> n" + startState); // Edge into start state

            // Accept states are double circles
            foreach (int state in trans.Keys)
                if (acceptStates.Contains(state))
                    wr.WriteLine("n" + state + " [peripheries=2];");

            // The transitions 
            foreach (KeyValuePair<int, IDictionary<String, int>> entry in trans)
            {
                int s1 = entry.Key;
                foreach (KeyValuePair<String, int> s1Trans in entry.Value)
                {
                    String lab = s1Trans.Key;
                    int s2 = s1Trans.Value;
                    wr.WriteLine("q" + s1 + " -> q" + s2 + " [symbol=\"" + lab + "\"];");
                }
            }
            wr.WriteLine("}");
            wr.Close();

        }
    }
}
