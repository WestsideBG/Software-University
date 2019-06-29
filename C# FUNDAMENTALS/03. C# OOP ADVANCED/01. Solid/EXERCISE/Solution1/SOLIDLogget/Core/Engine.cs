namespace SOLIDLogger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }


        public void Run()
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(args);
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split('|');

                this.commandInterpreter.AddMessage(args);
            }

            this.commandInterpreter.PrintMessageInfo();
        }
    }
}