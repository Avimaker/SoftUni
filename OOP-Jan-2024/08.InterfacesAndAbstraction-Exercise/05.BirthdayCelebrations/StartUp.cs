/*
Citizen Peter 22 9010101122 10/10/1990
Pet Sharo 13/11/2005
Robot MK-13 558833251
End
1990

*/

using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations;
public class StartUp
{
    static void Main(string[] args)
    {
        List<IBirthdate> listForCheck = new();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                break;
            }

            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] == "Citizen")
            {
                IBirthdate citizen = new Citizen(tokens[3], tokens[1], int.Parse(tokens[2]), tokens[4]);

                listForCheck.Add(citizen);
            }
            else if (tokens[0] == "Pet")
            {
                IBirthdate pet = new Pet(tokens[1], tokens[2]);

                listForCheck.Add(pet);
            }
        }

        string birthDayCheck = Console.ReadLine();

        foreach (var person in listForCheck)
        {
            if (person.Birthdate.EndsWith(birthDayCheck))
            {
                Console.WriteLine(person.Birthdate);
            }
        }
    }
}

