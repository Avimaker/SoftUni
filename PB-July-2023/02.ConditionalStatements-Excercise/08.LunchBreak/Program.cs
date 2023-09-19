using System;

namespace _08.LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfSitcom = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int restDuration = int.Parse(Console.ReadLine());

            double timeForLunch = (1.0 / 8) * restDuration;
            double timeForRest = (1.0 / 4) * restDuration;

            double leftTime = episodeDuration + timeForLunch + timeForRest;

          
            if (leftTime <= restDuration )
            {
                Console.WriteLine($"You have enough time to watch {nameOfSitcom} and left with {Math.Ceiling(restDuration-leftTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {nameOfSitcom}, you need {Math.Ceiling(leftTime-restDuration)} more minutes.");

            }

        }
    }
}

