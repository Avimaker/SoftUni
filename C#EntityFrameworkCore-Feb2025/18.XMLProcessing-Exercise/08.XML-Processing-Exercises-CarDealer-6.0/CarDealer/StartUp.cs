using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
            dbContext.Database.Migrate();
            Console.WriteLine("db migrated to the last version successfuly!");

            ////Query 9. Import Suppliers
            //const string xmlFilePath = "../../../Datasets/suppliers.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportSuppliers(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 10. Import Parts
            //const string xmlFilePath = "../../../Datasets/parts.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportParts(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 11. Import Cars
            //const string xmlFilePath = "../../../Datasets/cars.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportCars(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 12. Import Customers
            //const string xmlFilePath = "../../../Datasets/customers.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportCustomers(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 13. Import Sales
            //const string xmlFilePath = "../../../Datasets/sales.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportSales(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 14.Export Cars With Distance
            //string result = GetCarsWithDistance(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/GetCarsWithDistance.xml";
            //File.WriteAllText(xmlFilePath, result);

            ////Query 15. Export Cars from Make BMW
            //string result = GetCarsFromMakeBmw(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/GetCarsFromMakeBmw.xml";
            //File.WriteAllText(xmlFilePath, result);

            ////Query 16. Export Local Suppliers
            //string result = GetLocalSuppliers(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/GetLocalSuppliers.xml";
            //File.WriteAllText(xmlFilePath, result);

            ////Query 17. Export Cars with Their List of Parts
            //string result = GetCarsWithTheirListOfParts(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/GetCarsWithTheirListOfParts.xml";
            //File.WriteAllText(xmlFilePath, result);

            //Query 18. Export Total Sales by Customer
            string result = GetTotalSalesByCustomer(dbContext);
            Console.WriteLine(result);
            const string xmlFilePath = "../../../Results/GetTotalSalesByCustomer.xml";
            File.WriteAllText(xmlFilePath, result);


        }


        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            //use dto that already create plus root name + XmlHelper
            ImportSupplierDto[]? supplierDtos = XmlHelper
                .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            if (supplierDtos != null)
            {
                ICollection<Supplier> validSuppliers = new List<Supplier>();
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    bool isImporterValid = bool
                        .TryParse(supplierDto.isImporter, out bool isImporter);

                    if (!isImporterValid)
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.name,
                        IsImporter = isImporter
                    };

                    validSuppliers.Add(supplier);
                }

                context.Suppliers.AddRange(validSuppliers);
                context.SaveChanges();

                result = $"Successfully imported {validSuppliers.Count}";
            }

            return result;
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            //use dto that already create plus root name + XmlHelper
            ImportPartDto[]? partDtos = XmlHelper
                .Deserialize<ImportPartDto[]>(inputXml, "Parts");

            if (partDtos != null) //use for foreach
            {
                //If the supplierId doesn't exist, skip the record.
                ICollection<int> dbSupplierIds = context
                    .Suppliers
                    .Select(s => s.Id)
                    .ToArray();

                ICollection<Part> validParts = new List<Part>();

                foreach (ImportPartDto partDto in partDtos)
                {
                    //first check if the dto isValid
                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    //if it is valid we have to check parse props from dto
                    bool isPriceValid = decimal
                        .TryParse(partDto.Price, out decimal price);
                    bool isQuantityValid = int
                        .TryParse(partDto.Quantity, out int quantity);
                    bool isSupplierValid = int
                        .TryParse(partDto.SupplierId, out int supplierId);
                    //check if some of them are invalid we have to skip
                    if ((!isPriceValid) || (!isQuantityValid) || (!isSupplierValid))
                    {
                        //invalid values for price, quantity or supplier
                        continue;
                    }

                    // if they are valid and are parsed we have to check is there valid supplier in db to add to him
                    if (!dbSupplierIds.Contains(supplierId))
                    {
                        // Non-existing supplierId which would violate teh FK Contraint
                        continue;
                    }

                    // ако сме минали всички проверки успешно трябва да направим инстанция на частта която ще съдържа валидната информация
                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId
                    };

                    //добавяме я към колекцията от валидните части
                    validParts.Add(part);
                }

                //след форича в контекста през диби сета за частите трябва да добавя новите валидни части чрез ад реиндж.
                context.Parts.AddRange(validParts);

                // тригерирам запазване на промени
                context.SaveChanges();

                //ако всичко мине ок запазваме в резултат
                result = $"Successfully imported {validParts.Count}";

            }

            return result;
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            //use dto that already create plus root name + XmlHelper
            ImportCarDto[]? carDtos = XmlHelper
                .Deserialize<ImportCarDto[]>(inputXml, "Cars");
            if (carDtos != null)
            {
                ICollection<int> dbPartsId = context
                    .Parts
                    .Select(p => p.Id)
                    .ToArray();

                ICollection<Car> validCars = new List<Car>();
                //ICollection<PartCar> validPartCars = new List<PartCar>();//to be removed
                foreach (ImportCarDto carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isTraveledDistanceValid = long
                        .TryParse(carDto.TraveledDistance, out long traveledDistance);
                    if (!isTraveledDistanceValid)
                    {
                        continue;
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistance
                    };

                    if (carDto.Parts != null)
                    {
                        int[] partIds = carDto
                            .Parts
                            .Where(p => IsValid(p) && int.TryParse(p.Id, out int dummy))
                            .Select(p => int.Parse(p.Id))
                            .Distinct()
                            .ToArray();

                        foreach (int partId in partIds)
                        {
                            if (!dbPartsId.Contains(partId))
                            {
                                continue;
                            }

                            PartCar partCar = new PartCar()
                            {
                                PartId = partId,
                                Car = car
                            };

                            //validPartCars.Add(partCar);//validPartCars
                            car.PartsCars.Add(partCar);

                        }
                    }
                    validCars.Add(car);
                }

                context.Cars.AddRange(validCars);
                //context.PartsCars.AddRange(validPartCars);
                context.SaveChanges();

                //result = $"Successfully imported {validPartCars.Count}";
                result = $"Successfully imported {validCars.Count}";
            }

            return result;
        }

        //Query 11. Import CarsDS
        public static string ImportCarsDS(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            ImportCarDto[] carDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                carDtos = (ImportCarDto[])serializer.Deserialize(reader);
            }

            // Извличаме всички уникални PartId от XML данните
            var uniquePartIds = carDtos
                .SelectMany(c => c.Parts.Select(p => p.Id))
                .Distinct()
                .ToArray();

            // Проверяваме кои PartId съществуват в базата данни
            var existingPartIds = context.Parts
                .Where(p => uniquePartIds.Contains(p.Id.ToString()))
                .Select(p => p.Id.ToString())
                .ToArray();

            var cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = long.Parse(carDto.TraveledDistance), // Парсване на string към long
                    PartsCars = carDto.Parts
                        .Where(p => existingPartIds.Contains(p.Id))
                        .GroupBy(p => p.Id) // Групираме по PartId, за да избегнем дублиране
                        .Select(g => new PartCar
                        {
                            PartId = int.Parse(g.Key) // Парсване на string към int
                        })
                        .ToList()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCustomerDto[]? customerDtos = XmlHelper
                .Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
            if (customerDtos != null)
            {
                ICollection<Customer> validCustomers = new List<Customer>();
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isBirthDateValid = DateTime
                        .TryParse(customerDto.BirthDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);

                    //bool isBirthDateValid = DateTime
                    //    .TryParseExact(customerDto.BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);

                    if (!isBirthDateValid)
                    {
                        continue;
                    }

                    bool isYoungDriverValid = bool
                        .TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);

                    if (!isYoungDriverValid)
                    {
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    validCustomers.Add(customer);
                }

                context.Customers.AddRange(validCustomers);
                context.SaveChanges();

                result = $"Successfully imported {validCustomers.Count}";
            }

            return result;
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportSaleDto[]? saleDtos = XmlHelper
                .Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            if (saleDtos != null)
            {
                ICollection<int> dbCarIds = context
                    .Cars
                    .Select(c => c.Id)
                    .ToArray();

                ICollection<Sale> validSales = new List<Sale>();

                foreach (ImportSaleDto saleDto in saleDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    bool isCustomerIdValid = int.
                        TryParse(saleDto.CustomerId, out int customerId);

                    bool isCarIdValid = int.
                        TryParse(saleDto.CarId, out int carId);

                    bool isDiscountValid = decimal
                        .TryParse(saleDto.Discount, out decimal discount);

                    if ((!isCustomerIdValid) || (!isCarIdValid) || (!isDiscountValid))
                    {
                        continue;
                    }

                    if (!dbCarIds.Contains(carId))
                    {
                        continue;
                    }

                    Sale sale = new Sale()
                    {
                        CarId = carId,
                        CustomerId = customerId,
                        Discount = discount
                    };

                    validSales.Add(sale);
                }

                context.Sales.AddRange(validSales);
                context.SaveChanges();

                result = $"Successfully imported {validSales.Count}";

            }
            return result;
        }

        //EXPORTS

        //Query 14.Export Cars With Distance DS
        public static string GetCarsWithDistanceDS(CarDealerContext context)
        {
            // Извличане на автомобилите с пробег над 2,000,000 км
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsOverDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            // Сериализация на данните в XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsOverDistanceDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); // Премахване на namespaces

            StringBuilder xmlOutput = new StringBuilder();
            using (StringWriter writer = new StringWriter(xmlOutput))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return xmlOutput.ToString();
        }

        //Query 14.Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsOverDistanceDto[] cars = context
                .Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new ExportCarsOverDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            string result = XmlHelper
                .Serialize(cars, "cars");
            return result;
        }

        //Query 15. Export Cars from Make BMW (DS)
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            // Извличане на автомобилите на марката BMW
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportBmwCarDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            // Сериализация на данните в XML
            //XmlSerializer serializer = new XmlSerializer(typeof(ExportBmwCarDto[]), new XmlRootAttribute("cars"));
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty); // Премахване на namespaces

            //StringBuilder xmlOutput = new StringBuilder();
            //using (StringWriter writer = new StringWriter(xmlOutput))
            //{
            //    serializer.Serialize(writer, bmwCars, namespaces);
            //}

            //return xmlOutput.ToString();

            string result = XmlHelper
                .Serialize(bmwCars, "cars");
            return result;
        }

        //Query 16. Export Local Suppliers (DS)
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            // Извличане на локалните доставчици и броя на частите, които предлагат
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter) // Филтрираме доставчиците, които не внасят части
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count // Броят на частите, които доставчикът предлага
                })
                .ToArray();

            string result = XmlHelper
                .Serialize(localSuppliers, "suppliers");
            return result;

        }

        //Query 17. Export Cars with Their List of Parts (DS)
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            // Извличане на автомобилите и техните части
            var carsWithParts = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c
                        .PartsCars
                        .Select(pc => new ExportPartDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            // Сериализация на данните в XML
            string result = XmlHelper
                .Serialize(carsWithParts, "cars");
            return result;
        }

        //Query 18. Export Total Sales by Customer (DS)
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            // Извличане на клиентите и техните продажби
            var customersWithSales = context.Customers
                .Where(c => c.Sales.Any()) // Филтрираме клиентите, които са купили поне една кола
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    Sales = c.Sales.Select(s => new
                    {
                        CarPartsTotal = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                        Discount = s.Discount
                    }).ToList()
                })
                .ToList() // Извличаме данните в паметта
                .Select(c => new ExportCustomerSalesDto
                {
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = Math.Round(c.Sales.Sum(s => s.CarPartsTotal * (1 - (s.Discount / 100))), 2) // Закръгляне до 2 знака
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            // Сериализация на данните в XML
            string result = XmlHelper
                .Serialize(customersWithSales, "customers");

            result.ToString()
                .Replace("  ", "") // Премахване на двойни интервали
                .Replace("\r\n", "") // Премахване на нови редове
                .Replace("\n", ""); // Премахване на нови редове

            return result;
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