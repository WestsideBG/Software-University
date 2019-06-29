using System.Collections.Generic;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    public class CarPartsDto
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<PartDto> Parts { get; set; } = new List<PartDto>();
    }
}