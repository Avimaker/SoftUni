using System;

namespace _05.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {

            int hegih = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int obsticles = int.Parse(Console.ReadLine());

            double area = hegih * width * 4;
            area = Math.Ceiling(area - (area * obsticles / 100));

            string input = Console.ReadLine();

            while (input != "Tired!")
            {
                int paintInLiters = int.Parse(input);

                area -= paintInLiters;

                if (area <= 0)
                {
                    break;  
                }

                input = Console.ReadLine();
            }

            if (area > 0)
            {
                Console.WriteLine($"{area} quadratic m left.");
            }
            else if (area < 0)
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(area)} l paint left!");
            }
            else
            {
                Console.WriteLine("All walls are painted! Great job, Pesho!");
            }
 
        }
    }
}

