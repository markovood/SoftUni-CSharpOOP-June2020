using Logger.Enums;

namespace Logger.Core.Commands
{
    public class CriticalCommand : Command
    {
        public CriticalCommand(string dateTime, ReportLevel level, string message) : 
            base(dateTime, level, message)
        {
        }
    }
}