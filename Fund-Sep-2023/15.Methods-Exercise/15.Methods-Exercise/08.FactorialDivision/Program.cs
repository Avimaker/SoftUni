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
                                   
            Console.WriteLine($"{(firstFact(firsNum) / secondFact(secondNum)):F2}");

        }

        static double secondFact(int secondNum)
        {
            double factorialTwo = 1;
            for (int i = 1; i <= secondNum; i++)
            {
                factorialTwo *= i;
            }

            return factorialTwo;
        }

        static double firstFact(int firsNum)
        {
            double factorialOne = 1;
            for (int i = 1; i <= firsNum; i++)
            {
                factorialOne *= i;
            }

            return factorialOne;
        }
    }
}

