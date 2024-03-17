global using NUnit.Framework;

//namespace SoftUni.Tests;

//public class UniversityTest
//{
//    [Test]
//    public void RegisterStudent_ShouldAddCorectly()
//    {
//        University university = new University();
//        Student student = new Student()
//        {
//            Name = "Dimitrichko",
//            Age = 21,
//            Id = Guid.NewGuid()

//        };

//        university.RegisterStudent(student);

//        Assert.AreEqual(university.Students.Count, 1);
//        Assert.IsTrue(university.FindStudent(student.Id) == student);

//    }

//    [Test]
//    public void RegisterStudent_YoungerThan12_ShouldThrowAnError()
//    {
//        University university = new University();
//        Student student = new Student()
//        {
//            Name = "Malcho",
//            Age = 5,
//            Id = Guid.NewGuid()
//        };

//        Assert.Throws<ArgumentException>
//        (() =>
//        {
//            university.RegisterStudent(student);
//            //throw new ArgumentException();
//        }
//        );
//    }

//    [Test]
//    public void RegisterStudent_WithNegativeAge_ShouldThrowAnError()
//    {
//        University university = new University();
//        Student student = new Student()
//        {
//            Name = "Malcho",
//            Age = -5,
//            Id = Guid.NewGuid()
//        };

//        Assert.Throws<ArgumentException>
//        (() =>
//        {
//            university.RegisterStudent(student);
//            //throw new ArgumentException();
//        }
//        );
//    }

//}
