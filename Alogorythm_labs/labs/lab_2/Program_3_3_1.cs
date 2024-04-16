using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Alogorythm_labs.lab_1
{
    internal  class Program_3_3_1
    {

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите арифметическое выражение (для выхода введите пробел):");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (CheckBrackets(input))
                    Console.WriteLine("Скобки расставлены правильно.");
                else
                    Console.WriteLine("Ошибка! Неправильное расположение скобок.");
            }

            Console.ReadKey();
        }

        static bool CheckBrackets(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(')
                    stack.Push(c);
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                        return false;
                }
            }

            return stack.Count == 0;
        }
    }

}
