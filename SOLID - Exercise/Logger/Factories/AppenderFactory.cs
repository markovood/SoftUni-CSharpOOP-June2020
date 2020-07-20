using System;
using System.Linq;
using System.Reflection;

using Logger.Appenders.Contracts;
using Logger.Contracts;
using Logger.Enums;
using Logger.Layouts.Contracts;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        public IAppender GetAppender(string type, ILayout layout, string level = "Info")
        {
            var appenderType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == type).FirstOrDefault();
            if (appenderType == null)
            {
                    throw new ArgumentException("Invalid appender type");
            }

            IAppender appender = (IAppender)Activator.CreateInstance(appenderType, layout);

            switch (level.ToLower())
            {
                case "warning":
                    appender.ReportLevel = ReportLevel.Warning;
                    break;
                case "error":
                    appender.ReportLevel = ReportLevel.Error;
                    break;
                case "critical":
                    appender.ReportLevel = ReportLevel.Critical;
                    break;
                case "fatal":
                    appender.ReportLevel = ReportLevel.Fatal;
                    break;
                default:
                    appender.ReportLevel = ReportLevel.Info;
                    break;
            }

            return appender;
        }
    }
}