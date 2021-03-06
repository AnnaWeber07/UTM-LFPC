using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser
{
    public class Parser
    {
        public List<string> ParsingValue { get; set; } = new();

        public Parser(Grammar grammar, MatrixFiller m)
        {
            Console.WriteLine($"Input: {grammar.Input}");
            string initialParsing = "$<";

            for (int i = 1; i < grammar.Input.Length; i++)
            {
                string left = grammar.Input[i - 1].ToString();
                string right = grammar.Input[i].ToString();

                if (string.IsNullOrEmpty(m.Matrix[left][right]))
                {
                    Console.WriteLine($"Could not parse Input at characters: {left}{right}");
                    return;
                }

                initialParsing += $"{left}{m.Matrix[left][right]}";
            }

            initialParsing += $"{grammar.Input[^1]}>$";

            ParsingValue = initialParsing.Select(x => x.ToString()).ToList();

            Console.WriteLine(string.Join("", ParsingValue));

            Parse(grammar, m);
        }
        private void Parse(Grammar grammar, MatrixFiller m)
        {
            if (ParsingValue.Contains("S")) return;

            int posRight = ParsingValue.Count - 1;
            int posLeft = posRight;

            string derivation = "";

            while (ParsingValue[posLeft] != "<")
            {
                if (ParsingValue[posLeft] == ">")
                {
                    posRight = posLeft; derivation = "";
                }
                else if (ParsingValue[posLeft] != "=")
                {
                    derivation = derivation.Insert(0, ParsingValue[posLeft]);
                }

                posLeft--;
            }

            var keysWithDerivation = grammar.P.Where(x => x.Value.Contains(derivation)).Select(x => x.Key).ToList();
            var newDerivation = "";

            if (!keysWithDerivation.Any())
            {
                Console.WriteLine("Could not parse Input (keys with derivations not found)");
                return;
            }

            if (keysWithDerivation.Count == 1) newDerivation = keysWithDerivation[0];

            else
            {
                var possibleDerivation = "";
                var bestPickedDefinitions = "  ";

                foreach (var key in keysWithDerivation)
                {
                    var leftDefinition = m.Matrix[ParsingValue[posLeft - 1]][key];
                    var rightDefinition = m.Matrix[key][ParsingValue[posRight + 1]];
                    var pickedDefinitions = leftDefinition + rightDefinition;

                    if (!string.IsNullOrEmpty(leftDefinition) && !string.IsNullOrEmpty(rightDefinition))
                    {
                        if (rightDefinition == "=") { possibleDerivation = key; bestPickedDefinitions = pickedDefinitions; }
                        else if ((leftDefinition == "=") && bestPickedDefinitions[1] != '=') { possibleDerivation = key; bestPickedDefinitions = pickedDefinitions; }
                        else if (!bestPickedDefinitions.Contains('=')) { possibleDerivation = key; bestPickedDefinitions = pickedDefinitions; }

                    }
                }

                newDerivation = possibleDerivation;
            }

            if (string.IsNullOrEmpty(newDerivation))
            {
                Console.WriteLine("Could not parse Input (no new derivation)");
                return;
            }

            ParsingValue.RemoveRange(posLeft + 1, posRight - posLeft - 1);

            ParsingValue.Insert(posLeft + 1, newDerivation);

            var replaceLeft = m.Matrix[ParsingValue[posLeft - 1]][ParsingValue[posLeft + 1]];
            var replaceRight = m.Matrix[ParsingValue[posLeft + 1]][ParsingValue[posLeft + 3]];
            var testValue = ParsingValue.Select(x => x).ToList();

            testValue[posLeft] = replaceLeft;
            testValue[posLeft + 2] = replaceRight;

            if (string.IsNullOrEmpty(replaceLeft) && string.IsNullOrEmpty(replaceRight))
            {
                Console.WriteLine(string.Join("", testValue));
                Console.WriteLine($"Could not parse Input (no value in matrix[{ParsingValue[posLeft - 1]}][{ParsingValue[posLeft + 1]}] and matrix[{ParsingValue[posLeft + 1]}][{ParsingValue[posLeft + 3]}])");
                return;
            }

            else if (string.IsNullOrEmpty(replaceLeft))
            {
                Console.WriteLine(string.Join("", testValue));
                Console.WriteLine($"Could not parse Input (no value in matrix[{ParsingValue[posLeft - 1]}][{ParsingValue[posLeft + 1]}])");
                return;
            }

            else if (string.IsNullOrEmpty(replaceRight))
            {
                Console.WriteLine(string.Join("", testValue));
                Console.WriteLine($"Could not parse Input (no value in matrix[{ParsingValue[posLeft + 1]}][{ParsingValue[posLeft + 3]}])");
                return;
            }

            ParsingValue[posLeft] = replaceLeft;
            ParsingValue[posLeft + 2] = replaceRight;

            Console.WriteLine(string.Join("", ParsingValue));
            Parse(grammar, m);
        }
    }
}
