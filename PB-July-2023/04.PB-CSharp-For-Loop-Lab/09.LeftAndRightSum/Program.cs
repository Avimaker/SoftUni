using System;

namespace _06.VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberQuantity = int.Parse(Console.ReadLine());
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 1; i <= numberQuantity; i++)
            {
                int number = int.Parse(Console.ReadLine());
                //sum1 = sum1 + number;
                sum1 += number;
            }

            for (int i = 1; i <= numberQuantity; i++)
            {
                int number = int.Parse(Console.ReadLine());
                //sum2 = sum2 + number;
                sum2 += number;
            }

            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1 - sum2)}");
            }


        }
    }
}

