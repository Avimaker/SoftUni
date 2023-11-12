namespace _02.CharacterMultiplier;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split()
            .ToArray();

        int result = Sum(input[0], input[1]);

        Console.WriteLine(result);
    }

    private static int Sum(string first, string second)
    {

        int totalSum = 0;
        int maxLength = Math.Max(first.Length, second.Length);

        for (int i = 0; i < maxLength; i++)
        {

            if (i < first.Length && i < second.Length)
            {
                totalSum += first[i] * second[i];
            }
            else if (i < first.Length)
            {
                totalSum += first[i];
            }
            else if (i < second.Length)
            {
                totalSum += second[i];
            }
        }

        return totalSum;
    }





}


