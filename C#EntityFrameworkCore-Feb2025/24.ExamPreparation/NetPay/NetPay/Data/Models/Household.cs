using System;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models
{
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
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$", ErrorMessage = "Invalid phone number format.")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}

