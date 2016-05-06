using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StockTrk
{
    class Stocks
    {
        public Alert alert = new Alert();
        List<string> stockList = new List<string>();
        List<string> quotes = new List<string>();
        string stockQuotes;
        string symbol;
        char openPrice = 'O';
        char previousPrice = 'P';
        char askPrice = 'A';
        char buyPrice = 'B';
        char yearLow = 'J';
        char yearHigh = 'K';
        char daysLow = 'G';
        char daysHigh = 'H';
        char earningsPerShare = 'E';

        public string StockQuotes
        {
            get { return stockQuotes; }
            set { stockQuotes = value; }
        }
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public void displayStockInfo(string csvData)
        {
            Console.WriteLine("\nHere's your portfolio:");
            stockList = csvData.Split('\n').ToList();
            foreach (string stock in stockList)
            {
                Console.WriteLine();
                if (stock.Contains(", Inc.") || stock.Contains(", Inc"))
                {
                    quotes = stock.Replace(" ", "").Split(',').ToList();
                    quotes.RemoveAt(1);
                    loopQuotes(quotes);
                }
                else
                {
                    quotes = stock.Split(',').ToList();
                    loopQuotes(quotes);
                }
            }
            Console.WriteLine("TIME: " + DateTime.Now + "\n");
        }
        private void loopQuotes(List<string> quotes)
        {
            foreach (string item in quotes)
            {
                string quote = item.Trim('"');
                Console.WriteLine(getQuoteType(quote));
            }
        }
        private string getQuoteType(string quote)
        {
            if (Regex.IsMatch(quote, @"[A-Z]"))
            {
                symbol = quote;
                return quote;
            }
            else if (quote.EndsWith("%"))
            {
                return "Change and percent change: " + quote;
            }
            else if (Regex.IsMatch(quote, @"\d+\.\d+\-\d+\.\d+") || Regex.IsMatch(quote, @"\d+\.\d+\s\-\s\d+\.\d+"))
            {
                return "Today's range: $" + quote;
            }
            else if (Regex.IsMatch(quote, @"\d+\:"))
            {
                return "Last trade time and price: " + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(openPrice))
            {
                return "Today's open: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(previousPrice))
            {
                return "Previous close: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(daysLow))
            {
                return "Today's low: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(daysHigh))
            {
                return "Today's high: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(yearLow))
            {
                return "52-week low: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(yearHigh))
            {
                return "52-week high: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(buyPrice))
            {
                return "Buying at: $" + quote;
            }
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(askPrice))
            {
                return alert.checkAlert(quote, symbol);
            }  
            else if (quotes.IndexOf(quote) == stockQuotes.IndexOf(earningsPerShare))
            {
                return "Earnings per share: $" + quote;
            }
            else if (Regex.IsMatch(quote, @"\d+[^.]\d+"))
            {
                return "Volume: " + quote;
            }
            else
            {
                return quote;
            }
        }
        public string showCommonStocks()
        {
            return "\n\nSome common stocks:\n\nMSFT = Microsoft\nFB = Facebook\nGOOG = Google\nAAPL = APPLE\n"
                + "IBM = IBM\nTSLA = Tesla\nTWTR = Twitter\nADBE = Adobe\nATVI = Activision\n"
                + "AMZN = Amazon\nNFLX = Netflix\nCRM = Salesforce\nINTC = Intel\nORCL = Oracle\n"
                + "NVDA = NVIDIA Corp\nLNKD = LinkedIn\nYHOO = Yahoo!\nBTCUSD=X = Bitcoin\n"
                + "SAP = SAP SE\nPYPL = PayPal\nVZ = Verizon\nHPE = Hewlett Packard\n";
        }
        public string showCommonQuotes()
        {
            return "Some common quote symbols:\n\nA = Ask\nB = Buy\nO = Open\nP = Previous Close\n"
                + "M = Day's Range\nG = Day's Low\nH = Day's High\nJ = 52-Week Low\nK = 52-Week High\n"
                + "C = Change & Percent Change\nV = Volume\nE = Earnings/share\nL = Last trade time and price\n";
        }
    }
}
