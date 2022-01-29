using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class BlankReceipt
    {
        public BlankReceipt()
        {
        }

        internal void Run(string name)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            PrintHeader();
            PrintBody(name);
            PrintFooter();
        }

        private void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("© Westside                    ");
            Console.ResetColor();
        }

        private void PrintBody(string name)
        {
            Console.WriteLine($"Charged to {name}              ");
            Console.WriteLine("Received by Samir Azzam       ");
        }

        private void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT                  ");
            Console.WriteLine("------------------------------");
        }
    }
}