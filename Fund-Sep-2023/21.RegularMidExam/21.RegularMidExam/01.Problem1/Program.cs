/*
500
5
50
100
200
100
30

500
5
50
100
200
100
20

400
5
50
100
200
100
20

*/

namespace _01.Problem1;

class Program
{
    static void Main(string[] args)
    {
        double unlockExperience = int.Parse(Console.ReadLine());
        int numberOfBattles = int.Parse(Console.ReadLine());

        int battlesCount = 0;
        double currentExperience = 0;
        bool isTrue = false;



        for (int i = 0; i < numberOfBattles; i++)
        {
            battlesCount++;
            double currentInput = double.Parse(Console.ReadLine());




            if (battlesCount % 3 == 0)
            {
                currentInput *= 1.15;
            }
            else if (battlesCount % 5 == 0)
            {
                currentInput *= 0.90;
            }
            else if (battlesCount % 15 == 0)
            {
                currentInput *= 1.05;
            }


            currentExperience += currentInput;

            if (currentExperience >= unlockExperience)
            {
                isTrue = true;
                break;
            }
        }


        if (isTrue)
        {
            Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
        }
        else
        {
            double neededExperience = unlockExperience - currentExperience;
            Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience:f2} more needed.");
        }

    }
}

