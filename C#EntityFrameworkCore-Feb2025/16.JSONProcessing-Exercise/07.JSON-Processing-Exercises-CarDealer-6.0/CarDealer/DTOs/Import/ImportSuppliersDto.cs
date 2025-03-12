using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
	public class ImportSuppliersDto
	{

		[Required]
		[JsonProperty("name")]
		public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("isImporter")]
		public bool IsImporter { get; set; }

    }
}

