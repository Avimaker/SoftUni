namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp] //изпълнява се ПРЕДИ всеки метод
        public void SetUp()
        {
            database = new Database(1, 2);
        }

        //[TearDown] //изпълнява се СЛЕД всеки метод
        //public void CleanUp()
        //{
        //}


        [Test]
        public void CreatedDatabaseCount_ShouldBeCorrect()
        {
            //Arrange
            int expectedResult = 2;

            //Act
            //database = new(1,2) е в стартъпа преместено
            int actualResult = database.Count;

            //Assert
            Assert.NotNull(database);
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDatabase_ShouldAddElementsCorrectly(int[] data)
        {
            //Act
            //Database database = new(data);//има го във филд и затова се пише без Database
            database = new(data);//expected result
            int[] actualResult = database.Fetch();

            //Assert 
            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDatabase_ShouldThrowExeptionWhenTheCountIsMoreThan16(int[] data)
        {
            ////това само проверява дали хвърля грешка, но не и каква е като текст за да го направя по-долу.
            //Assert.Throws<InvalidOperationException>(()
            //    => database = new Database(data));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseCount_ShouldWorkCorrectly()
        {
            //Arrange
            int expectedResult = 2;

            //Act
            //database = new(1,2) е в стартъпа преместено
            int actualResult = database.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-3)]
        [TestCase(0)]
        public void DatabaseAddMethod_ShouldIncreaseCount(int number)
        {
            int expectedResult = 3;
            database.Add(number);
            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseAddMethod_ShouldAddElementsCorectly(int[] data)
        {
            database = new Database();

            foreach (var number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [Test]
        public void DatabaseAddMethod_ShouldThrowExeptionWhenTheCountIsMoreThan16()
        {

            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(321));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldDecreaseCount()
        {
            int expectedResult = 1;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldRemoveElementsCorrectly()
        {
            //int[] expectedResult = Array.Empty<int>(); //правилен начин
            int[] expectedResult = { }; //бърз начин :)

            database.Remove();
            database.Remove();

            //Assert.AreEqual(expectedResult, database.Fetch());//var 1

            int[] actualResult = database.Fetch();
            Assert.AreEqual(expectedResult, actualResult);//var 2
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldThrowErrorCorectly()
        {
            database = new();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Remove());

            Assert.AreEqual("The collection is empty!", exception.Message);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseFetchMethod_ShouldReturnElementsCorectly(int[] data)
        {
            database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }



    }
}
