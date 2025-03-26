using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("Category")]
    public class ImportCategoriesDto
	{
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;
    }
}


/*
<Categories>
    <Category>
        <name>Drugs</name>
    </Category>
    <Category>
        <name>Adult</name>
    </Category>
 
 
 
 */
