using System;

using Skeleton.Contracts;

namespace Skeleton.Tests.Fakes
{
    public class FakeDummy : ITarget
    {
        private int xp;
        private int health;

        public FakeDummy(int health, int xp)
        {
            this.xp = xp;
            this.health = health;
        }

        public int Health => this.health;

        public int GiveExperience()
        {
            return this.xp;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {

        }
    }
}