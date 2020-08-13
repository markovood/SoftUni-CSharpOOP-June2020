using System;
using System.Collections.Generic;
using System.Text;

using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected List<IRobot> Robots { get; set; }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }
    }
}