/*
5
Andrew Williams -6 2200
B Gomez 57 3333
Carolina Richards 27 670
Gilbert H 44 666.66
Joshua Anderson 35 300
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
            try
            {
                Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));

                persons.Add(person);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
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

