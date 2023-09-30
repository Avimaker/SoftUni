int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

for (int i = 0; i < numbers.Length; i++)
{
    int sumeLeft = 0;
    int sumeRight = 0;

    // Calculate the sum of elements to the left
    for (int j = 0; j < i; j++)
    {
        sumeLeft += numbers[j];
    }

    // Calculate the sum of elements to the right
    for (int k = i + 1; k < numbers.Length; k++)
    {
        sumeRight += numbers[k];
    }

    if (sumeLeft == sumeRight)
    {
        Console.WriteLine(i);
        return; // Stop searching as we found the index
    }
}

Console.WriteLine("no"); // No such index exists