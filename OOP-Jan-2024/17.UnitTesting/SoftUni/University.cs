using System;
namespace SoftUni
{
	public class University
	{

        public University()
        {
            Students = new List<Student>();
        }

        public List<Student> Students { get; set; }
		
		public void RegisterStudent(Student student)
        {
            if (student.Age < 12)
            {
                //Console.WriteLine("Students below 12 years should be not registered for university.");
                throw new ArgumentException("Students below 12 years should be not registered for university.");
            }

            Students.Add(student);
        }

        public Student FindStudent(Guid Id)
        {
            return Students.First(s => s.Id == Id);
        }

        public List<Student> FindStudent(string name)
        {
            return Students.Where(s => s.Name.Contains(name)).ToList();
        }

    }
}

