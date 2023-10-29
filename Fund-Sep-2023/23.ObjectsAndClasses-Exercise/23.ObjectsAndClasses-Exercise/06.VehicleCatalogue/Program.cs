/*
truck Man red 200
truck Mercedes blue 300
car Ford green 120
car Ferrari red 550
car Lamborghini orange 570
End
Ferrari
Ford
Man
Close the Catalogue

truck Volvo blue 220
truck Man red 350
car Tesla silver 450
car Nio red 650
truck Mack white 430
car Koenigsegg orange 750
End
Tesla
Nio
Man
Mack
Close the Catalogue

*/

using System.Collections.Generic;

namespace _06.VehicleCatalogue;

class Vehicle
{
    public Vehicle(string typeOfVehicle, string modelOfVehicle, string colorOfVehicle, double horsepowerOfVehicle)
    {
        Type = typeOfVehicle;
        Model = modelOfVehicle;
        Color = colorOfVehicle;
        Horsepower = horsepowerOfVehicle;
    }

    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double Horsepower { get; set; }

    public override string ToString()
    {
        return $"Type: {Type}\n" +
               $"Model: {Model}\n" +
               $"Color: {Color}\n" +
               $"Horsepower: {Horsepower}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        string command = default;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split();

            string typeOfVehicle = arguments[0];
            string modelOfVehicle = arguments[1];
            string colorOfVehicle = arguments[2];
            double horsepowerOfVehicle = double.Parse(arguments[3]);

            Vehicle vehicleInputInfo = new Vehicle(typeOfVehicle, modelOfVehicle, colorOfVehicle, horsepowerOfVehicle);

            vehicles.Add(vehicleInputInfo);
        }

        while ((command = Console.ReadLine()) != "Close the Catalogue")
        {
            string infoModel = command;

            int index = vehicles.FindIndex(x => x.Model == infoModel);

            Console.WriteLine(vehicles[index]);
        }

        // cars horsepower check
        int carsCount = 0;
        double carsHpSum = 0;
        for (int i = 0; i < vehicles.Count; i++)
        {
            List<Vehicle> indexCheck = new List<Vehicle> { vehicles[i] };

            if (indexCheck.Exists(x => x.Type == "car"))
            {
                var hpCheck = indexCheck.Select(h => h.Horsepower).ToArray();
                
                carsCount++;
                carsHpSum += hpCheck[0];
            }
        }
        double avgCarsHp = carsHpSum / carsCount;

        // trucks horsepower check
        int trucksCount = 0;
        double trucksHpSum = 0;
        for (int i = 0; i < vehicles.Count; i++)
        {
            List<Vehicle> indexCheck = new List<Vehicle> { vehicles[i] };

            if (indexCheck.Exists(x => x.Type == "truck"))
            {

                var hpCheck = indexCheck.Select(hp => hp.Horsepower).ToArray();

                trucksCount++;
                trucksHpSum += hpCheck[0];
            }
        }
        double avgTrucksHp = trucksHpSum / trucksCount;

        Console.WriteLine($"Cars have average horsepower of: {avgCarsHp:F2}.");
        Console.WriteLine($"Trucks  have average horsepower of: {avgTrucksHp:F2}.");
    }
}

