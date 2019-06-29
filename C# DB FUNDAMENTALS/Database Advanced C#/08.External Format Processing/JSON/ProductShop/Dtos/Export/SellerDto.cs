using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class SellerDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public List<SoldProductDto> Products { get; set; } = new List<SoldProductDto>();
    }
}