/*
"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"

Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000



*/


using Vehicles.Factories;
using Vehicles.Models;
using Vehicles.Models.Interface;

namespace Vehicles;
public class StartUp
{
    static void Main(string[] args)
    {

        List<Vehicle> vehicles = new();
        VehicleFactory vehicleFactory = new();

        double fuel, consumption, capacity;
        string type;

        VehicleRead(out fuel, out consumption, out capacity, out type);
        vehicles.Add(vehicleFactory.VehicleCreate(type, fuel, consumption, capacity));//Car

        VehicleRead(out fuel, out consumption, out capacity, out type);
        vehicles.Add(vehicleFactory.VehicleCreate(type, fuel, consumption, capacity));//truck

        VehicleRead(out fuel, out consumption, out capacity, out type);
        vehicles.Add(vehicleFactory.VehicleCreate(type, fuel, consumption, capacity));//bus




        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            try
            {
                ProcessCommand(vehicles);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        Console.WriteLine($"Car: {vehicles.OfType<Car>().Sum(c => c.FuelQuantity):f2}");
        Console.WriteLine($"Truck: {vehicles.OfType<Truck>().Sum(c => c.FuelQuantity):f2}");
        Console.WriteLine($"Bus: {vehicles.OfType<Bus>().Sum(c => c.FuelQuantity):f2}");


    }

    private static void VehicleRead(out double fuel, out double consumption, out double capacity, out string type)
    {
        string[] input = Console.ReadLine().Split();
        fuel = double.Parse(input[1]);
        consumption = double.Parse(input[2]);
        capacity = double.Parse(input[3]);
        type = input[0];
    }



    private static void ProcessCommand(List<Vehicle> vehicles)
    {
        string[] commandTokens = Console.ReadLine().Split();
        string command = commandTokens[0];
        string vehicleType = commandTokens[1];
        double value = double.Parse(commandTokens[2]);

        IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

        if (vehicleType == null)
        {
            throw new ArgumentException("Invalid vehicle type");
        }

        if (command == "Drive")
        {
            double distance = value;
            Console.WriteLine(vehicle.Drive(distance));
        }
        if (command == "DriveEmpty")
        {
            double distance = value;
            Console.WriteLine(vehicle.DriveEmpty(distance));

        }
        if (command == "Refuel")
        {
            double fuelAmount = value;
            vehicle.Refuel(fuelAmount);
        }

    }


}

