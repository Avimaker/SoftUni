namespace SoftUni.Tests;

public class UniversityTest
{
    private University university;
    private Student student;

    [SetUp]
    public void SetUp() // стартира се ПРЕДИ всеки тест
    {
        university = new University();
        student = new Student()
        {
            Name = "Dimitrichko",
            Age = 21,
            Id = Guid.NewGuid()

        };
    }

    [TearDown] // ползва се рядко / стартира се СЛЕД всеки тест
    public void CleanUp()
    {

    }


    [Test]
    public void RegisterStudent_ShouldAddCorectly()
    {
        university.RegisterStudent(student);

        Assert.AreEqual(university.Students.Count, 1);
        Assert.IsTrue(university.FindStudent(student.Id) == student);

    }

    [Test]
    public void RegisterStudent_YoungerThan12_ShouldThrowAnError()
    {
        student.Age = 5;

        Assert.Throws<ArgumentException>
        ( () =>
        {
            university.RegisterStudent(student);
        }
        );
    }

    [Test]
    public void RegisterStudent_WithNegativeAge_ShouldThrowAnError()
    {
        student.Age = -15;

        Assert.Throws<ArgumentException>
        (() =>
        {
            university.RegisterStudent(student);
        }
        );
    }

}
