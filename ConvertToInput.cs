using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab1
{
    class ConvertToInput
    {
        public int GetNumberOfVertices(string grammar)
        {
            string result = grammar.Substring(grammar.IndexOf('{'), grammar.IndexOf('}'));
            int frequency = result.Where(x => char.IsLetter(x)).Count();

            return frequency;
        }

        public int GetNumberOfEdges(string grammar)
        {
            int frequency = grammar.Count(f => f == '=');
            return frequency - 3;
        }


        //split the string by lines

        public String ReturnTheString(string grammar)
        {
            string result;

            return result;
        }


        //public string Converter(String grammar)
        //{
        //    string conv = grammar;
        //    string input;
        //    //creating array of string length
        //    char[] ch = new char[conv.Length];


        //var splitted = text
        //    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(part => part.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries));
    }
}
