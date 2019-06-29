using System;

namespace FestivalManager.Core.IO.Contracts
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }

        public void Write(string contents)
        {
            Console.Write(contents);
        }
    }
}