/*
1 2 3 4
adD 5 6
REmove 3
eNd
 */

namespace _2.StackSum;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        Stack<int> stack = new Stack<int>(numbers);

        string command = default;
        while ((command = Console.ReadLine().ToLower()) != "end")
        {
            string[] arguments = command.Split();

            if (arguments[0] == "add")
            {
                int first = int.Parse(arguments[1]);
                int second = int.Parse(arguments[2]);

                stack.Push(first);
                stack.Push(second);
            }
            else if (arguments[0] == "remove")
            {
                int n = int.Parse(arguments[1]);

                if (stack.Count >= n)
                {
                    for (int i = 0; i < n; i++)
                    {
                        stack.Pop();
                    }
                }
            }
        }

        Console.WriteLine($"Sum: {stack.Sum()}");

    }
}

