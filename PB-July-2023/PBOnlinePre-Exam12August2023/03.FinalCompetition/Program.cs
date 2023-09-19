using System;
using System.Runtime.ConstrainedExecution;

namespace _03.FinalCompetition
{
    class Program
    {
        static void Main(string[] args)
        {

            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = Console.ReadLine();
       
            double moneyWiningPrice = 0;

            if (place == "Bulgaria")
            {
                if (season == "summer")
                {
                    moneyWiningPrice = dancers * points;
                    moneyWiningPrice *= 0.95;
                }
                else if (season == "winter")
                {
                    moneyWiningPrice = dancers * points;
                    moneyWiningPrice *= 0.92;
                }
            }

            else if (place == "Abroad")
            {
                if (season == "summer")
                {
                    moneyWiningPrice = dancers * points * 1.5;
                    moneyWiningPrice *= 0.90;
                }
                else if (season == "winter")
                {
                    moneyWiningPrice = dancers * points * 1.5;
                    moneyWiningPrice *= 0.85;
                }
            }

            double charity = moneyWiningPrice * 0.75;

            double moneyLast = moneyWiningPrice - charity;

            double perDancer = moneyLast / dancers;

            Console.WriteLine($"Charity - {charity:f2}");
            Console.WriteLine($"Money per dancer - {perDancer:f2}");




        }
    }
}

