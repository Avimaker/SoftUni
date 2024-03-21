using System;
using Newtonsoft.Json;

namespace OnlineShopPromotions
{
	//public class ProductsDatabase
	public class Database<T> : IDatabase<T>
    {

		private string path = "../../../db.txt";

		//public List<Product> GetAll()
		public List<T> GetAll()
        {
			if (!File.Exists(path))
			{
				//return new List<Product>();
				return new List<T>();
                //return null;
            }

			using (StreamReader reader = new StreamReader(path))
			{
				//return JsonConvert.DeserializeObject<List<Product>>(reader.ReadToEnd());
				return JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
            }
		}

		//public void Save(List<Product> products)
		public void Save(List<T> products)
        {
			using (StreamWriter writer = new StreamWriter(path, false))
			{
				writer.WriteLine(JsonConvert.SerializeObject(products, Formatting.Indented));
			}
		}

	}
}

