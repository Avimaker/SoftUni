/*
5
John
5.5
John
4.5
Alice
6
Alice
3
George
5

*/

namespace _06.StudentAcademy;

class Student
{
    public Student(string name, double grade)
    {
        Name = name;
        Grade = new List<double>();
    }

    public string Name { get; set; }
    public List<double> Grade { get; set; }

    public override string ToString()
    {
        return $"{Name} -> {Grade.Average():F2}";
    }

}


class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Student> students = new Dictionary<string, Student>();

        for (int i = 0; i < n; i++)
        {
            string currentName = Console.ReadLine();
            double currentGrade = double.Parse(Console.ReadLine());

            if (!students.ContainsKey(currentName))
            {
                Student currentStudent = new Student(currentName, currentGrade);
                students.Add(currentName, currentStudent);
            }

            students[currentName].Grade.Add(currentGrade);
        }

        IEnumerable<KeyValuePair<string, Student>> orderedStudents = students.Where(g => g.Value.Grade.Average() >= 4.50);


        foreach (var item in orderedStudents)
        {
            Console.WriteLine(item.Value);
        }

    }
}

