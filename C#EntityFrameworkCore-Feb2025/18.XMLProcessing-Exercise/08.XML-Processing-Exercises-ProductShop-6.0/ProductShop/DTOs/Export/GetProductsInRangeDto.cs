using System;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class GetProductsInRangeDto
	{

        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string? Buyer { get; set; }

    }
}



/*

<?xml version="1.0" encoding="utf-16"?>
<Products>
  <Product>
    <name>TRAMADOL HYDROCHLORIDE</name>
    <price>516.48</price>
    <buyer> </buyer>
  </Product>

 
 
 */