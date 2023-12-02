/*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF
Generate

134softsf5ftuni2020rockz42
Slice>>>3>>>7
Contains>>>-rock
Contains>>>-uni-
Contains>>>-rocks
Flip>>>Upper>>>2>>>8
Flip>>>Lower>>>5>>>11
Generate
 
*/

namespace _04.ActivationKeys;

class Program
{

    static void Contains(string substring)
    {
        if (activationKey.Contains(substring))
        {
            Console.WriteLine($"{activationKey} contains {substring}");
        }
        else
        {
            Console.WriteLine("Substring not found!");
        }
    }
    // това ми е важно по стринговете, как се взима дължина за махане и последен
    static void Upper(int startIndex, int endIndex)
    {
        string prefix = activationKey.Substring(0, startIndex);
        string middle = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
        string sufix = activationKey.Substring(endIndex);
        activationKey = prefix + middle + sufix;
        Console.WriteLine(activationKey);
    }

    static void Lower(int startIndex, int endIndex)
    {
        string prefix = activationKey.Substring(0, startIndex);
        string middle = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
        string sufix = activationKey.Substring(endIndex);
        activationKey = prefix + middle + sufix;
        Console.WriteLine(activationKey);
    }

    static void Slice(int startIndex, int endIndex)
    {
        string prefix = activationKey.Substring(0, startIndex);
        string sufix = activationKey.Substring(endIndex);
        activationKey = prefix + sufix;
        Console.WriteLine(activationKey);
    }

    static string activationKey;

    static void Main(string[] args)
    {
        activationKey = Console.ReadLine();

        string command = default;
        while ((command = Console.ReadLine()) != "Generate")
        {
            string[] arguments = command.Split(">>>");

            if (arguments[0] == "Contains")
            {
                string substring = arguments[1];
                Contains(substring);
            }
            else if (arguments[0] == "Flip")
            {
                int startIndex = int.Parse(arguments[2]);
                int endIndex = int.Parse(arguments[3]);

                if (arguments[1] == "Upper")
                {
                    Upper(startIndex, endIndex);
                }
                else if (arguments[1] == "Lower")
                {
                    Lower(startIndex, endIndex);
                }
            }
            else if (arguments[0] == "Slice")
            {
                int startIndex = int.Parse(arguments[1]);
                int endIndex = int.Parse(arguments[2]);
                Slice(startIndex, endIndex);
            }

        }

        Console.WriteLine($"Your activation key is: {activationKey}");
    }


}

