using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var team = new FootballTeam("Levski", 15);

            Assert.AreEqual(team.Name, "Levski");
            Assert.AreEqual(team.Capacity, 15);
            Assert.AreEqual(team.Players.Count, 0);
        }

        [Test]
        public void TestNameThrowException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 15));
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 15));
        }

        [Test]
        public void TestCapacityThrowException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 0));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 14));
        }

        [Test]
        public void TestAddNewPlayerCapacity()
        {
            var team = new FootballTeam("Levski", 15);

            for (int i = 1; i <= 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer($"Pesho{i}", i, "Goalkeeper"));
            }

            var player = new FootballPlayer("Pesho", 16, "Goalkeeper");
            var expectedResult =  team.AddNewPlayer(player);

            Assert.AreEqual(expectedResult, "No more positions available!");
        }

        [Test]
        public void TestAddNewPlayerWorkCorectly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 16, "Goalkeeper");
            
            var actialResulat = team.AddNewPlayer(player);

            var expecterResult = $"Added player Pesho in position Goalkeeper with number 16";

            Assert.AreEqual(expecterResult, actialResulat); 
        }

        [Test]
        public void TestPickPlayerWorkCorectly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 1, "Goalkeeper");
            //var invalidPlayer = new FootballPlayer("Gosho", 8, "Forward");

            team.AddNewPlayer(player);

            Assert.AreEqual(team.PickPlayer("Pesho"), player);
            Assert.AreEqual(team.PickPlayer("Gosho"), null);

        }

        [Test]
        public void TestPlayerScoreWorkCorectly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 1, "Goalkeeper");
            team.AddNewPlayer(player);

            var expected = team.PlayerScore(1);

            Assert.AreEqual(player.ScoredGoals, 1);
            Assert.AreEqual(expected, $"Pesho scored and now has 1 for this season!");
        }
    }
}