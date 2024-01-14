/*
348
20 54 30 16 7 9

499
57 45 62 70 33 90 88 76
*/

namespace _04.FastFood;

class Program
{
    static void Main(string[] args)
    {
        int quantityOfFood = int.Parse(Console.ReadLine());

        int[] inputOrders = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Queue<int> orders = new Queue<int>(inputOrders);

        Console.WriteLine(orders.Max());

        for (int i = orders.Count - 1; i >= 0; i--)
        {
            if (orders.Peek() <= quantityOfFood)
            {
                quantityOfFood -= orders.Peek();
                orders.Dequeue();
            }
            else
            {
                //Console.Write("Orders left: ");
                //Console.Write(string.Join(" ", orders));
                //return;

                Console.Write("Orders left: " + string.Join(" ", orders));
                return;



            }
        }

        Console.WriteLine("Orders complete");
    }
}

