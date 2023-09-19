using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statue = rent * 0.70; // 30% po-malko
            double catering = statue - statue * 0.15; //15% po-malko
            double audio = catering / 2;

            double totalPrice = rent + statue + catering + audio;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}

