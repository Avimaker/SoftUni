namespace NetPay.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ContactPerson { get; set; }

        [StringLength(80, MinimumLength = 6)]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        public string PhoneNumber { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}

