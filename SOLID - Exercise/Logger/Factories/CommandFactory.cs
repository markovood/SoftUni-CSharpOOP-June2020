using Logger.Core.Commands;
using Logger.Enums;

namespace Logger.Factories
{
    public class CommandFactory
    {
        public Command GetCommand(ReportLevel reportLevel, string dateTime, string message)
        {
            Command cmd = null;
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    cmd = new InfoCommand(dateTime, reportLevel, message);
                    break;
                case ReportLevel.Warning:
                    cmd = new WarningCommand(dateTime, reportLevel, message);
                    break;
                case ReportLevel.Error:
                    cmd = new ErrorCommand(dateTime, reportLevel, message);
                    break;
                case ReportLevel.Critical:
                    cmd = new CriticalCommand(dateTime, reportLevel, message);
                    break;
                case ReportLevel.Fatal:
                    cmd = new FatalCommand(dateTime, reportLevel, message);
                    break;
            }

            return cmd;
        }
    }
}