/*
Siiceercaroetavm!:?:ahsott.:i:nstupmomceqr 
TakeOdd
Cut 15 3
Substitute :: -
Substitute | ^
Done

up8rgoyg3r1atmlmpiunagt!-irs7!1fgulnnnqy
TakeOdd
Cut 18 2
Substitute ! ***
Substitute ? .!.
Done
 
*/

namespace _06.Password_Reset;

class Program
{
    static void Main(string[] args)
    {

        string password = Console.ReadLine();

        string commands = default;
        while ((commands = Console.ReadLine()) != "Done")
        {
            string[] arguments = commands.Split();

            if (arguments[0] == "TakeOdd")
            {
                string oddPass = default;

                for (int i = 0; i < password.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        oddPass += password[i];
                    }
                }

                Console.WriteLine(oddPass);
                password = oddPass;
            }
            else if (arguments[0] == "Cut")
            {
                int index = int.Parse(arguments[1]);
                int length = int.Parse(arguments[2]);

                string substring = password.Substring(index, length);

                string cutPassword = password.Remove(index, substring.Length);

                Console.WriteLine(cutPassword);
                password = cutPassword;
            }
            else if (arguments[0] == "Substitute")
            {
                string substring = arguments[1];
                string substitute = arguments[2];

                if (password.Contains(substring))
                {
                    string substitutePassword = password.Replace(substring, substitute);
                    Console.WriteLine(substitutePassword);
                    password = substitutePassword;
                }
                else
                {
                    Console.WriteLine("Nothing to replace!");
                }

            }

        }

        Console.WriteLine($"Your password is: {password}");
    }
}



