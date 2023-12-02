/*
3
Audi A6|38000|62
Mercedes CLS|11000|35
Volkswagen Passat CC|45678|5
Drive : Audi A6 : 543 : 47
Drive : Mercedes CLS : 94 : 11
Drive : Volkswagen Passat CC : 69 : 8
Refuel : Audi A6 : 50
Revert : Mercedes CLS : 500
Revert : Audi A6 : 30000
Stop

4
Lamborghini Veneno|11111|74
Bugatti Veyron|12345|67
Koenigsegg CCXR|67890|12
Aston Martin Valkryie|99900|50
Drive : Koenigsegg CCXR : 382 : 82
Drive : Aston Martin Valkryie : 99 : 23
Drive : Aston Martin Valkryie : 2 : 1
Refuel : Lamborghini Veneno : 40
Revert : Bugatti Veyron : 2000
Stop

 
*/


namespace _08.NeedForSpeedIII;

class Car
{
    public string Name { get; set; }
    public int Milage { get; set; }
    public int Fuel { get; set; }
}

class Program
{
    static void Main()
    {

        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] carInfo = Console.ReadLine().Split("|");

            string name = carInfo[0];
            int milage = int.Parse(carInfo[1]);
            int fuel = int.Parse(carInfo[2]);

            Car currentCar = new Car
            {
                Name = name,
                Fuel = fuel,
                Milage = milage,
            };

            cars.Add(name, currentCar);
        }

        string command = default;
        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] arguments = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            switch (arguments[0])
            {
                case "Drive":


                    string name = arguments[1];
                    int distance = int.Parse(arguments[2]);
                    int fuel = int.Parse(arguments[3]);

                    Car car = cars[name]; // така е по лесно спрямо по-долу както съм писал

                    if (car.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        car.Fuel -= fuel;
                        car.Milage += distance;
                    }
                    if (car.Milage >= 100_000)
                    {
                        Console.WriteLine($"Time to sell the {name}!");
                        cars.Remove(name);
                    }

                    break;

                case "Refuel":

                    name = arguments[1];
                    fuel = int.Parse(arguments[2]);

                    int tank = 75;
                    int currentFuel = cars[name].Fuel;

                    if ((currentFuel + fuel) <= tank)
                    {
                        Console.WriteLine($"{name} refueled with {fuel} liters");
                        cars[name].Fuel = currentFuel + fuel;
                    }

                    if ((currentFuel + fuel) > tank)
                    {
                        int fill = ((currentFuel + fuel) - tank);
                        int refil = fuel - fill;
                        Console.WriteLine($"{name} refueled with {refil} liters");
                        cars[name].Fuel = 75;
                    }
                    break;

                case "Revert":

                    name = arguments[1];
                    distance = int.Parse(arguments[2]);

                    cars[name].Milage -= distance;

                    if (cars[name].Milage < 10_000)
                    {
                        cars[name].Milage = 10_000;
                    }
                    else
                    {
                        Console.WriteLine($"{cars[name].Name} mileage decreased by {distance} kilometers");

                    }

                    break;
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Value.Name} -> Mileage: {car.Value.Milage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
        }
    }
}

