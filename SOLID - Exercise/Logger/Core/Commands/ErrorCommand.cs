using Logger.Enums;

namespace Logger.Core.Commands
{
    public class ErrorCommand : Command
    {
        public ErrorCommand(string dateTime, ReportLevel level, string message) :
            base(dateTime, level, message)
        {
        }
    }
}