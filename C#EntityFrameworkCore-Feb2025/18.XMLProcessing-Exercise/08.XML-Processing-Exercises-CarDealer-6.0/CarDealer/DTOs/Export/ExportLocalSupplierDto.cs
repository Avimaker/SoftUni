﻿namespace CarDealer.DTOs.Export
{

    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class ExportLocalSupplierDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}