/*
1 2 3 4 5
add
add
print
end
 
5 10
multiply
subtract
print
end
 
*/

namespace _05.AppliedArithmetics;

class Program
{
    static void Main(string[] args)
    {

        Func<string, List<int>, List<int>> calculate = (command, numbers) =>
        {
            List<int> result = new();

            foreach (var number in numbers)
            {
                switch (command)
                {
                    case "add":
                        result.Add(number + 1);
                        break;
                    case "multiply":
                        result.Add(number * 2);
                        break;
                    case "subtract":
                        result.Add(number - 1);
                        break;
                }
            }
            return result;
        };

        Action<List<int>> print = input => Console.WriteLine(string.Join(" ", input));

        List<int> input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        string command = default;
        while ((command = Console.ReadLine()) != "end")
        {
            if (command == "print")
            {
                print(input);
            }
            else
            {
                input = calculate(command, input);
            }
        }

    }
}

