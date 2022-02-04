using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab1
{
    static class ConvertToInput
    {
        static public int GetNumberOfVertices(string[] lines)
        {
            int frequency = lines.ElementAt(1).Where(x => char.IsLetter(x)).Count();
            return frequency - 2;
        }


        static public int GetNumberOfEdges(string[] lines)
        {
            int frequency = lines.ElementAt(1).Where(x => char.IsLetter(x)).Count();
            return frequency - 2;
        }


        //var splitted = text
        //    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(part => part.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries));
    }
}
