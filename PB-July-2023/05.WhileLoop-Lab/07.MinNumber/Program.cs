using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int minValue = int.MaxValue;
            string input = "";

            while ((input = Console.ReadLine()) != "Stop")
            {
                int number = int.Parse(input);

                if (number < minValue)
                {
                    minValue = number;
                }

            }

            Console.WriteLine(minValue);

        }
    }
}

