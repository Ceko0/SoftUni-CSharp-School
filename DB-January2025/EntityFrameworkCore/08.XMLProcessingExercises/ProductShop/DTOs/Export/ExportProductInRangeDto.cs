namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductInRangeDto
    {
        [XmlElement("name")] 
        public string Name { get; set; } = null!;

        [XmlElement("price")] 
        public string Price { get; set; } = null!;

        [XmlElement("buyer")] 
        public string Buyer { get; set; } = null!;
    }
}
