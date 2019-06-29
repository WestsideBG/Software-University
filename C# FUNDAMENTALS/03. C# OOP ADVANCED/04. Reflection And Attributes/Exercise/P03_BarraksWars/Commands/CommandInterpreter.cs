using System;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower().Contains(commandName));

            IExecutable command = (IExecutable)Activator.CreateInstance(type, new object[] {data, repository, unitFactory});

            return command;
        }
    }
}