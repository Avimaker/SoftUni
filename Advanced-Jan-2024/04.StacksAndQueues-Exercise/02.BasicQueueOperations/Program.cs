/*
5 2 32
1 13 45 32 4

4 1 666
666 69 13 420

3 3 90
90 90 90
 
*/

namespace _02.BasicQueueOperations;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int addNumbers = input[0];
        int removeNumbers = input[1];
        int numberToSearh = input[2];

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < addNumbers; i++)
        {
            queue.Enqueue(numbers[i]);
        }

        for (int i = 0; i < removeNumbers; i++)
        {
            queue.Dequeue();
        }

        bool ifExist = queue.Contains(numberToSearh);

        if (ifExist)
        {
            Console.WriteLine("true");
        }
        else if (queue.Count == 0)
        {
            Console.WriteLine("0");
        }
        else
        {
            int smallest = queue.Dequeue();
            while (queue.Count > 0)
            {
                int toCheck = queue.Dequeue();
                if (toCheck < smallest)
                {
                    smallest = toCheck;
                }
            }

            Console.WriteLine(smallest);
        }



    }
}

