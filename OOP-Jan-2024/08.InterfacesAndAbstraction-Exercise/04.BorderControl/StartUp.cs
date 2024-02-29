/*
Peter 22 9010101122
MK-13 558833251
MK-12 33283122
End
122

 */

using System.Xml.Linq;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl;
public class StartUp
{
    static void Main(string[] args)
    {
        List<IId> listOfPersonsForCheck = new();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                break;
            }

            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 3)
            {
                IId citizen = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]));

                listOfPersonsForCheck.Add(citizen);
            }
            else if (tokens.Length == 2)
            {
                IId robot = new Robot(tokens[1], tokens[0]);

                listOfPersonsForCheck.Add(robot);
            }
        }

        string fakeIds = Console.ReadLine();

        foreach (var person in listOfPersonsForCheck)
        {
            if (person.Id.EndsWith(fakeIds))
            {
                Console.WriteLine(person.Id);
            }
        }

    }
}

