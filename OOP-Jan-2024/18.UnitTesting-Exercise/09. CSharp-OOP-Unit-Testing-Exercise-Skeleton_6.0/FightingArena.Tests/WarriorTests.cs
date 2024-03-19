namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void Warrior_Ctor_ShouldInitializePropertiesCorrectly()
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
        public void Warrior_Ctor_ShouldThrowExceptionIf_Name_IsNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior(name, 25, 50));
            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void Warrior_Ctor_ShouldThrowExceptionIf_Damage_IsNullOrNegative(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Conan", damage, 50));
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }


        [TestCase(-1)]
        [TestCase(-20)]
        public void Warrior_Ctor_ShouldThrowExceptionIf_HP_IsNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Warrior("Conan", 15, hp));
            Assert.AreEqual("HP should not be negative!", exception.Message);
        }


        [Test]
        public void AttackMethod_ShouldCorrectly()
        {
            int expectedAttackHp = 95;
            int expectedDeffenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackHp, attacker.HP);
            Assert.AreEqual(expectedDeffenderHp, defender.HP);

        }


        [TestCase(30)]
        [TestCase(29)]
        [TestCase(5)]
        public void Warrior_ShouldNotAttackIf_HisHP_IsEqualOrLessThan30(int hp)
        {

            Warrior attacker = new("Pesho", 10, hp);
            Warrior defender = new("Gosho", 5, 90);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }


        [TestCase(30)]
        [TestCase(29)]
        [TestCase(5)]
        public void Warrior_ShouldNotAttackIf_EnemyHP_IsEqualOrLessThan30(int hp)
        {

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, hp);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }


        [TestCase(101)]
        public void Warrior_ShouldNotAttackIf_EnemyDamage_IsBiggerThanHisHP(int damage)
        {

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", damage, 90);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void Warrior_ShouldKillEnemyIfHisDamageIsBiggerThanEnemyHP()
        {

            Warrior attacker = new("Pesho", 100, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);

        }
    }
}