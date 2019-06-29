namespace SOLIDLogger.Appenders
{
    using System;
    using Contracts;
    using Layouts.Contracts;
    using Loggers.enums;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public int MessagesAppended { get; set; }

        public ReportLevel ReportLevel { set; get; }


        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));
                this.MessagesAppended++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";
        }
    }
}