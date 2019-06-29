namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string typeName)
		{
		    var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

		    var instance = (ISet)Activator.CreateInstance(type, name);
		    return instance;
		}
	}
}
