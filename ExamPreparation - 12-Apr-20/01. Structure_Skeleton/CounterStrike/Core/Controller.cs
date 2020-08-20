using System;
using System.Linq;
using System.Text;

using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name, bulletsCount);
                    break;
                case "Rifle":
                    gun = new Rifle(name, bulletsCount);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);// NB ! or . in msg
            }

            this.guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;
            switch (type)
            {
                case "Terrorist":
                    player = new Terrorist(username, health, armor, gun);
                    break;
                case "CounterTerrorist":
                    player = new CounterTerrorist(username, health, armor, gun);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var ordered = this.players.Models
                                .OrderBy(m => m.GetType().Name)
                                .ThenByDescending(m => m.Health)
                                .ThenBy(m => m.Username);
            foreach (var player in ordered)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string StartGame()
        {
            return this.map.Start(this.players.Models.Where(m => m.IsAlive).ToList());
        }
    }
}