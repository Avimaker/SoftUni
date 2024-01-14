namespace _08.BalancedParenthesis;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Stack<char> stack = new();

        foreach (var currentChar in input)
        {

            //if (currentChar == '(' || currentChar == '[' || currentChar == '{')
            //{
            //    stack.Push(currentChar);
            //    continue;
            //}

            if ("([{".Contains(currentChar))
            {
                stack.Push(currentChar);
                continue;
            }

            if (stack.Count == 0)
            {
                stack.Push(currentChar);
                break;
            }

            else if (currentChar == ')' && stack.Peek() == '(')
            {
                stack.Pop();
            }
            else if (currentChar == ']' && stack.Peek() == '[')
            {
                stack.Pop();
            }
            else if (currentChar == '}' && stack.Peek() == '{')
            {
                stack.Pop();
            }
        }

        //if (stack.Count == 0)
        //{
        //    Console.WriteLine("YES");
        //}
        //else
        //{
        //    Console.WriteLine("NO");
        //}

        Console.WriteLine(stack.Any() ? "NO" : "YES");

    }

}

