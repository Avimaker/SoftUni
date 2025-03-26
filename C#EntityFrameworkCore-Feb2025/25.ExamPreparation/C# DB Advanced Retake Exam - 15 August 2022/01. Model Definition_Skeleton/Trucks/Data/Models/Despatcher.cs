using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public string? Position { get; set; }

        public ICollection<Truck> Trucks { get; set; } = new List<Truck>();
    }
}

