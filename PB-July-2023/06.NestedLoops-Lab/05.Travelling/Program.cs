using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string vacation = Console.ReadLine();
            double budget = 0;
            double incoms = 0;
            double savings = 0;

            while (vacation != "End")
            {
                budget = double.Parse(Console.ReadLine());
                while (savings < budget)
                {
                    incoms = double.Parse(Console.ReadLine());
                    savings += incoms;
                }
                Console.WriteLine($"Going to {vacation}!");
                
                savings = 0;
                budget = 0;
                vacation = Console.ReadLine();
            }


        }
    }
}

