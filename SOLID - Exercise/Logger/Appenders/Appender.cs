using Logger.Appenders.Contracts;
using Logger.Contracts;
using Logger.Enums;
using Logger.Layouts.Contracts;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessages { get; protected set; }

        public abstract void AppendLine(string dateTime, ReportLevel level, string msg);

        public virtual string Info()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.AppendedMessages}";
        }
    }
}