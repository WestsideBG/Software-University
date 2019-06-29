﻿using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class Sold_ProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}