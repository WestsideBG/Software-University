using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.Core.Controllers;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void PerformSetsShouldReturnFailMessage()
	    {
            Stage stage = new Stage();
            SetController setController = new SetController(stage);
            Set set = new Short("WestSet");
            stage.AddSet(set);
	        string actual = setController.PerformSets();
	        string expected = "1. WestSet:\r\n-- Did not perform";

            Assert.AreEqual(expected,actual);
	    }

        [Test]
        public void PerformSetsShouldReturnSuccessMessage()
        {
            Stage stage = new Stage();
            SetController setController = new SetController(stage);
            Set set = new Short("WestSet");
            Performer performer = new Performer("Name",18);
            Song song = new Song("SongName",new TimeSpan(0,2,30));
            Instrument instrument = new Microphone();
            performer.AddInstrument(instrument);
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);

            string actual = setController.PerformSets();
            string expected = "1. WestSet:\r\n-- 1. SongName (02:30)\r\n-- Set Successful";

            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void PerformSetsShouldWearDownInstrument()
        {
            Stage stage = new Stage();
            SetController setController = new SetController(stage);
            Set set = new Short("WestSet");
            IPerformer performer = new Performer("Name", 18);
            Song song = new Song("SongName", new TimeSpan(0, 2, 30));
            Instrument instrument = new Microphone();
            performer.AddInstrument(instrument);
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);
            stage.AddPerformer(performer);

            setController.PerformSets();

            var currPerformer = stage.GetPerformer("Name");
            var instruments = currPerformer.Instruments;

            var actual = instruments.First().Wear;
            var expected = 20;
            
            Assert.AreEqual(expected,actual);
        }



    }
}