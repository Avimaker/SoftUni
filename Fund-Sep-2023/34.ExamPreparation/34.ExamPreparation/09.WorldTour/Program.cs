/*
Hawai::Cyprys-Greece
Add Stop:7:Rome
Remove Stop:11:16
Switch:Hawai:Bulgaria
Travel

Albania:Bulgaria:Cyprus:Deuchland
Add Stop:3:Nigeria
Remove Stop:4:8
Switch:Albania: Azərbaycan
Travel
 
*/


namespace _09.WorldTour;

class Program
{
    static void Main(string[] args)
    {
        string inputRoute = Console.ReadLine();
        string newRoute;

        string command = default;
        while ((command = Console.ReadLine()) != "Travel")
{
            string[] arguments = command.Split(":");

            if (arguments[0] == "Add Stop")
            {
                int index = int.Parse(arguments[1]);
                string newCountry = arguments[2];
                int indexCheck = inputRoute.Length;

                if (indexCheck > index)
                {
                    newRoute = inputRoute.Insert(index, newCountry);
                    inputRoute = newRoute;
                }
                Console.WriteLine(inputRoute);
            }
            else if (arguments[0] == "Remove Stop")
            {
                int startIndex = int.Parse(arguments[1]);
                int endIndex = int.Parse(arguments[2]);
                int indexCheck = inputRoute.Length;
                int removeLength = endIndex - startIndex + 1; // така намирам дължината за махане, тук са ми дали полсения индекс да е включен и затова има и плюс 1

                if (indexCheck > endIndex)
                {
                    newRoute = inputRoute.Remove(startIndex, removeLength);
                    inputRoute = newRoute;
                }
                Console.WriteLine(inputRoute);
            }
            else if (arguments[0] == "Switch")
            {
                string oldString = arguments[1];
                string newString = arguments[2];

                newRoute = inputRoute.Replace(oldString, newString);
                inputRoute = newRoute;
                Console.WriteLine(inputRoute);
            }
        }

        Console.WriteLine($"Ready for world tour! Planned stops: {inputRoute}");

    }
}

