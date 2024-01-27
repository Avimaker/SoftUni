/*
1 10
odd

20 30
even

*/

namespace _04.FindEvensOrOdds;

class Program
{
    static void Main(string[] args)
    {

        int[] inputRange = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        List<int> range = new List<int>();
        range = Enumerable.Range(inputRange[0], (inputRange[1] - inputRange[0] + 1)).ToList();

        string command = Console.ReadLine();

        Predicate<int> isEven = x => x % 2 == 0;

        if (command == "even")
        {
            foreach (var number in range)
            {
                if (isEven(number))
                {
                    Console.Write($"{number} ");
                }
            }

        }
        else if (command == "odd")
        {
            foreach (var number in range)
            {
                if (!isEven(number))
                {
                    Console.Write($"{number} ");
                }
            }

        }

    }
}

