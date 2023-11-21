/*
George, Peter, Bill, Tom
G4e@55or%6g6!68e!!@
R1@!3a$y4456@
B5@i@#123ll
G@e54o$r6ge#
7P%et^#e5346r
T$o553m&6
end of race

Ivan, Peter, James, Kyle
I4v@43an%66?77!!@
G1@!3u$s445s6@
B3@i@#245ll
I&v54a%66n@
7P%et^#e5346r
J$a553m&e6s
K2y3=l/^e23
end of race
 
*/


using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race;

class Racer
{
    public Racer(string name)
    {
        Name = name;
        //Distance = AddDistance(distance);
    }

    public string Name { get; set; }
    public int Distance { get; set; }

    //public int AddDistance(int distance)
    //{
    //    return Distance += distance;
    //}

}

class Program
{
    static void Main(string[] args)
    {
        List<string> participants = Console.ReadLine()
            .Split(", ")
            .ToList();

        List<Racer> racers = new List<Racer>();

        foreach (var name in participants)
        {
            racers.Add(new Racer(name));
        }


        string lettersPattern = (@"[A-Za-z]");
        string digitsPattern = (@"[\d]");

        string command = default;
        while ((command = Console.ReadLine()) != "end of race")
        {
            StringBuilder nameBuilder = new StringBuilder();
            foreach (Match match in Regex.Matches(command, lettersPattern))
            {
                nameBuilder.Append(match.Value);
            }
            string racerName = nameBuilder.ToString();

            int distance = 0;
            StringBuilder digitsBuilder = new StringBuilder();
            foreach (Match match in Regex.Matches(command, digitsPattern))
            {
                distance += int.Parse(match.Value);
            }

            Racer foundRacer = racers.FirstOrDefault(r => r.Name == racerName);
            if (foundRacer != null)
            {
                foundRacer.Distance += distance;
            }
        }

        List<Racer> orderedList = new List<Racer>();
        orderedList = racers.OrderByDescending(r => r.Distance).Take(3).ToList();

        Console.WriteLine($"1st place: {orderedList[0].Name}");
        Console.WriteLine($"2nd place: {orderedList[1].Name}");
        Console.WriteLine($"3rd place: {orderedList[2].Name}");
    }
}

