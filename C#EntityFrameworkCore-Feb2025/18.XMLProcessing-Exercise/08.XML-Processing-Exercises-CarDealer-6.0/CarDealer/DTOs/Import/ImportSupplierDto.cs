
namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSupplierDto
	{
        // Two type of attributes in DTO:
        // 1. Validation attributes -> define the constrains for validation of deserialized data (only when deserializing)
        // 2. XmlSerializer attributes -> define constraint for XmlSerializer for how to serialize/deserialize the object into Xml
        [Required]
        [XmlElement("name")]
		public string name { get; set; } = null!;

        [Required]
        [XmlElement("isImporter")]
        public string isImporter { get; set; } = null!;

    }
}

