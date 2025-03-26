namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportSoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ExportProductDto[] Products { get; set; } = null!;
    }
}
