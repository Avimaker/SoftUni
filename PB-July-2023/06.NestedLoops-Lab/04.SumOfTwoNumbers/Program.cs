using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int magicN = int.Parse(Console.ReadLine());

            int counter = 0;
            bool isFound = false;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    counter++;

                    int sum = i + j;

                    if (sum == magicN)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {sum})");
                        //Console.WriteLine($"({i} + {j} = {sum})");
                        isFound = true;
                        break;
                        //return; - Tова прекъсва направо тук
                    }

                }

                if (isFound)
                {
                    break;
                }

            }
            if (!isFound)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicN}"); 
            }

        }
    }
}

