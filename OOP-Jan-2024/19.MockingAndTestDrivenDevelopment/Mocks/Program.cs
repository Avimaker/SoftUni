using System.Reflection.Metadata;
using Moq;
namespace Mocks;
class Program
{
    public static void Main(string[] args)
    {
        //Mock<IPromotionStrategy> - конфигурационният обект - репера върху реалната промоционална стратегия
        //mockPromotion - мок от даден тип е обекта който конфигурура класа фейка
        //mockPromotion.Object - връща точния обект - създаден мок/фейк

        Mock<IPromotionStrategy> mockPromotion = new();

        // връщаното инфо от мока с дефолтни стпйности, ако ние не сетнем наши
        IPromotionStrategy promotion = mockPromotion.Object;
        UsePromotion(promotion); //виж най-долу в кода на метода


        //**тук може да сетнеме мока**
        //тук сетвам актуланата дата и час
        mockPromotion.Setup(p => p.GetDate()).Returns(DateTime.Now);
        Console.WriteLine(mockPromotion.Object.GetDate());


        //тук сетвам, че каквато и стойност да се подаде да връща 20
        mockPromotion.Setup(p => p.GetPromotion(It.IsAny<decimal>())).Returns(20);
        Console.WriteLine(mockPromotion.Object.GetPromotion(500));//20


        //сетвам рейндж от 0 до 1000 - връща 53 например
        mockPromotion.Setup(p => p.GetPromotion(It.IsInRange<decimal>(0, 1000, Moq.Range.Inclusive))).Returns(53);
        Console.WriteLine(mockPromotion.Object.GetPromotion(500));//53


        //сетвам за определено число 44343 да върне -100
        mockPromotion.Setup(p => p.GetPromotion(44343)).Returns(-100);
        Console.WriteLine(mockPromotion.Object.GetPromotion(44343));


        //Callback - сетвам за всички позитивни числа месидж който да ми върне, ако отговаря на условията 
        mockPromotion.Setup(p => p.GetPromotion(It.Is<decimal>(p => p > 0)))
         .Returns(20)
         .Callback<decimal>(p =>
         {
             global::System.Console.WriteLine($"GetPromotion with a positive {p} number called");
         });
        Console.WriteLine(mockPromotion.Object.GetPromotion(44343));

        //Verifiable - проверка дали се е изпълнил ?!?!?!!?
        mockPromotion.Setup(p => p.GetPromotion(150)).Returns(100).Verifiable();
        Console.WriteLine(mockPromotion.Object.GetPromotion(150));
        mockPromotion.Verify(p => p.GetPromotion(150), Times.AtLeastOnce());


        //Throw exception - 
        mockPromotion.Setup(p => p.GetPromotion(It.Is<decimal>(p => p < 0)))
            .Throws<ArgumentException>(() =>
            {
                throw new ArgumentException("Custum msg");
            });
        Console.WriteLine(mockPromotion.Object.GetPromotion(-5));




        //искаме да върне 100 а връща 0 в този метод, ако не сме сетнали нищо
        void UsePromotion(IPromotionStrategy promotionStrategy)
        {
            Console.WriteLine(promotion.GetPromotion(100)); //връща 0 което е дефолтна стойност
        }
    }

}
public interface IPromotionStrategy
{
    public decimal GetPromotion(decimal price);

    public DateTime GetDate();
}

//class FakePromotion : IPromotionStrategy
//{
//    public decimal GetPromotion(decimal price)
//    {
//        return 20;
//    }
//}

