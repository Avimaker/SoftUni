using System;
using Vehicles.Models.Interface;

namespace Vehicles.Models;

public abstract class Vehicle : IDrive, IRefuel, IVehicle
{

    private double fuelQuantity;
    private double fuelConsumption;
    private double increasedConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        this.increasedConsumption = increasedConsumption;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        private set { this.fuelQuantity = value; }
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        private set { this.fuelConsumption = value; }
    }

    public virtual string Drive(double distance)
    {
        double consumption = FuelConsumption + increasedConsumption;

        if (FuelQuantity < distance * consumption)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        FuelQuantity -= consumption * distance;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amountLiters)
    {
        FuelQuantity += amountLiters;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}

