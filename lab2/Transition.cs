using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2final_final
{
    public class Transition
    {
        private string _firstState;
        private string _weight;
        private string _lastState;

        public Transition(string firstState, string weight, string lastState)
        {
            FirstState = firstState;
            Weight = weight;
            LastState = lastState;
        }

        public string FirstState
        {
            get { return _firstState; }
            set { _firstState = value; }
        }

        public string Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string LastState
        {
            get { return _lastState; }
            set { _lastState = value; }
        }

    }
}
