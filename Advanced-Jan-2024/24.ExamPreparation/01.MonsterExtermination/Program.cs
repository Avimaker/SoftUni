/*
20,15,10
5,15,10,25

30,25,40,35
15,20,10,30


 */

namespace _01.MonsterExtermination;
class Program
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

        int battleResult = 0;
        int monstersCount = 0;

        while (armorOfMonster.Count != 0 && soldiersStrike.Count != 0)
        {
            int armor = armorOfMonster.Peek();
            int strike = soldiersStrike.Peek();
            battleResult = Math.Abs(armor - strike);
            int tempStrike = 0;

            if (strike >= armor)
            {
                armorOfMonster.Dequeue();//moster dies
                soldiersStrike.Pop();//soldier hits
                monstersCount++;

                if (battleResult != 0)
                {
                    if (soldiersStrike.Count > 0)
                    {
                        tempStrike = soldiersStrike.Pop();//soldier next strike power
                        tempStrike += battleResult;
                        soldiersStrike.Push(tempStrike);
                    }
                    else
                    {
                        soldiersStrike.Push(battleResult);
                    }
                }
            }

            else if (strike < armor)
            {
                soldiersStrike.Pop();//soldier hits
                armorOfMonster.Dequeue();//moster stays live
                armorOfMonster.Enqueue(battleResult);
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

