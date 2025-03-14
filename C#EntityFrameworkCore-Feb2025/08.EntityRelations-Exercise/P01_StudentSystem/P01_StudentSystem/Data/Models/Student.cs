﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
       
        public int StudentId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "varchar(10)")]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
            = new HashSet<Homework>();
        public ICollection<StudentCourse> StudentsCourses { get; set; }
            = new HashSet<StudentCourse>();
    }
}

