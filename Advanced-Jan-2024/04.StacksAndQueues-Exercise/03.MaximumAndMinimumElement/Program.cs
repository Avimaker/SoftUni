/*
9
1 97
2
1 20
2
1 26
1 20
3
1 91
4
 
*/


namespace _03.MaximumAndMinimumElement;

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            int[] query = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            if (query[0] == 1)
            {
                stack.Push(query[1]);
            }
            else if (query[0] == 2)
            {
                stack.Pop();
            }
            else if (query[0] == 3 && stack.Any())
            {
                Console.WriteLine(stack.Max());
            }
            else if (query[0] == 4 && stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
        }

        Console.WriteLine(string.Join(", ", stack));
       
    }
}

