/*
3 5 2 43 12 3 54 10 23
76 5 34 2 4 12
*/

namespace _03.MergingLists;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstList = ReadIntList();
        List<int> secondList = ReadIntList();

        List<int> result = new List<int>();

        int iterations = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;

        for (int i = 0; i < iterations; i++)
        {
            if (i < firstList.Count)
            {
            result.Add(firstList[i]);
            }
            if (i < secondList.Count)
            {
            result.Add(secondList[i]);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }

    private static List<int> ReadIntList()
    {
        return Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
    }
}

