/*
3
Peter
George
Swap me with Peter
0 2
 
*/

namespace GenericSwapMethodString;
class Program
{
    static void Main()
    {

        List<string> items = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string item = Console.ReadLine();
            items.Add(item);
        }

        int[] tokens = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Swap(tokens[0], tokens[1], items);

        foreach (var item in items)
        {
            Console.WriteLine($"{item.GetType()}: {item}");
        }


    }

    static void Swap<T>(int firstIndex, int secondIndex, List<T> items)
    {
        T temp = items[firstIndex];
        items[firstIndex] = items[secondIndex];
        items[secondIndex] = temp;
    }
}

