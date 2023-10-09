using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int length = input.Length;
            EvenMiddeSymbolPrint(input, length);

        }

        private static void EvenMiddeSymbolPrint(string input, int length)
        {
            if (length % 2 == 0)
            {
                int middle = length / 2;
                Console.WriteLine($"{input[middle-1]}{input[(middle)]}");
            }
            else if (length % 2 != 0)
            {
                int middle = length / 2;
                Console.WriteLine($"{input[(middle)]}");
            }
        }
    }
}

