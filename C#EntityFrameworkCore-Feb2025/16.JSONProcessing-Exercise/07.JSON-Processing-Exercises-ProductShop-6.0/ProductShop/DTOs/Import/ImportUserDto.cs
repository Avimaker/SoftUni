using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
	public class ImportUserDto
    {

        [JsonProperty("firstName")] //ако е кръстено идиотски
        public string? firstName { get; set; } //може да бъде null

        [Required]
        [JsonProperty(nameof(lastName))]
        public string lastName { get; set; } = null!;

        [JsonProperty("age")]
        public string? age { get; set; }


    }
}

