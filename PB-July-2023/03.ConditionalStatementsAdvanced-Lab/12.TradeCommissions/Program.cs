using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {

            string city = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());

            double commission = 0;


            if (city == "Sofia" && sells >= 0)
            {
                
                if (sells >= 0 && sells <= 500)
                {
                    commission = sells * 0.05;

                }
                else if (sells > 500 && sells <= 1000)
                {
                    commission = sells * 0.07;

                }
                else if (sells > 1000 && sells <= 10000)
                {
                    commission = 0.08 * sells;

                }
                else if (sells > 10000)
                {
                    commission = sells * 0.12;

                }

                Console.WriteLine($"{commission:f2}");
            }

            else if (city == "Varna" && sells >= 0)
            {

                if (sells >= 0 && sells <= 500)
                {
                    commission = sells * 0.045;

                }
                else if (sells > 500 && sells <= 1000)
                {
                    commission = sells * 0.075;

                }
                else if (sells > 1000 && sells <= 10000)
                {
                    commission = 0.10 * sells;

                }
                else if (sells > 10000)
                {
                    commission = sells * 0.13;

                }

                Console.WriteLine($"{commission:f2}");
            }

            else if (city == "Plovdiv" && sells >= 0)
            {

                if (sells >= 0 && sells <= 500)
                {
                    commission = sells * 0.055;

                }
                else if (sells > 500 && sells <= 1000)
                {
                    commission = sells * 0.08;

                }
                else if (sells > 1000 && sells <= 10000)
                {
                    commission = 0.12 * sells;

                }
                else if (sells > 10000)
                {
                    commission = sells * 0.145;

                }

                Console.WriteLine($"{commission:f2}");
            }


            else
            {
                Console.WriteLine("error");
            }

        }
    }
}

