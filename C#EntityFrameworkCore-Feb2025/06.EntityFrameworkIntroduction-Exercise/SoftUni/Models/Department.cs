namespace SoftUni.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [Column("ManagerID")]
        public int ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        [InverseProperty("Departments")]
        public virtual Employee Manager { get; set; } = null!;

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
