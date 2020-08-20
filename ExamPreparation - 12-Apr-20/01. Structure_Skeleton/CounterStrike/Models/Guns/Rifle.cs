namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int ONE_STRIKE_BULLETS = 10;

        public Rifle(string name, int bulletsCount) :
            base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount == 0)
            {
                return 0;
            }

            this.BulletsCount -= ONE_STRIKE_BULLETS;
            return ONE_STRIKE_BULLETS;
        }
    }
}