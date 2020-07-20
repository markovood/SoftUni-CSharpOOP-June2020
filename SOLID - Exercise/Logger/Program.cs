using System;
using System.Collections.Generic;

using Logger.Appenders;
using Logger.Appenders.Contracts;
using Logger.Contracts;
using Logger.Core;
using Logger.Core.Commands;
using Logger.Core.Readers;
using Logger.Enums;
using Logger.Factories;
using Logger.Layouts;
using Logger.Layouts.Contracts;

namespace Logger
{
    public class Program
    {
        public static void Main()
        {
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //var simpleLayout = new SimpleLayout();
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(xmlLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var file = new LogFile();
            //var fileAppender = new FileAppender(xmlLayout, file);
            //fileAppender.ReportLevel = ReportLevel.Fatal;

            //var logger = new Logger(consoleAppender, fileAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory();
            IReader reader = new ConsoleReader();

            IAppender[] appenders = ReadAllAppenders(reader, layoutFactory, appenderFactory);
            var logger = new Logger(appenders);

            var commandInterpreter = new CommandInterpreter(logger);
            var cmdFactory = new CommandFactory();

            List<string[]> msgsArgs = ReadAllMessages(reader);
            foreach (var msgArgs in msgsArgs)
            {
                string reportLevel = msgArgs[0];
                string dateTime = msgArgs[1];
                string msg = msgArgs[2];

                ReportLevel level;
                if (!Enum.TryParse(reportLevel, true, out level))
                {
                    throw new ArgumentException("Invalid level!");
                }

                Command command = cmdFactory.GetCommand(level, dateTime, msg);
                commandInterpreter.Execute(command);
            }

            Console.WriteLine(logger);
        }

        private static List<string[]> ReadAllMessages(IReader reader)
        {
            List<string[]> msgsArgs = new List<string[]>();
            while (true)
            {
                // "<REPORT LEVEL>|<time>|<message>"
                string message = reader.ReadLine();
                if (message == "END")
                {
                    break;
                }

                msgsArgs.Add(message.Split('|', StringSplitOptions.RemoveEmptyEntries));
            }

            return msgsArgs;
        }

        private static IAppender[] ReadAllAppenders(IReader reader, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            int N = int.Parse(reader.ReadLine());
            IAppender[] appenders = new IAppender[N];

            for (int i = 0; i < N; i++)
            {
                // "<appender type> <layout type> <REPORT LEVEL>"
                string[] appenderArgs = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = appenderArgs[0];
                string layoutType = appenderArgs[1];


                ILayout layout = layoutFactory.GetLayout(layoutType);
                IAppender appender = null;
                if (appenderArgs.Length == 3)
                {
                    string reportLevel = appenderArgs[2];
                    appender = appenderFactory.GetAppender(type, layout, reportLevel);
                }
                else
                {
                    appender = appenderFactory.GetAppender(type, layout);
                }

                appenders[i] = appender;
            }

            return appenders;
        }
    }
}