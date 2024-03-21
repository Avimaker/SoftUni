using System;
using OnlineShopPromotions.Tests.Fakes;

namespace OnlineShopPromotions.Tests
{
	public class StoreTest
	{
		[Test]
		public void AddProducts_ShouldWorkAndSaveToDb()
		{
			//Store store = new();//тук мажа направо по базата данни
			//Store store = new Store(new Database<Product>());
			//Store store = new Store(new FakeDatabase());

			FakeDatabase fakeDb = new();
			Store store = new Store(fakeDb);

            store.AddProduct(new Product() { Id = -1, Name = "Test Product", Price = 100000000 });

			Assert.AreEqual(1, store.Products.Count);
			Assert.IsTrue(store.Products.Any(p => p.Id == -1));
			Assert.AreEqual(1, fakeDb.numberOfSaveCalls);
		}
	}
}

