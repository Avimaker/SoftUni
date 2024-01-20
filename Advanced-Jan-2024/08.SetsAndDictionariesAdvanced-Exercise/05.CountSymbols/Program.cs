/*
SoftUni rocks

Did you know Math.Round rounds to the nearest even integer?

*/

namespace _05.CountSymbols;

class Program
{
    static void Main(string[] args)

    //Solve method 1
    {
        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        char[] input = Console.ReadLine().ToCharArray();

        for (int i = 0; i < input.Length; i++)
        {
            if (!charCounts.ContainsKey(input[i]))
            {
                charCounts.Add(input[i], 0); // 0 for tart counter
            }
            charCounts[input[i]]++;
        }

        Dictionary<char, int> sortedCharCounts = new Dictionary<char, int>(charCounts.OrderBy(key => key.Key));

        foreach (var item in sortedCharCounts)
        {
            Console.WriteLine($"{item.Key}: {item.Value} time/s");
        }
    }

    ////Solve method 2
    //{
    //    SortedDictionary<char, int> charsCounts = new();

    //    string input = Console.ReadLine();

    //    foreach (var ch in input)
    //    {
    //        if (!charsCounts.ContainsKey(ch))
    //        {
    //            charsCounts.Add(ch, 0);
    //        }

    //        charsCounts[ch]++;
    //    }

    //    foreach (var charCount in charsCounts)
    //    {
    //        Console.WriteLine($"{charCount.Key}: {charCount.Value} time/s");
    //    }
    //}

}

