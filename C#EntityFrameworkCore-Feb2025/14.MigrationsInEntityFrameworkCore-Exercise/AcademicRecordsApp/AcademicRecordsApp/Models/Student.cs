using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [InverseProperty("Student")]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
