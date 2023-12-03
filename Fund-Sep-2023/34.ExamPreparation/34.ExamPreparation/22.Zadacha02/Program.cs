/*
 
*/


using System.Text.RegularExpressions;

namespace _22.Zadacha02;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"[@#]+(?<color>[a-z]{3,})[@#]+([^a-z\d]*)/+(?<amount>\d+)/+";

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            string color = match.Groups["color"].Value;
            int amount = int.Parse(match.Groups["amount"].Value);

            Console.WriteLine($"You found {amount} {color} eggs!");
        }
    }
}
