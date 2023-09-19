using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {

        // 1. Read Input
            double budget = double.Parse(Console.ReadLine());
            int videoCardQuantity = int.Parse(Console.ReadLine());
            int cpuQuantity = int.Parse(Console.ReadLine());
            int ramQuantity = int.Parse(Console.ReadLine());

            // 2. Calculate total costs
            // - calculate the Videocard costs
            // - if videoCardCount > cpuCount - 15% discount
            double videoCardCosts = videoCardQuantity * 250;
            double cpuCosts = 0.35 * videoCardCosts;
            double ramCosts = 0.10 * videoCardCosts;

            double totalCosts = videoCardCosts + cpuQuantity * cpuCosts + ramQuantity * ramCosts;

            // 3. Print output

            if (videoCardQuantity > cpuQuantity)
            {
                totalCosts = totalCosts - totalCosts * 0.15; 
                
                if (budget >= totalCosts)
                {
                    Console.WriteLine($"You have {budget - totalCosts:f2} leva left!");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {totalCosts - budget:f2} leva more!");
                }

            }
            else
            {
                if (budget >= totalCosts)
                {
                    Console.WriteLine($"You have {budget - totalCosts:f2} leva left!");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {totalCosts - budget:f2} leva more!");
                }
            }

            
        }
    }
}

