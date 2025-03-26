﻿namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")] 
        public string Price { get; set; } = null!;

    }
}
