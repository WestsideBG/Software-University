namespace SOLIDLogger.Core
{
    using Appenders.Contracts;
    using Appenders.Factory;
    using Appenders.Factory.Contracts;
    using Layouts.Contracts;
    using Layouts.Factory;
    using Layouts.Factory.Contracts;
    using Loggers.enums;

    using System;
    using System.Collections.Generic;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IAppenderFactory appenderFactory = new AppenderFactory();
        private ILayoutFactory layoutFactory = new LayoutFactory();
        private ICollection<IAppender> appenders;

        public CommandInterpreter()
        {
            appenders = new List<IAppender>();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = layoutFactory.CreateLayout(layoutType);
            IAppender appender = appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            foreach (var appender in appenders)
            {
                string dateTime = args[1];
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
                string message = args[2];

                appender.Append(dateTime,reportLevel,message);
            }

        }

        public void PrintMessageInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}