/*
2
AudiA4 23 0.3
BMW-M2 45 0.42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End

*/

using System;
namespace SpeedRacing
{
    public class StartUp
    {

        static void Main()
        {
            Dictionary<string, Car> cars = new();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                if (!cars.Keys.Contains(model))
                {
                    cars.Add(model, new Car());
                }

                cars[model].FuelAmount += fuelAmount;
                cars[model].FuelConsumptionPerKilometer += fuelConsumptionFor1km;
            }

            string command = default;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();

                if (arguments[0] == "Drive")
                {
                    string carModel = arguments[1];
                    double distance = double.Parse(arguments[2]);

                    Car car = cars[carModel];

                    car.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }

        }

    }
}

