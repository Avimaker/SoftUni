using System;

namespace _07.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            //if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday" )
            //{
            //    if (hour >= 10 && hour <= 18)
            //    {
            //        Console.WriteLine("open");
            //    }
            //    else
            //    {
            //        Console.WriteLine("closed");
            //    }

            //}

            //else
            //{
            //    Console.WriteLine("closed");
            //}

            if (day != "Sunday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}

