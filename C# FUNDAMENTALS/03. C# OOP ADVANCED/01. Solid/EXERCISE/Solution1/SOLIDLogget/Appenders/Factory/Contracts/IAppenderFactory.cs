namespace SOLIDLogger.Appenders.Factory.Contracts
{
    using SOLIDLogger.Appenders.Contracts;
    using SOLIDLogger.Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}