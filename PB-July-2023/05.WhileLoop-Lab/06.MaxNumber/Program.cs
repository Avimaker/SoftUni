using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxValue = int.MinValue;
            string input = "";

            while ((input = Console.ReadLine()) != "Stop")
            {
                int number = int.Parse(input);

                if (number > maxValue)
                {
                    maxValue = number;
                }

            }

            Console.WriteLine(maxValue);

        }
    }
}

