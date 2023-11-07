/*
George 123456 20
Peter 78911 15
Stephen 524244 10
End

Lewis 123456 20
James 78911 15
Robert 523444 11
Jennifer 345244 13
Mary 52424678 22
Patricia 567343 54
End


*/

namespace _07.OrderByAge;

class Person
{
    public Person(string name, string id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }

    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name} with ID: {Id} is {Age} years old."; 
    }

}


class Program
{
    static void Main(string[] args)
    {

        List<Person> persons = new List<Person>();

        string command = default;
        while ((command = Console.ReadLine()) != "End")
{
            string[] arguments = command.Split();

            string currentName = arguments[0];
            string currentId = arguments[1];
            int currentAge = int.Parse(arguments[2]);

            Person inputInfo = new Person(currentName, currentId, currentAge);

            if (!persons.Exists(x => x.Id == currentId))
            {
                persons.Add(inputInfo);
                continue;
            }

            if (persons.Exists(x => x.Id == currentId))
            {

                persons.Add(new Person(currentName, currentId, currentAge));

            }

        }
            List<Person> orderedPersons = persons.OrderBy(person => person.Age).ToList();

            foreach (var person in orderedPersons)
            {
                Console.WriteLine(person);
            }


    }
}



 