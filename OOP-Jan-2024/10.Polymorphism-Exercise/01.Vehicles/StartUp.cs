/*
Car 15 0.3
Truck 100 0.9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10

Car 30.4 0.4
Truck 99.34 0.9
5
Drive Car 500
Drive Car 13.5
Refuel Truck 10.300
Drive Truck 56.2
Refuel Car 100.2

*/


using Vehicles.Models;
using Vehicles.Models.Interface;

namespace Vehicles;
public class StartUp
{
    static void Main(string[] args)
    {

        string[] input = Console.ReadLine().Split();
        double fuel = double.Parse(input[1]);
        double consumption = double.Parse(input[2]);

        IVehicle car = new Car(fuel, consumption);

        string[] input2 = Console.ReadLine().Split();
        fuel = double.Parse(input2[1]);
        consumption = double.Parse(input2[2]);

        IVehicle truck = new Truck(fuel, consumption);

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
            else if (action == "Refuel" && vehicle == "Car")
            {
                car.Refuel(value);
            }
            else if (action == "Refuel" && vehicle == "Truck")
            {
                truck.Refuel(value);
            }
        }
        Console.WriteLine(car);
        Console.WriteLine(truck);

    }
}

