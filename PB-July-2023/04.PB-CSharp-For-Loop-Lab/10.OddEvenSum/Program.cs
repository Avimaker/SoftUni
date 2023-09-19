using System;

namespace _06.VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberQuantity = int.Parse(Console.ReadLine());
            double evenSum = 0;
            double oddSum = 0;


            for (int i = 1; i <= numberQuantity; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum = evenSum + number;
                }
                if (i % 2 != 0)
                {
                    oddSum = oddSum + number;
                }
            }

            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(evenSum - oddSum)}");
            }


        }
    }
}

