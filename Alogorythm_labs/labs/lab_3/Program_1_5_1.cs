using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Alogorythm_labs.lab_1
{
    internal class Program_1_5_1
    {

        public static (int, int, Dictionary<int, int?>, double, string) DinamProg(List<(int, int, int)> graph)
        {
            var startTime = Stopwatch.StartNew();

            var vertices = new HashSet<int>(graph.Select(x => x.Item1).Concat(graph.Select(x => x.Item2)));
            var verticesPaths = new Dictionary<int, int?>();
            var verticesPathsNames = new Dictionary<int, int?>();

            foreach (var v in vertices)
            {
                verticesPaths[v] = null;
            }
            verticesPaths[1] = 0;

            while (verticesPaths[vertices.Max()] == null)
            {
                foreach (var v in vertices)
                {
                    if (verticesPaths[v] == null)
                    {
                        var a = graph.Where(x => x.Item2 == v).ToList();
                        foreach (var j in a)
                        {
                            if (verticesPaths[j.Item1] == null)
                            {
                                break;
                            }
                            else
                            {
                                (int minPath, int? minPathVertex) = GetMinPath(a, verticesPaths);
                                verticesPaths[v] = minPath;
                                verticesPathsNames[v] = minPathVertex;
                            }
                        }
                    }
                }
            }

            var pathList = new List<int>();
            int current = vertices.Max();
            while (current != 1)
            {
                pathList.Add(current);
                current = verticesPathsNames[current].Value;
            }

            pathList.Add(1);
            pathList.Reverse();
            var path = string.Join("->", pathList);

            startTime.Stop();
            var time = startTime.Elapsed.TotalSeconds;

            return (vertices.Count, graph.Count, verticesPaths, time, path);
        }

        public static (int, int?) GetMinPath(List<(int, int, int)> a, Dictionary<int, int?> f)
        {
            int minPath = int.MaxValue;
            int? minPathVertex = null;

            foreach (var item in a)
            {
                if (f[item.Item1] != null && item.Item3 + f[item.Item1].Value < minPath)
                {
                    minPath = item.Item3 + f[item.Item1].Value;
                    minPathVertex = item.Item1;
                }
            }

            return (minPath, minPathVertex);
        }

        public static void Main(string[] args)
        {
            var graph1 = new List<(int, int, int)>
        {
            (1, 2, 1), (2, 3, 2), (3, 6, 3), (6, 7, 4), (2, 7, 15),
            (1, 7, 20), (5, 7, 6), (1, 5, 25), (4, 5, 9), (1, 4, 8)
        };


            var graph2 = new List<(int, int, int)>
        {
            (1, 2, 16), (1, 3, 11), (3, 2, 2), (3, 5, 5), (2, 5, 2),
            (5, 4, 3), (2, 4, 4), (5, 7, 6), (5, 4, 3), (4, 7, 1), (6, 7, 10), (4, 6, 9)
        };

            var graph3 = new List<(int, int, int)>
        {
            (1, 2, 3), (2, 6, 6), (3, 6, 6), (2, 3, 4), (1, 3, 8),
            (1, 4, 4), (4, 1, 4), (4, 3, 10), (4, 5, 9), (3, 5, 7), (5, 7, 2), (3, 7, 8), (6, 7, 4)
        };

            var results1 = DinamProg(graph1);
            Console.WriteLine($"Graph 1: Number of vertices: {results1.Item1}, Number of edges: {results1.Item2}, Time: {results1.Item4}, Shortest path: {results1.Item5}");

            var results2 = DinamProg(graph2);
            Console.WriteLine($"Graph 2: Number of vertices: {results2.Item1}, Number of edges: {results2.Item2}, Time: {results2.Item4}, Shortest path: {results2.Item5}");

            var results3 = DinamProg(graph3);
            Console.WriteLine($"Graph 3: Number of vertices: {results3.Item1}, Number of edges: {results3.Item2}, Time: {results3.Item4}, Shortest path: {results3.Item5}");

            Console.ReadKey();

        }

    }

}
