using FightingArena;

using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.name = "Pesho";
            this.damage = 10;
            this.hp = 5;
            this.warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void ConstructorShouldSetAllPropertiesCorrectly()
        {
            string expectedName = this.name;
            int expectedDamage = this.damage;
            int expectedHp = this.hp;

            string actualName = this.warrior.Name;
            int actualDamage = this.warrior.Damage;
            int actualHp = this.warrior.HP;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedName, actualName, "Name was not set correctly");
                Assert.AreEqual(expectedDamage, actualDamage, "Damage was not set correctly");
                Assert.AreEqual(expectedHp, actualHp, "HP was not set correctly");
            });
        }

        [Test]
        public void SettingNameShouldThrowArgumentExceptionWhenNullOrEmptyOrWhiteSpace()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    () => new Warrior(null, this.damage, this.hp),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Name should not be empty or whitespace!"),
                    "Name was set to null");

                Assert.That(
                    () => new Warrior("", this.damage, this.hp),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Name should not be empty or whitespace!"),
                    "Name was set to empty");

                Assert.That(
                    () => new Warrior("     ", this.damage, this.hp),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Name should not be empty or whitespace!"),
                    "Name was set to white-space");
            });
        }

        [Test]
        public void SettingDamageShouldThrowArgumentExceptionWhenZeroOrNegative()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    () => new Warrior(this.name, 0, this.hp),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Damage value should be positive!"),
                    "Damage was set to 0");

                Assert.That(
                    () => new Warrior(this.name, -5, this.hp),
                    Throws
                     .ArgumentException
                     .With
                     .Message
                     .EqualTo("Damage value should be positive!"),
                    "Damage was set to negative value");
            });
        }

        [Test]
        public void SettingHpShouldThrowArgumentExceptionWhenNegative()
        {
            Assert.That(
                () => new Warrior(this.name, this.damage, -5),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenHpIsEqualOrLessTo30()
        {
            Warrior enemy = new Warrior("Gosho", 15, 100);

            Assert.That(
                () => this.warrior.Attack(enemy),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenOtherWarriorHpIsEqualOrLessTo30()
        {
            Warrior attacker = new Warrior("Pesho", 15, 35);
            Warrior enemy = new Warrior("Gosho", 15, 20);

            Assert.That(
                () => attacker.Attack(enemy),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenAttackerHpIsLessThanEnemyDamage()
        {
            Warrior attacker = new Warrior("Pesho", 15, 35);
            Warrior enemy = new Warrior("Gosho", 150, 35);

            Assert.That(
                () => attacker.Attack(enemy),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackShouldReduceHpByTheEnemyDamage()
        {
            Warrior attacker = new Warrior("Pesho", 150, 35);
            Warrior enemy = new Warrior("Gosho", 35, 35);
            int expectedHp = 0;

            attacker.Attack(enemy);
            int actualHp = attacker.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]
        public void AttackShouldSetEnemyHpToZeroWhenDamageIsGreaterThanEnemyHp()
        {
            Warrior attacker = new Warrior("Pesho", 150, 35);
            Warrior enemy = new Warrior("Gosho", 35, 35);
            int expectedEnemyHp = 0;

            attacker.Attack(enemy);
            int actualEnemyHp = enemy.HP;

            Assert.AreEqual(expectedEnemyHp, actualEnemyHp);
        }

        [Test]
        public void AttackShouldReduceEnemyHpByDamageAmountWhenDamageIsLessThanEnemyHp()
        {
            Warrior attacker = new Warrior("Pesho", 25, 35);
            Warrior enemy = new Warrior("Gosho", 35, 35);
            int expectedEnemyHp = 10;

            attacker.Attack(enemy);
            int actualEnemyHp = enemy.HP;

            Assert.AreEqual(expectedEnemyHp, actualEnemyHp);
        }
    }
}