/*
4
Allie is going!
George is going!
John is not going!
George is not going!

5
Tom is going!
Annie is going!
Tom is going!
Garry is going!
Jerry is going!

*/

namespace _03.HouseParty;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<string> names = new List<string>();

        for (int i = 0; i < n; i++)
        {
            List<string> currentName = Console.ReadLine()
            .Split()
            .ToList();

            string justName = currentName[0];
            string goingOrNot = currentName[2];


            if (goingOrNot != "not")
            {
                bool isTrue = names.Contains(justName);
                if (isTrue)
                {
                    Console.WriteLine($"{justName} is already in the list!");
                }
                else
                {
                    names.Add(justName);
                }
            }

            else if (goingOrNot == "not")
            {
                bool isTrue = names.Contains(justName);
                if (isTrue)
                {
                    names.Remove(justName);
                }
                else
                {
                Console.WriteLine($"{justName} is not in the list!");
                }
            }


        }

        //for (int i = 0; i < names.Count; i++)
        //{
        //    Console.WriteLine($"{names[i]}");
        //}

        Console.WriteLine(string.Join("\n", names)); // \n за нов ред

        //foreach (string name in names)
        //{
        //    Console.WriteLine(names);
        //}

    }
}

