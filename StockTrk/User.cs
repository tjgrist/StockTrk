using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace StockTrk
{
    class User
    {
        string email;
        bool validated;
        string stocks;
        string stockQuotes;
        public string baseUrl;
        string fullUrl;
        Articles stockNews = new Articles();

        public bool Validated
        {
            get { return validated; }
            set { validated = value; }
        }
        public User()
        {
            Console.WriteLine("Sign in with your email:\n");
            email = Console.ReadLine();
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                validated = true;
            }
            else
            {
                Console.WriteLine("Invalid entry.\n");
            }
        }
        public string buildURL(Stocks market, YahooFinance api)
        {
            baseUrl = api.YahooUrl;
            Console.Write("\nWhich STOCKS would you like to view?\nSeparate your stock symbols with commas." + market.showCommonStocks());
            stocks = Console.ReadLine().ToUpper().Replace(" ","");
            stockNews.StockWatch = stocks.Split(',').ToList();
            Console.WriteLine("Add the stock info you would like to see.\n" + market.showCommonQuotes());
            stockQuotes = Console.ReadLine().ToUpper().Replace(" ","").Replace(",","");
            market.StockQuotes = "S" + stockQuotes;
            fullUrl = baseUrl + stocks + "&f=S" + stockQuotes;
            return fullUrl;
        }
        
        public void displayOptions(YahooFinance api, Stocks market)
        {
            bool options = true;
            while (options)
            {
                printOptions();
                string response = Console.ReadLine().ToLower().Replace(" ","");
                switch (response)
                {
                    case "1":
                        changeStocks(api);
                        break;
                    case "2":
                        changeQuotes(api, market);
                        break;
                    case "3":
                        viewStocks(api, market);
                        break;
                    case "4":
                        api.downloadCsv();
                        Console.WriteLine("\nA .csv file was DOWNLOADED to your Downloads folder.\n");
                        break;
                    case "5":
                        showRedditOptions();
                        break;
                    case "6":
                        setPriceAlert(market);
                        break;
                    case "q":
                        options = false;
                        break;
                    default:
                        break;                        
                }

            }

        }
        private void changeStocks(YahooFinance api)
        {
            Console.WriteLine("Which stock would you like to REPLACE or REMOVE?");
            string replacableStock = Console.ReadLine().ToUpper();
            Console.WriteLine("Press ENTER to remove this stock: {0}.\nOR, type the stock with which you'd like to replace {0}.", replacableStock);
            string newStock = Console.ReadLine().ToUpper();
            string url = api.YahooUrl;
            api.YahooUrl = url.Replace(replacableStock, newStock);
        }
        private void changeQuotes(YahooFinance api, Stocks market)
        {
            Console.WriteLine("Which QUOTES would you like to add to your stocks?\n" + market.showCommonQuotes());
            string addQuotes = Console.ReadLine().ToUpper();
            api.YahooUrl = api.YahooUrl + addQuotes;
            market.StockQuotes = market.StockQuotes + addQuotes;
        }
        private void viewStocks(YahooFinance api, Stocks market)
        {
            api.showData(api.YahooUrl, market);
        }
        private void setPriceAlert(Stocks market)
        {
            Console.WriteLine("For which stock would you like an alert?");
            string alertStock = Console.ReadLine().ToUpper();
            market.setAlertStock(alertStock);
            Console.WriteLine("At what price (or lower) would you like an alert for {0}?",alertStock);
            string priceDip = Console.ReadLine();
            market.setAskPriceAlert(priceDip);        
        }
        private void showRedditOptions()
        {
            Console.WriteLine("Enter 1 to search tech-related articles.\n"
                + "Enter 2 to search the subreddit for your tracked stocks.");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    stockNews.showTechFinanceArticles();
                    break;
                case "2":
                    stockNews.searchUserStocks();
                    break;
                default:
                    break;
            }
        }
        private void printOptions()
        {
            Console.WriteLine("What would you like to do?\n"
            + "Enter 1 to CHANGE STOCKS.\n"
            + "Enter 2 to CHANGE stock QUOTES.\n"
            + "Enter 3 to VIEW your TRACKED stocks.\n"
            + "Enter 4 to DOWNLOAD a CSV file of your stock portfolio.\n"
            + "Enter 5 to SEARCH for ARTICLES from Reddit's StockMarket subreddit.\n"
            + "Enter 6 to SET a PRICE DIP ALERT for a specific stock.\n"
            + "To QUIT these options, enter 'Q'");
        }
    }
}
