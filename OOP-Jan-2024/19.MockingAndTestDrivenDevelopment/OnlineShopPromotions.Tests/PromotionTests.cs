namespace OnlineShopPromotions.Tests;

public class Tests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void FridayPromotion_ShouldBe50Percent()
    {
        Promotion promotion = new Promotion(new DateTime(2024, 3, 22));

        Assert.AreEqual(50, promotion.GetDiscountPrice(100));
    }

    [Test]
    public void FirstAprilPromotion_ShouldBePlus50Percent()
    {
        Promotion promotion = new Promotion(new DateTime(2024, 4, 1));

        Assert.AreEqual(150, promotion.GetDiscountPrice(100));
    }

    [Test]
    public void FirstApril2030Promotion_ShouldBePlus150Percent()
    {
        Promotion promotion = new Promotion(new DateTime(2030, 4, 1));

        Assert.AreEqual(250, promotion.GetDiscountPrice(100));
    }

}
