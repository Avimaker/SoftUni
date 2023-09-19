using System;

namespace _02.FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double winingSume = double.Parse(Console.ReadLine());

            double pants = tshirtPrice * 0.75;
            double socks = pants * 0.20;
            double sportShoes = (tshirtPrice + pants) * 2;

            double combineSum = tshirtPrice + pants + socks + sportShoes;
            double discountPrice = combineSum * 0.85;

            if (discountPrice >= winingSume)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {discountPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {winingSume - discountPrice:f2} lv. more.");

            }

        }
    }
}

