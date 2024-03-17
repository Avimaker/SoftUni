using System;
namespace SoftUni
{
	public class Student
	{

		public Student()
		{
			Id = Guid.NewGuid();
		}

		public string Name { get; set; }

		public int Age { get; set; }

		public Guid Id { get; set; }
        //public int Id { get; set; }

    }

}

