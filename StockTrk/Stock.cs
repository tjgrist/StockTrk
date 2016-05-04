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
        string stockQuotes;
        string askPriceAlert;
        string alertStock;
        char openPrice = 'O';
        char previousPrice = 'P';
        char askPrice = 'A';
        char buyPrice = 'B';
        char yearLow = 'J';
        char yearHigh = 'K';


        public void getInfo(string csvData)
        {
            Console.WriteLine("\nHere's the requested information about your stocks:");
            stockList = csvData.Split('\n').ToList();
            foreach (string stock in stockList)
            {
                Console.WriteLine();

                quotes = stock.Split(',').ToList(); //Splits stock name if contains 'Inc'.

                foreach (string namePrice in quotes)
                {
                    string quote = namePrice.Trim('"');
                    if (quote.Contains(" Inc."))
                    {
                        quotes.Remove(quote);
                    }
                    else
                    {
                        Console.WriteLine(checkQuote(quote)); //Match with index of char.
                    }
                }
            }
        }
        public string checkQuote(string quote)
        {
            if (Regex.IsMatch(quote, @"[A-Z]"))
            {
                return quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(openPrice))
            {
                return "Today's open: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(previousPrice))
            {
                return "Previous day's open: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(askPrice))
            {
                if (Convert.ToSingle(quote) <= Convert.ToSingle(askPriceAlert))
                {                  
                    return "ALERT! Your stock dipped below your set level!" + " It's at: $" + quote
                        + " Your price alert was set to: $" + askPriceAlert;
                }
                else
                {
                    return "Asking: $" + quote;
                }
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(buyPrice))
            {
                return "Buying at: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(yearLow))
            {
                return "52-week low: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(yearHigh))
            {
                return "52-week high: $" + quote;
            }
            else if (quote.EndsWith("%"))
            {
                return "Real-time percent change: " + quote;
            }
            else if (Regex.IsMatch(quote, @"\d+"))
            {
                return "$" + quote;
            }
            else
            {
                return quote;
            }
        }
        public string showCommonStocks()
        {
            return "\nSome common stocks:\nMSFT (Microsoft)\nFB (Facebook)\nGOOG (Google)\nAAPL (APPLE)\n"
                + "BTCUSD=X (Bitcoin)\nYHOO (Yahoo!)\nTSLA (Tesla)\nTWTR (Twitter)\nADBE (Adobe)\n"
                +"AMZN (Amazon)\nNFLX (Netflix)\nCRM (Salesforce)\n";
        }
        public string showCommonQuotes()
        {
            return "Some common quote symbols:\n\nS = Ticker\nA = Ask\nB = Buy\n"
                + "O = Open\nP = Previous close\nJ = 52-week Low\nK = 52-week High\nP2 = Percent change\n";
        }
        public string StockQuotes
        {
            get { return stockQuotes; }
            set { stockQuotes = value; }
        }
        public string AskPriceAlert
        {
            get { return askPriceAlert; }
            set { askPriceAlert = value; }
        }
    }
}
