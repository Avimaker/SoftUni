using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("Product")]
    public class ImportProductDto
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("price")]
        public string Price { get; set; } = null!;

        [Required]
        [XmlElement("sellerId")]
        public string SellerId { get; set; } = null!;

        [XmlElement("buyerId")]
        public string? BuyerId { get; set; }
    }
}



/*
    <Product>
        <name>Care One Hemorrhoidal</name>
        <price>932.18</price>
        <sellerId>25</sellerId>
        <buyerId>24</buyerId>
    </Product>
*/