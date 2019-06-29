using System;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    public class CustomersDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}