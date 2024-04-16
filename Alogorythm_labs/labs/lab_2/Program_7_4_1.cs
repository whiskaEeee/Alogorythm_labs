using System;
using System.Collections.Generic;
using System.Linq;

namespace Alogorythm_labs.lab_1
{
    internal class Program_7_4_1
    {
        class Edge
        {
            public int Source;
            public int Destination;
            public int Weight;

            public Edge(int source, int destination, int weight)
            {
                Source = source;
                Destination = destination;
                Weight = weight;
            }
        }
        static int FindParent(int[] parent, int vertex)
        {
            if (parent[vertex] == -1)
                return vertex;
            return FindParent(parent, parent[vertex]);
        }
        static void Union(int[] parent, int x, int y)
        {
            int xSet = FindParent(parent, x);
            int ySet = FindParent(parent, y);
            parent[xSet] = ySet;
        }
        static List<Edge> KruskalMST(List<Edge> edges, int numberOfVertices)
        {
            List<Edge> minimumSpanningTree = new List<Edge>();
            edges = edges.OrderBy(edge => edge.Weight).ToList();
            int[] parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
                parent[i] = -1;
            int edgeCount = 0;
            int index = 0;
            while (edgeCount < numberOfVertices - 1)
            {
                Edge nextEdge = edges[index++];
                int x = FindParent(parent, nextEdge.Source);
                int y = FindParent(parent, nextEdge.Destination);
                if (x != y)
                {
                    minimumSpanningTree.Add(nextEdge);
                    Union(parent, x, y);
                    edgeCount++;
                }
            }
            return minimumSpanningTree;
        }
        public static void Main(string[] args)
        {
                List<Edge> edges = new List<Edge>
            {
                new Edge(0, 1, 4),
                new Edge(1, 2, 1),
                new Edge(2, 3, 1),
                new Edge(3, 7, 6),
                new Edge(7, 6, 5),
                new Edge(3, 6, 8),
                new Edge(2, 7, 7),
                new Edge(6, 5, 1),
                new Edge(5, 4, 4),
                new Edge(4, 0, 9),
                new Edge(0, 5, 10),
                new Edge(4, 2, 3),
                new Edge(1, 6, 2),
                new Edge(2, 5, 1),
            };
                int numberOfVertices = 8;
                List<Edge> minimumSpanningTree = KruskalMST(edges, numberOfVertices);
                Console.WriteLine("Edges in the Minimum Spanning Tree:");
                foreach (var edge in minimumSpanningTree)
                {
                    Console.WriteLine($"{edge.Source} - {edge.Destination} (Weight: {edge.Weight})");
                }
            Console.ReadKey();
        }
    }
}
