namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        //импорт xml
        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            string result = string.Empty;

            StringBuilder sb = new StringBuilder();

            ImportDespatcherDto[]? despatcherDtos = XmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            List<Despatcher> validDespatchers = new List<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto) || string.IsNullOrEmpty(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var despatcher = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = new List<Truck>()
                };

                int validTrucksCount = 0;

                if (despatcherDto.Trucks != null)
                {
                    foreach (var truckDto in despatcherDto.Trucks)
                    {
                        if (!IsValid(truckDto) ||
                            !Enum.IsDefined(typeof(CategoryType), truckDto.CategoryType) ||
                            !Enum.IsDefined(typeof(MakeType), truckDto.MakeType))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        var truck = new Truck
                        {
                            RegistrationNumber = truckDto.RegistrationNumber,
                            VinNumber = truckDto.VinNumber,
                            TankCapacity = truckDto.TankCapacity,
                            CargoCapacity = truckDto.CargoCapacity,
                            CategoryType = (CategoryType)truckDto.CategoryType,
                            MakeType = (MakeType)truckDto.MakeType,
                            Despatcher = despatcher
                        };

                        despatcher.Trucks.Add(truck);
                        validTrucksCount++;
                    }
                }

                validDespatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, validTrucksCount));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            result = sb.ToString().TrimEnd();

            return result;
        }


        //импорт json
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
            List<Client> validClients = new List<Client>();

            foreach (var clientDto in clientDtos)
            {
                // Validate basic client properties
                if (string.IsNullOrWhiteSpace(clientDto.Name) ||
                    clientDto.Name.Length < 3 || clientDto.Name.Length > 40 ||
                    string.IsNullOrWhiteSpace(clientDto.Nationality) ||
                    clientDto.Nationality.Length < 2 || clientDto.Nationality.Length > 40 ||
                    string.IsNullOrWhiteSpace(clientDto.Type))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Special validation for "usual" type clients
                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Validate other allowed types
                if (!(clientDto.Type == "golden" || clientDto.Type == "platinum" || clientDto.Type == "silver"))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                    ClientsTrucks = new List<ClientTruck>()
                };

                var uniqueTruckIds = clientDto.Trucks?.Distinct().ToList() ?? new List<int>();
                int validTrucksCount = 0;

                foreach (var truckId in uniqueTruckIds)
                {
                    var truck = context.Trucks.Find(truckId);
                    if (truck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck
                    {
                        Client = client,
                        TruckId = truckId
                    });
                    validTrucksCount++;
                }

                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, validTrucksCount));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        // helper method
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}