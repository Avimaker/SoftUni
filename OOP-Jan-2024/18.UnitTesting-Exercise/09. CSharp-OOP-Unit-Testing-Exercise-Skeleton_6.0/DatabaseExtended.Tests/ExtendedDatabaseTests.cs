namespace DatabaseExtended.Tests;

using System;
using ExtendedDatabase;
using NUnit.Framework;

[TestFixture]
public class ExtendedDatabaseTests
{
    private const string ValidUserNamePesho = "Pesho";
    private const long ValidIdPesho = 10001;
    private const string ValidUserNameGosho = "Gosho";
    private const long ValidIdGosho = 10002;
    private Database database;

    [SetUp]
    public void SetUp()
    {
        Person pesho = new Person(ValidIdPesho, ValidUserNamePesho);
        Person gosho = new Person(ValidIdGosho, ValidUserNameGosho);
        Person[] people = new Person[] { pesho, gosho };
        database = new Database(people);
    }

    [Test]
    public void Ctor_WithValidEmptyParameters_ShouldCreateNewInstance()
    {
        Database db = new Database();

        //Assert.That(db, Is.Not.Null);
        Assert.NotNull(db);
        Assert.AreEqual(db.Count, 0);
    }

    [Test]
    public void Ctor_WithValidParameters_ShouldCreateNewInstance()
    {
        Assert.NotNull(database);
        Assert.AreEqual(database.Count, 2);
    }

    [Test]
    public void DatabaseCount_ShouldWorkCorrectly()
    {
        //Arrange
        int expectedResult = 2;

        //Act
        int actualResult = database.Count;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseAddMethod_ShouldIncreaseCount()
    {
        Person newTestPerson = new Person(10017, "Dimitrichko");

        //Arrange
        int expectedResult = 3;

        //Act
        database.Add(newTestPerson);
        int actualResult = database.Count;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DatabaseAddMethod_ShouldWorkCorrectly()
    {
        Person newTestPerson = new Person(10017, "Dimitrichko");

        //Arrange
        long expectedResultId = 10017;
        string expectedResultUserName = "Dimitrichko";

        //Act
        database.Add(newTestPerson);
        long actualId = newTestPerson.Id;
        string actualUsername = newTestPerson.UserName;

        //Assert
        Assert.AreEqual(expectedResultId, actualId);
        Assert.AreEqual(expectedResultUserName, actualUsername);
    }

    [Test]
    public void DatabaseAddMethod_ShouldThrowExeptionWhenTheCountIsMoreThan16()
    {
        Person[] peoples =
        {
            new Person(10001, "Pesho"),
            new Person(10002, "Gosho"),
            new Person(10003, "Ivan"),
            new Person(10004, "Petkan"),
            new Person(10005, "Dragan"),
            new Person(10006, "Nasko"),
            new Person(10007, "Ico"),
            new Person(10008, "Kaloyan"),
            new Person(10009, "Konstantin"),
            new Person(10010, "Ivanka"),
            new Person(10011, "Maria"),
            new Person(10012, "Ginka"),
            new Person(10013, "Irena"),
            new Person(10014, "Penka"),
            new Person(10015, "Gergana"),
            new Person(10016, "Darina"),
        };

        database = new Database(peoples);

        Person newTestPerson = new Person(10017, "Dimitrichko");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(newTestPerson));

        Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);

    }

    [Test]
    public void DatabaseAddMethod_ShouldThrowExeptionWhenUserNameExist()
    {
        Person newTestPerson = new Person(10000, "Pesho");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(newTestPerson));

        Assert.AreEqual("There is already user with this username!", exception.Message);
    }

    [Test]
    public void DatabaseAddMethod_ShouldThrowExeptionWhenUserIdExist()
    {
        Person newTestPerson = new Person(10001, "Psiho");

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.Add(newTestPerson));

        Assert.AreEqual("There is already user with this Id!", exception.Message);
    }

    [Test]
    public void DatabaseRemoveMethod_ShoulWorkCorrectly()
    {
        int expectedCount = 1;

        database.Remove();

        Assert.AreEqual(expectedCount, database.Count);
    }

    [Test]
    public void DatabaseRemoveMethod_ShouldThrowExceptionIfDatabaseIsEmpty()
    {
        Database database = new();

        Assert.Throws<InvalidOperationException>(()
            => database.Remove());
    }

    [Test]
    public void DatabaseFindByUsderNameMethod_ShouldWorkProperly()
    {
        //Arrange
        string expectedResult = "Pesho";

        //Act
        string actualResult = database.FindByUsername("Pesho").UserName;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);

    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void DatabaseFindByUsderNameMethod_ThrowExceptionIfUserNameIsNull(string username)
    {

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
            => database.FindByUsername(username));

        Assert.AreEqual("Username parameter is null!", exception.ParamName);
    }

    [Test]
    [TestCase("Kiro")]
    [TestCase("Paul")]
    public void DatabaseFindByUsernameMethod_ShouldThrowExceptionIfUsernameIsNotFound(string username)
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.FindByUsername(username));

        Assert.AreEqual("No user is present by this username!", exception.Message);
    }



    [Test]
    public void DatabaseFindByUsderIdMethod_ShouldWorkProperly()
    {

        //Arrange
        long expectedResultId = 10001;
        string expectedResultName = "Pesho";

        //Act
        long actualResult = database.FindById(10001).Id;
        string actualResultName = database.FindById(10001).UserName;

        //Assert
        Assert.AreEqual(expectedResultId, actualResult);
        Assert.AreEqual(expectedResultName, actualResultName);
    }

    [Test]
    public void DatabaseFindByIdMethod_ShouldThrowExceptionIfIdIsNegative()
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
                    => database.FindById(-1));

        Assert.AreEqual("Id should be a positive number!", exception.ParamName);
    }

    [Test]
    public void DatabaseFindByIdMethod_ShouldThrowExceptionIfIdNotFound()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                    => database.FindById(25));

        Assert.AreEqual("No user is present by this ID!", exception.Message);
    }

}