using System;

namespace OnlineShopPromotions.Tests.Fakes
{
    public class FakeDatabase : IDatabase<Product>
    {

        public int numberOfSaveCalls = 0;

        public List<Product> GetAll()
        {
            return new List<Product>();
        }

        public void Save(List<Product> values)
        {
            numberOfSaveCalls++;
        }
    }
}

