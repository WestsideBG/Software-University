using System.Collections.Generic;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.Dtos.Export
{
    public class UserDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public object SoldProducts { get; set; } 
    }
}