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
        List<string> quotes = new List<string>();
        //Add member variables for stock qoutes or iterate through uri substring for certain characters.
        string stockQuotes;
        char openPrice = 'o';
        char askPrice = 'a';
        char buyPrice = 'b';

        public void getInfo(string csvData)
        {
            Console.WriteLine("\nHere's the requested information about your stocks:");
            stockList = csvData.Split('\n').ToList();
            foreach (string stock in stockList)
            {
                Console.WriteLine();

                quotes = stock.Split(',').ToList(); //Quote is here. Match with index of character.



                foreach (string namePrice in quotes)
                {//This loop is only printing "name" for the first stock if it has 'inc'
                    string quote = namePrice.Trim('"');
                    if ((quote.Contains("Inc")) && (quotes.IndexOf(quote) == 0))
                    {
                        //quotes.Insert(0, quote);
                        quote.Remove(quote.IndexOf("Inc"));
                        Console.WriteLine("Name: "+quote);
                    }
                    else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(openPrice))
                    {
                        Console.WriteLine("Today's open: $" + quote);
                    }
                    else
                    {
                        Console.WriteLine(checkQuote(quote));
                    }
                }
            }
        }
        public string checkQuote(string quote)
        {
            if (quote.EndsWith("%"))
            {
                return "Real-time percent change: " + quote;
            }
            if (Regex.IsMatch(quote, @"\d+"))
            {
                return "$" + quote;
            }
            else
            {
                return quote;
            }
        }
        public void analyzeQuotes(string addQuotes)
        {
            stockQuotes = addQuotes;
            foreach (char quote in addQuotes)
            {    
            }
        }
        public string showCommonStocks()
        {
            return "\nSome common stocks:\nMSFT(Microsoft)\nFB(Facebook)\nGOOG(Google)\nAAPL(APPLE)\n"
                + "BTCUSD=X(Bitcoin)\nYHOO(Yahoo!)\nTSLA(Tesla)\nTWTR(Twitter)\nADBE(Adobe)\n"
                +"AMZN(Amazon)\nNFLX(Netflix)\nCRM(Salesforce)\n";
        }
        public string showCommonQuotes()
        {
            return "Some common quote symbols:\n\n'x'(Stock Exchange)\n'a'(ask)\n'b'(buy)\n'o'(open)\n"
                + "'p2'(percent change)\n'p'(previous close)\n'j'(52-week Low)\n'k'(52-week High)\n";
        }
        public char OpenPrice
        {
            get { return openPrice; }
            set { openPrice = value; }
        }
        public string StockQuotes
        {
            get { return stockQuotes; }
            set { stockQuotes = value; }
        }




    }
}
