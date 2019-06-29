// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

//using Travel.Core.Controllers;
//using Travel.Entities;
//using Travel.Entities.Airplanes;
//using Travel.Entities.Items;

using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Items;

namespace Travel.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void SuccessfulTrip()
        {
            var passengers = new[]
            {
                new Passenger("Westside1"),
                new Passenger("Westside2"),
                new Passenger("Westside3"),
                new Passenger("Westside4"),
                new Passenger("Westside5"),
                new Passenger("Westside6")
            };

            Airplane airplane = new LightAirplane();

            foreach (var passenger in passengers)
            {
                airplane.AddPassenger(passenger);
            }

            Trip trip = new Trip("Sofia", "London", airplane);

            Airport airport = new Airport();

            airport.AddTrip(trip);

            var bag = new Bag(passengers[1], new[] { new Colombian() });
            passengers[1].Bags.Add(bag);

            var completedTrip = new Trip("Sofia", "Manchester", airplane);
            completedTrip.Complete();

            airport.AddTrip(completedTrip);

            var flightController = new FlightController(airport);

            var actualResult = flightController.TakeOff();
            var expectedResult = @"SofiaLondon1:
Overbooked! Ejected Westside2
Confiscated 1 bags ($50000)
Successfully transported 5 passengers from Sofia to London.
Confiscated bags: 1 (1 items) => $50000";
            Assert.AreEqual(expectedResult,actualResult);
            Assert.That(trip.IsCompleted, Is.True);

        }
    }
}
