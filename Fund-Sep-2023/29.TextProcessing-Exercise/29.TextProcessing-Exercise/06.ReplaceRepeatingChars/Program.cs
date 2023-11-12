using System.Text;

namespace _06.ReplaceRepeatingChars;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        //string input = "aaaaabbbbbcdddeeeedssaa";

        StringBuilder result = new StringBuilder();

        result.Append(input[0].ToString());

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                result.Append(input[i]);
            }
        }

        Console.WriteLine(result);
    }
}

