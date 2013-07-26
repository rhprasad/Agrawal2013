using System;

public class Stock : Security
{
    public int morningStarRating { get; set; }

    public Stock(string symbol, string blame, double price, DateTime date, int action, int qty, int rating)
        : base(symbol, blame, price, date, action, qty)
    {
        morningStarRating = rating;
    }

    public override string toString()
    {
        return
            "Symbol: " + ticker + "\r\n" +
            "Name: " + name + "\r\n" +
            "Price: " + activityPrice.ToString() + "\r\n" +
            "Date: " + activityDate.ToString() + "\r\n" +
            "Action: " + buySellAction.ToString() + "\r\n" +
            "Quantity: " + quantity.ToString() + "\r\n" +
            "Rating: " + morningStarRating.ToString() + "\r\n";
    }
}