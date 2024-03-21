using System;
namespace OnlineShopPromotions;

public class Promotion
{
    private DateTime dateToday;

    public Promotion(DateTime dateToday)
    {
        this.dateToday = dateToday;
    }

    public Promotion() : this(DateTime.Now)
    {
        // poor man's DI
    }


    public decimal GetDiscountPrice(decimal price)
    {
        //пак е петък и затова го слагаме на първо място за да не е 50% намалението
        if (dateToday.Day == 1 && dateToday.Month == 4 && dateToday.Year == 2030)
        {
            return price + price * 1.5m;
        }

        if (dateToday.DayOfWeek == DayOfWeek.Tuesday)
        {
            return price - price * 0.3m;
        }

        if (dateToday.DayOfWeek == DayOfWeek.Friday)
        {
            return price - price * 0.5m;
        }

        if (dateToday.Day == 1 && dateToday.Month == 4)
        {
            return price + price * 0.5m;
        }

        return price;
    }
}

