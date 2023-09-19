using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badScore = int.Parse(Console.ReadLine());
            int badScoreCount = 0;
            int examCount = 0;
            int sum = 0;
            int score = 0;
            string task = "";
            string currentTask = "";
            bool exit = false;

            while ((currentTask = Console.ReadLine()) != "Enough")
            {
                score = int.Parse(Console.ReadLine());
                sum += score;
                examCount++;
                task = currentTask;

                if (score <= 4)
                {
                    badScoreCount++;
                    if (badScoreCount >= badScore)
                    {
                        exit = true;
                        break;
                    }

                }

            }

            if (exit)
            {
                Console.WriteLine($"You need a break, {badScoreCount} poor grades.");
            }
            else
            {
                double averageScore = (1.00 * sum) / examCount;
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {examCount}");
                Console.WriteLine($"Last problem: {task}");
            }


        }
    }
}

