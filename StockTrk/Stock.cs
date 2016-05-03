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
        //Add member variables for stock qoutes.
        //char stockExchange = 'x';
        //char askPrice = 'a';
        //char buyPrice = 'b';

        public void getInfo(string csvData)
        {
            Console.WriteLine("\nHere's the requested information about your stocks:");
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
            return "\nSome common stocks:\nMSFT(Microsoft)\nFB(Facebook)\nGOOG(Google)\nAAPL(APPLE)\n"
                + "BTCUSD=X(Bitcoin)\nYHOO(Yahoo!)\nTSLA(Tesla)\nTWTR(Twitter)\nADBE(Adobe)\n"
                +"AMZN(Amazon)\nNFLX(Netflix)\nCRM(Salesforce)\nNYSE(New York Stock Exchange)\n";
        }
        public string showCommonQuotes()
        {
            return "Some common quote symbols:\n\n'x'(Stock Exchange)\n'a'(ask)\n'b'(buy)\n'o'(open)\n"
                + "'p2'(percent change)\n'p'(previous close)\n'j'(52-week Low)\n'k'(52-week High)\n";
        }
    }
}
