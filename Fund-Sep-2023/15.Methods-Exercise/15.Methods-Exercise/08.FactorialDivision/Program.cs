/*
5
2
*/

using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firsNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
                                   
            Console.WriteLine($"{(Factorial(firsNum) / Factorial(secondNum)):F2}");

        }

        static double Factorial(int number)
        {
            double factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}

