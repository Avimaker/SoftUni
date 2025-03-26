
using System.Xml.Serialization;
using NetPay.DataProcessor.ImportDtos;

namespace NetPay.DataProcessor.ExportDtos
{
    public class HouseholdDto
    {
        [XmlElement("ContactPerson")]
        public string ContactPerson { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlArray("Expenses")]
        [XmlArrayItem("Expense")]
        public ExpenseDto[] Expenses { get; set; }
    }
}

