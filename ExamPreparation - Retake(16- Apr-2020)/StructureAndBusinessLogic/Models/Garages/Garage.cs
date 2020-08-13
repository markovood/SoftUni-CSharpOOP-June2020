using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CAPACITY = 10;

        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.Capacity = CAPACITY;
            this.robots = new Dictionary<string, IRobot>();
        }

        public int Capacity { get; }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots.ToImmutableDictionary();

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count >= this.Capacity )
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.Any(r => r.Key == robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            var entity = this.robots.FirstOrDefault(r => r.Key == robotName);

            if (entity.Equals(default(KeyValuePair<string, IRobot>)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            entity.Value.Owner = ownerName;
            entity.Value.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}