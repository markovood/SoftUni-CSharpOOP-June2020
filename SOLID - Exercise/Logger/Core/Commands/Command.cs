using Logger.Enums;

namespace Logger.Core.Commands
{
    public abstract class Command
    {
        protected Command(string dateTime, ReportLevel level, string message)
        {
            this.Level = level;
            this.DateTime = dateTime;
            this.Message = message;
        }

        public string DateTime { get; }
        public ReportLevel Level { get; }
        public string Message { get; }
    }
}