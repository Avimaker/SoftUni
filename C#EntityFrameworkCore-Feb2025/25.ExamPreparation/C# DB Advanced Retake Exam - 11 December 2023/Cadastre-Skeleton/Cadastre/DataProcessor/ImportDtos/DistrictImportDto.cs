using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class DistrictImportDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; }

        [XmlElement("PostalCode")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        [MaxLength(8)]
        public string PostalCode { get; set; }

        [XmlAttribute("Region")]
        [Required]
        public string Region { get; set; }

        [XmlArray("Properties")]
        [XmlArrayItem("Property")]
        public List<PropertyImportDto> Properties { get; set; }
    }
}