/*
4
Lakia Eason 3.90
Prince Messing 5.49
Akiko Segers 4.85
Rocco Erben 6.00

3
Mary Elizabeth 4.22
Li Xiao 5.74
Liz Smith 4.87

*/

namespace _04.Students;

class Student
{
    public Student(string firstName, string lastName, double grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:F2}";
    }

}

class Program
{
    static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());
        List<Student> students = new List<Student>();
        //double grade = 0;

        for (int i = 0; i < studentsCount; i++)
        {
            string[] inputInfo = Console.ReadLine()
            .Split()
            .ToArray();
            //grade = double.Parse(inputInfo[2]);

            Student articles = new Student(inputInfo[0], inputInfo[1], double.Parse(inputInfo[2]));
            students.Add(articles);
        }

        //students = students.OrderByDescending(student => student.Grade).ToList();// така прави прожекция върху първия лист

        var orderedList = students.OrderByDescending(student => student.Grade);

        //foreach (var student in orderedList)
        //{
        //    Console.WriteLine(student);
        //}

         Console.WriteLine(string.Join("\n", orderedList));


    }
}

