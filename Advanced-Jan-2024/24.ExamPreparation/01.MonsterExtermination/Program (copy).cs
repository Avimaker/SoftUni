/*
20,15,10
5,15,10,25

30,25,40,35
15,20,10,30


 */

using Microsoft.VisualBasic;

namespace _01.MonsterExtermination;
class Program2
{
    static void Main(string[] args)
    {
        Queue<int> armorOfMonster = new Queue<int>(Console.ReadLine()
           .Split(",", StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray());


        Stack<int> soldiersStrike = new Stack<int>(Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        int monstersCount = 0;

        while (armorOfMonster.Count != 0 && soldiersStrike.Count != 0)
        {
            int armor = armorOfMonster.Peek();
            int strike = soldiersStrike.Peek();
            int tempStrike = 0;

            if (strike >= armor)
            {
                monstersCount++;
                strike -= armor;

                if (strike == 0)
                {
                    armorOfMonster.Dequeue();//moster dies
                    soldiersStrike.Pop();//soldier hits
                }
                else
                {
                    armorOfMonster.Dequeue();
                    if (soldiersStrike.Count == 1)
                    {
                        soldiersStrike.Pop();
                        soldiersStrike.Push(strike);
                        continue;
                    }
                    else
                    {
                        soldiersStrike.Pop();
                        tempStrike = strike;
                        soldiersStrike.Push(soldiersStrike.Pop() + tempStrike);
                    }
                }
            }

            else if (strike < armor)
            {
                armor -= strike;
                soldiersStrike.Pop();//soldier hits
                armorOfMonster.Dequeue();//moster stays live
                armorOfMonster.Enqueue(armor);
            }
        }//while end

        if (armorOfMonster.Count == 0)
        {
            Console.WriteLine("All monsters have been killed!");
        }
        if (soldiersStrike.Count == 0)
        {
            Console.WriteLine("The soldier has been defeated.");
        }

        Console.WriteLine($"Total monsters killed: {monstersCount}");
    }
}

