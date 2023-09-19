using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumNumber = int.Parse(Console.ReadLine());
            int number = 0;
            int sum = 0;

            while (sum < sumNumber)
            {
                number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}

