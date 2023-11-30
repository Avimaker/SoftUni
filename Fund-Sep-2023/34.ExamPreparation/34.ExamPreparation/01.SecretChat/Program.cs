/*
heVVodar!gniV
ChangeAll:|:V:|:l
Reverse:|:!gnil
InsertSpace:|:5
Reveal

Hiware?uiy
ChangeAll:|:i:|:o
Reverse:|:?uoy
Reverse:|:jd
InsertSpace:|:3
InsertSpace:|:7
Reveal
 
*/

namespace _01.SecretChat;

class Program
{
    static void Main(string[] args)
    {
        string secretMsg = Console.ReadLine();

        string line;

        while ((line = Console.ReadLine()) != "Reveal")
        {
            string[] tokens = line.Split(":|:");
            string command = tokens[0];

            if (command == "InsertSpace")
            {
                int index = int.Parse(tokens[1]);
                secretMsg = secretMsg.Insert(index, " ");
            }
            else if (command == "ChangeAll")
            {
                string substring = tokens[1];
                string replacement = tokens[2];
                secretMsg = secretMsg.Replace(substring, replacement);
            }
            else //Reverse
            {
                string substring = tokens[1];
                int substringIndex = secretMsg.IndexOf(substring);
                if (substringIndex == -1)
                {
                    Console.WriteLine("error");
                    continue;
                }

                secretMsg = secretMsg.Remove(substringIndex, substring.Length);
                string reversedSubstring = new string(substring.Reverse().ToArray());
                secretMsg += reversedSubstring;
            }
            Console.WriteLine(secretMsg);

        }
        Console.WriteLine($"You have a new text message: {secretMsg}");
    }
}

