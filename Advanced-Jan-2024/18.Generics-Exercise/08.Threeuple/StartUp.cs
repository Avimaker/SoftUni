/*
Adam Smith Wallstreet New York
Mark 18 drunk
Karren 0.10 USBank

Anatoly Andreevich Kutuzova Kaliningrad
Marley 9 not
Grant 2 NGB

*/

namespace Threeuple;
class StartUp
{
    static void Main(string[] args)
    {
        //Line 1
        Threeuple<string, string, string> firstLine = new();

        string[] firstLineInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        firstLine.item1 = firstLineInput[0] + " " + firstLineInput[1];
        firstLine.item2 = firstLineInput[2];
        firstLine.item3 = string.Join(" ", firstLineInput[3..]);

        Console.WriteLine($"{firstLine.item1} -> {firstLine.item2} -> {firstLine.item3}");

        //Line 2
        Threeuple<string, int, bool> secondLine = new();

        string[] secondLineInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        secondLine.item1 = secondLineInput[0];
        secondLine.item2 = int.Parse(secondLineInput[1]);
        bool isDrunk = false;
        if (secondLineInput[2] == "drunk")
        {
            isDrunk = true;
        }
        secondLine.item3 = isDrunk;


        Console.WriteLine($"{secondLine.item1} -> {secondLine.item2} -> {secondLine.item3}");

        //Line 3
        Threeuple<string, double, string> thirdLine = new();

        string[] thirdLineInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        thirdLine.item1 = thirdLineInput[0];
        thirdLine.item2 = double.Parse(thirdLineInput[1]);
        thirdLine.item3 = thirdLineInput[2];


        Console.WriteLine($"{thirdLine.item1} -> {thirdLine.item2} -> {thirdLine.item3}");

    }
}

