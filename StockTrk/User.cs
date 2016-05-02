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
        string baseUrl;
        string fullUrl;
        string answer;
        Stock market = new Stock();

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
         
        public string buildURL()
        {
            //Build the Yahoo! URL string from basic.
            baseUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=";
            Console.Write("Which stocks would you like to add?\nSeparate your stock symbols with commas." + market.showCommonStocks());
            stocks = Console.ReadLine().Replace(" ","");
            Console.WriteLine("Add the stock info you would like to see.\n" + market.showCommonQuotes());
            stockQuotes = Console.ReadLine().Replace(" ","").Replace(",","");
            fullUrl = baseUrl + stocks + "&f=ns" + stockQuotes;
            return fullUrl;
        }
        
        public void promptOptions()
        {
            bool option = true;
            while (option)
            {

                Console.WriteLine("What would you like to do?\n" 
                    +"To change stocks, type '1'.\nTo change Stock quotes, type '2'.\n"
                    +"To view your tracked stocks, type '3'.\nTo quit these options, type 'q'");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        market.changeStocks();
                        break;
                    case "2":
                        market.changeQuotes();
                        break;
                    case "3":
                        viewStocks();
                        break;
                    case "q":
                        option = false;
                        break;
                }

            }

        }
        public void promptChangeStocks()
        {
            Console.WriteLine("Would you like to change any stocks in your portfolio?");
            answer = Console.ReadLine().Replace(" ","").ToLower();
            if (answer == "yes")
            {
                market.changeStocks();
            }
            addStockInfo();
            //Change the stocks that the user wants to see
        }
        public void viewStocks()
        {
            //View stocks & info
            YahooFinance account = new YahooFinance();
            account.showData(account.Csv);
        }
        public void addStockInfo()
        {
            Console.WriteLine("Would you like to add stock quotes?");
            answer = Console.ReadLine();
            //Change grabbed stock info
        }

    }
}
