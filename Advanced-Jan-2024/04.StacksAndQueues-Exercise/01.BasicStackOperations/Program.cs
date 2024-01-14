/*
5 2 13
1 13 45 32 4

4 1 666
420 69 13 666

3 3 90
90 90 90
 
*/

namespace _01.BasicStackOperations;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int n = input[0];
        int popFrom = input[1];
        int numberToSearh = input[2];

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            stack.Push(numbers[i]);
        }

        for (int i = 0; i < popFrom; i++)
        {
            stack.Pop();
        }

        bool ifExist = stack.Contains(numberToSearh);

        if (ifExist)
        {
            Console.WriteLine("true");
        }
        else if (stack.Count == 0)
        {
            Console.WriteLine("0");
        }
        //else
        //{
        //    int smallest = stack.Pop();
        //    while (stack.Count > 0)
        //    {
        //        int toCheck = stack.Pop();
        //        if (toCheck < smallest)
        //        {
        //            smallest = toCheck;
        //        }
        //    }

        //    Console.WriteLine(smallest);
        //}
        else if (stack.Any())
        {
            Console.WriteLine(stack.Min());
        }


    }
}

