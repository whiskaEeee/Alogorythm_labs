using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Alogorythm_labs.lab_1
{
    internal class Program_3_1_1
    {

        public static void Main(string[] args)
        {
            List<int> list = GenerateList(20);
            Console.WriteLine("\t\t[Test]\nBefore sorting");
            PrintList(list);

            ShakerSortAlgorithm(list);

            Console.WriteLine("After sorting");
            PrintList(list);

            Stopwatch stopwatch = new Stopwatch();


            List<int> nums = new List<int> {2500, 3500, 6500};
            for (int i = 0; i < 3; i++)
            {
                list = GenerateList(nums[i]);

                
                stopwatch.Start();
                ShakerSortAlgorithm(list);
                stopwatch.Stop();
                
                TimeSpan elapsedTime = stopwatch.Elapsed;
                Console.WriteLine($"Time passed for {nums[i]} elements: {elapsedTime.TotalMilliseconds} milliseconds.");

                stopwatch.Reset();
            }


            Console.ReadKey();
        }

        static void ShakerSortAlgorithm(List<int> list)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        Swap(list, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;

                swapped = false;
                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (list[i] > list[i + 1])
                    {
                        Swap(list, i, i + 1);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        static void Swap(List<int> list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        static void PrintList(List<int> list)
        {
            foreach (int num in list)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");
        }

        static List<int> GenerateList(int count)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(-100, 101));
            }

            return numbers;
        }
    }

}
