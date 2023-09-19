using System;

namespace _06.VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberQuantity = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 1; i <= numberQuantity; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum = sum + number;
            }

            Console.WriteLine(sum);
        }
    }
}

