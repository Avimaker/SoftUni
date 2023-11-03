/*
5
register John CS1234JS
register George JAVA123S
register Andy AB4142CD
register Jesica VR1223EE
unregister Andy
*/

namespace _04.SoftUniParking;

class User
{
    public User(string userName, string licensePlateNumber)
    {
        UserName = userName;
        LicensePlateNumber = licensePlateNumber;
    }

    public string UserName { get; set; }

    public string LicensePlateNumber { get; set; }

    public override string ToString()
    {
        return $"{UserName} => {LicensePlateNumber}";
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, User> users = new Dictionary<string, User>();

        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string[] arguments = Console.ReadLine().Split();
            string command = arguments[0];
            string userName = arguments[1];

            switch (command)
            {
                case "register":
                    string licensePlateNumber = arguments[2];
                    User newUser = new User(userName, licensePlateNumber);
                    if (!users.ContainsKey(userName))
                    {
                        users.Add(newUser.UserName, newUser);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }

                    break;
                case "unregister":
                    if (users.ContainsKey(userName))
                    {
                        users.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }

                    break;
            }
        }

        foreach (var userPair in users)
        {
            Console.WriteLine(userPair.Value);
        }
    }
}