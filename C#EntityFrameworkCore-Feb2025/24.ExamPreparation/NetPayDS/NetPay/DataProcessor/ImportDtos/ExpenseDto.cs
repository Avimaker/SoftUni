using Newtonsoft.Json;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ExpenseDto
    {
        [JsonProperty("ExpenseName")]
        public string ExpenseName { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("PaymentStatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty("HouseholdId")]
        public int HouseholdId { get; set; }

        [JsonProperty("ServiceId")]
        public int ServiceId { get; set; }
    }
}

