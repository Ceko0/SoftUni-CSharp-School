
namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string? FirstName { get; set; } 
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlArray("soldProducts")]
        public ExportProductDto[] SoldProducts { get; set; } = null!;
    }
}
