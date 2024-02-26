/*
5
Andrew Williams 65 2200
Newton Holland 57 3333
Rachelle Nelson 27 600
Brandi Scott 44 666.66
George Miller 35 559.4
20
 
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
            Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));

            persons.Add(person);
        }

        decimal percentIncrease = decimal.Parse(Console.ReadLine());

        foreach (var p in persons)
        {
            p.IncreaseSalary(percentIncrease); 
        }

        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}

