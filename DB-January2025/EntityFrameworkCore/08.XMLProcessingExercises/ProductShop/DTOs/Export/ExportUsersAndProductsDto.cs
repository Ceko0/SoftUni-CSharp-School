namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class ExportUsersAndProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public ExportUserWithProductsDto[] Users { get; set; }
    }
}
