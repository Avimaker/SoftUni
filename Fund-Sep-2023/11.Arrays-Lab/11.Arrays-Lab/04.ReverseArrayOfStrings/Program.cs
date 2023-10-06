/*
-1 hi ho w

a b c d e

 */

//input

var items = Console.ReadLine().Split().ToArray();

for (int i = 0; i < items.Length / 2; i++)
{
    //string oldelement = items[i];
    //items[i] = items[items.Length - 1 - i];
    //items[items.length - 1 - i] = oldelement;
    string firstEment = items[i];
    string lastElement = items[items.Length - 1 - i];

    items[i] = lastElement;
    items[items.Length - 1 - i] = firstEment;
}

Console.WriteLine(string.Join(" ", items));

