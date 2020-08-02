using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AXE_ATTACK = 10;
    private const int AXE_DURABILITY = 10;
    private const int BROKEN_AXE_DURABILITY = 0;
    private const int DUMMY_HEALTH = 100;
    private const int DUMMY_XP = 100;

    private Dummy dummy;

    [SetUp]
    public void Set()
    {
        this.dummy = new Dummy(DUMMY_HEALTH, DUMMY_XP);
    }

    [Test]
    public void AxeLosesDurabilityAfterEachAttack()
    {
        Axe axe = new Axe(AXE_ATTACK, AXE_DURABILITY);

        axe.Attack(this.dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void AttackingWithBrokenAxeShouldThrowInvalidOperationException()
    {
        Axe axe = new Axe(AXE_ATTACK, BROKEN_AXE_DURABILITY);

        Assert.That(
            () => axe.Attack(this.dummy), 
            Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Axe is broken."));
    }
}