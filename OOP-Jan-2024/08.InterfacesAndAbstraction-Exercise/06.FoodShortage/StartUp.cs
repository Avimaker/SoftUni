/*
2
Peter 25 8904041303 04/04/1989
Stan 27 WildMonkeys
Peter
George
Peter
End


4
Stam 23 TheSwarm
Ton 44 7308185527 18/08/1973
George 31 Terrorists
Pen 27 881222212 22/12/1988
John
Geo rge
John
Joro
Stam
Pen
End
 
 */

using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage;
public class StartUp
{
    static void Main(string[] args)
    {
        List<IBuy> listForCheck = new();

        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 4)
            {
                IBuy citizen = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]), tokens[3]);
                listForCheck.Add(citizen);
            }
            else
            {
                IBuy rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                listForCheck.Add(rebel);
            }

        }

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                break;
            }

            listForCheck.FirstOrDefault(buyer => buyer.Name == input)?.BuyFood();
        }

        Console.WriteLine(listForCheck.Sum(p => p.Food));
    }
}

