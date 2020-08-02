using FightingArena;

using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Gosho", 50, 80);
            this.arena = new Arena();
            this.arena.Enroll(this.warrior);
        }

        [Test]
        public void ConstructorShouldInitializeInnerCollection()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldThrowInvalidOperationExceptionWhenSuchWarriorNameAlreadyExists()
        {
            Assert.That(
                () => this.arena.Enroll(warrior),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void EnrollShouldAddWarriorToInnerCollection()
        {
            Assert.That(this.arena.Warriors.Count, Is.EqualTo(1));
        }

        [Test]
        public void CountShouldReturnCorrectCountOfInnerCollection()
        {
            int expectedCount = 1;

            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionWhenAnyOfTheFightersNamesDontExist()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    () => this.arena.Fight("Pesho", "Gosho"),
                    Throws
                     .InvalidOperationException
                     .With
                     .Message
                     .Contains("There is no fighter with name"),
                    "Attacker name exists");

                Assert.That(
                    () => this.arena.Fight("Gosho", "Pesho"),
                    Throws
                     .InvalidOperationException
                     .With
                     .Message
                     .Contains("There is no fighter with name"),
                    "Deffender name exists");
            });
        }

        [Test]
        public void FightShouldMakeAttackerAttackTheDeffender()
        {
            string attackerName = "Pesho";
            int attackerInitialDamage = 55;
            int attackerInitialHp = 85;
            Warrior attacker = new Warrior(attackerName, attackerInitialDamage, attackerInitialHp);
            this.arena.Enroll(attacker);
            Warrior defender = this.warrior;

            this.arena.Fight(attacker.Name, defender.Name);
            int expectedAttackerHp = attackerInitialHp - defender.Damage;

            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHp));
        }
    }
}
