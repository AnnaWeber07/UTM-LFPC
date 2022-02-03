using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab1
{
    class AdjacencyList
    {
        LinkedList<Tuple<char, char>>[] adjacencyList;

        // Constructor - creates an empty Adjacency List
        public AdjacencyList(int vertices)
        {
            adjacencyList = new LinkedList<Tuple<char, char>>[vertices];

            for (int i = 0; i < adjacencyList.Length; ++i)
            {
                adjacencyList[i] = new LinkedList<Tuple<char, char>>();
            }
        }

        // Appends a new Edge to the linked list
        public void addEdgeAtEnd(char startVertex, char endVertex, char weight)
        {
            adjacencyList[startVertex].AddLast(new Tuple<char, char>(endVertex, weight));
        }

        // Adds a new Edge to the linked list from the front
        public void addEdgeAtBegin(char startVertex, char endVertex, char weight)
        {
            adjacencyList[startVertex].AddFirst(new Tuple<char, char>(endVertex, weight));
        }

        // Returns number of vertices
        // Does not change for an object
        public int getNumberOfVertices()
        {
            return adjacencyList.Length;
        }

        // Returns a copy of the Linked List of outward edges from a vertex
        public LinkedList<Tuple<char, char>> this[char index]
        {
            get
            {
                LinkedList<Tuple<char, char>> edgeList
                               = new LinkedList<Tuple<char, char>>(adjacencyList[index]);

                return edgeList;
            }
        }

        // Prints the Adjacency List
        public void printAdjacencyList()
        {
            int i = 0;

            foreach (LinkedList<Tuple<char, char>> list in adjacencyList)
            {
                Console.Write("adjacencyList[" + i + "] -> ");

                foreach (Tuple<char, char> edge in list)
                {
                    Console.Write(edge.Item1 + "(" + edge.Item2 + ")");
                }

                ++i;
                Console.WriteLine();
            }
        }

        // Removes the first occurence of an edge and returns true
        // if there was any change in the collection, else false
        public bool removeEdge(char startVertex, char endVertex, char weight)
        {
            Tuple<char, char> edge = new Tuple<char, char>(endVertex, weight);

            return adjacencyList[startVertex].Remove(edge);
        }
    }

    class TestGraph
    {
        //public static void Main()
        //{
        //    Console.WriteLine("Enter the number of vertices -");
        //    int vertices = Int32.Parse(Console.ReadLine());

        //    AdjacencyList adjacencyList = new AdjacencyList(vertices + 1);

        //    Console.WriteLine("Enter the number of edges -");
        //    int edges = Int32.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter the edges with weights -");
        //    int startVertex, endVertex, weight;

        //    for (int i = 0; i < edges; ++i)
        //    {
        //        startVertex = Int32.Parse(Console.ReadLine());
        //        endVertex = Int32.Parse(Console.ReadLine());
        //        weight = Int32.Parse(Console.ReadLine());

        //        adjacencyList.addEdgeAtEnd(startVertex, endVertex, weight);
        //    }

        //    adjacencyList.printAdjacencyList();
        //    adjacencyList.removeEdge(1, 2, 1);
        //    adjacencyList.printAdjacencyList();
        //}
    }

}
