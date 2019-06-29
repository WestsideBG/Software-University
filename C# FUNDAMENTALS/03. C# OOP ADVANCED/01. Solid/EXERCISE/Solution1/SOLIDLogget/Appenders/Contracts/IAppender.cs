namespace SOLIDLogger.Appenders.Contracts
{
    using Loggers.enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel errorLevel, string message);

        int MessagesAppended { get; set; }
    }
}