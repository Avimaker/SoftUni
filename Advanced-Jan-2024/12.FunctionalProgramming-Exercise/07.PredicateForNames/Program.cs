/*
4
Karl Anna Kris Yahto

4
Karl James George Robert Patricia
*/

namespace _07.PredicateForNames;

class Program
{
    static void Main(string[] args)
    {
        int nameLength = int.Parse(Console.ReadLine());

        List<string> input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Predicate<string> nameCheck = name => name.Length <= nameLength;

        Func<List<string>, Predicate<string>, List<string>> list = (input, nameCheck) =>
        {
            List<string> result = new();

            foreach (var name in input)
            {
                if (nameCheck(name))
                {
                    result.Add(name);
                }

            }
            return result;
        };

        List<string> result = list(input, nameCheck);

        Console.WriteLine(string.Join(Environment.NewLine, result));

    }
}


//Var 2
//using System;

//Action<string[], Predicate<string>> print = (names, match) =>
//{
//    foreach (var name in names)
//    {
//        if (match(name))
//        {
//            Console.WriteLine(name);
//        }
//    }
//};

//int length = int.Parse(Console.ReadLine());

//string[] names = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

////Predicate<string> validateNameLength = name =>
////    name.Length <= length;

//print(names, n => n.Length <= length);

