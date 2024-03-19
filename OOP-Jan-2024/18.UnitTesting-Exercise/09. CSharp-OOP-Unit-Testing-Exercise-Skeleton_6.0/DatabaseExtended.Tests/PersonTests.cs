using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace DatabaseExtended.Tests
{

    [TestFixture]
    public class PersonTests
	{
        private const string ValidUserName = "Pesho";
        private const long ValidId = 10001;

        [Test]
        public void Ctor_WithValidParameters_ShouldWorkProperly()
        {
            Person person = new Person(ValidId, ValidUserName);


            //Assert.That(person.UserName, Is.EqualTo(ValidUserName));
            Assert.AreEqual(ValidUserName, person.UserName);
            Assert.AreEqual(ValidId, person.Id);

            Assert.That(person, Is.Not.Null);

        }
    }
}

