using Logger.Enums;

namespace Logger.Core.Commands
{
    public class InfoCommand : Command
    {
        public InfoCommand(string dateTime, ReportLevel level, string message) :
            base(dateTime, level, message)
        {
        }
    }
}