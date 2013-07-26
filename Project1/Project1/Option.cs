using System;

public class Option : Security
{
    public DateTime expirationDate { get; set; }

    public Option(string symbol, string blame, double price, DateTime date, int action, int qty, DateTime expiration)
        : base(symbol, blame, price, date, action, qty)
    {
        expirationDate = expiration;
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
            "Expiration Date: " + expirationDate + "\r\n";
    }
}