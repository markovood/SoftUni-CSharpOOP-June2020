using Logger.Enums;

namespace Logger.Core.Commands
{
    public class FatalCommand : Command
    {
        public FatalCommand(string dateTime, ReportLevel level, string message) :
            base(dateTime, level, message)
        {
        }
    }
}