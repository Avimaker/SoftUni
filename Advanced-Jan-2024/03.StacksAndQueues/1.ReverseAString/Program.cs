/*
I Love C#
 */

namespace _1.ReverseAString;

class Program
{
    static void Main(string[] args)
    {
        Stack<char> stack = new Stack<char>(Console.ReadLine().ToCharArray());

        //foreach (var item in stack)
        //{
        //    stack.Push(item);
        //}

        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }
    }
}

