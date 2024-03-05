using Vehicles.Models;

namespace Vehicles.Factories
{
	public class VehicleFactory
	{

		public Vehicle VehicleCreate(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
		{
			return type switch
			{
				"Car" => new Car(fuelQuantity, fuelConsumption, tankCapacity),
				"Truck" => new Truck(fuelQuantity, fuelConsumption, tankCapacity),
				"Bus" => new Bus(fuelQuantity, fuelConsumption, tankCapacity),
				_ => throw new ArgumentException("Invalid vehicle type")
			};

		}

	}
}

