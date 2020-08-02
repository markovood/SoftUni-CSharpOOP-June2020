using Moq;

using NUnit.Framework;

using Skeleton.Contracts;
using Skeleton.Tests.Fakes;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGetTargetXpWhenTargetIsDead()
    {
        IWeapon weapon = new FakeAxe(10, 10);
        ITarget target = new FakeDummy(100, 100);
        Hero hero = new Hero("Pesho", weapon);

        hero.Attack(target);

        Assert.That(hero.Experience, Is.EqualTo(100), "Hero's XP don't change after target is dead");
    }

    [Test]
    public void HeroShouldGetTargetXpWhenTargetIsDeadWithMOQ()
    {
        const int EXPECTED_XP = 100;

        var weapon = new Mock<IWeapon>();
        var target = new Mock<ITarget>();
        target.Setup(x => x.IsDead()).Returns(true);
        target.Setup(x => x.GiveExperience()).Returns(EXPECTED_XP);
        Hero hero = new Hero("Pesho", weapon.Object);

        hero.Attack(target.Object);

        Assert.That(hero.Experience, Is.EqualTo(EXPECTED_XP), "Hero's XP don't change after target is dead");
    }
}