/*
20 30 40 50
10 20 30 40

10 20 30 40 50
50 40 30 30 10

*/

namespace _06.CardsGame;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstPlayer = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> secondPlayer = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();


        while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
        {

            if (firstPlayer[0] > secondPlayer[0])
            {
                int tempHand = firstPlayer[0];
                int wonHand = secondPlayer[0];
                firstPlayer.Add(tempHand);
                firstPlayer.Add(wonHand);
            }
            else if (firstPlayer[0] < secondPlayer[0])
            {
                int tempHand = secondPlayer[0];
                int wonHand = firstPlayer[0];
                secondPlayer.Add(tempHand);
                secondPlayer.Add(wonHand);
            }
            
                firstPlayer.RemoveAt(0);
                secondPlayer.RemoveAt(0);
            

        }

        if (firstPlayer.Count > secondPlayer.Count)
        {
            Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
        }
        else
        {
            Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
        }
    }
}

