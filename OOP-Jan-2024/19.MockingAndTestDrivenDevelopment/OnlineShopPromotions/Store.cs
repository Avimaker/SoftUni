using System;
namespace OnlineShopPromotions
{
    public class Store
    {
        //private List<Product> products;
        //private ProductsDatabase database = new ProductsDatabase();
        private IDatabase<Product> database;

        //public Store(Product database)
        public Store(IDatabase<Product> database)
        {
            this.database = database;
            Products = database.GetAll();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            database.Save(Products);
        }

        public List<Product> Products { get; set; }

    }
}

