﻿/*
1 1 2 2 3 3 4 4 5 5
1 0
-1 0
1 0
1 0
1 0
end

a 2 4 a 2 4
0 3
0 2
0 1
0 1
end

a 2 4 a 2 4 
4 0
0 2
0 1
0 1
end


Пробвайте да дебъгнете с този примерен вход.
 
1 d 5 5 d 1 a a
-0 -5
end
 
Изход:
 
Invalid input! Adding additional elements to the board
Sorry you lose :(
1 d 5 5 -1a -1a d 1 a a


*/


namespace _06.MemoryGame;

class Program
{
    static void Main(string[] args)
    {
        List<string> cards = Console.ReadLine()
            .Split()
            .ToList();

        int sequenceCheck = cards.Count;
        int movesCounter = 0;
        string input = default;

        while ((input = Console.ReadLine()) != "end")
        {
            movesCounter++;
            int middleOfSequence = cards.Count / 2;
            int[] inputIndexes = input.Split().Select(int.Parse).ToArray();
            int firstIndex = inputIndexes[0];
            int secondIndex = inputIndexes[1];

            string cheatNumber = $"-{movesCounter}a";
            string[] cheatNumberRange = new string[2] { cheatNumber, cheatNumber };

            //cheat check
            if (firstIndex == secondIndex ||
                (firstIndex < 0 || firstIndex > cards.Count - 1) ||
                (secondIndex < 0 || secondIndex > cards.Count - 1))
            {
                Console.WriteLine("Invalid input! Adding additional elements to the board");
                cards.InsertRange(middleOfSequence, cheatNumberRange);
            }

            //normal case
            else
            {
                //hit two elements
                if (cards[firstIndex] == cards[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {cards[firstIndex]}!");
                    if (firstIndex > secondIndex)
                    {
                        cards.RemoveAt(firstIndex);
                        cards.RemoveAt(secondIndex);
                    }
                    else
                    {
                        cards.RemoveAt(firstIndex);
                        cards.RemoveAt(secondIndex - 1);
                    }
                }
                //hit two different ekements
                else if (cards[firstIndex] != cards[secondIndex])
                {
                    Console.WriteLine("Try again!");
                }

                // hit all matching elements
                if (cards.Count == 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    break;
                }
            }

        }//input end

        if (cards.Count != 0)
        {
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", cards));
        }
    }

}
