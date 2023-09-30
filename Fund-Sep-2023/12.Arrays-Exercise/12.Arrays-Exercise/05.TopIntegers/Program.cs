int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

bool isTopNumber = true;

for (int i = 0; i < numbers.Length; i++)
{
    int leftNumber = numbers[i];

    for (int k = i + 1; k < numbers.Length; k++)
    {
        if (leftNumber <= numbers[k])
        {
            isTopNumber = false;
            break;
        }
    }


    if (isTopNumber)
    {
        Console.Write($"{leftNumber} ");
    }

    isTopNumber = true;
}
