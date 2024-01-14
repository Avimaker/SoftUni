/*
2 + 5 + 10 - 2 - 1
*/

namespace _3.SimpleCalculator;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Trim().Split();

        Stack<string> expression = new Stack<string>();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            expression.Push(input[i]);
        }

        while (expression.Count > 1)
        {

            int leftNum = int.Parse(expression.Pop());
            string sign = expression.Pop();
            int rightNum = int.Parse(expression.Pop());

            if (sign == "+")
            {
                expression.Push((leftNum + rightNum).ToString());
            }
            else if (sign == "-")
            {
                expression.Push((leftNum - rightNum).ToString());
            }
        }

        Console.WriteLine(expression.Pop());

    }
}
