/*
350
Rob Mary Paisley Spencer
 
*/

namespace _11.TriFunction;

class Program
{
    static void Main(string[] args)
    {
        Func<string, int, bool> checkEqualOrLargerNameSum =
    //(name, sum) => name.Sum(ch => ch) >= sum;
    (name, sum) =>
    {
        int charsSum = name.Sum(ch => ch);

        return charsSum >= sum;
    };


        Func<string[], int, Func<string, int, bool>, string> getFirstName =
            //(names, sum, match) => names.FirstOrDefault(name => match(name, sum));
            (names, sum, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name, sum))
                    {
                        return name;
                    }
                }

                return default;
            };

        int sum = int.Parse(Console.ReadLine());

        string[] names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string foundName = getFirstName(names, sum, checkEqualOrLargerNameSum);

        Console.WriteLine(foundName);
    }
}

