using System;

namespace _04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read input

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            // 2. Calculate profit
            // - Apply discount if necessary
            // - Pay rent

            double profit = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
            int totlToysCount = puzzles + dolls + bears + minions + trucks;
            if (totlToysCount >= 50)
            {
                profit = profit - 0.25 * profit; // 0.75 * profit
            }

            profit = profit - 0.1 * profit;

            // 3. Print output

            //if (profit >= tripPrice)
            //{
            //    Console.WriteLine($"Yes! {profit - tripPrice:F2} lv left.");
            //}
            //else
            //{
            //    Console.WriteLine($"Not enough money! {tripPrice - profit:F2} lv needed.");
            //}


            double diff = Math.Abs(profit - tripPrice);

            if (profit >= tripPrice)
            {
                Console.WriteLine($"Yes! {diff:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {diff:F2} lv needed.");
            }


        }
    }
}

