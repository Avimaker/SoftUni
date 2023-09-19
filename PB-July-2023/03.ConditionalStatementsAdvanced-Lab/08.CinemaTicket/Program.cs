using System;

namespace _08.CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfTheWeek = Console.ReadLine();

            //switch (dayOfTheWeek)
            //{
            //    case "Monday":
            //    case "Tuesday":
            //    case "Friday":
            //        Console.WriteLine(12);
            //        break;
            //    case "Wednesday":
            //    case "Thursday":
            //        Console.WriteLine(14);
            //        break;
            //    case "Saturday":
            //    case "Sunday":
            //        Console.WriteLine(16);
            //        break;
            //}

            int money = 0;

            if (dayOfTheWeek == "Monday" || dayOfTheWeek == "Tuesday" || dayOfTheWeek == "Friday")
            {
                money = 12;
            }
            else if (dayOfTheWeek == "Wednesday" || dayOfTheWeek == "Thursday")
            {
                money = 14;
            }
            else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            {
                money = 16;
            }

            Console.WriteLine(money);

        
        }
    }
}

