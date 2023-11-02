namespace _01.CountRealNumbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var numberOccurrences = new SortedDictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            //// var 1
            //if (!numberOccurrences.ContainsKey(numbers[i])) // ако не съдържа числото 
            //{
            //    numberOccurrences[numbers[i]] = 1; // да го добави и сложи стойност 1
            //}
            //else
            //{
            //    numberOccurrences[numbers[i]]++; // ако го има увеличавам с едно появяванията
            //}

            // var 2 - тук трябва да сме сигурни, че не съществува за да не изгърми с Add
            if (!numberOccurrences.ContainsKey(numbers[i])) // ако не съдържа числото 
            {
                numberOccurrences.Add(numbers[i], 0); // да го добави и сложи стойност 0
            }

                numberOccurrences[numbers[i]]++; // ако го има увеличавам с едно появяванията




        }

        foreach (KeyValuePair<int, int> kvp in numberOccurrences) //kvp вместо item за да свикна
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }

    }
}

