using System.Text.Json.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class PropertyExportDto
    {
        [JsonPropertyName("PropertyIdentifier")]
        public string PropertyIdentifier { get; set; }

        [JsonPropertyName("Area")]
        public int Area { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("DateOfAcquisition")]
        public string DateOfAcquisition { get; set; }

        [JsonPropertyName("Owners")]
        public List<OwnerExportDto> Owners { get; set; }
    }
}