using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                Console.WriteLine("Invalid");
            }
        }
        public string buildURL(Stocks market, YahooFinance api)
        {
            baseUrl = api.YahooUrl;
            Console.Write("\nWhich STOCKS would you like to view?\nSeparate your stock symbols with commas." + market.showCommonStocks());
            stocks = Console.ReadLine().ToUpper().Replace(" ","");
            Console.WriteLine("Add the stock info you would like to see.\n" + market.showCommonQuotes());
            stockQuotes = Console.ReadLine().ToUpper().Replace(" ","").Replace(",","");
            market.StockQuotes = stockQuotes;
            fullUrl = baseUrl + stocks + "&f=" + stockQuotes;
            return fullUrl;
        }
        
        public void promptOptions(YahooFinance api, Stocks market)
        {
            bool option = true;
            while (option)
            {
                showOptions();
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
                        Console.WriteLine("\nA .csv file has been downloaded to your Downloads folder.\n");
                        break;
                    case "5":
                        stockNews.showTechFinanceArticles(api);
                        break;
                    case "6":
                        setPriceAlert(market);
                        break;
                    case "q":
                        option = false;
                        break;
                }

            }

        }
        public void changeStocks(YahooFinance api)
        {
            Console.WriteLine("Which stock would you like to REPLACE or REMOVE?");
            string replacableStock = Console.ReadLine().ToUpper();
            Console.WriteLine("Press ENTER to remove this stock: {0}.\nOR, type the stock with which you'd like to replace {0}.", replacableStock);
            string newStock = Console.ReadLine().ToUpper();
            string url = api.YahooUrl;
            api.YahooUrl = url.Replace(replacableStock, newStock);
        }
        public void changeQuotes(YahooFinance api, Stocks market)
        {
            Console.WriteLine("Which QUOTES would you like to add to your stocks?\n" + market.showCommonQuotes());
            string addQuotes = Console.ReadLine().ToUpper();
            api.YahooUrl = api.YahooUrl + addQuotes;
            market.StockQuotes = market.StockQuotes + addQuotes;
        }
        public void viewStocks(YahooFinance api, Stocks market)
        {
            api.showData(api.YahooUrl, market);
        }
        public void setPriceAlert(Stocks market)
        {
            Console.WriteLine("For which stock would you like an alert?");
            string alertStock = Console.ReadLine().ToUpper();
            market.setAlertStock(alertStock);
            Console.WriteLine("At what price (or lower) would you like an alert for {0}?",alertStock);
            string priceDip = Console.ReadLine();
            market.setAskPriceAlert(priceDip);           
        }
        public void showOptions()
        {
            Console.WriteLine("What would you like to do?\n"
            + "To CHANGE STOCKS, enter '1'.\nTo CHANGE stock QUOTES, enter '2'.\n"
            + "To VIEW your TRACKED stocks, enter '3'.\n"
            + "To DOWNLOAD a CSV file of your stock portfolio, enter '4'.\n"
            + "To GRAB tech-related ARTICLES from Reddit's StockMarket subreddit, enter '5'\n"
            + "SET a PRICE DIP ALERT with '6'\n"
            + "To QUIT these options, enter 'Q'");
        }
        public bool Validated
        {
            get { return validated; }
            set { validated = value; }
        }
    }
}
