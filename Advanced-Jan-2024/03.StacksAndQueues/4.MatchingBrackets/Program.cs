/*
1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
*/

namespace _4.MatchingBrackets;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Stack<int> bracketIndex = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                bracketIndex.Push(i);
            }

            if (input[i] == ')')
            {
                int startIndex = bracketIndex.Pop();
                Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
            }

        }


    }
}

