using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.BaggageCompartments = baggageCompartments;
            this.Seats = seats;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
            
        }

        public int Seats { get; }
        public int BaggageCompartments { get; }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger) => this.passengers.Add(passenger);

        public IPassenger RemovePassenger(int seat)
        {
            IPassenger removedPassenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return removedPassenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IEnumerable<IBag> baggage = this.baggageCompartment.Where(p => p.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(p => p.Owner.Username == passenger.Username);

            return baggage;
        }

        public void LoadBag(IBag bag)
        {
            if (this.BaggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}