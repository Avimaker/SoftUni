using System;
namespace _07.EntityRelations.Data.Models
{
	public class Student
	{

		public int StudentPk { get; set; }

		public string Name { get; set; } = string.Empty;

		public string FacultyNumber { get; set; } = string.Empty;

        public int Semester { get; set; }


    }
}

