using System;

namespace _02.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {

            int f = 0;
            int s = 0;
            int sum = 0;

            for (f = 1; f <= 10; f++)
            {

                for (s = 1; s <= 10; s++)
                {

                    sum = f * s;

                    Console.WriteLine($"{f} * {s} = {sum}");

                }

            }
        }
    }
}

