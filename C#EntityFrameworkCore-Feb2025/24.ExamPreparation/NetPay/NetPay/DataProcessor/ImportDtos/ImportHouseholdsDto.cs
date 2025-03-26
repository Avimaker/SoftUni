
using NetPay.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class ImportHouseholdsDto
	{

        [Required]
        [XmlElement("ContactPerson")]
        [StringLength(50, MinimumLength = 5)]
        public string ContactPerson { get; set; } = null!;

        [XmlElement("Email")]
        [StringLength(80, MinimumLength = 6)]
        public string? Email { get; set; }

        [Required]
        [XmlAttribute("phone")]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        
    }
}

