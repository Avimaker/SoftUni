using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goalSteps = 10000;
            int steps = 0;
            int totalSteps = 0;
            string input = "";
            bool goingHome = false;

            while (totalSteps <= goalSteps)
            {
                input = Console.ReadLine();

                if (input == "Going home")
                {
                    steps = int.Parse(Console.ReadLine());
                    totalSteps += steps;

                    if (totalSteps <= goalSteps)
                    {
                        goingHome = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                steps = int.Parse(input);
                totalSteps += steps;


            }

            if (goingHome)
            {
                Console.WriteLine($"{goalSteps - totalSteps} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - goalSteps} steps over the goal!");
            }
        }
    }
}

