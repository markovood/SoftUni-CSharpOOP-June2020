using System.IO;

using Logger.Contracts;
using Logger.Enums;
using Logger.Layouts.Contracts;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile file;

        // this ctor is needed in AppenderFactory to create FileAppender dynamically through reflection
        public FileAppender(ILayout layout) :
            base(layout)
        {
            this.file = new LogFile();
        }

        public FileAppender(ILayout layout, ILogFile file) : 
            base(layout)
        {
            this.file = file;
        }

        public override void AppendLine(string dateTime, ReportLevel level, string msg)
        {
            if (level >= this.ReportLevel)
            {
                using (StreamWriter writer = new StreamWriter(this.file.Path, true))
                {
                    string message = string.Format(this.Layout.Format, dateTime, level.ToString().ToUpper(), msg);
                    this.file.Write(message);
                    writer.WriteLine(message);
                    this.AppendedMessages++;
                }
            }
        }

        public override string Info()
        {
            return base.Info() + $", File size {this.file.Size}";
        }
    }
}