/*
5 4 8 6 3 8 7 7 9
16

1 7 8 2 5 4 7 8 9 6 3 2 5 4 6
20
*/

namespace _05.FashionBoutique;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> clothes = new Stack<int>(Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray());

        int rackCapacity = int.Parse(Console.ReadLine());
        int rackQuantity = 0;

        while (clothes.Count != 0)
        {
            int clothesValue = 0;

            while (clothesValue < rackCapacity && clothes.Any())
            {
                clothesValue += clothes.Peek();
                if (clothesValue <= rackCapacity)
                {
                    clothes.Pop();
                }
            }
            rackQuantity++;
        }

        Console.WriteLine(rackQuantity);
    }

}

