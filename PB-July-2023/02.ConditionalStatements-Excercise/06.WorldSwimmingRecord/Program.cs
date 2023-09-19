using System;

namespace _06.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read input

            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double secondsFor1M = double.Parse(Console.ReadLine());

            // 2. Calculate the time
            // - for every 15m add 12.5 sec
            double totalTime = distanceInMeters * secondsFor1M + Math.Floor(distanceInMeters / 15) * 12.5;

            // 3. Print output
            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTime - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}

