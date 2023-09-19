using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            //double totalSum = 0;
            //string input = Console.ReadLine();

            //while (input != "NoMoreMoney")
            //{
            //    double income = double.Parse(input);
            //        if (income < 0)
            //        {
            //            Console.WriteLine("Invalid operation!");
            //            break;
            //        }
            //    Console.WriteLine($"Increase: {income:f2}");
            //    totalSum += income;
            //    input = Console.ReadLine();
            //}

            //Console.WriteLine($"Total: {totalSum:f2}");

            double totalSum = 0;
            string input = "";

            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {
                double income = double.Parse(input);
                if (income < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {income:f2}");
                totalSum += income;
            }

            Console.WriteLine($"Total: {totalSum:f2}");


        }
    }
}

