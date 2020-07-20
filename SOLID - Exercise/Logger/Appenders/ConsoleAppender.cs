using System;

using Logger.Enums;
using Logger.Layouts.Contracts;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) :
            base(layout)
        {
        }

        public override void AppendLine(string dateTime, ReportLevel level, string msg)
        {
            if (level >= this.ReportLevel)
            {
                Console.WriteLine(this.Layout.Format, dateTime, level.ToString().ToUpper(), msg);
                this.AppendedMessages++;
            }
        }
    }
}