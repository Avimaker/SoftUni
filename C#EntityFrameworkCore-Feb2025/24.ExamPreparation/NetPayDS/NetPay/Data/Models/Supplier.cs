namespace NetPay.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string SupplierName { get; set; }

        public ICollection<SupplierService> SuppliersServices { get; set; } = new List<SupplierService>();
    }
}

