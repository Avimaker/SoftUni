using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int smallestNumber = n;

            SmallestNumCounting(ref n, ref smallestNumber);

            Console.WriteLine(smallestNumber);

        }

        static void SmallestNumCounting(ref int n, ref int smallestNumber)
        {
            for (int i = 1; i < 3; i++)
            {
                n = int.Parse(Console.ReadLine());
                if (n < smallestNumber)

                {
                    smallestNumber = n;
                }

            }
        }
    }
}

