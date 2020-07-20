using System.Text;

using Logger.Appenders.Contracts;
using Logger.Contracts;
using Logger.Enums;

namespace Logger
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string dateTime, string message)
        {
            ReportLevel reportLevel = ReportLevel.Critical;
            Log(dateTime, message, reportLevel);
        }

        public void Error(string dateTime, string message)
        {
            ReportLevel reportLevel = ReportLevel.Error;
            Log(dateTime, message, reportLevel);
        }

        public void Fatal(string dateTime, string message)
        {
            ReportLevel reportLevel = ReportLevel.Fatal;
            Log(dateTime, message, reportLevel);
        }

        public void Info(string dateTime, string message)
        {
            ReportLevel reportLevel = ReportLevel.Info;
            Log(dateTime, message, reportLevel);
        }

        public void Warning(string dateTime, string message)
        {
            ReportLevel reportLevel = ReportLevel.Warning;
            Log(dateTime, message, reportLevel);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (var appender in this.appenders)
            {
                sb.AppendLine(appender.Info());
            }
            
            return sb.ToString().Trim();
        }

        private void Log(string dateTime, string message, ReportLevel reportLevel)
        {
            foreach (var appender in this.appenders)
            {
                appender.AppendLine(dateTime, reportLevel, message);
            }
        }
    }
}