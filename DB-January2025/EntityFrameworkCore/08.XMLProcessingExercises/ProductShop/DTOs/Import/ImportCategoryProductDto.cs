namespace ProductShop.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement("CategoryId")]
        public string CategoryId { get; set; } = null!;

        [XmlElement("ProductId")]
        public string ProductId { get; set; } = null!;
    }
}
