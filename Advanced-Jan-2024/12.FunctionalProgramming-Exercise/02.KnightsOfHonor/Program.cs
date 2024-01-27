/*
Eathan Lucas Noah Arthur 
*/

namespace _02.KnightsOfHonor;

class Program
{
    static void Main(string[] args)
    {
        Action<string[]> print = names =>
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        };

        print(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
    }
}


//// Var 2
//using System;

//Action<string, string[]> printNamesWithAddedTitle = (title, names) =>
//{
//    foreach (var name in names)
//    {
//        Console.WriteLine($"{title} {name}");
//    }
//};

//string[] input = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

//printNamesWithAddedTitle("Sir", input);