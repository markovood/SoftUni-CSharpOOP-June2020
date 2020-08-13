using System;
using System.Collections.Generic;
using System.Linq;

using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private List<IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();

            var chargeProcedure = new Charge();
            var chipProcedure = new Chip();
            var polishProcedure = new Polish();
            var restProcedure = new Rest();
            var techProcedure = new TechCheck();
            var workProcedure = new Work();

            this.procedures = new List<IProcedure>() 
            {
                chargeProcedure,
                chipProcedure,
                polishProcedure,
                restProcedure,
                techProcedure,
                workProcedure
            };
        }

        public string Charge(string robotName, int procedureTime)
        {
            var robot = EnsureRobotExistence(robotName);

            procedures
                .Where(pr => pr.GetType().Name == "Charge")
                .First()
                .DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            var robot = EnsureRobotExistence(robotName);

            procedures
                .Where(pr => pr.GetType().Name == "Chip")
                .First()
                .DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var procedure = this.procedures.First(pr => pr.GetType().Name == procedureType);
            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, happiness, energy, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, happiness, energy, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, happiness, energy, procedureTime);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            var robot = EnsureRobotExistence(robotName);

            procedures
                .Where(pr => pr.GetType().Name == "Polish")
                .First()
                .DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            var robot = EnsureRobotExistence(robotName);

            procedures
                .Where(pr => pr.GetType().Name == "Rest")
                .First()
                .DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            var robot = EnsureRobotExistence(robotName);

            this.garage.Sell(robot.Name, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var robot = EnsureRobotExistence(robotName);

            procedures
                .Where(pr => pr.GetType().Name == "TechCheck")
                .First()
                .DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            var robot = EnsureRobotExistence(robotName);

            procedures
                .Where(pr => pr.GetType().Name == "Work")
                .First()
                .DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private IRobot EnsureRobotExistence(string robotName)
        {
            var entity = this.garage.Robots.FirstOrDefault(r => r.Key == robotName);
            if (entity.Equals(default(KeyValuePair<string,IRobot>)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return entity.Value;
        }
    }
}