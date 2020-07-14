using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        public static void Main()
        {
            var heroFactory = new HeroFactory();
            List<BaseHero> heroes = new List<BaseHero>();

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    var hero = heroFactory.GetHero(heroType, heroName);
                    heroes.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            heroes.ForEach(h => Console.WriteLine(h.CastAbility()));

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = heroes.Sum(h => h.Power);
            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}