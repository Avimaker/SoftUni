
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NetPay.DataProcessor.ImportDtos
{
	public class ImportExpenseDto
	{
        [Required]
        [JsonProperty(nameof(ExpenseName))]
        [StringLength(50, MinimumLength = 5)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Amount))]
        [Range(0.01, 100000)]
        public decimal Amount { get; set; }

        [Required]
        [JsonProperty(nameof(DueDate))]
        public string DueDate { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(PaymentStatus))]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(HouseholdId))]
        public int HouseholdId { get; set; }

        [Required]
        [JsonProperty(nameof(ServiceId))]
        public int ServiceId { get; set; }
    }
}

