using System;

namespace _05.GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read input

            double budget = double.Parse(Console.ReadLine());
            int statistCount = int.Parse(Console.ReadLine());
            double clothesPricePerStatist = double.Parse(Console.ReadLine());

            // 2. Calculate costs
            // - decor costs 10% of total budget
            // - more than 150 statist - 10% discount

            double decor = budget * 0.1;
            double clothesPrice = statistCount * clothesPricePerStatist;
            
            if (statistCount > 150)
            {
                clothesPrice = clothesPrice - clothesPrice * 0.1;
            }
          
            double totlaPrice = decor + clothesPrice;

            // 3. Print output

            if (totlaPrice <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - totlaPrice:F2} leva left.");
                            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totlaPrice - budget:F2} leva more.");
            }
        }
    }
}

