namespace Travel.Core.Controllers
{
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private IAirport airport;

        private IAirplaneFactory airplaneFactory = null;
        private IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;
            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        public string RegisterPassenger(string username)
        {
            //If the airport already has a passenger with that username, throw an InvalidOperationException with the message "Passenger {username} already registered!".
            // The command adds a new passenger into the airport and returns "Registered {passenger.Username}"


            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            var passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }

        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            //Gets a passenger with the provided username from the airport. Then, creates a bag with all the provided items and adds it to the passenger’s bags.
            // The command returns "Registered bag with item1, item2, itemN for {username}"


            var passenger = this.airport.GetPassenger(username);

            var items = bagItems.Select(i => this.itemFactory.CreateItem(i)).ToArray();
            var bag = new Bag(passenger, items);

            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }

        public string RegisterTrip(string source, string destination, string planeType)
        {
            //Creates a trip with that source and destination and adds it to the airport. The Id is auto-generated from the Trip class itself.
            // The command returns "Registered trip {tripId}".

            var airplane = airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        public string CheckIn(string username, string tripId, IEnumerable<int> bagsToCheckInCount)
        {
            //Gets a passenger with the provided username and a trip with the provided id.
            // If the passenger has already checked in (is already in any trips’ airplanes), throw an InvalidOperationException with the message "{username} is already checked in!". 
            // Then, the command checks in all the passenger bags with that index.
            // Checking in works like this:
            // The bag with that index gets removed from the passenger’s bags. Then, depending on whether the bag should be confiscated, one of the following things happens:
            // If it should be confiscated (if the total value of the bag is over $3000), the bag is added to the airport’s confiscated bags. If not, the bag gets added to the airport’s checked bags. Any other bags, whose indices are not listed in the command input are left with the passenger (and eventually board the plane along with the passenger).
            // After checking in any bags, the passenger is added to the trip.
            // The command returns "Checked in {username} with {bagsToCheckInCount-confiscatedBagsCount}/{bagsToCheckInCount} checked in bags".

            var passenger = this.airport.GetPassenger(username);
            var trip = this.airport.GetTrip(tripId);

            var checkedIn = trip.Airplane.Passengers.Any(p => p.Username == username);

            if (checkedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

            var confiscatedBagsCount = CheckInBags(passenger, bagsToCheckInCount);
            trip.Airplane.AddPassenger(passenger);

            return
                $"Checked in {passenger.Username} with {bagsToCheckInCount.Count() - confiscatedBagsCount}/{bagsToCheckInCount.Count()} checked in bags";
        }

        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
        {
            IList<IBag> bags = passenger.Bags;

            var confiscatedBagCount = 0;
            foreach (var bag in bagsToCheckIn)
            {
                var currentBag = bags[bag];
                bags.RemoveAt(bag);

                if (ShouldConfiscate(currentBag))
                {
                    airport.AddConfiscatedBag(currentBag);
                    confiscatedBagCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            this.airport.AddPassenger(passenger);

            return confiscatedBagCount;
        }

        private static bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = 0;

            for (int i = 0; i < bag.Items.Count; i++)
            {
                luggageValue += bag.Items.ToArray()[i].Value;
            }

            var shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }
    }
}