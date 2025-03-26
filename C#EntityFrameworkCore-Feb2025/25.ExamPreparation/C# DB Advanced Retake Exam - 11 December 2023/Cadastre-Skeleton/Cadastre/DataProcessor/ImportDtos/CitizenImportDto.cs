using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class CitizenImportDto
    {
        [JsonPropertyName("FirstName")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [JsonPropertyName("BirthDate")]
        [Required]
        public string BirthDate { get; set; }

        [JsonPropertyName("MaritalStatus")]
        [Required]
        [RegularExpression(@"^(Unmarried|Married|Divorced|Widowed)$")]
        public string MaritalStatus { get; set; }

        [JsonPropertyName("Properties")]
        public List<int> Properties { get; set; }
    }
}