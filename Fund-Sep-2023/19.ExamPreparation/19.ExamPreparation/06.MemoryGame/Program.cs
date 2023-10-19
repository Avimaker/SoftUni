/*
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
        int middleOfSequence = cards.Count / 2;
        int movesCounter = 0;
        string moves = default;

        while ((moves = Console.ReadLine()) != "end")
        {
            movesCounter++;
            string[] playIndex = moves.Split();

            string cheatNumber = $"-{movesCounter}a";

            int moveOne = int.Parse(playIndex[0]);
            int moveTwo = int.Parse(playIndex[1]);

            if (moveOne == moveTwo || moveOne < 0 || moveOne > cards.Count - 1 || moveTwo < 0 || moveTwo > cards.Count - 1)
            {
                Console.WriteLine("Invalid input! Adding additional elements to the board");//cheat
                cards.Insert(middleOfSequence - 1, cheatNumber);
                cards.Insert(middleOfSequence - 1, cheatNumber);
            }

            else if (cards[moveOne] == cards[moveTwo])
            {
                Console.WriteLine($"Congrats! You have found matching elements - {cards[moveOne]}!");
                if (moveOne > moveTwo)
                {
                    cards.RemoveAt(moveOne);
                    cards.RemoveAt(moveTwo);
                }
                else
                {
                    cards.RemoveAt(moveTwo);
                    cards.RemoveAt(moveOne);
                }
            }
            else if (cards[moveOne] != cards[moveTwo])
            {
                Console.WriteLine("Try again!");
            }

            if (cards.Count <= 1)
            {
                Console.WriteLine($"You have won in {movesCounter} turns!");
                return;
            }

        }

        Console.WriteLine("Sorry you lose :(");
        Console.WriteLine(string.Join(" ", cards));
    }

}
