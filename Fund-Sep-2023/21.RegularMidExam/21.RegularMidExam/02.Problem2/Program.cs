/*
Travel 10||Enemy 30||Repair 15||Titan
50
80

Travel 20||Enemy 50||Enemy 50||Enemy 10||Repair 15||Enemy 50||Titan
60
100


 */

namespace _02.Problem2;

class Program
{
    static void Main(string[] args)
    {

        //input
        List<string> inputCommands = Console.ReadLine()
            .Split("||")
            .ToList();
        int fuel = int.Parse(Console.ReadLine());
        int ammonition = int.Parse(Console.ReadLine());


        int currentFuel = fuel;
        int currentAmmo = ammonition;

        //starting loop

        for (int i = 0; i < inputCommands.Count; i++)
        {
            string[] currentCommands = inputCommands[i].Split().ToArray();

            while (currentCommands[0] != "Titan")// end check
            {

                if (currentCommands[0] == "Travel")
                {
                    int lightYears = int.Parse(currentCommands[1]);
                    //int fuelSpend = lightYears / 10;
                    if (currentFuel >= lightYears)
                    {
                        Console.WriteLine($"The spaceship travelled {lightYears} light-years.");
                        //currentFuel -= fuelSpend;
                        currentFuel -= lightYears;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Mission failed.");
                        return;
                    }
                }
                else if (currentCommands[0] == "Enemy")
                {
                    int arguments = int.Parse(currentCommands[1]);
                    if (currentAmmo >= arguments)
                    {
                        currentAmmo -= arguments;
                        Console.WriteLine($"An enemy with {arguments} armour is defeated.");
                        break;
                    }
                    else
                    {
                        int fuelNeeded = (arguments * 2);

                        if (currentFuel >= fuelNeeded) //da vidia posle =0 ???
                        {
                            currentFuel -= fuelNeeded;
                            Console.WriteLine($"An enemy with {arguments} armour is outmaneuvered.");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Mission failed.");
                            return;
                        }
                    }
                }
                else if (currentCommands[0] == "Repair")
                {
                    int arguments = int.Parse(currentCommands[1]);
                    currentFuel += arguments;
                    currentAmmo += (arguments * 2);
                    Console.WriteLine($"Ammunitions added: {arguments * 2}.");
                    Console.WriteLine($"Fuel added: {arguments}.");
                    break;
                }

            }
        }
            Console.WriteLine("You have reached Titan, all passengers are safe.");
            return;

    }
}

