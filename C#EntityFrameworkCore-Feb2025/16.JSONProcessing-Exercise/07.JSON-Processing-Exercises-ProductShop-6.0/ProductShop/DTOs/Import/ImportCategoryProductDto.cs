using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
	public class ImportCategoryProductDto
	{
		[Required]
		[JsonProperty(nameof(CategoryId))]
		public string CategoryId { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(ProductId))]
        public string ProductId { get; set; } = null!;

    }
}

