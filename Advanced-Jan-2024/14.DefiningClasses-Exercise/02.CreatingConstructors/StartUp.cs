namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {

        Person person = new();

        person.Name = "Peter";
        person.Age = 20;

        Person george = new Person
        {
            Name = "George",
            Age = 25

        };


        Console.WriteLine($"{person.Name}: {person.Age}");
        Console.WriteLine($"{george.Name}: {george.Age}");

    }
}

 