
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlRoot("Properties")]
    public class PropertiesExportXmlDto
    {
        [XmlElement("Property")]
        public List<PropertyExportXmlDto> Properties { get; set; }
    }
}