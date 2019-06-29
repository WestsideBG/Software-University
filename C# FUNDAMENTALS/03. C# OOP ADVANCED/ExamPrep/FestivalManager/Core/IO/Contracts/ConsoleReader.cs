using System;

namespace FestivalManager.Core.IO.Contracts
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}