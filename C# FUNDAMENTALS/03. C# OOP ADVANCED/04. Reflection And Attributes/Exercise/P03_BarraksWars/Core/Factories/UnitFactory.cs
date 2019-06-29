namespace _03BarracksFactory.Core.Factories
{
    using System.Linq;
    using System.Reflection;
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().First(a => a.Name == unitType);

            IUnit instance = (IUnit)Activator.CreateInstance(type);

            return instance;
        }
    }
}
