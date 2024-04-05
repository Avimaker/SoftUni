using System;
using System.Xml.Linq;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class FootballPlayerTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Ctor_ValidParameters_Success()
        {
            // Arrange
            string name = "Stoichkov";
            int playerNumber = 9;
            string position = "Forward";

            // Act
            FootballPlayer player = new FootballPlayer(name, playerNumber, position);

            // Assert
            Assert.AreEqual(name, player.Name);
            Assert.AreEqual(playerNumber, player.PlayerNumber);
            Assert.AreEqual(position, player.Position);
            Assert.AreEqual(0, player.ScoredGoals);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Ctor_InvalidName_ExceptionThrown(string name)
        {
            // Arrange
            int playerNumber = 9;
            string position = "Forward";

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, playerNumber, position));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [TestCase("0")]
        [TestCase("22")]
        public void Ctor_InvalidNumber_ExceptionThrown(int playerNumber)
        {
            // Arrange
            string name = "Stoichkov";
            string position = "Forward";

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, playerNumber, position));
            Assert.AreEqual("Player number must be in range [1,21]", exception.Message);
        }

        [TestCase("Skameikadjia")]
        public void Ctor_InvalidPosition_ExceptionThrown(string position)
        {
            // Arrange
            string name = "Stoichkov";
            int playerNumber = 9;

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballPlayer(name, playerNumber, position));
            Assert.AreEqual("Invalid Position", exception.Message);
        }


        [Test]
        public void ScoredGoals_GetInitialValue_Zero()
        {
            // Arrange
            string name = "Stoichkov";
            int playerNumber = 9;
            string position = "Forward";
            // Act
            FootballPlayer player = new FootballPlayer(name, playerNumber, position);

            // Assert
            Assert.AreEqual(0, player.ScoredGoals);
        }

        [Test]
        public void Score_ShouldWorkProper()
        {
            // Arrange
            string name = "Stoichkov";
            int playerNumber = 9;
            string position = "Forward";
            // Act
            FootballPlayer player = new FootballPlayer(name, playerNumber, position);

            player.Score();

            // Assert
            Assert.AreEqual(1, player.ScoredGoals);
        }
    }
}