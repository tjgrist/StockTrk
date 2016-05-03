using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StockTrk
{
    class Stock : YahooFinance
    {
        List<string> stockList = new List<string>();
        List<string> info = new List<string>();

        public void getInfo(string csvData)
        {
            Console.WriteLine("\nHere's the requested information about your stocks:\n");
            stockList = csvData.Split('\n').ToList();
            foreach (string stock in stockList)
            {
                Console.WriteLine();
                info = stock.Split(',').ToList();
                foreach (string item in info)
                {
                    Console.WriteLine(checkQuote(item)); 
                }
            }
        }
        public string checkQuote(string item)
        {
            item = item.Trim('"');
            if (item.EndsWith("%"))
            {
                return "Real-time percent change: " + item;
            }
            if (Regex.IsMatch(item, @"\d+"))
            {
                return "$" + item;
            }
            else
            {
                return item;
            }
        }
        public string showCommonStocks()
        {
            return "\nSome common stocks:\nMSFT(Microsoft),FB(Facebook),GOOG(Google),AAPL(APPLE)\n"
                +"S&P500,NYSE(New York Stock Exchange),BTCUSD=X(Bitcoin),YHOO(Yahoo!),'TSLA'(Tesla)\n";
            //Print some common stocks.
        }
        public string showCommonQuotes()
        {
            //print some common quotes.
            return "Some common quote symbols:\n\n'x'(Stock Exchange),'a'(ask),'b'(buy),'o',(open)\n"
                +"'p2'(percent change),'p'(previous close)'j'(52-week Low)'k'(52-week High)\n";
        }
        public void changeStocks(YahooFinance api)
        {
            //Change the stocks viewed by the user.
            Console.WriteLine("Which stock would you like to replace?");
            string replacableStock = Console.ReadLine();
            Console.WriteLine("Which stock would you like to replace it with?");
            string newStock = Console.ReadLine();
            string url = api.YahooUrl;
            api.YahooUrl = url.Replace(replacableStock, newStock);
            showData(api.YahooUrl);
        }
        public void changeQuotes()
        {
            //Change the quotes viewed by the user.
        }
    }
}
