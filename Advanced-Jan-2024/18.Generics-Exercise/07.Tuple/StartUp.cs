/*
Adam Smith California
Mark 2
23 21.23212321
 
*/

namespace Tuple;
class StartUp
{
    static void Main(string[] args)
    {
        //Line 1
        Tuple<string, string> firstLine = new();

        string[] firstLineInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        firstLine.item1 = firstLineInput[0] + " " + firstLineInput[1];
        firstLine.item2 = firstLineInput[2];

        Console.WriteLine($"{firstLine.item1} -> {firstLine.item2}");

        //Line 2
        Tuple<string, int> secondLine = new();

        string[] secondLineInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        secondLine.item1 = secondLineInput[0];
        secondLine.item2 = int.Parse(secondLineInput[1]);

        Console.WriteLine($"{secondLine.item1} -> {secondLine.item2}");

        //Line 3
        Tuple<int, double> thirdLine = new();

        string[] thirdLineInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        thirdLine.item1 = int.Parse(thirdLineInput[0]);
        thirdLine.item2 = double.Parse(thirdLineInput[1]);

        Console.WriteLine($"{thirdLine.item1} -> {thirdLine.item2}");

    }
}

