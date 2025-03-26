using System;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductsDto
	{
        [XmlElement("CategoryId")]
        public string? CategoryId { get; set; }

        [XmlElement("ProductId")]
        public string? ProductId { get; set; }

    }
}

/*

<CategoryProducts>
    <CategoryProduct>
        <CategoryId>4</CategoryId>
        <ProductId>1</ProductId>
    </CategoryProduct>
    <CategoryProduct>
        <CategoryId>11</CategoryId>
        <ProductId>2</ProductId>
    </CategoryProduct>
 
 
 */