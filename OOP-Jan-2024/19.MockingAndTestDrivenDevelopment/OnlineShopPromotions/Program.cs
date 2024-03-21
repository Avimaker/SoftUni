using Newtonsoft.Json;

namespace OnlineShopPromotions;
class Program
{
    static void Main(string[] args)
    {

        List<Product> products = new List<Product>()
        {
                new Product()
            {
                Name = "Nike",
                Id = 1,
                Price = 100
            },
                new Product()
            {
                Name = "Adidas",
                Id = 2,
                Price = 115
            },
                new Product()
            {
                Name = "Puma",
                Id = 3,
                Price = 80
            }
        };

        //Store store = new();
        Store store = new Store(new Database<Product>());

        //store.AddProduct(products[0]);
        //store.AddProduct(products[1]);
        //store.AddProduct(products[2]);


        ////Това беше за тест
        //string productsAsText = JsonConvert.SerializeObject(products, Formatting.Indented);

        //Console.WriteLine(productsAsText);
        //List<Product> list2 = JsonConvert.DeserializeObject<List<Product>>(productsAsText);


    }
}

