
using System.Xml.Serialization;
using NetPay.DataProcessor.ImportDtos;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlRoot("Households")]
    public class HouseholdsDto
    {
        [XmlElement("Household")]
        public HouseholdDto[] Households { get; set; }
    }
}

