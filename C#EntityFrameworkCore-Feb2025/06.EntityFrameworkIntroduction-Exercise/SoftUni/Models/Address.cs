namespace SoftUni.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public  class Address
    {
        public Address()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }

        [StringLength(100)]
        [Unicode(false)]

        // One side relations
        public string AddressText { get; set; } = null!;
        [Column("TownID")]
        public int? TownId { get; set; } //foreign key

        [ForeignKey("TownId")]
        [InverseProperty("Addresses")]
        public virtual Town? Town { get; set; } //reference to 

        //Many side of relation navigation property
        [InverseProperty("Address")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
