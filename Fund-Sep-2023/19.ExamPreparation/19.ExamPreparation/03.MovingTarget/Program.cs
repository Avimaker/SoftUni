/*
52 74 23 44 96 110
Shoot 5 10
Shoot 1 80
Strike 2 1
Add 22 3
End

1 2 3 4 5
Strike 0 1
End

 */


using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.MovingTarget;

class Program
{
    static void Main(string[] args)
    {

        List<int> targets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string commands = default;
        while ((commands = Console.ReadLine()) != "End")
        {
            string[] arguments = commands.Split();
            int index = int.Parse(arguments[1]);

            if (arguments[0] == "Shoot")
            {
                int power = int.Parse(arguments[2]);

                if (IsValidIndex(index, targets))
                {
                    targets[index] -= power;
                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
            }
            else if (arguments[0] == "Add")
            {
                int value = int.Parse(arguments[2]);

                if (IsValidIndex(index, targets))
                {
                    targets.Insert(index, value);
                }
                else
                {
                    Console.WriteLine("Invalid placement!");
                }
            }
            else //(arguments[0] == "Strike")
            {
                int radius = int.Parse(arguments[2]);

                if (IsValidIndex(index, targets)
                    && IsValidIndex(index + radius, targets)
                    && IsValidIndex(index - radius, targets))
                {
                    for (int i = 1; i <= radius; i++)
                    {
                        targets.RemoveAt(index + i);
                    }

                    targets.RemoveAt(index);

                    for (int i = 1; i <= radius; i++)
                    {
                        targets.RemoveAt(index - i);
                    }

                }
                else
                {
                    Console.WriteLine("Strike missed!");

                }

            }
        }

        Console.WriteLine(string.Join("|", targets));

    }

    static bool IsValidIndex(int index, List<int> targets)
    {
        return index >= 0 && index < targets.Count;
    }
}
