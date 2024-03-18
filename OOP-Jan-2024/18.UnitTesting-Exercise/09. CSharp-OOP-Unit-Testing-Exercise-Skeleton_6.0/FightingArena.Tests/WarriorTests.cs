namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void Warrior_Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string expectedName = "Conan";
            int expectedDamage = 50;
            int expectedHp = 100;

            // Act
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            // Assert
            Assert.NotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void Warrior_Constructor_ShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior(name, 25, 50));
            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void Warrior_Constructor_ShouldThrowExceptionIfDamageIsNullOrNegative(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Conan", damage, 50));
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }


        [TestCase(-1)]
        [TestCase(-20)]
        public void Warrior_Constructor_ShouldThrowExceptionIfHPIsNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Conan", 15, hp));
            Assert.AreEqual("HP should not be negative!", exception.Message);
        }


        [Test]
        public void AttackMethodShouldCorrectly()
        {
            int expectedAttackHp = 95;
            int expectedDeffenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackHp, attacker.HP);
            Assert.AreEqual(expectedDeffenderHp, defender.HP);

        }

    }
}