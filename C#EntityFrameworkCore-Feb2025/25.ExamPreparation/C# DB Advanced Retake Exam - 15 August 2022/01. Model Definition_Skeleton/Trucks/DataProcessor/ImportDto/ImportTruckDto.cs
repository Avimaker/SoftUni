using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        [StringLength(8)]
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17)]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; }

        [Range(950, 1420)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [Range(5000, 29000)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}