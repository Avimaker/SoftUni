namespace SoftUni.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public class Project
    {
        public Project()
        {
            //this.Employees = new HashSet<Employee>();
            this.EmployeesProjects = new HashSet<EmployeeProject>();
        }

        [Key]
        [Column("ProjectID")]
        public int ProjectId { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndDate { get; set; }

        //[ForeignKey("ProjectId")]
        //[InverseProperty("Projects")]
        //public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }
}
