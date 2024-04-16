using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Alogorythm_labs.lab_1
{
    internal class Program_4_4_1
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
            public List<Edge> Edges { get; set; }

            public Graph(int vertices)
            {
                Vertices = vertices;
                Edges = new List<Edge>();
            }

            public void AddEdge(int source, int destination, int weight)
            {
                Edges.Add(new Edge { Source = source, Destination = destination, Weight = weight });
            }

            public List<Edge> KruskalMST()
            {
                List<Edge> result = new List<Edge>();

                Edges = Edges.OrderBy(edge => edge.Weight).ToList();

                int[] parent = new int[Vertices];
                for (int v = 0; v < Vertices; v++)
                    parent[v] = v;

                int index = 0;
                int edgeCount = 0;
                while (edgeCount < Vertices - 1)
                {
                    Edge nextEdge = Edges[index++];
                    int x = Find(parent, nextEdge.Source);
                    int y = Find(parent, nextEdge.Destination);

                    if (x != y)
                    {
                        result.Add(nextEdge);
                        Union(parent, x, y);
                        edgeCount++;
                    }
                }
                return result;
            }


            private int Find(int[] parent, int i)
            {
                if (parent[i] != i)
                    parent[i] = Find(parent, parent[i]);
                return parent[i];
            }

            private void Union(int[] parent, int x, int y)
            {
                int xSet = Find(parent, x);
                int ySet = Find(parent, y);
                parent[xSet] = ySet;
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

            List<Edge> result = graph.KruskalMST();
            Console.WriteLine("Edges in the MST:");
            foreach (var edge in result)
            {
                Console.WriteLine($"{edge.Source} -- {edge.Destination} : {edge.Weight}");
            }

            Console.ReadKey();
        }
    }

}
