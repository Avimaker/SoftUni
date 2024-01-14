/*
3
1 5
10 3
3 4
*/

namespace _07.TruckTour;

class Program
{
    static void Main(string[] args)
    {
        int petrolPumpCount = int.Parse(Console.ReadLine());

        Queue<int[]> pumps = new();

        for (int i = 0; i < petrolPumpCount; i++)
        {
            int[] input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            //int petrol = input[0];
            //int distance = input[1];

            pumps.Enqueue(input);
        }

        int bestRoute = 0;
        int totalPetrol = 0;
        int currentDistance = 0;

        while (true)
        {
            foreach (var pump in pumps)
            {
                totalPetrol += pump[0]; //1
                currentDistance = pump[1]; //5

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

        }


        Console.WriteLine(bestRoute);
    }
}

