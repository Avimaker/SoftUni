﻿/*
200 90 40 100
20 40 30 50
50 60 80 90

199 190 100 100
20 40 30 50
50 60 70 80


 */

namespace _01.OffroadChallenge;
class Program
{
    static void Main(string[] args)
    {

        Stack<int> initialFuels = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        Queue<int> additionalFuels = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        Queue<int> neededFuels = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        int altitude = 1;
        bool didNotReach = false;

        while (initialFuels.Count > 0)
        {
            int initialFuel = initialFuels.Pop();
            int additionalFuel = additionalFuels.Dequeue();
            int neededFuel = neededFuels.Dequeue();

            int actualFuel = initialFuel - additionalFuel;
            if (actualFuel >= neededFuel)
            {
                Console.WriteLine($"John has reached: Altitude {altitude++}");
            }
            else
            {
                Console.WriteLine($"John did not reach: Altitude {altitude--}");
                didNotReach = true;
                break;
            }
        }

        if (didNotReach)
        {
            Console.WriteLine("John failed to reach the top.");
            if (altitude == 0)
            {
                Console.WriteLine("John didn't reach any altitude.");
            }
            else
            {
                Console.Write($"Reached altitudes: ");

                for (int i = 0; i < altitude; i++)
                {
                    Console.Write($"Altitude {i + 1}");
                    if (i < altitude - 1)
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
        }
    }

}