using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab1
{
    static class Validator
    {
        public static bool Validate(char[,] matrix, string inputFormat)
        {
            var symArr = inputFormat.ToCharArray();

            char lastVertex = char.MinValue;

            for (var i = 0; i < symArr.Length; i++)
            {
                var sym = symArr[i];

                if (!TryFindColIdx(matrix, sym, out var colIdx))
                {
                    return false;
                }

                if (i == 0)
                {
                    var firstVertex = matrix[1, colIdx];
                    if (firstVertex == '-')
                    {
                        return false;
                    }

                    lastVertex = firstVertex;
                    continue;
                }

                if (!TryFindStrIdx(matrix, lastVertex, out var strIdx))
                {
                    return false;
                }

                lastVertex = matrix[strIdx, colIdx];
                if (lastVertex == '-')
                {
                    return false;
                }

                if (lastVertex == '*' && i == symArr.Length - 1)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool TryFindColIdx(char[,] matrix, char sym, out int idx)
        {
            idx = 0;

            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] == sym)
                {
                    idx = i;
                    return true;
                }
            }
            return false;
        }

        private static bool TryFindStrIdx(char[,] matrix, char sym, out int idx)

        {
            idx = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == sym)
                {
                    idx = i;
                    return true;
                }
            }

            return false;
        }
    }
}
