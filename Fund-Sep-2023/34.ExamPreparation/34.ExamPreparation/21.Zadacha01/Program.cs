/*
A7ci0
Illusion 1 c
Illusion 4 o
Abjuration
Abracadabra

TR1GG3R
Necromancy
Illusion 8 m
Illusion 9 n
Abracadabra

SwordMaster
Target Target Target
Abjuration
Necromancy
Alteration master
Abracadabra

evgEni
Illusion 3 A
 
*/



namespace _21.Zadacha01;

class Program
{
    static void Main(string[] args)
    {

        string inputSpell = Console.ReadLine();

        string commands = default;
        while ((commands = Console.ReadLine()) != "Abracadabra")
        {
            string[] arguments = commands.Split();

            string spellName = arguments[0];

            if (spellName != "Abjuration" && spellName != "Necromancy" && spellName != "Illusion" && spellName != "Divination" && spellName != "Alteration")
            {
                Console.WriteLine("The spell did not work!");
                continue;
            }


            if (arguments[0] == "Abjuration")
            {
                string newSpell = inputSpell.ToUpper();
                Console.WriteLine(newSpell);
                inputSpell = newSpell;
            }

            else if (arguments[0] == "Necromancy")
            {
                string newSpell = inputSpell.ToLower();
                Console.WriteLine(newSpell);
                inputSpell = newSpell;
            }

            else if (arguments[0] == "Illusion")
            {
                int index = int.Parse(arguments[1]);
                string letter = arguments[2];

                if (index >= 0 && index < inputSpell.Length)
                {
                    string removeIndex = inputSpell.Remove(index, 1);
                    string newSpell = removeIndex.Insert(index, letter);
                    Console.WriteLine("Done!");
                    inputSpell = newSpell;
                }
                else
                {
                    Console.WriteLine("The spell was too weak.");
                }
            }

            else if (arguments[0] == "Divination")
            {
                string firstSubstring = arguments[1];
                string secondSubstring = arguments[2];

                if (inputSpell.Contains(firstSubstring))
                {
                    string newSpell = inputSpell.Replace(firstSubstring, secondSubstring);
                    Console.WriteLine(newSpell);
                    inputSpell = newSpell;
                }
            }

            else if (arguments[0] == "Alteration")
            {
                string substring = arguments[1];
                int startIndex = inputSpell.IndexOf(substring);
                int length = substring.Length;

                if (inputSpell.Contains(substring))
                {
                    string newSpell = inputSpell.Remove(startIndex, length);
                    Console.WriteLine(newSpell);
                    inputSpell = newSpell;
                }


            }
        }

        //output
        /*
        The possible outputs are:
        o	"The spell did not work!"
        o	"The spell was too weak."
        o	"Done!"
        */
    }

}


