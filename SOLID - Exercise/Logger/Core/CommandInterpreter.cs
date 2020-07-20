using Logger.Contracts;
using Logger.Core.Commands;
using Logger.Enums;

namespace Logger.Core
{
    public class CommandInterpreter
    {
        private ILogger logger;

        public CommandInterpreter(ILogger logger)
        {
            this.logger = logger;
        }

        public void Execute(Command command)
        {
            switch (command.Level)
            {
                case ReportLevel.Info:
                    this.logger.Info(command.DateTime, command.Message);
                    break;
                case ReportLevel.Warning:
                    this.logger.Warning(command.DateTime, command.Message);
                    break;
                case ReportLevel.Error:
                    this.logger.Error(command.DateTime, command.Message);
                    break;
                case ReportLevel.Critical:
                    this.logger.Critical(command.DateTime, command.Message);
                    break;
                case ReportLevel.Fatal:
                    this.logger.Fatal(command.DateTime, command.Message);
                    break;
            }
        }
    }
}