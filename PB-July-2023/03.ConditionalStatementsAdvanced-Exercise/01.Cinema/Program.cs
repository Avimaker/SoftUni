using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read input

            string type = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());


            // 2. Calculate profit
            // -  Ticket price
            // - calc total profit (ticket price * all seats)

            int allSeats = row * col;
            double totalProfit = 0.0;

            switch (type)
            {
                case "Premiere":
                    totalProfit = allSeats * 12.00;
                break;
                case "Normal":
                    totalProfit = allSeats * 7.50;
                    break;
                case "Discount":
                    totalProfit = allSeats * 5.00;
                break;
            }

            // 3. Print output

            Console.WriteLine($"{totalProfit:f2} leva");
        }
    }
}

