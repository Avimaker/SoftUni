using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.Migrate();
            //Console.WriteLine("Database migrated successful");

            //// Problem 09
            //string jsonString = File.ReadAllText("../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 10
            //string jsonString = File.ReadAllText("../../../Datasets/parts.json");
            //string result = ImportParts(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 11
            //string jsonString = File.ReadAllText("../../../Datasets/cars.json");
            //string result = ImportCars(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 12
            //string jsonString = File.ReadAllText("../../../Datasets/customers.json");
            //string result = ImportCustomers(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 13
            //string jsonString = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSales(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 14 Export
            //string result = GetOrderedCustomers(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/GetOrderedCustomers.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            //// Problem 15 Export
            //string result = GetCarsFromMakeToyota(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/GetCarsFromMakeToyota.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            //// Problem 16 Export
            //string result = GetLocalSuppliers(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/GetLocalSuppliers.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            //// Problem 17 Export
            //string result = GetCarsWithTheirListOfParts(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/GetCarsWithTheirListOfParts.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            // Problem 18 Export
            string result = GetTotalSalesByCustomer(dbContext);
            Console.WriteLine(result);
            // записваме файл с резултата в папка Results
            const string outputFilePath = "../../../Results/GetTotalSalesByCustomer.json";
            File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            //// Problem 19 Export
            //string result = GetSalesWithAppliedDiscount(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/GetSalesWithAppliedDiscount.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

        }

        ////Problem 09
        //public static string ImportSuppliersDS(CarDealerContext context, string inputJson)
        //{
        //    var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
        //    context.Suppliers.AddRange(suppliers);
        //    context.SaveChanges();
        //    return $"Successfully imported {suppliers.Count}.";
        //}

        //Problem 09 ET
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportSuppliersDto[]? importSuppliersDtos = JsonConvert
                .DeserializeObject<ImportSuppliersDto[]>(inputJson);

            if (importSuppliersDtos != null)
            {
                ICollection<Supplier> validSuppliers = new List<Supplier>();

                foreach (ImportSuppliersDto importSuppliersDto in importSuppliersDtos)
                {
                    if (!IsValid(importSuppliersDto))
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = importSuppliersDto.Name,
                        IsImporter = importSuppliersDto.IsImporter
                    };

                    validSuppliers.Add(supplier);
                }

                context.Suppliers.AddRange(validSuppliers);
                context.SaveChanges();

                result = $"Successfully imported {validSuppliers.Count}.";
            }

            return result;
        }


        // Problem 10
        public static string ImportPartsDS(CarDealerContext context, string inputJson)
        {
            // Десериализация на JSON данните
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            // Събиране на всички уникални supplierId от частите
            var supplierIds = parts
                .Select(p => p.SupplierId)
                .Distinct()
                .ToList();

            // Проверка кои supplierId съществуват в базата
            var validSupplierIds = context.Suppliers
                .Where(s => supplierIds.Contains(s.Id))
                .Select(s => s.Id)
                .ToHashSet();

            // Филтриране само на части с валидни доставчици
            var validParts = parts
                .Where(p => validSupplierIds.Contains(p.SupplierId))
                .ToList();

            // Записване в базата
            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }


        // Problem 10 ET
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ImportPartsDto[]? importPartsDtos = JsonConvert
                .DeserializeObject<ImportPartsDto[]>(inputJson) ?? new ImportPartsDto[0];

            if (importPartsDtos != null)
            {
                ICollection<Part> validParts = new List<Part>();

                foreach (ImportPartsDto importPartsDto in importPartsDtos)
                {

                    if (!IsValid(importPartsDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal
                        .TryParse(importPartsDto.Price, out decimal price);
                    bool isQuantityValid = int
                        .TryParse(importPartsDto.Quantity, out int quantity);
                    bool isSupplierIdValid = int
                        .TryParse(importPartsDto.SupplierId, out int supplierId);

                    if ((!isPriceValid) || (!isQuantityValid) || (!isSupplierIdValid))
                    {
                        continue;
                    }

                    // Проверка дали доставчикът съществува
                    if (!context.Suppliers.Any(s => s.Id == supplierId))
                    {
                        continue;
                    }


                    Part part = new Part()
                    {
                        Name = importPartsDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId
                    };

                    validParts.Add(part);
                }
                context.Parts.AddRange(validParts);
                context.SaveChanges();

                result = $"Successfully imported {validParts.Count}.";
            }

            return result;
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            // Десериализиране на JSON данни
            var carDtos = JsonConvert.DeserializeObject<List<ImportCarsDto>>(inputJson);

            // Събиране на всички уникални Part ID от всички коли
            var allPartIds = carDtos
                .SelectMany(c => c.PartsId)
                .Distinct()
                .ToList();

            // Проверка кои Part ID съществуват в базата
            var validPartIds = context.Parts
                .Where(p => allPartIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToHashSet();

            var cars = new List<Car>();
            foreach (var dto in carDtos)
            {
                var car = new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,
                    PartsCars = new HashSet<PartCar>()
                };

                // Добавяме само валидни части и премахваме дубликати
                foreach (var partId in dto.PartsId
                    .Distinct()
                    .Where(id => validPartIds.Contains(id)))
                {
                    car.PartsCars.Add(new PartCar { PartId = partId });
                }

                cars.Add(car);
            }

            // Добавяне и записване
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}.";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var saleDtos = JsonConvert.DeserializeObject<List<importSalesDto>>(inputJson);

            var sales = saleDtos.Select(s => new Sale
            {
                CarId = s.CarId,
                CustomerId = s.CustomerId,
                Discount = s.Discount / 100m // Конвертиране от процент към десетична дроб
            }).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }


        // Problem 14 export
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 15 export
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 16 export
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 17 export
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            pc.Part.Name,
                            Price = pc.Part.Price.ToString("0.00")
                        })
                        .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 18 export
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            // Retrieve customers with their sales and related data
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    c.Name,
                    Sales = c.Sales.Select(s => new
                    {
                        s.Discount,
                        CarPartsSum = s.Car.PartsCars.Sum(pc => pc.Part.Price)
                    }).ToList()
                })
                .ToList() // Bring data into memory
                .Select(c => new
                {
                    fullName = " " + c.Name, // Add a space before the name
                    boughtCars = c.Sales.Count,
                    spentMoney = Math.Round(c.Sales.Sum(s => s.CarPartsSum * (1 - s.Discount / 100m)), 2) // Round to 2 decimal places
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }



        // Problem 19 export
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    Car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    s.Customer.Name,
                    s.Discount,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount)
                })
                .ToList()
                .Select(s => new
                {
                    car = s.Car,
                    customerName = s.Name,
                    discount = $"{s.Discount * 100:F2}",
                    price = $"{s.Price:F2}",
                    priceWithDiscount = $"{s.PriceWithDiscount:F2}"
                })
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }


        // helper method IsValid
        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }

    }
}