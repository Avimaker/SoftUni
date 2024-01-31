/*
3
Peter 12
Sam 31
Ivan 48

5
Niki 33
Yord 88
Teo 22
Lily 44
Stan 11
 
*/

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        Family family = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personProperties = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new(personProperties[0], int.Parse(personProperties[1]));

            family.AddMember(person);
        }

    
        Family sortedMembersOver30 = new(family.People.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList());


        foreach (var member in sortedMembersOver30.People)
        {
            Console.WriteLine($"{member.Name} {member.Age}");
        }

    }
}



