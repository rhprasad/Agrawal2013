// Ryan Prasad
// rhprasad@mail.usf.edu
// ISM 6930 Agrawal

using System;
using System.Collections;

namespace Project1
{
    class Program
    {


        static DateTime GetDate()
        {
            Console.WriteLine();
            Console.Write("     Year: ");
            string s = Console.ReadLine();
            int year = int.Parse(s);
            Console.Write("     Month: ");
            s = Console.ReadLine();
            int month = int.Parse(s);
            Console.Write("     Day: ");
            s = Console.ReadLine();
            int day = int.Parse(s);

            return new DateTime(year, month, day);
        }


        static void Main(string[] args)
        {
            Boolean done = false;
            ArrayList portfolio = new ArrayList();

            Console.WriteLine("WELCOME TO THE PORTFOLIO TRACKER");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Your current holdings are as follows: You have no holdings.");
            Console.WriteLine();

            do
            {

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Enter 1 to buy stock.");
                Console.WriteLine("Enter 2 to buy options.");
                Console.WriteLine("Enter 3 to sell stock.");
                Console.WriteLine("Enter 4 to sell options.");
                Console.WriteLine("Enter 0 to end the session.");

                string s = Console.ReadLine();
                int action = int.Parse(s);

                switch (action)
                {

                    case 0: // EXIT
                        done = true;
                        Console.WriteLine();
                        break;

                    case 1: // BUY STOCK

                        Console.WriteLine();
                        Console.Write("Stock ticker to buy: ");
                        string buyStockTicker = Console.ReadLine();
                        Console.Write("Name: ");
                        string buyStockName = Console.ReadLine();
                        Console.Write("Price: ");
                        s = Console.ReadLine();
                        double buyStockPrice = double.Parse(s);
                        Console.Write("Date: ");
                        DateTime buyStockDate = GetDate();
                        Console.Write("Quantity: ");
                        s = Console.ReadLine();
                        int buyStockQuantity = int.Parse(s);
                        Console.Write("Morning Star Rating: ");
                        s = Console.ReadLine();
                        int buyStockRating = int.Parse(s);

                        Stock newStock = new Stock(buyStockTicker, buyStockName, buyStockPrice, buyStockDate, action, buyStockQuantity, buyStockRating);
                        portfolio.Add(newStock);

                        Console.WriteLine("Stock added to portfolio.");
                        Console.WriteLine();
                        break;

                    case 2: // BUY OPTION

                        Console.WriteLine();
                        Console.Write("Option ticker to buy: ");
                        string buyOptionTicker = Console.ReadLine();
                        Console.Write("Name: ");
                        string buyOptionName = Console.ReadLine();
                        Console.Write("Price: ");
                        s = Console.ReadLine();
                        double buyOptionPrice = double.Parse(s);
                        Console.Write("Date: ");
                        DateTime buyOptionDate = GetDate();
                        Console.Write("Quantity: ");
                        s = Console.ReadLine();
                        int buyOptionQuantity = int.Parse(s);
                        Console.Write("Expiration date: ");
                        DateTime buyOptionExpiration = GetDate();

                        Option newOption = new Option(buyOptionTicker, buyOptionName, buyOptionPrice, buyOptionDate, action, buyOptionQuantity, buyOptionExpiration);
                        portfolio.Add(newOption);

                        Console.WriteLine("Option added to portfolio.");
                        Console.WriteLine();
                        break;

                    case 3: // SELL STOCK

                        Console.WriteLine();
                        Console.Write("Stock ticker to sell: ");
                        string sellStockTicker = Console.ReadLine();
                        Console.Write("Quantity: ");
                        s = Console.ReadLine();
                        int sellStockQuantity = int.Parse(s);

                        foreach (Security i in portfolio)
                        {
                            if (sellStockTicker == i.ticker && (i.buySellAction == 1 || i.buySellAction == 3))
                            {
                                i.quantity -= sellStockQuantity;
                                i.buySellAction = action;
                                break;
                            }
                        }

                        Console.WriteLine("Stock sold.");
                        Console.WriteLine();
                        break;

                    case 4: // SELL OPTION

                        Console.WriteLine();
                        Console.Write("Option ticker to sell: ");
                        string sellOptionTicker = Console.ReadLine();
                        Console.Write("Quantity: ");
                        s = Console.ReadLine();
                        int sellOptionQuantity = int.Parse(s);

                        foreach (Security i in portfolio)
                        {
                            if (sellOptionTicker == i.ticker && (i.buySellAction == 2 || i.buySellAction == 4))
                            {
                                i.quantity -= sellOptionQuantity;
                                i.buySellAction = action;
                                break;
                            }
                        }

                        Console.WriteLine("Option sold.");
                        Console.WriteLine();
                        break;
                }


            }
            while (done == false);

            Console.WriteLine("Thanks for using the Portfolio Tracker");
            Console.WriteLine("Your current holdings are as follows:");
            Console.WriteLine();
            if (portfolio.Count < 1)
                Console.WriteLine("No securities in portfolio.");
            else
            {
                foreach (Security i in portfolio)
                {
                    Console.WriteLine(i.toString());
                }
            }
            Console.ReadLine();

        }
    }
}
