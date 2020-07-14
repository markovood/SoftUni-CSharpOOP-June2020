namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;

        public Warrior(string name) : 
            base(name, POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}