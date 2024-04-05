using System;
using Moq;
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

			//FakeDatabase fakeDb = new(); //вместо фейк db
			Mock<IDatabase<Product>> mockDb = new();
            //трябва да сетна мока за да не гърми както е във фейк
            mockDb.Setup(db => db.GetAll()).Returns(new List<Product>());

            //Store store = new Store(fakeDb);
            Store store = new Store(mockDb.Object);


            store.AddProduct(new Product() { Id = -1, Name = "Test Product", Price = 100000000 });

            // fake db
            //Assert.AreEqual(1, store.Products.Count);
            //Assert.IsTrue(store.Products.Any(p => p.Id == -1));
            //Assert.AreEqual(1, fakeDb.numberOfSaveCalls);

            Assert.AreEqual(1, store.Products.Count);
            Assert.IsTrue(store.Products.Any(p => p.Id == -1));
            //mockDb.Verify(db => db.Save(It.Is<List<Product>>(p => p.Count == 1 && p.Any(product => product.Id == -1))), Times.AtLeastOnce);
            mockDb.Verify(db => db.Save(It.IsAny<List<Product>>()), Times.Once);

            //Assert.AreEqual(1, fakeDb.numberOfSaveCalls);


        }
    }
}

