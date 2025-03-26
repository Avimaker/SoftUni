using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class HouseholdDto
    {
        [XmlElement("ContactPerson")]
        public string ContactPerson { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlAttribute("phone")]
        public string Phone { get; set; }
    }
}

