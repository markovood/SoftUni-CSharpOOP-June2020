using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int ALIVE_DUMMY_HEALTH = 10;
    private const int DEAD_DUMMY_HEALTH = 0;
    private const int DUMMY_XP = 10;
    private const int ATTACK_PTS = 10;

    private Dummy aliveDummy;
    private Dummy deadDummy;

    [SetUp]
    public void Set()
    {
        this.aliveDummy = new Dummy(ALIVE_DUMMY_HEALTH, DUMMY_XP);
        this.deadDummy = new Dummy(DEAD_DUMMY_HEALTH, DUMMY_XP);
    }

    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        this.aliveDummy.TakeAttack(ATTACK_PTS);

        Assert.That(this.aliveDummy.Health, Is.EqualTo(0), "Dummy Health doesn't change after attack.");
    }

    [Test]
    public void DeadDummyShouldThrowInvalidOperationExceptionWhenAttacked()
    {
        Assert.That(
            () => this.deadDummy.TakeAttack(ATTACK_PTS),
            Throws
             .InvalidOperationException
             .With
             .Message
             .EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        int actual = this.deadDummy.GiveExperience();

        Assert.AreEqual(DUMMY_XP, actual);
    }

    [Test]
    public void AliveDummyShouldThrowInvalidOperationExceptionWhenGivingXP()
    {
        Assert.That(
            () => this.aliveDummy.GiveExperience(),
            Throws
             .InvalidOperationException
             .With
             .Message
             .EqualTo("Target is not dead."));
    }
}