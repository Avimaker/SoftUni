using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int row = 1; row <= number; row++)
            {
                PrintRow(row);
            }

            for (int row = number - 1; row >= 1; row--)
            {
                PrintRow(row);
            }

        }

        private static void PrintRow(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col+" ");
            }
            Console.WriteLine();
        }
    }
}

