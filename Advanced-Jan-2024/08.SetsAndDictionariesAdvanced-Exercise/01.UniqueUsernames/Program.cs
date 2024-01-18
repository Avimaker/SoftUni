/*
6
John
John
John
Peter
John
Boy1234
 
*/

namespace _01.UniqueUsernames;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        HashSet<string> uniqNames = new();
 
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            uniqNames.Add(input);
        }

        foreach (var name in uniqNames)
        {
            Console.WriteLine(name);
        }


    }
}

