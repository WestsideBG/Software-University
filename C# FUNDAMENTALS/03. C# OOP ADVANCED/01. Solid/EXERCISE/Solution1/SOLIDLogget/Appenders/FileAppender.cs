namespace SOLIDLogger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Contracts;
    using Loggers.enums;
    using System;
    using System.IO;


    internal class FileAppender : IAppender
    {
        private const string path = "log.txt";
        private ILayout layout;
        private ILogFile file;

        public int MessagesAppended { get; set; }

        public FileAppender(ILayout layout, ILogFile file)
        {
            this.layout = layout;
            this.file = file;
        }

        public ReportLevel ReportLevel { get; set; }


        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            string log = string.Format(layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
            this.file.Write(log);
            if (this.ReportLevel <= reportLevel)
            {
                File.AppendAllText(path, log);
                this.MessagesAppended++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}, File size: {this.file.Sum}";
        }
    }
}