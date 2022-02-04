using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab1
{
    public static class Logic
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

        public static char[,] GetArray(string[] dataFromFile)
        {
            var vnDataString = GetVDataString(dataFromFile[0]);
            var vtDataString = GetVDataString(dataFromFile[1]);

            var vnElements = GetVElements(vnDataString);
            var vtElements = GetVElements(vtDataString);

            var array = new char[vnElements.Count(), vtElements.Count()];

            for (var i = 3; i < dataFromFile.Length; i++)
            {
                var objEdgeDest = ParseInstructionLine(dataFromFile[i]);

                var x = GetCellIdx(vnElements, objEdgeDest.obj);
                var y = GetCellIdx(vtElements, objEdgeDest.edge);

                array[x, y] = objEdgeDest.destination;
            }

            FillEmptyCells(array);

            return array;
        }

        public static string GetVDataString(string vDataLine)
        {
            return vDataLine.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        public static char[] GetVElements(string vDataString)
        {
            var elements = vDataString.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            return elements
                .Select(x => char.Parse(x))
                .ToArray();
        }

        public static (char obj, char edge, char destination) ParseInstructionLine(string line)
        {
            var splitted = line.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var obj = char.Parse(splitted[0]);
            var edge = splitted[1].ElementAt(0);
            var destination = splitted[1].Length > 1
                ? splitted[1].ElementAt(1)
                : '*';

            return (obj, edge, destination);
        }

        public static int GetCellIdx(char[] definitionArray, char x)
        {
            for (var i = 0; i < definitionArray.GetLength(0); i++)
            {
                if (definitionArray[i] == x)
                {
                    return i;
                }
            }

            throw new InvalidOperationException();
        }

        public static void FillEmptyCells(char[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == '\0')
                    {
                        array[i, j] = '-';
                    }
                }
            }
        }
    }
}