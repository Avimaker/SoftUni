/*
3
1 5
10 3
3 4
*/

namespace _07.TruckTour2;

class Program
{
    static void Main(string[] args)
    {
        int petrolPumpCount = int.Parse(Console.ReadLine());

        Queue<(int, int)> pumps = new();

        for (int i = 0; i < petrolPumpCount; i++)
        {
            int[] input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            int petrol = input[0];
            int distance = input[1];

            pumps.Enqueue((petrol, distance));
        }

        int bestRoute = 0;
        int totalPetrol = 0;
        int currentDistance = 0;
        int countOfPumps = pumps.Count;

        while (countOfPumps > 0)
        {
            foreach ((int, int) pump in pumps)
            {
                totalPetrol += pump.Item1; //1
                currentDistance = pump.Item2; //5

                if (totalPetrol - currentDistance < 0)
                {
                    totalPetrol = 0;
                    break;
                }
                else
                {
                    totalPetrol -= currentDistance;
                }
            }

            if (totalPetrol > 0)
            {
                break;
            }


            bestRoute++;
            pumps.Enqueue(pumps.Dequeue());

            countOfPumps--;
        }


        Console.WriteLine(bestRoute);
    }
}

