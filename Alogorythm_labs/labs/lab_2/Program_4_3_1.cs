using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Alogorythm_labs.lab_1
{
    internal class Program_4_3_1
    {

        public static void Main(string[] args)
        {
            int n = 5;
            double[] array = new double[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = CalculateElement(i + 1);
                Console.WriteLine($"Элемент массива array[{i}] = {array[i]}");
            }

            double result = CalculateExpression(n);
            Console.WriteLine($"Результат выражения для n = {n}: {result}");

            Console.ReadKey();
        }

        static double CalculateElement(int n)
        {
            return Math.Pow(2, n + 1) / Math.Pow(3, (n - 1));
        }

        static double CalculateExpression(int n)
        {

            if (n == 1)
                return (2.0 * 2);

            else
                return CalculateExpression(n - 1) + CalculateElement(n);
        }
    }

}
