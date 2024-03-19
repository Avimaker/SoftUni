namespace FightingArena.Tests
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new();
        }

        [Test]
        public void Arena_Ctor_ShouldWorkCorectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Arena_Count_ShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new("Conan", 15, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedResult, arena.Count);
        }

        [Test]
        public void Arena_EnrolMethod_ShouldWorkCorrectly()
        {
            Warrior warrior = new("Conan", 15, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void Arena_EnrolMethod_ShouldThrowExceptionIfWarriorIsAlreadyEnnroled()
        {
            Warrior warrior = new("Conan", 15, 100);

            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Arena_FightMethod_ShouldWorkCorrectly()
        {
            Warrior attacker = new("Conan", 15, 100);
            Warrior defender = new("TheRock", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 35;

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void Arena_FightMethod_ShouldThrowExceptionIfAttackerIsNotFound()
        {
            Warrior attacker = new("Conan", 15, 100);
            Warrior defender = new("TheRock", 5, 50);

            //arena.Enroll(attacker);
            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name)
                );

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }


        [Test]
        public void Arena_FightMethod_ShouldThrowExceptionIfDefenderIsNotFound()
        {
            Warrior attacker = new("Conan", 15, 100);
            Warrior defender = new("TheRock", 5, 50);

            arena.Enroll(attacker);
            //arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name)
                );

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }

    }
}
