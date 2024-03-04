using System;
namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, IncreasedConsumption)
        {
        }

        public override void Refuel(double amountLiters)
        {
            base.Refuel(amountLiters * 0.95);
        }
    }
}

