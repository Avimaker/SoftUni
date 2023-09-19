using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int pcs = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;

            if (flowersType == "Roses")
            {
                if (pcs > 80)
                {
                    price = (pcs * 5.00) * 0.90;
                }
                else
                {
                    price = pcs * 5.00;
                }
            }

            else if (flowersType == "Dahlias")
            {
                if (pcs > 90)
                {
                    price = (pcs * 3.80) * 0.85;
                }
                else
                {
                    price = pcs * 3.80;
                }
            }

            else if (flowersType == "Tulips")
            {
                if (pcs > 80)
                {
                    price = (pcs * 2.80) * 0.85;
                }
                else
                {
                    price = pcs * 2.80;
                }
            }

            else if (flowersType == "Narcissus")
            {
                if (pcs < 120)
                {
                    price = (pcs * 3.00) * 1.15;
                }
                else
                {
                    price = pcs * 3.00;
                }
            }

            else if (flowersType == "Gladiolus")
            {
                if (pcs < 80)
                {
                    price = (pcs * 2.50) * 1.20;
                }
                else
                {
                    price = pcs * 2.50;
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {pcs} {flowersType} and {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");     
            }


        }
    }
}

