namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        // имаме 2 FK които сочат към Users и затова трябва да сложим инвърс пропърти атрибут/или FAPI, защото EF не знае по кой FK, коя колекция да пълни
        //Продавач имаме FK към Юзъра, който продава този продукт 
        public int SellerId { get; set; }
        //Навигационно прпърти - add virtual
        public virtual User Seller { get; set; } = null!;

        // може да има продукти които още нямат купувач, nullable
        public int? BuyerId { get; set; }
        //Навигационно прпърти - трябва да се добави ?
        public virtual User? Buyer { get; set; } = null!;

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new HashSet<CategoryProduct>();
    }
}