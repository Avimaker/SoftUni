/*
2
John-PowerPuffsCoders
Tony-Tony is the best
Peter->PowerPuffsCoders
Tony->Tony is the best
end of assignment

2
John-PowerPuffsCoders
John-Tony is the best

*/

namespace _05.TeamworkProjects;

class Team
{
    public Team(string teamName, string creatorName)
    {
        Name = teamName;
        Creator = creatorName;
        Members = new List<string>();
    }

    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }

    public override string ToString()
    {
        return $"{Name}\n" +
               $"- {Creator}\n" +
               $"{GetMembersString()}";
    }

    public string GetMembersString()
    {
        Members = Members.OrderBy(name => name).ToList();

        string result = "";

        for (int i = 0; i < Members.Count - 1; i++)
        {
            result += $"-- {Members[i]}\n";
        }
        result += $"-- {Members[Members.Count - 1]}";

        return result;
    }
}


class Program
{
    static void Main(string[] args)
    {
        int countOfTeams = int.Parse(Console.ReadLine());

        List<Team> teams = new List<Team>();

        for (int i = 0; i < countOfTeams; i++)
        {
            string[] teamsInput = Console.ReadLine()
            .Split("-")
            .ToArray();

            string teamName = teamsInput[1];
            string creatorName = teamsInput[0];

            Team team = new Team(teamName, creatorName);

            bool ifExistTeam = false;
            ifExistTeam = teams.Exists(teams => teams.Name == teamName);
            if (ifExistTeam)
            {
                Console.WriteLine($"Team {teamName} was already created!");
                break;
            }

            bool ifExistUser = false;
            ifExistUser = teams.Exists(teams => teams.Creator == creatorName);
            if (ifExistUser)
            {
                Console.WriteLine($"{creatorName} cannot create another team!");
                break;
            }

            teams.Add(team);
            Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
        }


        string command = default;
        while ((command = Console.ReadLine()) != "end of assignment")
        {
            // 0 User - 1 Team
            string[] arguments = command.Split("->");
            string joinerName = arguments[0];
            string teamName = arguments[1];

            bool ifExistTeam = true;
            ifExistTeam = teams.Exists(teams => teams.Name == teamName);
            if (!ifExistTeam)
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (teams.Any(team => team.Creator == joinerName) ||
                teams.Any(team => team.Members.Contains(joinerName)))
            {
                Console.WriteLine($"Member {joinerName} cannot join team {teamName}!");
                continue;
            }

            //teams.FirstOrDefault(t => t.Name == teamName)?.Members.Add(joinerName);

            //Team temp = teams.Find(t => t.Name == teamName);
            //if (temp != null)
            //{
            //    temp.Members.Add(joinerName);
            //}

            teams.First(t => t.Name == teamName).Members.Add(joinerName);

        }

        List<Team> leftTeams = teams.Where(t => t.Members.Count > 0).ToList();

        List<Team> orderedTeams = leftTeams
            .OrderByDescending(t => t.Members.Count)
            .ThenBy(t => t.Name)
            .ToList();

        //foreach (Team team in orderedTeams)
        //{
        //    Console.WriteLine(team);
        //}

        orderedTeams.ForEach(team => Console.WriteLine(team));

        List<Team> disbandTeams = teams.Where(t => t.Members.Count <= 0).ToList();

        Console.WriteLine("Teams to disband:");
        disbandTeams = disbandTeams.OrderBy(t => t.Name).ToList();
        disbandTeams.ForEach(team => Console.WriteLine(team.Name));
    }
}

