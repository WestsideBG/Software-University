namespace SOLIDLogger.Loggers.Contracts
{
    public interface ILogFile
    {
        int Sum { get; }

        void Write(string message);
    }
}