using System;

namespace _07.NxN_atrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[number];

            FillArray(number, arr);
            PrintMatrix(arr);
        }

        static void PrintMatrix(int[] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                Console.WriteLine(string.Join(" ", arrayToPrint));
            }
        }

        static void FillArray(int number, int[] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                arrayToPrint[i] = number;
            }
        }
    }
}

