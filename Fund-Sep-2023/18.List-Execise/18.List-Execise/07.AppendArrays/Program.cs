/*
7 | 4  5|1 0| 2 5 |3
 */

namespace _07.AppendArrays;

class Program
{
    static void Main(string[] args)
    {
        string[] stringArray = Console.ReadLine()
            .Split('|', StringSplitOptions.RemoveEmptyEntries);

        List<string> symbols = ExtractSymbols(stringArray);

        Console.WriteLine(string.Join(" ", symbols));
    }

    private static List<string> ExtractSymbols(string[] stringArray)
    {

        List<string> result = new List<string>();

        for (int i = stringArray.Length - 1; i >= 0; i--)
        {
            string sequence = stringArray[i];
            string[] array = sequence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            result.AddRange(array);
        }
        return result;
    }
}

