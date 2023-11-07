/*
SoftUni -> AA12345
SoftUni -> BB12345
Microsoft -> CC12345
HP -> BB12345
End

SoftUni -> AA12345
SoftUni -> CC12344
Lenovo -> XX23456
SoftUni -> AA12345
Movement -> DD11111
End

SoftUni -> AA12345
SoftUni -> AA12345
End

*/

using System.Xml.Linq;

namespace _07.CompanyUsers;

class User
{
    public User(string company)
    {
        Company = company;
        Id = new List<string>();
    }

    public string Company { get; set; }
    public List<string> Id { get; set; }

    public override string ToString()
    {
        string result = $"{Company}\n";

        for (int i = 0; i < Id.Count; i++)
        {
            result += $"-- {Id[i]}\n";
        }

        return result.Trim();
    }

    public void AddId(string id)
    {
        if (!Id.Contains(id))
        {
            Id.Add(id);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, User> users = new Dictionary<string, User>();

        string command = default;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split(" -> ");
            string company = arguments[0];
            string id = arguments[1];


            if (!users.ContainsKey(company))// add company
            {
                User newCompany = new User(company);
                users.Add(company, newCompany);
            }

            users[company].AddId(id);

        }

        foreach (var item in users)
        {
            Console.WriteLine(item.Value);
        }
    }
}

