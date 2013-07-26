using System;

public class Security
{
    public string ticker { get; set; }
    public string name { get; set; }
    public double activityPrice { get; set; }
    public DateTime activityDate { get; set; }
    public int buySellAction { get; set; }
    public int quantity { get; set; }

    public Security(string symbol, string blame, double price, DateTime date, int action, int qty) 
    {
        ticker = symbol;
        name = blame;
        activityPrice = price;
        activityDate = date;
        buySellAction = action;
        quantity = qty;
    }

    public virtual string toString()
    {
        return ticker + " " + name + " " + activityPrice.ToString() + " " + activityDate.ToString() + " " + buySellAction.ToString() + " " + quantity.ToString();
    }
}
