namespace DatabaseExtended.Tests;

using ExtendedDatabase;
using NUnit.Framework;

[TestFixture]
public class ExtendedDatabaseTests
{
    private const string ValidUserNamePesho = "Pesho";
    private const long ValidIdPesho = 10001;
    private const string ValidUserNameGosho = "Gosho";
    private const long ValidIdGosho = 10002;
    private Database sut;

    [SetUp]
    public void SetUp()
    {
        Person pesho = new Person(ValidIdPesho, ValidUserNamePesho);
        Person gosho = new Person(ValidIdGosho, ValidUserNameGosho);
        Person[] people = new Person[] { pesho, gosho };
        sut = new Database(people);
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
        Assert.NotNull(sut);
        Assert.AreEqual(sut.Count, 2);
    }


}