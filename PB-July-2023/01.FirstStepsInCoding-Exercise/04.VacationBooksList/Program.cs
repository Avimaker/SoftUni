using System;

namespace _04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesCurrentBook = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int totalHours = pagesCurrentBook / pagesPerHour;
            int hoursPerDay = totalHours / days;

            Console.WriteLine(hoursPerDay);
        }
    }
}

