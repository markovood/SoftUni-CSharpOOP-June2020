using System;

namespace Raiding
{
    public class HeroFactory
    {
        public BaseHero GetHero(string heroType, string heroName)
        {
            switch (heroType)
            {
                case "Druid":
                    return new Druid(heroName);
                case "Paladin":
                    return new Paladin(heroName);
                case "Rogue":
                    return new Rogue(heroName);
                case "Warrior":
                    return new Warrior(heroName);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}