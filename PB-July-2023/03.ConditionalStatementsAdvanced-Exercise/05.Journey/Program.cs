using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string type = "";
            double price = 0.0;

            if (budget <= 100.00 && season == "summer")
            {
                price = budget * 0.70;
                destination = "Bulgaria";
                type = "Camp";
            }
            else if (budget <= 100.00 && season == "winter")
            {
                price = budget * 0.30;
                destination = "Bulgaria";
                type = "Hotel";
            }
            else if (budget <= 1000.00 && season == "summer")
            {
                price = budget * 0.60;
                destination = "Balkans";
                type = "Camp";
            }
            else if (budget <= 1000.00 && season == "winter")
            {
                price = budget * 0.20;
                destination = "Balkans";
                type = "Hotel";
            }
            else
            {
                price = budget * 0.10;
                destination = "Europe";
                type = "Hotel";
            }


            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {budget - price:f2}");

        }
    }
}

