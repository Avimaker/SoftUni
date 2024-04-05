using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> GetAll() => vehicles.AsReadOnly();

        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            return vehicles.Remove(vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier));
        }

        public IVehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);
        }

    }
}

