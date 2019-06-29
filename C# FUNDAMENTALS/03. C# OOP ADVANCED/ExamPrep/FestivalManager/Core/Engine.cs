
namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;


	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

	    private IFestivalController festivalCоntroller;
	    private ISetController setCоntroller;

	    public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
	    {
	        this.reader = reader;
	        this.writer = writer;
	        this.festivalCоntroller = festivalCоntroller;
	        this.setCоntroller = setCоntroller;
	    }

		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

			    try
			    {
			        string.Intern(input);

			        var result = this.ProcessCommand(input);
			        this.writer.WriteLine(result);
			    }
			    catch (TargetInvocationException ex)
			    {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
			    }
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var inputArgs = input.Split();

			var command = inputArgs.First();
			var args = inputArgs.Skip(1).ToArray();

		    string result;

            if (command == "LetsRock")
			{
				 result = this.setCоntroller.PerformSets();
			}
			else
			{
			    var festivalcontrolfunction = this.festivalCоntroller.GetType()
			        .GetMethods()
			        .FirstOrDefault(x => x.Name == command);

			    result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { args });

            }

			return result;
		}
	}
}