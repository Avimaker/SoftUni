using System.Text.Json.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class OwnerExportDto
    {
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("MaritalStatus")]
        public string MaritalStatus { get; set; }
    }
}