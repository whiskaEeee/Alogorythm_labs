using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Alogorythm_labs.lab_1
{
    internal class Program_8_1_1
    {

        public static void Main(string[] args)
        {
            List<int> list = GenerateList(20);
            Console.WriteLine("\t\t[Test]\nBefore sorting");
            PrintList(list);

            ShellSortAlgorithm(list);

            Console.WriteLine("After sorting");
            PrintList(list);

            Stopwatch stopwatch = new Stopwatch();


            List<int> nums = new List<int> { 1600, 2800, 8800 };
            for (int i = 0; i < 3; i++)
            {
                list = GenerateList(nums[i] * 2);


                stopwatch.Start();
                ShellSortAlgorithm(list);
                stopwatch.Stop();

                TimeSpan elapsedTime = stopwatch.Elapsed;
                Console.WriteLine($"Time passed for {nums[i]} elements: {elapsedTime.TotalMilliseconds} milliseconds.");

                stopwatch.Reset();
            }


            Console.ReadKey();
        }

        static void ShellSortAlgorithm(List<int> array)
        {
            int n = array.Count;
            int gap = n / 2;
            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j = i;
                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = temp;
                }
                gap /= 2;
            }
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
