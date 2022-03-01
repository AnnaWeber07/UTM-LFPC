using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab2_final
{
    class Transition
    {
        public String lab;
        public int target;

        public Transition(String lab, int target)
        {
            this.lab = lab; this.target = target;
        }

        public override String ToString()
        {
            return "-" + lab + "-> " + target;
        }
    }
}
