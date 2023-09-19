using System;

namespace _05.HairSalon
{
    class Program
    {
        static void Main(string[] args)
        {

            int profit = int.Parse(Console.ReadLine());

            int income = 0;

            
            string input = Console.ReadLine();
            while (input != "closed")
            {
                if (input == "haircut")
                {
                    string style = Console.ReadLine();
                    if (style == "mens")
                    {
                        income += 15;
                    }
                    else if (style == "ladies")
                    {
                        income += 20;
                    }
                    else if (style == "kids")
                    {
                        income += 10;
                    }
                }

                if (input == "color")
                {
                    string style = Console.ReadLine();
                    if (style == "touch up")
                    {
                        income += 20;
                    }
                    else if (style == "full color")
                    {
                        income += 30;
                    }
                }

                if (income >= profit)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (income >= profit)
            {
                Console.WriteLine("You have reached your target for the day!");
                Console.WriteLine($"Earned money: {income}lv.");
            }
            else
            {
                Console.WriteLine($"Target not reached! You need {profit - income}lv. more.");
                Console.WriteLine($"Earned money: {income}lv.");

            }


        }
    }
}

