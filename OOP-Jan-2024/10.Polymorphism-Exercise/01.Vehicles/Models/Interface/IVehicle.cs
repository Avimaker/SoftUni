using System;
namespace Vehicles.Models.Interface
{
    public interface IVehicle : IDrive, IRefuel
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
    }
}

