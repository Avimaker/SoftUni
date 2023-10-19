/*

16
0 0 0 0
20
0 2 0
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace _02.TheLift_Philip;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());

        int[] wagons = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int wagonCapacity = 4;

        for (int i = 0; i < wagons.Length; i++)
        {
            int currentWagon = wagons[i];
            if (currentWagon < wagonCapacity)
            {
                int emptySeats = wagonCapacity - wagons[i];
                people -= emptySeats;
                if (people < 0)
                {
                    wagons[i] = 4 - Math.Abs(people);
                    Console.WriteLine("The lift has empty spots!");
                    PrintWagons(wagons);
                    return;
                }
                wagons[i] = wagonCapacity;
            }
        }
        if (people != 0)
        {
            Console.WriteLine($"There isn't enough space! {people} people in a queue!");
        }

        PrintWagons(wagons);

    }

    private static void PrintWagons(int[] wagons)
    {
        Console.WriteLine(string.Join(" ", wagons));
    }
}


List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

List<int> bomb = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

int bombNumber = bomb[0];
int bombPower = bomb[1];

        while (list.Contains(bombNumber))
        {
            int index = list.IndexOf(bombNumber);
int leftPower = Math.Max(0, index - bombPower);
int rightPower = Math.Min(list.Count - 1, index + bombPower);

int powerRange = rightPower - leftPower + 1;

list.RemoveRange(leftPower, powerRange);

        }

        Console.WriteLine(list.Sum());