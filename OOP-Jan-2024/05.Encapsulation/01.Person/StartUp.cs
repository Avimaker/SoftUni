/*
5
Brandi Anderson 65
Andrew Williams 57
Newton Holland 27
Andrew Clark 44
Brandi Scott 35

*/

namespace PersonsInfo;
public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> persons = new();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]));

            persons.Add(person);
        }

        ////var 1
        //List<Person> orderedPersons = persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList();
        //foreach (var person in orderedPersons)
        //{
        //    Console.WriteLine(person);
        //}

        ////var 2
        //persons = persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList();
        //foreach (var person in persons)
        //{
        //    Console.WriteLine(person);
        //}

        //var 3

        foreach (var person in persons
                                .OrderBy(p => p.FirstName)
                                .ThenBy(p => p.Age))
        {
            Console.WriteLine(person);
        }



        ////var 4
        //persons.OrderBy(p => p.FirstName)
        //   .ThenBy(p => p.Age)
        //   .ToList()
        //   .ForEach(p => Console.WriteLine(p.ToString()));

    }
}

