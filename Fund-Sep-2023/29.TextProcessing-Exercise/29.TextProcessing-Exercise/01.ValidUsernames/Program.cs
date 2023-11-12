/*
sh, too_long_username, !lleg@l ch@rs, jeffbutt
*/

namespace _01.ValidUsernames;

using System.Text;

class Program
{
    static void Main(string[] args)
    {

        string[] userNames = Console.ReadLine()
            .Split(", ");

        foreach (string userName in userNames)
        {

            if (userName.Length < 3 || userName.Length > 16)
            {
                continue;
            }

            if (IsValid(userName))
            {
                Console.WriteLine(userName);
            }

        }

    }

    private static bool IsValid(string userName)
    {

        return userName.All(ch => char.IsLetterOrDigit(ch) ||
                            ch == '-' || ch == '_');
    }
}

