using System;
using System.Collections.Generic;
using System.Linq;

namespace Alogorythm_labs.lab_1
{
    internal class Turing
    {
        class TuringMachine
        {
            public string Tape { get; private set; }
            public int Head { get; private set; }
            public string CurrentState { get; private set; }

            public TuringMachine(string initialTape)
            {
                Tape = initialTape;
                Head = 0;
                CurrentState = "q0";
            }

            public void Execute()
            {
                while (true)
                {
                    if (CurrentState == "q0")
                    {
                        if (Head < Tape.Length)
                        {
                            int number = int.Parse(Tape[Head].ToString());
                            string unaryRepresentation = new string('1', number);
                            Tape = unaryRepresentation;
                            Head = Tape.Length;
                            CurrentState = "q1";
                        }
                    }
                    else if (CurrentState == "q1")
                    {
                        break;
                    }
                }
            }
        }



        public static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                TuringMachine tm = new TuringMachine(i.ToString());
                tm.Execute();
                Console.WriteLine($"Unary representation: {tm.Tape}");
            }
            Console.ReadKey();
        }
    }
}
