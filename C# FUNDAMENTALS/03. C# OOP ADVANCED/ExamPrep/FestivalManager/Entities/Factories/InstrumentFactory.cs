namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string typeName)
		{
		    var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

		    var instance = (IInstrument) Activator.CreateInstance(type);

		    return instance;
		}
	}
}