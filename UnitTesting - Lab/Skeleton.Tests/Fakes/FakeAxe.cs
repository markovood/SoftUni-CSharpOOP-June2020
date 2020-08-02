using Skeleton.Contracts;

namespace Skeleton.Tests.Fakes
{
    public class FakeAxe : IWeapon
    {
        public FakeAxe(int attackPoints, int durabilityPoints)
        {
            this.AttackPoints = attackPoints;
            this.DurabilityPoints = durabilityPoints;
        }

        public int AttackPoints { get; }

        public int DurabilityPoints { get; private set; }

        public void Attack(ITarget target)
        {

        }
    }
}