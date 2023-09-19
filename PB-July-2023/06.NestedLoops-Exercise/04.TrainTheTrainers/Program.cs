using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            double totalSum = 0;
            int presCount = 0;

            string presName = Console.ReadLine();

            while (presName != "Finish")
            {

                double currentSum = 0;
                for (int i = 0; i < n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    currentSum += grade;
                }

                double currentAverage = currentSum / n;
                Console.WriteLine($"{presName} - {currentAverage:f2}.");

                totalSum += currentSum;
                presCount++;
                presName = Console.ReadLine();
            }

            double finalAsses = totalSum / (n * presCount);
            Console.WriteLine($"Student's final assessment is {finalAsses:f2}.");

        }
    }
}

