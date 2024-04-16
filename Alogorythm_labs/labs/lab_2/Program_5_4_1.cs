using System;
using System.Collections.Generic;
using System.Linq;

namespace Alogorythm_labs.lab_1
{
    internal class Program_5_4_1
    {
        public class Edge
        {
            public int Source { get; set; }
            public int Destination { get; set; }
            public int Weight { get; set; }
        }

        public class Graph
        {
            public int Vertices { get; set; }
            public List<List<Edge>> AdjacencyList { get; set; }

            public Graph(int vertices)
            {
                Vertices = vertices;
                AdjacencyList = new List<List<Edge>>(vertices);
                for (int i = 0; i < vertices; i++)
                {
                    AdjacencyList.Add(new List<Edge>());
                }
            }

            public void AddEdge(int source, int destination, int weight)
            {
                AdjacencyList[source].Add(new Edge { Source = source, Destination = destination, Weight = weight });
                AdjacencyList[destination].Add(new Edge { Source = destination, Destination = source, Weight = weight });
            }

            public List<Edge> PrimMST()
            {
                List<Edge> result = new List<Edge>();
                bool[] visited = new bool[Vertices];
                int[] parent = new int[Vertices];
                int[] key = new int[Vertices];

                for (int i = 0; i < Vertices; i++)
                {
                    key[i] = int.MaxValue;
                }

                key[0] = 0;
                parent[0] = -1;

                for (int count = 0; count < Vertices - 1; count++)
                {
                    int u = MinKey(key, visited);
                    visited[u] = true;

                    foreach (var edge in AdjacencyList[u])
                    {
                        int v = edge.Destination;
                        if (!visited[v] && edge.Weight < key[v])
                        {
                            parent[v] = u;
                            key[v] = edge.Weight;
                        }
                    }
                }

                for (int i = 1; i < Vertices; i++)
                {
                    result.Add(new Edge { Source = parent[i], Destination = i, Weight = key[i] });
                }

                return result;
            }

            private int MinKey(int[] key, bool[] visited)
            {
                int min = int.MaxValue;
                int minIndex = -1;

                for (int v = 0; v < Vertices; v++)
                {
                    if (!visited[v] && key[v] < min)
                    {
                        min = key[v];
                        minIndex = v;
                    }
                }

                return minIndex;
            }
        }

        public static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 2, 6);
            graph.AddEdge(0, 3, 5);
            graph.AddEdge(1, 3, 15);
            graph.AddEdge(2, 3, 4);

            List<Edge> result = graph.PrimMST();
            Console.WriteLine("Edges in the MST:");
            foreach (var edge in result)
            {
                Console.WriteLine($"{edge.Source} -- {edge.Destination} : {edge.Weight}");
            }

            Console.ReadKey();
        }
    }
}
