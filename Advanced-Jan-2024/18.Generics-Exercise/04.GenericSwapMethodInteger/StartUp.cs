/*
3
7
123
42
0 2
 
*/

namespace GenericSwapMethodInteger;
class StartUp
{
    static void Main()
    {

        List<int> items = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            int item = int.Parse(Console.ReadLine());
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
        ////classic
        //T temp = items[firstIndex];
        //items[firstIndex] = items[secondIndex];
        //items[secondIndex] = temp;

        //usingTuple
        (items[secondIndex], items[firstIndex]) =
        (items[firstIndex], items[secondIndex]);
    }
}

