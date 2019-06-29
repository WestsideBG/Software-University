namespace SOLIDLogger.Loggers
{
    using enums;
    using Contracts;
    using Appenders.Contracts;

    public class Logger : ILogger
    {
        private IAppender appender;
        private IAppender fileAppender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public Logger(IAppender appender, IAppender fileAppender) : this(appender)
        {
            this.fileAppender = fileAppender;
        }

        public void Error(string dateTime, string message)
        {
            Appender(dateTime, ReportLevel.ERROR, message);
        }

        public void Info(string dateTime, string message)
        {
            Appender(dateTime, ReportLevel.INFO, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Appender(dateTime, ReportLevel.FATAL, message);
        }

        public void Critical(string dateTime, string message)
        {
            Appender(dateTime, ReportLevel.CRITICAL, message);
        }

        public void Warning(string dateTime, string message)
        {
            Appender(dateTime, ReportLevel.WARNING, message);
        }

        private void Appender(string dateTime, ReportLevel reportLevel, string message)
        {
            this.appender?.Append(dateTime, reportLevel, message);
            this.fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}