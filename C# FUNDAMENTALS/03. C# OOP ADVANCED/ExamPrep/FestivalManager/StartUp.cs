namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
			Stage stage = new Stage();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            ISetFactory setFactory = new SetFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();
			IFestivalController festivalController = new FestivalController(stage,instrumentFactory,performerFactory,setFactory,songFactory);
			ISetController setController = new SetController(stage);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			var engine = new Engine(reader,writer,festivalController,setController);

			engine.Run();
		}
	}
}