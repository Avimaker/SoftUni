using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(13)]
        [RegularExpression(@"^\+\d{12}$", ErrorMessage = "Phone number must be in the format +XXXXXXXXXXXX")]
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

