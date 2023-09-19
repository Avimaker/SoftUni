using System;

namespace _09.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            int nights = days - 1;
            double pricePerNight = 0.0;
            double totalPrice = 0.0;

            // room type * nights - discounts

            if (roomType == "room for one person") { pricePerNight = 18.00; }
            else if (roomType == "apartment") { pricePerNight = 25.00; }
            else if (roomType == "president apartment") { pricePerNight = 35.00; }

            // discounts
            if (roomType == "apartment")
            {
                if (days < 10) { pricePerNight = pricePerNight * 0.70; }
                else if (days > 10 && days <= 15) { pricePerNight = pricePerNight * 0.65; }
                else if (days > 15) { pricePerNight = pricePerNight * 0.50; }
            }
            else if (roomType == "president apartment")
            {
                if (days < 10) { pricePerNight = pricePerNight * 0.90; }
                else if (days > 10 && days <= 15) { pricePerNight = pricePerNight * 0.85; }
                else if (days > 15) { pricePerNight = pricePerNight * 0.80; }
            }

            totalPrice = nights * pricePerNight;

            if (rating == "positive")
            {
                totalPrice = totalPrice * 1.25;
            }
            else
            {
                totalPrice = totalPrice * 0.90;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

