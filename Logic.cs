using System;
using System.Collections.Generic;
using System.Linq;

namespace LFPC_lab1
{
    public static class Logic
    {
        public static char[,] GetArray(string[] dataFromFile)
        {

            var vnDataString = GetVDataString(dataFromFile[0]);
            var vtDataString = GetVDataString(dataFromFile[1]);

            var vnElements = GetVElements(vnDataString);
            var vtElements = GetVElements(vtDataString);


            var array = new char[vnElements.Count() + 1, vtElements.Count() + 1];

            for (var i = 3; i < dataFromFile.Length; i++)
            {
                var objEdgeDest = ParseInstructionLine(dataFromFile[i]);

                var x = GetCellIdx(vnElements, objEdgeDest.obj);
                var y = GetCellIdx(vtElements, objEdgeDest.edge);

                for (var a = 0; a < vnElements.Length; a++)
                {
                    array[a + 1, 0] = vnElements[a];

                    for (var b = 0; b < vtElements.Length; b++)
                        array[0, b + 1] = vtElements[b];
                }

                array[x + 1, y + 1] = objEdgeDest.destination;
            }

            FillEmptyCells(array);


            // string[,] converted = (string[,])array.Clone();


            return array;
        }


        public static string[,] CopyArray(char[,] matrix, string[] dataFromFile)
        {
            Dictionary<char, string> openWith = new Dictionary<char, string>();

            var vnDataString = GetVDataString(dataFromFile[0]);
            var vtDataString = GetVDataString(dataFromFile[1]);

            var vnElements = GetVElements(vnDataString);
            var vtElements = GetVElements(vtDataString);

            var stringArray = new string[vnElements.Count() + 1, vtElements.Count() + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    string s = String.Format("{0}", matrix[i, j]);
                    stringArray[i, j] = s;
                }
            }

            for (int i = 0; i < vnElements.Length; i++) //mapping of elements
            {
                string j = String.Format("q{0}", i);
                char c = vnElements[i];
                openWith.Add(c, j);
            }




            return stringArray;
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

//стек абстрактная структура данных для fa анализ строки для грамматики
//mapping s=>q0 output