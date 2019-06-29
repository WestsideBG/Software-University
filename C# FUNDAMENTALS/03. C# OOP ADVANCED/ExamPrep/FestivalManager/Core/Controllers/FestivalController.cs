using System.Text;

namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;


    public class FestivalController : IFestivalController
	{
		private readonly IStage stage;
	    private IInstrumentFactory instrumentFactory;
	    private IPerformerFactory performerFactory;
	    private ISetFactory setFactory;
	    private ISongFactory songFactory;
        

		public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISetFactory setFactory, ISongFactory songFactory)
		{
		    this.stage = stage;
		    this.instrumentFactory = instrumentFactory;
		    this.performerFactory = performerFactory;
		    this.setFactory = setFactory;
		    this.songFactory = songFactory;
		}

		public string ProduceReport()
		{
		    var result = new StringBuilder();

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			result.AppendLine($"Festival length: {TimeFormat(totalFestivalLength)}");

			foreach (var set in this.stage.Sets)
			{
			    result.AppendLine($"--{set.Name} ({TimeFormat(set.ActualDuration)}):");

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

				    result.AppendLine($"---{performer.Name} ({instruments})");
				}

				if (!set.Songs.Any())
				    result.AppendLine("--No songs played");
				else
				{
				    result.AppendLine("--Songs played:");
					foreach (var song in set.Songs)
					{
					    result.AppendLine($"----{song.Name} ({TimeFormat(song.Duration)})");
					}
				}
			}

			return result.ToString().Trim();
		}

		public string RegisterSet(string[] args)
		{
		    //Creates a set of the specified type with the specified name and adds it to the stage’s sets.
		    //Upon a successful set registration, the command returns "Registered {type} set".

		    string name = args[0];
		    string type = args[1];

		    ISet set = setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return $"Registered {type} set";


        }

        public string SignUpPerformer(string[] args)
		{
           //Creates a performer with the specified name and age, which holds a list of instruments and adds them to the stage.
           //Upon successful creation, the command returns "Registered performer {performerName}".
		   //Note: Performers can have no instruments.This is valid input.


			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumentsNames = args.Skip(2).ToArray();

			var instruments = instrumentsNames
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
		    //Creates a song with the specified name and duration and adds it to the stage’s songs.
		    //Upon successful creation, the command returns "Registered song {songName} ({duration:mm\\:ss})".

		    string name = args[0];
		    int[] durationArgs = args[1].Split(':').Select(int.Parse).ToArray();
		    int minutes = durationArgs[0];
		    int seconds = durationArgs[1];
            TimeSpan duration = new TimeSpan(0,minutes,seconds);

		    ISong song = songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);


		    return $"Registered song {name} ({duration:mm\\:ss})";

		}

	    public string AddSongToSet(string[] args)
	    {
	        //Adds the song with the given name to the set with the given name.
	        // If the set doesn’t exist in the stage, throw an InvalidOperationException with the message "Invalid set provided".
	        // If the song doesn’t exist in the stage, throw an InvalidOperationException with the message "Invalid song provided".
	        // If successful, the command returns "Added {songName} ({duration:mm\\:ss}) to {setName}".

	        var songName = args[0];
	        var setName = args[1];

	        if (!this.stage.HasSet(setName))
	        {
	            throw new InvalidOperationException("Invalid set provided");
	        }

	        if (!this.stage.HasSong(songName))
	        {
	            throw new InvalidOperationException("Invalid song provided");
	        }

	        var set = this.stage.GetSet(setName);
	        var song = this.stage.GetSong(songName);

	        set.AddSong(song);

	        return $"Added {song} to {set.Name}";
        }

	    public string AddPerformerToSet(string[] args)
		{
		    //Adds the specified performer with the specified name to the set.
		    // If the performer doesn’t exist in the stage, throw an InvalidOperationException with the message "Invalid performer provided".
		    // If the set doesn’t exist in the stage, throw an InvalidOperationException with the message "Invalid set provided".
		    // If successful, the command returns "Added {performerName} to {setName}".

		    var performerName = args[0];
		    var setName = args[1];

		    if (!this.stage.HasPerformer(performerName))
		    {
		        throw new InvalidOperationException("Invalid performer provided");
		    }

		    if (!this.stage.HasSet(setName))
		    {
		        throw new InvalidOperationException("Invalid set provided");
		    }

		    var performer = this.stage.GetPerformer(performerName);
		    var set = this.stage.GetSet(setName);

		    set.AddPerformer(performer);

		    return $"Added {performer.Name} to {set.Name}";
        }

	    public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

	    private string TimeFormat(TimeSpan ts)
	    {
	        var minutes = ts.Hours * 60 + ts.Minutes;
	        var seconds = ts.Seconds;

	        return $"{minutes:d2}:{seconds:d2}";
	    }
	}
}