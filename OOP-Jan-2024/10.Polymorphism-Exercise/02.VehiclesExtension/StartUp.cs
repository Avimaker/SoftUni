/*
"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"
Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
8
Refuel ar -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000  


*/


using Vehicles.Models;
using Vehicles.Models.Interface;

namespace Vehicles;
public class StartUp
{
    static void Main(string[] args)
    {
        string check;
        double fuel, consumption, capacity;
        CreateVehicle(out fuel, out consumption, out capacity, out check);
        IVehicle car = new Car(fuel, consumption, capacity);

        CreateVehicle(out fuel, out consumption, out capacity, out check);
        IVehicle truck = new Truck(fuel, consumption, capacity);

        CreateVehicle(out fuel, out consumption, out capacity, out check);
        IVehicle bus = new Bus(fuel, consumption, capacity);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split();
            string action = command[0];
            string vehicle = command[1];
            double value = double.Parse(command[2]);

            if (action == "Drive" && vehicle == "Car")
            {
                try
                {
                    Console.WriteLine(car.Drive(value));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (action == "Drive" && vehicle == "Truck")
            {
                try
                {
                    Console.WriteLine(truck.Drive(value));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (action == "Drive" && vehicle == "Bus")
            {
                try
                {
                    Console.WriteLine(bus.Drive(value));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (action == "DriveEmpty" && vehicle == "Bus")
            {
                try
                {
                    Console.WriteLine(bus.DriveEmpty(value));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (action == "Refuel" && vehicle == "Car")
            {
                try
                {
                    car.Refuel(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else if (action == "Refuel" && vehicle == "Truck")
            {
                try
                {
                    truck.Refuel(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (action == "Refuel" && vehicle == "Bus")
            {
                try
                {
                    bus.Refuel(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid vehicle type");
            }
        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);



    }

    private static void CreateVehicle(out double fuel, out double consumption, out double capacity, out string check)
    {
        string[] input = Console.ReadLine().Split();
        fuel = double.Parse(input[1]);
        consumption = double.Parse(input[2]);
        capacity = double.Parse(input[3]);
        check = input[0];
        if (check != "Car" && check != "Truck" && check != "Bus")
        {
            Console.WriteLine("Invalid vehicle type");
        }
    }
}

