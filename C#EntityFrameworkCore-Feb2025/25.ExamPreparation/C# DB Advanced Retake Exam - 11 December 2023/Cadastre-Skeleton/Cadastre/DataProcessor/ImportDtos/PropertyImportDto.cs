﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class PropertyImportDto
    {
        [XmlElement("PropertyIdentifier")]
        [Required]
        [MinLength(16)]
        [MaxLength(20)]
        public string PropertyIdentifier { get; set; }

        [XmlElement("Area")]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [XmlElement("Details")]
        [MinLength(5)]
        [MaxLength(500)]
        public string Details { get; set; }

        [XmlElement("Address")]
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Address { get; set; }

        [XmlElement("DateOfAcquisition")]
        [Required]
        public string DateOfAcquisition { get; set; }
    }
}