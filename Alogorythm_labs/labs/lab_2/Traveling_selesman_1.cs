using System;
using System.Collections.Generic;
using System.Linq;

namespace Alogorythm_labs.lab_1
{
    internal class Traveling_selesman_1
    {
        static int V = 5;


        static int travllingSalesmanProblem(int[,] graph,
                                            int s)
        {
            List<int> vertex = new List<int>();

            for (int i = 0; i < V; i++)
                if (i != s)
                    vertex.Add(i);

            int min_path = Int32.MaxValue;

            do
            {

                int current_pathweight = 0;
                int k = s;

                for (int i = 0; i < vertex.Count; i++)
                {
                    current_pathweight += graph[k, vertex[i]];
                    k = vertex[i];
                }

                current_pathweight += graph[k, s];

                min_path
                    = Math.Min(min_path, current_pathweight);

            } while (findNextPermutation(vertex));

            return min_path;
        }

        public static List<int> swap(List<int> data, int left,
                                     int right)
        {

            int temp = data[left];
            data[left] = data[right];
            data[right] = temp;

            return data;
        }

        public static List<int> reverse(List<int> data,
                                        int left, int right)
        {

            while (left < right)
            {
                int temp = data[left];
                data[left++] = data[right];
                data[right--] = temp;
            }

            return data;
        }


        public static bool findNextPermutation(List<int> data)
        {

            if (data.Count <= 1)
                return false;
            int last = data.Count - 2;

            while (last >= 0)
            {
                if (data[last] < data[last + 1])
                    break;
                last--;
            }

            if (last < 0)
                return false;
            int nextGreater = data.Count - 1;

            for (int i = data.Count - 1; i > last; i--)
            {
                if (data[i] > data[last])
                {
                    nextGreater = i;
                    break;
                }
            }

            data = swap(data, nextGreater, last);


            data = reverse(data, last + 1, data.Count - 1);

            return true;
        }

        public static void Main(string[] args)
        {
            int[,] graph
                = new int[5, 5] { { 0, 7, 12, 25, 10},
                              { 10, 0, 9, 5, 11},
                              { 13, 8, 0, 6, 4},
                              { 6, 11, 15, 0, 15},
                              { 5, 9, 12, 17, 0},};
            int[,] graph_1
                = new int[5, 5] { { 0, 0, 12, 25, 10},
                              { 0, 0, 9, 5, 11},
                              { 13, 8, 0, 6, 4},
                              { 6, 11, 15, 0, 0},
                              { 5, 9, 12, 0, 0},};
            int s = 0;
            Console.WriteLine(travllingSalesmanProblem(graph, s));
            Console.WriteLine(travllingSalesmanProblem(graph_1, s));
            Console.ReadKey();
        }
    }
}
