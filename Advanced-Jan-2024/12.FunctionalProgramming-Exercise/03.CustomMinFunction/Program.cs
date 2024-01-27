/*
1 4 3 2 1 7 13 
4 5 -2 3 -5 8 
*/

namespace _03.CustomMinFunction;

class Program
{
    static void Main(string[] args)
    {

        Func<int[], int> printSmallest = x => x.Min();

        int[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(printSmallest(input));


    }
}



//var 2
//using System;
//using System.Collections.Generic;
//using System.Linq;

//Func<HashSet<int>, int> min = numbers =>
//{
//    int min = int.MaxValue;

//    foreach (var number in numbers)
//    {
//        if (number < min)
//        {
//            min = number;
//        }
//    }

//    return min;
//};

//HashSet<int> numbers = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToHashSet();

//Console.WriteLine(min(numbers));