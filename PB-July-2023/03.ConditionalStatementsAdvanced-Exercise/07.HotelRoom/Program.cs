using System;
using System.Text;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. read input

            string month = Console.ReadLine();
            int sleepCount = int.Parse(Console.ReadLine());

            double priceStudio = 0.0;
            double priceApartment = 0.0;

            //2. calculate
            // - room
            // - month

            if (month == "May" || month == "October")
            {
                priceStudio = 50.00;
                priceApartment = 65.00;

                if (sleepCount > 7 && sleepCount <= 14)
                    {
                    priceStudio = priceStudio * 0.95;
                    }
                else if (sleepCount > 14)
                    {
                    priceStudio = priceStudio * 0.70;
                    }
            }

            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20;
                priceApartment = 68.70;

                if (sleepCount > 14)
                {
                    priceStudio = priceStudio * 0.80;
                }

            }
            else if (month == "July" || month == "August")
            {
                priceStudio = 76.00;
                priceApartment = 77.00;
            }

            //4. discount apartment

            if (sleepCount > 14)
            {
                priceApartment = priceApartment * 0.90;
            }

            //4. Output

            Console.WriteLine($"Apartment: {sleepCount * priceApartment:f2} lv.");
            Console.WriteLine($"Studio: {sleepCount * priceStudio:f2} lv.");
        }
    }
}

