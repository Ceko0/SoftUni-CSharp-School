namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlElement("firstName")]
        public string? FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
