using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            int shipPrice = 0;
            double discount = 1;
            double totalCosts = 0;

            // season prices

            switch (season)
            {
                case "Spring":
                    shipPrice = 3000;
                    break;

                case "Summer":
                    shipPrice = 4200;
                    break;

                case "Autumn":
                    shipPrice = 4200;
                    break;

                case "Winter":
                    shipPrice = 2600;
                    break;
            }

            // discounts

            if (fishermans <= 6)
            {
                discount = discount * 0.90;
            }
            else if (fishermans > 6 && fishermans <= 11)
            {
                discount = discount * 0.85;
            }
            else if (fishermans >= 12)
            {
                discount = discount * 0.75;
            }

            // total costs

            totalCosts = shipPrice * discount;

            // even check
            if (fishermans % 2 == 0 && season != "Autumn")
            {
                totalCosts = totalCosts * 0.95;
            }
            
            // output
            if (budget >= totalCosts)
            {
               Console.WriteLine($"Yes! You have {budget-totalCosts:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalCosts-budget:f2} leva.");
            }

        }
    }
}

