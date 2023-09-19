using System;

namespace _07.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0;
            int climbersCount = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber <= 5) { c1+=currentNumber; }
                else if (currentNumber <= 12) { c2+=currentNumber; }
                else if (currentNumber <= 25) { c3+=currentNumber; }
                else if (currentNumber <= 40) { c4+=currentNumber; }
                else { c5+=currentNumber; }

                climbersCount += currentNumber;
            }

            Console.WriteLine($"{100.0 * c1 / climbersCount:f2}%");
            Console.WriteLine($"{100.0 * c2 / climbersCount:f2}%");
            Console.WriteLine($"{100.0 * c3 / climbersCount:f2}%");
            Console.WriteLine($"{100.0 * c4 / climbersCount:f2}%");
            Console.WriteLine($"{100.0 * c5 / climbersCount:f2}%");
        }
    }
}

