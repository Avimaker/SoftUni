using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.DTOs.Import
{
	public class ImportPartsDto
	{
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("quantity")]
        public string? Quantity { get; set; }

        [Required]
        [JsonProperty("supplierId")]
        public string SupplierId { get; set; } = null!;
    }
}

