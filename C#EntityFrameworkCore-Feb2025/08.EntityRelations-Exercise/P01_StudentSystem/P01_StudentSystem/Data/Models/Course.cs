using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {

        public int CourseId { get; set; }

        [MaxLength(80)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; }
            = new HashSet<Resource>();
        public ICollection<Homework> Homeworks { get; set; }
            = new HashSet<Homework>();
        public ICollection<StudentCourse> StudentsCourses { get; set; }
            = new HashSet<StudentCourse>();
    }
}

