namespace SOLIDLogger.Appenders.Factory
{
    using System;
    using Appenders.Contracts;
    using Contracts;
    using Layouts.Contracts;
    using Loggers;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return  new FileAppender(layout,new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");

            }
        }
    }
}