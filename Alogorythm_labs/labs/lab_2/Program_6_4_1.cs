using System;
using System.Collections.Generic;
using System.Linq;

namespace Alogorythm_labs.lab_1
{
    internal class Program_6_4_1
    {
        static int V = 8;
        static int minKey(int[] key, bool[] mstSet)
        {

            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t"
                                  + graph[i, parent[i]]);
        }

        static void primMST(int[,] graph)
        {
            int[] parent = new int[V];


            int[] key = new int[V];

            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {

                int u = minKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < V; v++)
                    if (graph[u, v] != 0 && mstSet[v] == false
                        && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            printMST(parent, graph);
        }

        public static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 9, 10, 0, 0 },
                                      { 4, 0, 1, 0, 3, 0, 2, 0 },
                                      { 0, 1, 0, 1, 0, 1, 0, 7 },
                                      { 0, 0, 1, 0, 0, 0, 8, 6 },
                                      { 9, 3, 0, 0, 0, 4, 0, 0 },
                                      { 10, 0, 1, 0, 4, 0, 1, 0 },
                                      { 0, 2, 0, 8, 0, 1, 0, 5 },
                                      { 0, 0, 7, 6, 0, 0, 5, 0 },
            };
            primMST(graph);
            Console.ReadKey();
        }
    }
}
