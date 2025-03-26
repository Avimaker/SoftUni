namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        //xml
        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();
            var districtsDto = XmlHelper.Deserialize<List<DistrictImportDto>>(xmlDocument, "Districts");

            var existingDistrictNames = dbContext.Districts
                .Select(d => d.Name)
                .ToHashSet();

            var existingPostalCodes = dbContext.Districts
                .Select(d => d.PostalCode)
                .ToHashSet();

            var existingPropertyIdentifiers = dbContext.Properties
                .Select(p => p.PropertyIdentifier)
                .ToHashSet();

            var existingPropertyAddresses = dbContext.Properties
                .Select(p => p.Address)
                .ToHashSet();

            foreach (var districtDto in districtsDto)
            {
                if (!IsValidDistrict(districtDto))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                if (existingDistrictNames.Contains(districtDto.Name))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                if (existingPostalCodes.Contains(districtDto.PostalCode))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                if (!Enum.TryParse(districtDto.Region, out Region region))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                var district = new District
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = region,
                    Properties = new List<Property>()
                };

                int validPropertiesCount = 0;

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValidProperty(propertyDto))
                    {
                        sb.AppendLine("Invalid Data!");
                        continue;
                    }

                    if (!DateTime.TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfAcquisition))
                    {
                        sb.AppendLine("Invalid Data!");
                        continue;
                    }

                    if (existingPropertyIdentifiers.Contains(propertyDto.PropertyIdentifier))
                    {
                        sb.AppendLine("Invalid Data!");
                        continue;
                    }

                    if (existingPropertyAddresses.Contains(propertyDto.Address))
                    {
                        sb.AppendLine("Invalid Data!");
                        continue;
                    }

                    var property = new Property
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = dateOfAcquisition
                    };

                    district.Properties.Add(property);
                    existingPropertyIdentifiers.Add(property.PropertyIdentifier);
                    existingPropertyAddresses.Add(property.Address);
                    validPropertiesCount++;
                }

                dbContext.Districts.Add(district);
                existingDistrictNames.Add(district.Name);
                existingPostalCodes.Add(district.PostalCode);
                dbContext.SaveChanges();

                sb.AppendLine($"Successfully imported district - {district.Name} with {validPropertiesCount} properties.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValidDistrict(DistrictImportDto districtDto)
        {
            var validationContext = new ValidationContext(districtDto);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(districtDto, validationContext, validationResults, true);
        }

        private static bool IsValidProperty(PropertyImportDto propertyDto)
        {
            var validationContext = new ValidationContext(propertyDto);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(propertyDto, validationContext, validationResults, true);
        }

        //json
        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder sb = new StringBuilder();
            var citizensDto = JsonConvert.DeserializeObject<List<CitizenImportDto>>(jsonDocument);

            var existingPropertyIds = dbContext.Properties
                .Select(p => p.Id)
                .ToHashSet();

            foreach (var citizenDto in citizensDto)
            {
                if (!IsValidCitizen(citizenDto))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                if (!DateTime.TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                if (!Enum.TryParse(citizenDto.MaritalStatus, out MaritalStatus maritalStatus))
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                var citizen = new Citizen
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = maritalStatus,
                    PropertiesCitizens = new List<PropertyCitizen>()
                };

                int validPropertiesCount = 0;

                foreach (var propertyId in citizenDto.Properties)
                {
                    if (!existingPropertyIds.Contains(propertyId))
                    {
                        sb.AppendLine("Invalid Data!");
                        continue;
                    }

                    citizen.PropertiesCitizens.Add(new PropertyCitizen
                    {
                        PropertyId = propertyId,
                        CitizenId = citizen.Id
                    });

                    validPropertiesCount++;
                }

                dbContext.Citizens.Add(citizen);
                dbContext.SaveChanges();

                sb.AppendLine($"Succefully imported citizen - {citizen.FirstName} {citizen.LastName} with {validPropertiesCount} properties.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValidCitizen(CitizenImportDto citizenDto)
        {
            var validationContext = new ValidationContext(citizenDto);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(citizenDto, validationContext, validationResults, true);
        }

        //helper method
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
