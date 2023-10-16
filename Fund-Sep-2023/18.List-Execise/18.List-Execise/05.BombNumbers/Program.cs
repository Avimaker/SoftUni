/*
1 2 2 4 2 2 2 9
4 2

1 4 4 2 8 9 1
9 3

1 7 7 1 2 3
7 1

*/

namespace _05.BombNumbers;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List <int> bomb = Console.ReadLine()
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

            list.RemoveRange(leftPower,powerRange);

        }

        Console.WriteLine(list.Sum());
    }
}

