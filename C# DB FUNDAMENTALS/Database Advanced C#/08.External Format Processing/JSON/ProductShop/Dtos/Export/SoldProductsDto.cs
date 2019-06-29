using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class SoldProductsDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public List<Sold_ProductDto> Products { get; set; }
    }
}