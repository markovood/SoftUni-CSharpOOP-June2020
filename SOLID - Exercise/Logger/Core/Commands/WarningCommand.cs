using Logger.Enums;

namespace Logger.Core.Commands
{
    public class WarningCommand : Command
    {
        public WarningCommand(string dateTime, ReportLevel level, string message) :
            base(dateTime, level, message)
        {
        }
    }
}