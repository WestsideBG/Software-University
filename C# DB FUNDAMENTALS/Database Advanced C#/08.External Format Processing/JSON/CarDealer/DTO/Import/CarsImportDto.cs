using System.Collections.Generic;
using CarDealer.Models;

namespace CarDealer.DTO.Import
{
    public class CarsImportDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<PartCar> PartCars { get; set; } = new List<PartCar>();

        public ICollection<int> PartsId { get; set; } = new List<int>();
    }
}