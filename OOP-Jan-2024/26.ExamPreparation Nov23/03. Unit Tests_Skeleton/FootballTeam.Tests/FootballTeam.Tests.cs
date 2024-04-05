using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        private FootballTeam team;
        private FootballPlayer player;

        [SetUp]
        public void Setup()
        {
            string teamName = "Karabunar";
            int teamCapacity = 20;
            team = new FootballTeam(teamName, teamCapacity);

            string name = "Stoichkov";
            int playerNumber = 9;
            string position = "Forward";
            player = new FootballPlayer(name, playerNumber, position);
        }

        [Test]
        public void Ctor_InitializeFields_Success()
        {
            // Arrange
            string teamNameTest = "Karabunar";
            int teamCapacityTest = 20;

            // Act
            //FootballTeam team = new FootballTeam(teamName, teamCapacity);

            // Assert
            Assert.AreEqual(teamNameTest, team.Name);
            Assert.AreEqual(teamCapacityTest, team.Capacity);
            Assert.IsNotNull(team.Players);
            Assert.AreEqual(0, team.Players.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Ctor_InvalidTeamName_ExceptionThrown(string testName)
        {
            // Arrange
            string teamNameTest = testName;
            int teamCapacityTest = 20;

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballTeam(teamNameTest, teamCapacityTest));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [TestCase("14")]
        public void Ctor_InvalidTeamName_ExceptionThrown(int testCapacity)
        {
            // Arrange
            string teamNameTest = "Karabunar";
            int teamCapacityTest = testCapacity;

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballTeam(teamNameTest, teamCapacityTest));
            Assert.AreEqual("Capacity min value = 15", exception.Message);
        }

        [Test]
        public void Prop_Players_GetInitialValue_EmptyList()
        {
            // Arrange
            //FootballTeam team = new FootballTeam("TeamA", 20);

            // Assert
            CollectionAssert.AreEqual(new List<FootballPlayer>(), team.Players);
        }

        [Test]
        public void AddNewPlayer_AddPlayer_Success()
        {
            // Arrange

            // Act
            string result = team.AddNewPlayer(player);

            // Assert
            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", result);
            Assert.IsTrue(team.Players.Contains(player));
        }

        [Test]
        public void AddNewPlayer_AddPlayer_ReturnsErrorMessage()
        {
            // Arrange
            FootballTeam team = new FootballTeam("KrivaNiva", 15);
            FootballPlayer player1 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player2 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player3 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player4 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player5 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player6 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player7 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player8 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player9 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player10 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player11 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player12 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player13 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player14 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player15 = new FootballPlayer("Pesho", 10, "Forward");
            FootballPlayer player16 = new FootballPlayer("Pesho", 10, "Forward");


            // Act
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);
            string error = team.AddNewPlayer(player16);

            // Assert
            Assert.AreEqual("No more positions available!", error);

        }

        [Test]
        public void PickPlayer_PlayerExistsInTeam_ReturnsPlayer()
        {
            // Arrange
            team.AddNewPlayer(player);

            // Act
            FootballPlayer pickedPlayer = team.PickPlayer("Stoichkov");

            // Assert
            Assert.IsNotNull(pickedPlayer);
            Assert.AreEqual("Stoichkov", pickedPlayer.Name);
            Assert.AreEqual(9, pickedPlayer.PlayerNumber);
            Assert.AreEqual("Forward", pickedPlayer.Position);
        }

        [Test]
        public void PickPlayer_PlayerDoesNotExistInTeam_ReturnsNull()
        {
            // Arrange
            team.AddNewPlayer(player);

            // Act
            FootballPlayer pickedPlayer = team.PickPlayer("Strahil");

            // Assert
            Assert.IsNull(pickedPlayer);
        }

        [Test]
        public void PlayerScore_PlayerExists_ScoresAndReturnsMessage()
        {
            // Arrange
            team.AddNewPlayer(player);

            // Act
            string message = team.PlayerScore(9);

            // Assert
            Assert.AreEqual($"{player.Name} scored and now has {player.ScoredGoals} for this season!", message);
            Assert.AreEqual(1, player.ScoredGoals);
        }

        
    }
}