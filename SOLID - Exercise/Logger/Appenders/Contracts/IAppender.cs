using Logger.Enums;
using Logger.Layouts.Contracts;

namespace Logger.Appenders.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        int AppendedMessages { get; }
        void AppendLine(string dateTime, ReportLevel level, string msg);
        string Info();
    }
}