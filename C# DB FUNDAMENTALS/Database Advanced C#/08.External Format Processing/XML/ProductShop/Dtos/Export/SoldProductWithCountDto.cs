namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class SoldProductWithCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}