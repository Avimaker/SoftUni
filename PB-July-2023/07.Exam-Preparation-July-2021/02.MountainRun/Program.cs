using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recoredInSec = double.Parse(Console.ReadLine()); 
            double distanceInMeters = double.Parse(Console.ReadLine()); 
            double timeInSecondsForOneMeter = double.Parse(Console.ReadLine());

            double timeForClimb = distanceInMeters * timeInSecondsForOneMeter;
            double delay = Math.Floor(distanceInMeters / 50) * 30;

            double finalTime = timeForClimb + delay;

            if (finalTime < recoredInSec)
            {
                Console.WriteLine($"Yes! The new record is {finalTime:f2} seconds.");
            }
            else
            {
                double needeTime = recoredInSec - finalTime;
                Console.WriteLine($"No! He was {-1 * needeTime:f2} seconds slower."); // da ne e minus chisloto umnojavame po minus 1
            }
        }
    }
}

