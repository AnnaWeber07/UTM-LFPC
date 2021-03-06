using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser
{
    public class MatrixFiller
    {
        public Dictionary<string, Dictionary<string, string>> Matrix { get; set; }

        public MatrixFiller(HashSet<string> Vn, HashSet<string> Vt)
        {
            Matrix = new();

            var symbols = new List<string>(Vn);
            symbols.AddRange(Vt);
            symbols.Add("$");

            foreach (var row in symbols)
            {
                Matrix[row] = new Dictionary<string, string>();
                foreach (var column in symbols)
                {
                    Matrix[row][column] = "";
                    if (column == "$") Matrix[row][column] = ">";
                    if (row == "$") Matrix[row][column] = "<";
                }
            }

            Matrix["$"]["$"] = "";
        }

        public override string ToString()
        {
            string matrix = "   ";
            foreach (var key in this.Matrix.Keys)
            {
                matrix += $"| {key} ";
            }

            matrix += "\n";

            foreach (var (key, values) in this.Matrix)
            {
                matrix += $"{key}  ";
                foreach (var value in values.Values)
                {
                    matrix += $"| {(value == string.Empty ? " " : value)} ";
                }
                matrix += "\n";
            }

            return matrix;
        }
    }
}
