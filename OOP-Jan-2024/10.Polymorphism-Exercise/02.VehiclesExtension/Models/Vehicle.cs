using System;
using Vehicles.Models.Interface;

namespace Vehicles.Models;

public abstract class Vehicle : IDrive, IRefuel, IVehicle
{

    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;
    private double increasedConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increasedConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        TankCapacity = tankCapacity;
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

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        private set
        {
            if (this.FuelQuantity > value)
            {
                FuelQuantity = 0;
            }
            this.tankCapacity = value;
        }
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

    public virtual string DriveEmpty(double distance)
    {

        if (FuelQuantity < distance * FuelConsumption)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        FuelQuantity -= FuelConsumption * distance;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amountLiters)
    {
        if (amountLiters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (amountLiters + FuelQuantity > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amountLiters} fuel in the tank");
        }

        if (GetType().Name == "Truck")
        {
            amountLiters *= 0.95;
        }

        FuelQuantity += amountLiters;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}

