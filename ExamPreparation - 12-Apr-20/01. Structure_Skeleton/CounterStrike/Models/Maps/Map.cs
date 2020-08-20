using System.Collections.Generic;
using System.Linq;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.OfType<Terrorist>().ToList();
            var counterTerrorists = players.OfType<CounterTerrorist>().ToList();

            bool countersWin = false;
            bool terroristsWin = false;
            while (true)
            {
                if (terrorists.All(t => t.IsAlive == false) && counterTerrorists.Any(ct => ct.IsAlive))
                {
                    countersWin = true;
                    break;
                }

                if (counterTerrorists.All(ct => ct.IsAlive == false) && terrorists.Any(t => t.IsAlive))
                {
                    terroristsWin = true;
                    break;
                }

                // terrorist attack
                foreach (var terrorist in terrorists.Where(t => t.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(ct => ct.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                // counterTerrorist attack
                foreach (var counterTerrorist in counterTerrorists.Where(ct => ct.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(t => t.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            string result = string.Empty;
            if (countersWin)
            {
                result =  "Counter Terrorist wins!";
            }

            if (terroristsWin)
            {
                result =  "Terrorist wins!";
            }

            return result;
        }
    }
}