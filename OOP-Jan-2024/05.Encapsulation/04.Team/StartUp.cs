/*
5
Andrew Williams 20 2200
Newton Holland 57 3333
Rachelle Nelson 27 600
Grigor Dimitrov 25 666.66
Brandi Scott 35 555

 
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

        //decimal percentIncrease = decimal.Parse(Console.ReadLine());

        //foreach (var p in persons)
        //{
        //    p.IncreaseSalary(percentIncrease); 
        //}

        //foreach (var person in persons)
        //{
        //    Console.WriteLine(person);
        //}

        Team team = new Team("SoftUni");

        foreach (var person in persons)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}

