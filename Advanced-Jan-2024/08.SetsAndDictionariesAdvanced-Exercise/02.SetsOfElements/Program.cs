/*
4 3
1
3
5
7
3
4
5
*/

namespace _02.SetsOfElements;

class Program
{
    static void Main(string[] args)
    {

        int[] sets = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = sets[0];
        int m = sets[1];

        HashSet<int> first = new HashSet<int>();
        HashSet<int> second = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());
            first.Add(input);
        }
        for (int i = 0; i < m; i++)
        {
            int input = int.Parse(Console.ReadLine());
            second.Add(input);
        }

        Console.Write(string.Join(" ", (first.Intersect(second))));
    }

}

