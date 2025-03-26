namespace Trucks.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        //xml
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                        .OrderBy(t => t.RegistrationNumber)
                        .Select(t => new ExportTruckDto
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            var xml = XmlHelper.Serialize(despatchers, "Despatchers");
            return xml;
        }

        //json
        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber,
                            TankCapacity = ct.Truck.TankCapacity,
                            CargoCapacity = ct.Truck.CargoCapacity,
                            CategoryType = (int)ct.Truck.CategoryType,
                            MakeType = (int)ct.Truck.MakeType
                        })
                        .ToList()
                })
                .AsEnumerable() // Switch to client evaluation
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.Trucks
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .Select(t => new
                        {
                            t.TruckRegistrationNumber,
                            t.VinNumber,
                            t.TankCapacity,
                            t.CargoCapacity,
                            CategoryType = ((CategoryType)t.CategoryType).ToString(),
                            MakeType = ((MakeType)t.MakeType).ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.Trucks.Count)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
