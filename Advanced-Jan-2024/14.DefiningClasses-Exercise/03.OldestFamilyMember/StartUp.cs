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

        Person oldestMember = family.GetOldestMemeber();

        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

    }
}

 