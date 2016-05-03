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
        //Stock market = new Stock();
        Articles stockNews = new Articles();

        public User()
        {
            //Regex email authentification. Could use System.Net.Mail.MailAddress instead.
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
        public bool Validated
        {
            get { return validated; }
            set { validated = value; }
        }
         
        public string buildURL(Stock market)
        {
            baseUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=";
            Console.Write("\nWhich STOCKS would you like to view?\nSeparate your stock symbols with commas." + market.showCommonStocks());
            stocks = Console.ReadLine().Replace(" ","");
            Console.WriteLine("Add the stock info you would like to see.\n" + market.showCommonQuotes());
            stockQuotes = Console.ReadLine().Replace(" ","").Replace(",","");
            market.StockQuotes = stockQuotes;
            fullUrl = baseUrl + stocks + "&f=" + stockQuotes;
            return fullUrl;
        }
        
        public void promptOptions(YahooFinance api, Stock market)
        {
            bool option = true;
            while (option)
            {
                Console.WriteLine("What would you like to do?\n" 
                    +"To change STOCKS, enter '1'.\nTo change stock QUOTES, enter '2'.\n"
                    +"To view your tracked stocks, enter '3'.\n"
                    +"To download a CSV file of your stock potfolio, enter '4'.\n"
                    +"To grab tech-related articles from Reddit's StockMarket subreddit, enter '5'\n"
                    +"To quit these options, enter 'Q'");
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
                        stockNews.showTechFinanceArticles();
                        break;
                    case "q":
                        option = false;
                        break;
                }

            }

        }
        public void changeStocks(YahooFinance api)
        {
            string replacableStock;
            string newStock;
            string url;
            Console.WriteLine("Which stock would you like to replace?");
            replacableStock = Console.ReadLine();
            Console.WriteLine("Which stock would you like to replace it with?");
            newStock = Console.ReadLine();
            url = api.YahooUrl;
            api.YahooUrl = url.Replace(replacableStock, newStock);
        }
        public void changeQuotes(YahooFinance api, Stock market)
        {
            string addQuotes;
            Console.WriteLine("Which quotes would you like to add to your stocks?\n"
                + "Don't use commas to seperate." + market.showCommonQuotes());
            addQuotes = Console.ReadLine();
            market.analyzeQuotes(addQuotes);
            api.YahooUrl = api.YahooUrl + addQuotes;
        }
        public void viewStocks(YahooFinance api, Stock market)
        {
            api.showData(api.YahooUrl, market);
        }
    }
}
