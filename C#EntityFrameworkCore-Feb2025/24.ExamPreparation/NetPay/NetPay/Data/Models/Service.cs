using System;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string ServiceName { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<SupplierService> SuppliersServices { get; set; } = new List<SupplierService>();
    }
}

