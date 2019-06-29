namespace SOLIDLogger.Loggers
{
    using System.Linq;
    using Contracts;

    public class LogFile : ILogFile
    {
        public int Sum { get; private set; }

        public void Write(string message)
        {
            Sum += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}