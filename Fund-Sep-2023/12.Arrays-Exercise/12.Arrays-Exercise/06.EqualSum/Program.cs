/*
1 2 3 3
 */

// Input
int[] numMasiv = Console.ReadLine().Split().Select(int.Parse).ToArray();

for (int i = 0; i < numMasiv.Length; i++)
{
    int sumeLeft = 0;
    int sumeRight = 0;

    // Calculate the sum of the left
    for (int j = 0; j < i; j++)
    {
        sumeLeft += numMasiv[j];
    }

    // Calculate the sum of the right
    for (int k = i + 1; k < numMasiv.Length; k++)
    {
        sumeRight += numMasiv[k];
    }

    if (sumeLeft == sumeRight)
    {
        Console.WriteLine(i);
        return;
        //stop
    }
}

Console.WriteLine("no"); // No such element