/*
1 2 3 4 5 6
2

20 10 40 30 60 50
3
*/

namespace _06.ReverseAndExclude;

class Program
{
    static void Main(string[] args)
    {
        List <int> input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Reverse()
            .ToList();

        int divider = int.Parse(Console.ReadLine());

        Predicate<int> divisible = number => number % divider == 0;

        List<int> result = new();

        foreach (var item in input)
        {
            if (!divisible(item))
            {
                result.Add(item);
            }
        }

        Console.WriteLine(string.Join(" ", result));

    }
}

//Var2
//using System;
//using System.Collections.Generic;
//using System.Linq;

//Func<List<int>, List<int>> reverse = numbers =>
//{
//    List<int> result = new();

//    for (int i = numbers.Count - 1; i >= 0; i--)
//    {
//        result.Add(numbers[i]);
//    }

//    return result;
//};

//Func<List<int>, Predicate<int>, List<int>> exclude = (numbers, match) =>
//{
//    List<int> result = new();

//    foreach (var number in numbers)
//    {
//        if (!match(number))
//        {
//            result.Add(number);
//        }
//    }

//    return result;
//};

//List<int> numbers = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToList();

//int divider = int.Parse(Console.ReadLine());

//Predicate<int> checkEven = number =>
//    number % divider == 0;

//numbers = exclude(numbers, checkEven);
//numbers = reverse(numbers);

//Console.WriteLine(string.Join(" ", numbers));